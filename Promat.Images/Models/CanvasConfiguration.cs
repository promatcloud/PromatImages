using System.Drawing.Imaging;

namespace Promat.Images.Models
{
    public class CanvasConfiguration
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public ImageFormat ImageFormat { get; private set; }
        public PixelFormat PixelFormat { get; private set; }

        /// <summary>
        /// Inicializa una nueva instancia para describir el lienzo
        /// </summary>
        /// <param name="width">Ancho en pixels del lienzo</param>
        /// <param name="height">Alto en pixels del lienzo</param>
        /// <param name="imageFormat">Formato de la imagen <see cref="System.Drawing.Imaging.ImageFormat"/></param>
        /// <param name="pixelFormat">Formato del pixel <see cref="System.Drawing.Imaging.PixelFormat"/></param>
        public CanvasConfiguration(int width, int height, ImageFormat imageFormat, PixelFormat pixelFormat)
            => CanvasConfigurationConstructor(width, height, imageFormat, pixelFormat);

        /// <summary>
        /// Inicializa una nueva instancia para describir el lienzo.
        /// Por defecto, la propiedad <see cref="ImageFormat"/> será <see cref="System.Drawing.Imaging.ImageFormat.Png"/>
        /// </summary>
        /// <param name="width">Ancho en pixels del lienzo</param>
        /// <param name="height">Alto en pixels del lienzo</param>
        /// <param name="pixelFormat">Formato del pixel <see cref="System.Drawing.Imaging.PixelFormat"/></param>
        public CanvasConfiguration(int width, int height, PixelFormat pixelFormat)
            => CanvasConfigurationConstructor(width, height, ImageFormat.Png, pixelFormat);

        /// <summary>
        /// Inicializa una nueva instancia para describir el lienzo
        /// Por defecto, la propiedad <see cref="PixelFormat"/> será <see cref="System.Drawing.Imaging.PixelFormat.Format32bppArgb"/>
        /// </summary>
        /// <param name="width">Ancho en pixels del lienzo</param>
        /// <param name="height">Alto en pixels del lienzo</param>
        /// <param name="imageFormat">Formato de la imagen <see cref="System.Drawing.Imaging.ImageFormat"/></param>
        public CanvasConfiguration(int width, int height, ImageFormat imageFormat)
            => CanvasConfigurationConstructor(width, height, imageFormat, PixelFormat.Format32bppArgb);

        /// <summary>
        /// Inicializa una nueva instancia para describir el lienzo
        /// Por defecto, la propiedad <see cref="ImageFormat"/> será <see cref="System.Drawing.Imaging.ImageFormat.Png"/>
        /// Por defecto, la propiedad <see cref="PixelFormat"/> será <see cref="System.Drawing.Imaging.PixelFormat.Format32bppArgb"/>
        /// </summary>
        /// <param name="width">Ancho en pixels del lienzo</param>
        /// <param name="height">Alto en pixels del lienzo</param>
        public CanvasConfiguration(int width, int height)
            => CanvasConfigurationConstructor(width, height, ImageFormat.Png, PixelFormat.Format32bppArgb);

        private void CanvasConfigurationConstructor(int width, int height, ImageFormat imageFormat, PixelFormat pixelFormat)
        {
            Width = width;
            Height = height;
            ImageFormat = imageFormat;
            PixelFormat = pixelFormat;
        }
    }
}
