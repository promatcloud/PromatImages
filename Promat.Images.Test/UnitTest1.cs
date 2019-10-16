using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Mime;
using System.Reflection;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using NUnit.Framework;
using Promat.Images;
using Promat.Images.Models;

namespace Tests
{
    public class Tests
    {
        public string[] Images { get; set; }
        public string OutputPath { get; set; }
        public string PromatLogoFile => Images[2];

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
            // Iniciamos la composición indicando que será de 512x512 pixels
            var resultImage = Composition.Begin(512, 512)
                    // Añadimos las imágenes
                    // la primera imagen se dibujará en un tamaño de 400 x 400 en el centro de la composición
                    .Add(Images[0], 400, 400, ContentAlignment.MiddleCenter)
                    // la sengunda imagen se dibujará en un tamaño de 350 x 350 en el centro de la composición
                    .Add(Images[1], 350, 350, ContentAlignment.MiddleCenter)
                    // la tercera imagen se dibujará en un tamaño de 256 x 256 en la esquiña inferior izquiera de la composición y ademas la desplazaremos 40 px más a la iaquiera y 5 px más hacia abajo
                    .Add(Images[2], 256, 256, ContentAlignment.BottomLeft, -40, 5)
                    // Obtenemos la composición con los parámetros configurados anteriormente
                    .Compose();
            // Guardamos la composición
            resultImage.Save(Path.Combine(OutputPath, "composition2.png"));
        }
        [Test]
        public void Test3()
        {
            var resultImage = Composition.CreateImageWithWatermark(Transformation.Resize(Images[2], 500, 500), Transformation.Resize(Images[0], 300, 300));
            var resultImage2 = Composition.CreateImageWithWatermark(Transformation.Resize(Images[2], 500, 500), Transformation.Resize(Images[0], 300, 300), 0.9f);

            resultImage.Save(Path.Combine(OutputPath, "composition3_1.png"));
            resultImage2.Save(Path.Combine(OutputPath, "composition3_2.png"));
        }
        [Test]
        public void Test4()
        {
            // Redimensionar a partir de un System.Drawing.Image o System.Drawing.Bitmap
            Image miImagenRedimensionada1 = Transformation.Resize(Image.FromFile(PromatLogoFile), 32, 32);

            // Redimensionar a partir de un archivo
            Image miImagenRedimensionada2 = Transformation.Resize(PromatLogoFile, 16, 16);

            // Reescalado a partir de un System.Drawing.Image o System.Drawing.Bitmap
            Image miImagenReescalada1 = Transformation.Scale(Image.FromFile(PromatLogoFile), 150, 120);

            // Reescalado a partir de un archivo
            Image miImagenReescalada2 = Transformation.Scale(PromatLogoFile, 75, 50);

            // Cambiar la opacidad 
            Image miImagenSemitransparente1 = Transformation.Opacity(Image.FromFile(PromatLogoFile), 0.5f);
            // Cambiar la opacidad 
            Image miImagenSemitransparente2 = Transformation.Opacity(PromatLogoFile, 0.5f);
        }
        [Test]
        public void CreationTest()
        {
            Creation.Arrow(new Point(0, 0), new Point(100, 0), 2, 10).Save(Path.Combine(OutputPath, "derecha.png"));
            Creation.Arrow(new Point(100, 0), new Point(0, 0), 2, 5).Save(Path.Combine(OutputPath, "izquierda.png"));
            Creation.Arrow(new Point(0, 0), new Point(0, 100), 2, 3).Save(Path.Combine(OutputPath, "arriba.png"));
            Creation.Arrow(new Point(0, 100), new Point(0, 0), 2, 4).Save(Path.Combine(OutputPath, "abajo.png"));
            Creation.Arrow(new Point(0, 0), new Point(100, 0), 2, 10, Color.Blue, true).Save(Path.Combine(OutputPath, "derechaBidireccional.png"));
            Creation.Arrow(new Point(100, 0), new Point(0, 0), 2, 5, Color.Aqua, true).Save(Path.Combine(OutputPath, "izquierdaBidireccional.png"));
            Creation.Arrow(new Point(0, 0), new Point(0, 100), 2, 3, Color.Brown, true).Save(Path.Combine(OutputPath, "arribaBidireccional.png"));
            Creation.Arrow(new Point(0, 100), new Point(0, 0), 2, 4, Color.DarkGreen, true).Save(Path.Combine(OutputPath, "abajoBidireccional.png"));

            Creation.Arrow(new Point(0, 0), new Point(200, 100), 2, 4, marginY: 10).Save(Path.Combine(OutputPath, "derechaArriba.png"));
            Creation.Arrow(new Point(0, 0), new Point(100, -50), 2, 15).Save(Path.Combine(OutputPath, "derechaAbajo.png"));
            Creation.Arrow(new Point(0, 0), new Point(-100, -50), 2, 15).Save(Path.Combine(OutputPath, "izquierdaAbajo.png"));
            Creation.Arrow(new Point(0, 0), new Point(-100, 50), 2, 8).Save(Path.Combine(OutputPath, "izquierdaArriba.png"));
            Creation.Arrow(new Point(0, 0), new Point(200, 100), 2, 4, Color.Blue, true, marginY: 10).Save(Path.Combine(OutputPath, "derechaArribaBidireccional.png"));
            Creation.Arrow(new Point(0, 0), new Point(100, -50), 2, 15, Color.Blue, true).Save(Path.Combine(OutputPath, "derechaAbajoBidireccional.png"));
            Creation.Arrow(new Point(0, 0), new Point(-100, -50), 2, 15, Color.Blue, true).Save(Path.Combine(OutputPath, "izquierdaAbajoBidireccional.png"));
            Creation.Arrow(new Point(0, 0), new Point(-100, 50), 2, 8, Color.Blue, true).Save(Path.Combine(OutputPath, "izquierdaArribaBidireccional.png"));
        }
    }
}