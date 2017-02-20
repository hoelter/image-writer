using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace WritingTextOnImage
{
    public class ImageWriter
    {
        public void WriteTextToImage(Bitmap image, string savePath, string textToWrite, FontFamily fontFamily)
        {
            using (var graphics = Graphics.FromImage(image))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                // Image is 444 x 248 pixels, this should place text center
                PointF writeLocation = new PointF(222f, 124f);
                var format = new StringFormat { Alignment = StringAlignment.Center };

                using (var font = new Font(fontFamily, 15, FontStyle.Regular))
                {
                    graphics.DrawString(textToWrite, font, Brushes.White, writeLocation, format);
                }
                image.Save(savePath, ImageFormat.Jpeg);
            }
        }

        public Bitmap LoadImage(string imagePath)
        {
            Bitmap image = new Bitmap(imagePath);
            return image;
        }

        public FontFamily LoadFont(string fontPath, string fontName)
        {
            PrivateFontCollection fonts = new PrivateFontCollection();
            fonts.AddFontFile(fontPath);
            FontFamily font = fonts.Families[0];
            return font;
        }
    }
}
