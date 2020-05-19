using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Promat.Images.Models;
using SixLabors.ImageSharp;
using Image = System.Drawing.Image;
using Point = System.Drawing.Point;

namespace Promat.Images.ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static byte[] ToByteArray(this Image image, ImageFormat imageFormat = null)
        {
            if (imageFormat == null)
            {
                imageFormat = ImageFormat.Png;
            }

            using (var memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, imageFormat);
                return memoryStream.ToArray();
            }
        }
        public static SixLabors.ImageSharp.Image ToImageSharpImage(this Image image, ImageFormat imageFormat = null)
            => SixLabors.ImageSharp.Image.Load(image.ToByteArray(imageFormat));
        public static Image ToImage(this SixLabors.ImageSharp.Image image, ImageFormat imageFormat = null)
        {
            if (imageFormat == null)
            {
                imageFormat = ImageFormat.Png;
            }
            using (var memoryStream = new MemoryStream())
            {
                var saved = false;
                if (imageFormat.Equals(ImageFormat.Gif))
                {
                    image.SaveAsGif(memoryStream);
                    saved = true;
                }
                if (imageFormat.Equals(ImageFormat.Bmp) ||
                    imageFormat.Equals(ImageFormat.MemoryBmp))
                {
                    image.SaveAsBmp(memoryStream);
                    saved = true;
                }
                if (imageFormat.Equals(ImageFormat.Jpeg))
                {
                    image.SaveAsJpeg(memoryStream);
                    saved = true;
                }
                if (!saved)
                {
                    image.SaveAsPng(memoryStream);
                }
                return Image.FromStream(memoryStream);
            }
        }
        public static bool IsHorizontalLeft(this ContentAlignment alignment) => alignment == ContentAlignment.BottomLeft || alignment == ContentAlignment.MiddleLeft || alignment == ContentAlignment.TopLeft;
        public static bool IsHorizontalCenter(this ContentAlignment alignment) => alignment == ContentAlignment.BottomCenter || alignment == ContentAlignment.MiddleCenter || alignment == ContentAlignment.TopCenter;
        public static bool IsHorizontalRight(this ContentAlignment alignment) => alignment == ContentAlignment.BottomRight || alignment == ContentAlignment.MiddleRight || alignment == ContentAlignment.TopRight;
        public static bool IsVerticalTop(this ContentAlignment alignment) => alignment == ContentAlignment.TopRight || alignment == ContentAlignment.TopCenter || alignment == ContentAlignment.TopLeft;
        public static bool IsVerticalMiddle(this ContentAlignment alignment) => alignment == ContentAlignment.MiddleRight || alignment == ContentAlignment.MiddleCenter || alignment == ContentAlignment.MiddleLeft;
        public static bool IsVerticalBottom(this ContentAlignment alignment) => alignment == ContentAlignment.BottomRight || alignment == ContentAlignment.BottomCenter || alignment == ContentAlignment.BottomLeft;
        public static Point GetPointToDraw(this CanvasConfiguration canvas, string imageFile, ContentAlignment alignment)
        {
            var image = Image.FromFile(imageFile);
            return canvas.GetPointToDraw(alignment, image.Width, image.Height);
        }
        public static Point GetPointToDraw(this CanvasConfiguration canvas, Stream stream, ContentAlignment alignment)
        {
            var image = Image.FromStream(stream);
            return canvas.GetPointToDraw(alignment, image.Width, image.Height);
        }
        public static Point GetPointToDraw(this CanvasConfiguration canvas, Image image, ContentAlignment alignment)
            => canvas.GetPointToDraw(alignment, image.Width, image.Height);
        public static Point GetPointToDraw(this CanvasConfiguration canvas, ContentAlignment alignment, int width, int height)
        {
            var x = alignment.IsHorizontalLeft() ?
                    0 :
                    alignment.IsHorizontalCenter() ?
                            canvas.Width / 2 - width / 2 :
                            canvas.Width - width;
            var y = alignment.IsVerticalTop() ?
                    0 :
                    alignment.IsVerticalMiddle() ?
                            canvas.Height / 2 - height / 2 :
                            canvas.Height - height;

            return new Point(x, y);
        }

        /// <summary>
        /// Devuelve una imagen del tamaño indicado resultado de redimensionar la imagen facilitada como parámetro
        /// </summary>
        /// <param name="image">Imagen a redimensionar</param>
        /// <param name="width">Ancho deseado</param>
        /// <param name="height">Alto deseado</param>
        public static Image Resize(this Image image, int width, int height) => Transformation.Resize(image, width, height);
        /// <summary>
        /// Devuelve una imagen redimensionada de la imagen indicada ajustada al tamaño indicado respetando su proponcionalidad.
        /// </summary>
        /// <param name="image">Imagen a reescalar</param>
        /// <param name="maxWidth">Ancho máximo deseado</param>
        /// <param name="maxHeight">Alto máximo deseado</param>
        public static Image Scale(this Image image, int maxWidth, int maxHeight) => Transformation.Resize(image, maxWidth, maxHeight);
        /// <summary>
        /// Devuelve una imagen resultado de rotar la imagen facilitada como parámetro
        /// </summary>
        /// <param name="image">Imagen a rotar</param>
        /// <param name="degrees">Grados que se quiere rotar</param>
        public static Image Rotate(this Image image, float degrees) => Transformation.Rotate(image, degrees);
        /// <summary>
        /// Devuelve una imagen resultado de aplicar el factor de opacidad indicado a la imagen facilitada como parámetro
        /// </summary>
        /// <param name="image">Imagen cuya opacidad se quiere cambiar</param>
        /// <param name="opacity">Valor de 0 a 1 que indica el grado de opacidad</param>
        public static Image Opacity(this Image image, float opacity) => Transformation.Opacity(image, opacity);
    }
}
