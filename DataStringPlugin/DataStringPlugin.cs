using PluginInterface;
using System;
using System.Device.Location;
using System.Drawing;

namespace DataStringPlugin
{
    public class DataStringPlugin : IPlugin
    {
        public string Name
        {
            get
            {
                return "Добавить дату и локацию";
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
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
            watcher.Start();
            var a = watcher.Position.Location.Latitude;
            var b = watcher.Position.Location.Longitude;
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                int fontsize = Math.Min(bitmap.Height, bitmap.Width) / 25;
                using (Font font = new Font("Times New Roman", fontsize))
                {
                    // если картинка черная?
                    using (SolidBrush brush = new SolidBrush(Color.Black))
                    {
                        StringFormat format = new StringFormat();
                        format.Alignment = StringAlignment.Far;
                        format.LineAlignment = StringAlignment.Far;

                        graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                        string text = "Дата: " + DateTime.Today.ToString("d") + "\n Место:";
                        if (!double.IsNaN(a) && !double.IsNaN(b))
                            text += a.ToString() + " " + b.ToString();
                        else
                            text += "HSE Perm";
                        graphics.DrawString(text, font, brush, new Rectangle(0, 0, bitmap.Width, bitmap.Height), format);
                    }
                }
            }
        }
    }
}
