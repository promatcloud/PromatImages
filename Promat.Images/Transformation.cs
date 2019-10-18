using System;
using System.IO;
using Promat.Images.ExtensionMethods;
using SixLabors.ImageSharp.Processing;
using Image = System.Drawing.Image;

namespace Promat.Images
{
    public static class Transformation
    {
        /// <summary>
        /// Devuelve una imagen del tamaño indicado resultado de redimensionar la imagen facilitada como parámetro
        /// </summary>
        /// <param name="image">Imagen a redimensionar</param>
        /// <param name="width">Ancho deseado</param>
        /// <param name="height">Alto deseado</param>
        public static Image Resize(Image image, int width, int height)
            => image.ToImageSharpImage().Clone(c => c.Resize(width, height)).ToImage();
        /// <summary>
        /// Devuelve una imagen del tamaño indicado resultado de redimensionar la imagen facilitada como parámetro
        /// </summary>
        /// <param name="imageFile">Archivo de imagen a redimensionar</param>
        /// <param name="width">Ancho deseado</param>
        /// <param name="height">Alto deseado</param>
        public static Image Resize(string imageFile, int width, int height)
            => SixLabors.ImageSharp.Image.Load(imageFile).Clone(c => c.Resize(width, height)).ToImage();
        /// <summary>
        /// Devuelve una imagen del tamaño indicado resultado de redimensionar la imagen facilitada como parámetro
        /// </summary>
        /// <param name="stream">El stream que contiene la información de la imagen a redimensionar</param>
        /// <param name="width">Ancho deseado</param>
        /// <param name="height">Alto deseado</param>
        public static Image Resize(Stream stream, int width, int height)
            => SixLabors.ImageSharp.Image.Load(stream).Clone(c => c.Resize(width, height)).ToImage();

        /// <summary>
        /// Devuelve una imagen redimensionada de la imagen indicada ajustada al tamaño indicado respetando su proponcionalidad.
        /// </summary>
        /// <param name="imageFile">Archivo de imagen a reescalar</param>
        /// <param name="maxWidth">Ancho máximo deseado</param>
        /// <param name="maxHeight">Alto máximo deseado</param>
        public static Image Scale(string imageFile, int maxWidth, int maxHeight)
            => Scale(Image.FromFile(imageFile), maxWidth, maxHeight);
        /// <summary>
        /// Devuelve una imagen redimensionada de la imagen indicada ajustada al tamaño indicado respetando su proponcionalidad.
        /// </summary>
        /// <param name="stream">El stream que contiene la información de la imagen a reescalar</param>
        /// <param name="maxWidth">Ancho máximo deseado</param>
        /// <param name="maxHeight">Alto máximo deseado</param>
        public static Image Scale(Stream stream, int maxWidth, int maxHeight)
            => Scale(Image.FromStream(stream), maxWidth, maxHeight);
        /// <summary>
        /// Devuelve una imagen redimensionada de la imagen indicada ajustada al tamaño indicado respetando su proponcionalidad.
        /// </summary>
        /// <param name="image">Imagen a reescalar</param>
        /// <param name="maxWidth">Ancho máximo deseado</param>
        /// <param name="maxHeight">Alto máximo deseado</param>
        public static Image Scale(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            return Resize(image, newWidth, newHeight);
        }

        /// <summary>
        /// Devuelve una imagen resultado de rotar la imagen facilitada como parámetro
        /// </summary>
        /// <param name="imageFile">Archivo de imagen a rotar</param>
        /// <param name="degrees">Grados que se quiere rotar</param>
        public static Image Rotate(string imageFile, float degrees) => Rotate(Image.FromFile(imageFile), degrees);
        /// <summary>
        /// Devuelve una imagen resultado de rotar la imagen facilitada como parámetro
        /// </summary>
        /// <param name="stream">El stream que contiene la información de la imagen a rotar</param>
        /// <param name="degrees">Grados que se quiere rotar</param>
        public static Image Rotate(Stream stream, float degrees) => Rotate(Image.FromStream(stream), degrees);
        /// <summary>
        /// Devuelve una imagen resultado de rotar la imagen facilitada como parámetro
        /// </summary>
        /// <param name="image">Imagen a rotar</param>
        /// <param name="degrees">Grados que se quiere rotar</param>
        public static Image Rotate(Image image, float degrees) => image.ToImageSharpImage().Clone(c => c.Rotate(degrees)).ToImage();

        /// <summary>
        /// Devuelve una imagen resultado de aplicar el factor de opacidad indicado a la imagen facilitada como parámetro
        /// </summary>
        /// <param name="image">Imagen cuya opacidad se quiere cambiar</param>
        /// <param name="opacity">Valor de 0 a 1 que indica el grado de opacidad</param>
        public static Image Opacity(Image image, float opacity)
            => image.ToImageSharpImage().Clone(c => c.Opacity(opacity)).ToImage();
        /// <summary>
        /// Devuelve una imagen resultado de aplicar el factor de opacidad indicado a la imagen facilitada como parámetro
        /// </summary>
        /// <param name="imageFile">Archivo de imagen cuya opacidad se quiere cambiar</param>
        /// <param name="opacity">Valor de 0 a 1 que indica el grado de opacidad</param>
        public static Image Opacity(string imageFile, float opacity)
            => SixLabors.ImageSharp.Image.Load(imageFile).Clone(c => c.Opacity(opacity)).ToImage();
        /// <summary>
        /// Devuelve una imagen resultado de aplicar el factor de opacidad indicado a la imagen facilitada como parámetro
        /// </summary>
        /// <param name="stream">El stream que contiene la información de la imagen cuya opacidad se quiere cambiar</param>
        /// <param name="opacity">Valor de 0 a 1 que indica el grado de opacidad</param>
        public static Image Opacity(Stream stream, float opacity)
            => SixLabors.ImageSharp.Image.Load(stream).Clone(c => c.Opacity(opacity)).ToImage();
    }
}