using PluginInterface;
using System;
using System.Drawing;

namespace PrewittPlugin
{
    [Version(1, 0)]
    public class PrewittPlugin : IPlugin
    {
        public string Name
        {
            get
            {
                return "Повышение контрастности изображения (фильтр Прюитта)";
            }
        }

        public string Author
        {
            get
            {
                return "Прюитт (Prewitt)";
            }
        }

        int[,] kernelX = new int[,]
            {
                { -1, 0, 1 },
                { -1, 0, 1 },
                { -1, 0, 1 }
            };

        int[,] kernelY = new int[,]
        {
                { -1, -1, -1 },
                {  0,  0,  0 },
                {  1,  1,  1 }
        };

        public void Transform(Bitmap bitmap)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;

            int[,] lx = new int[width - 2, height - 2];
            int[,] ly = new int[width - 2, height - 2];

            // Применение ядер kernelX и kernelY на изображении
            for (int i = 1; i < width - 2; i++)
            {
                for (int j = 1; j < height - 2; j++)
                {
                    int sumX = 0;
                    int sumY = 0;

                    for (int k = 0; k < 3; k++)
                    {
                        for (int l = 0; l < 3; l++)
                        {
                            Color pixel = bitmap.GetPixel(i + k - 1, j + l - 1);
                            int grayValue = (int)(0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B);

                            sumX += kernelX[k, l] * grayValue;
                            sumY += kernelY[k, l] * grayValue;
                        }
                    }

                    lx[i - 1, j - 1] = sumX;
                    ly[i - 1, j - 1] = sumY;
                }
            }
            GetFilteredImage(height, width, bitmap, lx, ly);
        }

        public void GetFilteredImage(int height, int width, Bitmap bitmap, int[,] lx, int[,] ly)
        {
            int[,] magnitude = new int[width - 2, height - 2];
            int sum = 0;

            for (int i = 0; i < width - 2; i++)
            {
                for (int j = 0; j < height - 2; j++)
                {
                    magnitude[i, j] = (int)Math.Sqrt(Math.Pow(lx[i, j], 2) + Math.Pow(ly[i, j], 2));
                    sum += magnitude[i, j];
                }
            }

            int threshold = sum / ((width - 2) * (height - 2));

            for (int i = 0; i < width - 2; i++)
            {
                for (int j = 0; j < height - 2; j++)
                {
                    magnitude[i, j] = magnitude[i, j] > threshold ? 255 : 0;
                    Color newColor = Color.FromArgb(magnitude[i, j], magnitude[i, j], magnitude[i, j]);
                    bitmap.SetPixel(i + 1, j + 1, newColor); // Нанесение результатов на изображение
                }
            }
        }
    }
}
