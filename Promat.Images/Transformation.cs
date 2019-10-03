using System;
using System.Drawing;
using Promat.Images.ExtensionMethods;
using SixLabors.ImageSharp.Processing;

namespace Promat.Images
{
    public static class Transformation
    {
        public static Image Resize(Image image, int width, int height)
            => image.ToImageSharpImage().Clone(c => c.Resize(width, height)).ToImage();
        public static Image Resize(string imageFile, int width, int height)
            => SixLabors.ImageSharp.Image.Load(imageFile).Clone(c => c.Resize(width, height)).ToImage();
        public static Image ScaleImage(string imageFile, int maxWidth, int maxHeight)
            => ScaleImage(Image.FromFile(imageFile), maxWidth, maxHeight);
        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            return Resize(image, newWidth, newHeight);
        }
    }
}