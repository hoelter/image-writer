using System;
using System.Drawing;
using System.IO;

namespace WritingTextOnImage
{
    class Program
    {
        static void Main(string[] args)
        {
            string rootProjectPath = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string imagePath = Path.Combine(rootProjectPath + "\\prometheus.jpg");
            string fontPath = Path.Combine(rootProjectPath + "\\Chunkfive.otf");
            string savePath = Path.Combine(rootProjectPath + "\\new_prometheus.jpg");

            var imageWriter = new ImageWriter();
            Bitmap image = imageWriter.LoadImage(imagePath);
            FontFamily font = imageWriter.LoadFont(fontPath, "chunkfive");

            imageWriter.WriteTextToImage(image, savePath, "Prometheus", font);

            //Console.ReadLine();
        }
    }
}
