using System.Drawing;
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
        public float Opacity { get; set; } = 1;

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

        private void ImageComposeConfigurationConstructor(Image image, int width, int height, Point pointToDrawInComposition)
        {
            Image = image;
            Width = width;
            Height = height;
            PointToDrawInComposition = pointToDrawInComposition;
        }
    }
}
