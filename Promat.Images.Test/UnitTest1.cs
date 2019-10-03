using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Mime;
using System.Reflection;
using NUnit.Framework;
using Promat.Images;
using Promat.Images.Models;

namespace Tests
{
    public class Tests
    {
        public string[] Images { get; set; }
        public string OutputPath { get; set; }

        [SetUp]
        public void Setup()
        {
            var imagesFolder = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..", "..", "..", "Images"));
            Images = Directory.GetFiles(imagesFolder);
            OutputPath = Path.Combine(imagesFolder, "output");
            Directory.CreateDirectory(OutputPath);
        }

        [Test]
        public void Test1()
        {
            var img1 = Image.FromFile(Images[0]);
            var img2 = Image.FromFile(Images[1]);
            var img3 = Image.FromFile(Images[2]);
            var resultImage = Composition.Begin(512, 512)
                    .Add(img1, 400, 400, ContentAlignment.MiddleCenter)
                    .Add(img2, 350, 350, ContentAlignment.MiddleCenter)
                    .Add(img3, 256, 256, ContentAlignment.BottomLeft, -40, 5)
                    .Compose();
            resultImage.Save(Path.Combine(OutputPath, "composition1.png"));
        }
        [Test]
        public void Test2()
        {
            var resultImage = Composition.Begin(512, 512)
                    .Add(Images[0], 400, 400, ContentAlignment.MiddleCenter)
                    .Add(Images[1], 350, 350, ContentAlignment.MiddleCenter)
                    .Add(Images[2], 256, 256, ContentAlignment.BottomLeft, -40, 5)
                    .Compose();
            resultImage.Save(Path.Combine(OutputPath, "composition2.png"));
        }
    }
}