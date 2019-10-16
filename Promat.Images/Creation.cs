using System;
using System.Drawing;
using Promat.Images.ExtensionMethods;
using SixLabors.ImageSharp.Processing;
using Pen = SixLabors.ImageSharp.Processing.Pen;
using Point = System.Drawing.Point;
using PointF = SixLabors.Primitives.PointF;
using Rectangle = SixLabors.Primitives.Rectangle;

namespace Promat.Images
{
    public static class Creation
    {
        /// <summary>
        /// Compone una flecha horizontal que apunta hacia la derecha
        /// </summary>
        /// <param name="horizontalWidth">Largo total de la flecha</param>
        /// <param name="lineWidth">Grueso de la línea de la flecha</param>
        /// <param name="arrowSize">Tamaño de la punta de la flecha (desde el centro de la línea a su parte superio/inferior)</param>
        /// <param name="arrowColor">Color de la flecha</param>
        /// <param name="bidireccional">True si queremos que la flecha tenga punta en sus dos extremos</param>
        /// <returns></returns>
        public static Image LeftToRigthHorizontalArrow(double horizontalWidth, float lineWidth, float arrowSize, Color? arrowColor = null, bool bidireccional = false)
            => PrivateLeftToRigthHorizontalArrow(horizontalWidth, lineWidth, arrowSize, arrowColor, bidireccional).ToImage();

        /// <summary>
        /// Compone una flecha según las especificaciones facilitadas
        /// </summary>
        /// <param name="from">Punto del que parte la flecha</param>
        /// <param name="to">Punto en el que termina la flecha</param>
        /// <param name="lineWidth">Grueso de la línea de la flecha</param>
        /// <param name="arrowSize">Tamaño de la punta de la flecha (desde el centro de la línea a su parte superio/inferior)</param>
        /// <param name="arrowColor">Color de la flecha</param>
        /// <param name="bidireccional">True si queremos que la flecha tenga punta en sus dos extremos</param>
        /// <param name="marginX">Pixels que se quiere dar de margen a la composición en el eje X (si es muy grande se reducirá hasta el máximo posible)</param>
        /// <param name="marginY">Pixels que se quiere dar de margen a la composición en el eje Y (si es muy grande se reducirá hasta el máximo posible)</param>
        /// <returns></returns>
        public static Image Arrow(Point from, Point to, float lineWidth, float arrowSize, Color? arrowColor = null, bool bidireccional = false, int marginX = 2, int marginY = 2)
        {
            var rectX = Math.Abs(from.X - to.X);
            var rectY = Math.Abs(from.Y - to.Y);
            var hipotenusa = Math.Sqrt(Math.Pow(rectX, 2) + Math.Pow(rectY, 2));
            var horizontalArrow = PrivateLeftToRigthHorizontalArrow(hipotenusa, lineWidth, arrowSize, arrowColor, bidireccional);
            var angulo = Convert.ToSingle(Math.Asin(rectY / hipotenusa) * 180 / Math.PI);
            var aDerechas = to.X >= from.X;
            var aAbajo = to.Y <= from.Y;
            var horizontal = to.Y == from.Y;
            var vertical = to.X == from.X;

            if (horizontal)
            {
                return aDerechas ?
                        horizontalArrow.ToImage() :
                        horizontalArrow.Clone(c => c.Rotate(RotateMode.Rotate180)).ToImage();
            }

            if (vertical)
            {
                return aAbajo ?
                        horizontalArrow.Clone(c => c.Rotate(RotateMode.Rotate90)).ToImage() :
                        horizontalArrow.Clone(c => c.Rotate(RotateMode.Rotate270)).ToImage();
            }

            SixLabors.ImageSharp.Image rotated;
            var xOffset = Convert.ToInt32(Math.Sin(angulo * Math.PI / 180) * arrowSize);
            var yOffset = Convert.ToInt32(Math.Cos(angulo * Math.PI / 180) * arrowSize);

            if (aAbajo)
            {
                rotated = aDerechas ? horizontalArrow.Clone(c => c.Rotate(angulo)) : horizontalArrow.Clone(c => c.Rotate(180 - angulo));
            }
            else
            {
                rotated = aDerechas ? horizontalArrow.Clone(c => c.Rotate(360 - angulo)) : horizontalArrow.Clone(c => c.Rotate(180 + angulo));
            }

            while (marginX > 0 && xOffset - marginX + rectX + marginX * 2 > rotated.Width)
            {
                marginX--;
            }
            while (marginY > 0 && yOffset - marginY + rectY + marginY * 2 > rotated.Height)
            {
                marginY--;
            }

            return rotated
                    .Clone(c => c.Crop(new Rectangle(xOffset - marginX, yOffset - marginY, rectX + marginX * 2, rectY + marginY * 2))
                                         .Resize(rectX, rectY))
                    .ToImage();
        }

        private static SixLabors.ImageSharp.Image PrivateLeftToRigthHorizontalArrow(double horizontalWidth, float lineWidth, float arrowSize, Color? arrowColor = null, bool bidireccional = false)
        {
            var color = arrowColor ?? Color.Black;
            var imageSharpColor = SixLabors.ImageSharp.Color.FromRgba(color.R, color.G, color.B, color.A);
            var horizontal = Convert.ToSingle(horizontalWidth);
            var pen = new Pen(imageSharpColor, lineWidth);
            SixLabors.ImageSharp.Image img;
            var linePoints = new[]
            {
                    new PointF(bidireccional ? arrowSize : 0, arrowSize),
                    new PointF(horizontal - arrowSize, arrowSize)
            };
            var arrowPoints = new[] {new PointF(horizontal - arrowSize, 0),
                    new PointF(horizontal - arrowSize, arrowSize * 2),
                    new PointF(horizontal, arrowSize) };
            var arrow2Points = new[] {new PointF(arrowSize, 0),
                    new PointF(arrowSize, arrowSize * 2),
                    new PointF(0, arrowSize) };

            using (var bitmap = new Bitmap(Convert.ToInt32(horizontalWidth), Convert.ToInt32(arrowSize * 2)))
            {
                img = SixLabors.ImageSharp.Image.Load(bitmap.ToByteArray());
            }

            return img.Clone(ctx =>
                             {
                                 ctx.DrawLines(pen, linePoints)
                                         .DrawPolygon(imageSharpColor, 1, arrowPoints)
                                         .FillPolygon(imageSharpColor, arrowPoints);

                                 if (bidireccional)
                                 {
                                     ctx.DrawPolygon(imageSharpColor, 1, arrow2Points)
                                             .FillPolygon(imageSharpColor, arrow2Points);
                                 }
                             }
                            );
        }
    }
}