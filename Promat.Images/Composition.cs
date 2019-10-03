using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Promat.Images.ExtensionMethods;
using Promat.Images.Models;
using SixLabors.ImageSharp.Processing;
using Image = System.Drawing.Image;

namespace Promat.Images
{
    public static class Composition
    {
        public static ComposeContext Begin(CanvasConfiguration configuration) => new ComposeContext
        {
            Configuration = configuration
        };
        public static ComposeContext Begin(int width, int height, ImageFormat imageFormat, PixelFormat pixelFormat) => new ComposeContext
        {
            Configuration = new CanvasConfiguration(width, height, imageFormat, pixelFormat)
        };
        public static ComposeContext Begin(int width, int height, ImageFormat imageFormat) => new ComposeContext
        {
            Configuration = new CanvasConfiguration(width, height, imageFormat)
        };
        public static ComposeContext Begin(int width, int height, PixelFormat pixelFormat) => new ComposeContext
        {
            Configuration = new CanvasConfiguration(width, height, pixelFormat)
        };
        public static ComposeContext Begin(int width, int height) => new ComposeContext
        {
            Configuration = new CanvasConfiguration(width, height)
        };

        public static ComposeContext Add(this ComposeContext context, ImageComposeConfiguration imageComposeConfiguration)
        {
            context.Images.Add(imageComposeConfiguration);
            return context;
        }

        public static ComposeContext Add(this ComposeContext context, Image image)
        {
            context.Images.Add(new ImageComposeConfiguration(image));
            return context;
        }
        public static ComposeContext Add(this ComposeContext context, Image image, int targetWidth, int targetHeight)
        {
            context.Images.Add(new ImageComposeConfiguration(image, targetWidth, targetHeight));
            return context;
        }
        public static ComposeContext Add(this ComposeContext context, Image image, ContentAlignment alignment)
        {
            context.Images.Add(new ImageComposeConfiguration(image, context.Configuration.GetPointToDraw(image, alignment)));
            return context;
        }
        public static ComposeContext Add(this ComposeContext context, Image image, int targetWidth, int targetHeight, ContentAlignment alignment)
        {
            context.Images.Add(new ImageComposeConfiguration(image, targetWidth, targetHeight, context.Configuration.GetPointToDraw(alignment, targetWidth, targetHeight)));
            return context;
        }
        public static ComposeContext Add(this ComposeContext context, Image image, ContentAlignment alignment, int xOffset, int yOffset)
        {
            var point = context.Configuration.GetPointToDraw(image, alignment);
            context.Images.Add(new ImageComposeConfiguration(image, new Point(point.X + xOffset, point.Y + yOffset)));
            return context;
        }
        public static ComposeContext Add(this ComposeContext context, Image image, int targetWidth, int targetHeight, ContentAlignment alignment, int xOffset, int yOffset)
        {
            var point = context.Configuration.GetPointToDraw(alignment, targetWidth, targetHeight);
            context.Images.Add(new ImageComposeConfiguration(image, targetWidth, targetHeight, new Point(point.X + xOffset, point.Y + yOffset)));
            return context;
        }

        public static ComposeContext Add(this ComposeContext context, string imageFile)
        {
            context.Images.Add(new ImageComposeConfiguration(imageFile));
            return context;
        }
        public static ComposeContext Add(this ComposeContext context, string imageFile, int targetWidth, int targetHeight)
        {
            context.Images.Add(new ImageComposeConfiguration(imageFile, targetWidth, targetHeight));
            return context;
        }
        public static ComposeContext Add(this ComposeContext context, string imageFile, ContentAlignment alignment)
        {
            context.Images.Add(new ImageComposeConfiguration(imageFile, context.Configuration.GetPointToDraw(imageFile, alignment)));
            return context;
        }
        public static ComposeContext Add(this ComposeContext context, string imageFile, int targetWidth, int targetHeight, ContentAlignment alignment)
        {
            context.Images.Add(new ImageComposeConfiguration(imageFile, targetWidth, targetHeight, context.Configuration.GetPointToDraw(alignment, targetWidth, targetHeight)));
            return context;
        }
        public static ComposeContext Add(this ComposeContext context, string imageFile, ContentAlignment alignment, int xOffset, int yOffset)
        {
            var point = context.Configuration.GetPointToDraw(imageFile, alignment);
            context.Images.Add(new ImageComposeConfiguration(imageFile, new Point(point.X + xOffset, point.Y + yOffset)));
            return context;
        }
        public static ComposeContext Add(this ComposeContext context, string imageFile, int targetWidth, int targetHeight, ContentAlignment alignment, int xOffset, int yOffset)
        {
            var point = context.Configuration.GetPointToDraw(alignment, targetWidth, targetHeight);
            context.Images.Add(new ImageComposeConfiguration(imageFile, targetWidth, targetHeight, new Point(point.X + xOffset, point.Y + yOffset)));
            return context;
        }

        public static Image Compose(this ComposeContext context) => Compose(context.Configuration, context.Images.ToArray());
        public static Image Compose(CanvasConfiguration canvasConfiguration, params ImageComposeConfiguration[] imagesConfigurations)
        {
            var composition = SixLabors.ImageSharp.Image.Load(GetNewBitmapToByte(canvasConfiguration.Width, canvasConfiguration.Height, canvasConfiguration.ImageFormat, canvasConfiguration.PixelFormat));

            foreach (var imageConfiguration in imagesConfigurations)
            {
                using (var imageCopy = imageConfiguration.Image.Clone(x => x.Resize(imageConfiguration.Width, imageConfiguration.Height)))
                {
                    composition.Mutate(context => context.DrawImage(imageCopy, new SixLabors.Primitives.Point(imageConfiguration.PointToDrawInComposition.X, imageConfiguration.PointToDrawInComposition.Y), 1));
                }
            }

            return composition.ToImage();
        }

        private static byte[] GetNewBitmapToByte(int width, int height, ImageFormat imageFormat = null, PixelFormat pixelFormat = PixelFormat.Format32bppArgb)
        {
            if (imageFormat == null)
            {
                imageFormat = ImageFormat.Png;
            }

            using (var memoryStream = new MemoryStream())
            {
                var bitmap = new Bitmap(width, height, pixelFormat);
                bitmap.Save(memoryStream, imageFormat);
                return memoryStream.ToArray();
            }
        }
    }
}
