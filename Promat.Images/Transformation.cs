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

        public static Image Scale(string imageFile, int maxWidth, int maxHeight)
            => Scale(Image.FromFile(imageFile), maxWidth, maxHeight);
        public static Image Scale(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            return Resize(image, newWidth, newHeight);
        }

        public static Image Opacity(Image image, float opacity)
            => image.ToImageSharpImage().Clone(c => c.Opacity(opacity)).ToImage();
        public static Image Opacity(string imageFile, float opacity)
            => SixLabors.ImageSharp.Image.Load(imageFile).Clone(c => c.Opacity(opacity)).ToImage();
    }
}