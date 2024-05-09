using PluginInterface;
using System.Collections.Generic;
using System.Drawing;

namespace MedianPlugin
{
    public class MedianPlugin : IPlugin
    {
        public string Name
        {
            get
            {
                return "Матричный медианный фильтр";
            }
        }

        public string Author
        {
            get
            {
                return "Me";
            }
        }

        public void Transform(Bitmap bitmap)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;

            for (int i = 2; i < width - 2; i++)
            {
                for (int j = 2; j < height - 2; j++)
                {
                    List<int> brights = new List<int>();

                    for (int k = -1; k < 4; k++)
                    {
                        for (int l = -1; l < 4; l++)
                        {
                            Color pixel = bitmap.GetPixel(i + k - 1, j + l - 1);
                            int grayValue = pixel.ToArgb();
                            brights.Add(grayValue);
                        }
                    }

                    brights.Sort();
                    int value = brights[12];
                    bitmap.SetPixel(i, j, Color.FromArgb(value));
                }
            }
        }
    }
}
