using PluginInterface;
using System.Drawing;

namespace ToGrayPlugin
{
    public class ToGrayPlugin : IPlugin
    {
        public string Name
        {
            get
            {
                return "Получить изображение в сером цвете";
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
            int level = 230;
            for (int i = 0; i < bitmap.Width; ++i)
            {
                for (int j = 0; j < bitmap.Height; ++j)
                {
                    Color color = bitmap.GetPixel(i, j);
                    int grayValue = (int)(0.299 * color.R + 0.587 * color.G + 0.114 * color.B);

                    int shade = grayValue / 32; // Разделение на 8 уровней серого (0-31 - уровень 0, 32-63 - уровень 1 и т.д.)

                    int newGrayValue = shade * 32; // Переводим уровень в соответствующее значение серого

                    Color newColor = Color.FromArgb(newGrayValue, newGrayValue, newGrayValue);
                    bitmap.SetPixel(i, j, newColor);
                }
            }
        }
    }
}
