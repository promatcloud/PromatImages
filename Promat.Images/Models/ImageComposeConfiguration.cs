using System.Drawing;
using System.IO;
using Promat.Images.ExtensionMethods;
using Image = SixLabors.ImageSharp.Image;

namespace Promat.Images.Models
{
    public class ImageComposeConfiguration
    {
        public Image Image { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Point PointToDrawInComposition { get; private set; }
        public float Opacity { get; private set; }

        public ImageComposeConfiguration(System.Drawing.Image image, int width, int height, Point pointToDrawInComposition)
            => ImageComposeConfigurationConstructor(image.ToImageSharpImage(), width, height, pointToDrawInComposition);
        public ImageComposeConfiguration(System.Drawing.Image image, int width, int height, int coordinateXToDrawInComposition, int coordinateYToDrawInComposition)
            => ImageComposeConfigurationConstructor(image.ToImageSharpImage(), width, height, new Point(coordinateXToDrawInComposition, coordinateYToDrawInComposition));
        public ImageComposeConfiguration(System.Drawing.Image image, int width, int height)
            => ImageComposeConfigurationConstructor(image.ToImageSharpImage(), width, height, Point.Empty);
        public ImageComposeConfiguration(System.Drawing.Image image, Point pointToDrawInComposition)
            => ImageComposeConfigurationConstructor(image.ToImageSharpImage(), image.Width, image.Height, pointToDrawInComposition);
        public ImageComposeConfiguration(System.Drawing.Image image)
            => ImageComposeConfigurationConstructor(image.ToImageSharpImage(), image.Width, image.Height, Point.Empty);
        public ImageComposeConfiguration(System.Drawing.Image image, int width, int height, Point pointToDrawInComposition, float opacity)
            => ImageComposeConfigurationConstructor(image.ToImageSharpImage(), width, height, pointToDrawInComposition, opacity);
        public ImageComposeConfiguration(System.Drawing.Image image, int width, int height, int coordinateXToDrawInComposition, int coordinateYToDrawInComposition, float opacity)
            => ImageComposeConfigurationConstructor(image.ToImageSharpImage(), width, height, new Point(coordinateXToDrawInComposition, coordinateYToDrawInComposition), opacity);
        public ImageComposeConfiguration(System.Drawing.Image image, int width, int height, float opacity)
            => ImageComposeConfigurationConstructor(image.ToImageSharpImage(), width, height, Point.Empty, opacity);
        public ImageComposeConfiguration(System.Drawing.Image image, Point pointToDrawInComposition, float opacity)
            => ImageComposeConfigurationConstructor(image.ToImageSharpImage(), image.Width, image.Height, pointToDrawInComposition, opacity);
        public ImageComposeConfiguration(System.Drawing.Image image, float opacity)
            => ImageComposeConfigurationConstructor(image.ToImageSharpImage(), image.Width, image.Height, Point.Empty, opacity);

        public ImageComposeConfiguration(Image image, int width, int height, Point pointToDrawInComposition)
            => ImageComposeConfigurationConstructor(image, width, height, pointToDrawInComposition);
        public ImageComposeConfiguration(Image image, int width, int height, int coordinateXToDrawInComposition, int coordinateYToDrawInComposition)
            => ImageComposeConfigurationConstructor(image, width, height, new Point(coordinateXToDrawInComposition, coordinateYToDrawInComposition));
        public ImageComposeConfiguration(Image image, int width, int height)
            => ImageComposeConfigurationConstructor(image, width, height, Point.Empty);
        public ImageComposeConfiguration(Image image, Point pointToDrawInComposition)
            => ImageComposeConfigurationConstructor(image, image.Width, image.Height, pointToDrawInComposition);
        public ImageComposeConfiguration(Image image)
            => ImageComposeConfigurationConstructor(image, image.Width, image.Height, Point.Empty);
        public ImageComposeConfiguration(Image image, int width, int height, Point pointToDrawInComposition, float opacity)
            => ImageComposeConfigurationConstructor(image, width, height, pointToDrawInComposition, opacity);
        public ImageComposeConfiguration(Image image, int width, int height, int coordinateXToDrawInComposition, int coordinateYToDrawInComposition, float opacity)
            => ImageComposeConfigurationConstructor(image, width, height, new Point(coordinateXToDrawInComposition, coordinateYToDrawInComposition), opacity);
        public ImageComposeConfiguration(Image image, int width, int height, float opacity)
            => ImageComposeConfigurationConstructor(image, width, height, Point.Empty, opacity);
        public ImageComposeConfiguration(Image image, Point pointToDrawInComposition, float opacity)
            => ImageComposeConfigurationConstructor(image, image.Width, image.Height, pointToDrawInComposition, opacity);
        public ImageComposeConfiguration(Image image, float opacity)
            => ImageComposeConfigurationConstructor(image, image.Width, image.Height, Point.Empty, opacity);

        public ImageComposeConfiguration(string imageFile)
        {
            Image = Image.Load(imageFile);
            Width = Image.Width;
            Height = Image.Height;
            PointToDrawInComposition = Point.Empty;
        }
        public ImageComposeConfiguration(string imageFile, Point pointToDrawInComposition)
        {
            Image = Image.Load(imageFile);
            Width = Image.Width;
            Height = Image.Height;
            PointToDrawInComposition = pointToDrawInComposition;
        }
        public ImageComposeConfiguration(string imageFile, int width, int height, Point pointToDrawInComposition)
            => ImageComposeConfigurationConstructor(Image.Load(imageFile), width, height, pointToDrawInComposition);
        public ImageComposeConfiguration(string imageFile, int width, int height, int coordinateXToDrawInComposition, int coordinateYToDrawInComposition)
            => ImageComposeConfigurationConstructor(Image.Load(imageFile), width, height, new Point(coordinateXToDrawInComposition, coordinateYToDrawInComposition));
        public ImageComposeConfiguration(string imageFile, int width, int height)
            => ImageComposeConfigurationConstructor(Image.Load(imageFile), width, height, Point.Empty);
        public ImageComposeConfiguration(string imageFile, float opacity)
        {
            Image = Image.Load(imageFile);
            Width = Image.Width;
            Height = Image.Height;
            PointToDrawInComposition = Point.Empty;
            SetOpacity(opacity);
        }
        public ImageComposeConfiguration(string imageFile, Point pointToDrawInComposition, float opacity)
        {
            Image = Image.Load(imageFile);
            Width = Image.Width;
            Height = Image.Height;
            PointToDrawInComposition = pointToDrawInComposition;
            SetOpacity(opacity);
        }
        public ImageComposeConfiguration(string imageFile, int width, int height, Point pointToDrawInComposition, float opacity)
            => ImageComposeConfigurationConstructor(Image.Load(imageFile), width, height, pointToDrawInComposition, opacity);
        public ImageComposeConfiguration(string imageFile, int width, int height, int coordinateXToDrawInComposition, int coordinateYToDrawInComposition, float opacity)
            => ImageComposeConfigurationConstructor(Image.Load(imageFile), width, height, new Point(coordinateXToDrawInComposition, coordinateYToDrawInComposition), opacity);
        public ImageComposeConfiguration(string imageFile, int width, int height, float opacity)
            => ImageComposeConfigurationConstructor(Image.Load(imageFile), width, height, Point.Empty, opacity);

        public ImageComposeConfiguration(Stream stream)
        {
            Image = Image.Load(stream);
            Width = Image.Width;
            Height = Image.Height;
            PointToDrawInComposition = Point.Empty;
        }
        public ImageComposeConfiguration(Stream stream, Point pointToDrawInComposition)
        {
            Image = Image.Load(stream);
            Width = Image.Width;
            Height = Image.Height;
            PointToDrawInComposition = pointToDrawInComposition;
        }
        public ImageComposeConfiguration(Stream stream, int width, int height, Point pointToDrawInComposition)
            => ImageComposeConfigurationConstructor(Image.Load(stream), width, height, pointToDrawInComposition);
        public ImageComposeConfiguration(Stream stream, int width, int height, int coordinateXToDrawInComposition, int coordinateYToDrawInComposition)
            => ImageComposeConfigurationConstructor(Image.Load(stream), width, height, new Point(coordinateXToDrawInComposition, coordinateYToDrawInComposition));
        public ImageComposeConfiguration(Stream stream, int width, int height)
            => ImageComposeConfigurationConstructor(Image.Load(stream), width, height, Point.Empty);
        public ImageComposeConfiguration(Stream stream, float opacity)
        {
            Image = Image.Load(stream);
            Width = Image.Width;
            Height = Image.Height;
            PointToDrawInComposition = Point.Empty;
            SetOpacity(opacity);
        }
        public ImageComposeConfiguration(Stream stream, Point pointToDrawInComposition, float opacity)
        {
            Image = Image.Load(stream);
            Width = Image.Width;
            Height = Image.Height;
            PointToDrawInComposition = pointToDrawInComposition;
            SetOpacity(opacity);
        }
        public ImageComposeConfiguration(Stream stream, int width, int height, Point pointToDrawInComposition, float opacity)
            => ImageComposeConfigurationConstructor(Image.Load(stream), width, height, pointToDrawInComposition, opacity);
        public ImageComposeConfiguration(Stream stream, int width, int height, int coordinateXToDrawInComposition, int coordinateYToDrawInComposition, float opacity)
            => ImageComposeConfigurationConstructor(Image.Load(stream), width, height, new Point(coordinateXToDrawInComposition, coordinateYToDrawInComposition), opacity);
        public ImageComposeConfiguration(Stream stream, int width, int height, float opacity)
            => ImageComposeConfigurationConstructor(Image.Load(stream), width, height, Point.Empty, opacity);

        private void SetOpacity(float opacity)
        {
            if (opacity > 1)
            {
                Opacity = 1;
                return;
            }

            if (opacity < 0)
            {
                Opacity = 0;
                return;
            }

            Opacity = opacity;
        }

        private void ImageComposeConfigurationConstructor(Image image, int width, int height, Point pointToDrawInComposition, float opacity = 1)
        {
            Image = image;
            Width = width;
            Height = height;
            PointToDrawInComposition = pointToDrawInComposition;
            SetOpacity(opacity);
        }
    }
}
