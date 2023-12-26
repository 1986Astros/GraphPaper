using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharkInSeine
{
    public partial class GraphPaperControl : UserControl
    {
        public GraphPaperControl()
        {
            InitializeComponent();
        }
        public GraphPaper Details;

        private void GraphPaperControl_Paint(object sender, PaintEventArgs e)
        {
            if (Details == null)
                return;

            GraphicsState gs = e.Graphics.Save();
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PageUnit = GraphicsUnit.Point;

            float DpmmX = e.Graphics.DpiX / 25.4F;
            float DpmmY = e.Graphics.DpiY / 25.4F;
            SizeF LineSizeInPixels;
            SizeF SquareSizeInPixels;

            switch (Details.LineWidthUnits)
            {
                case GraphPaper.Units.Inches:
                    LineSizeInPixels = new SizeF(e.Graphics.DpiX * Details.LineWidth, e.Graphics.DpiY * Details.LineWidth);
                    break;
                case GraphPaper.Units.Millimeters:
                    LineSizeInPixels = new SizeF(DpmmX * Details.LineWidth, DpmmY * Details.LineWidth);
                    break;
                default:
                    throw new Exception($"LineWidthUnits {Details.LineWidthUnits} not supported.");
            }

            switch (Details.ShapeWidthUnits)
            {
                case GraphPaper.Units.Inches:
                    SquareSizeInPixels = new SizeF(e.Graphics.DpiX * Details.ShapeWidth, e.Graphics.DpiY * Details.ShapeWidth);
                    break;
                case GraphPaper.Units.Millimeters:
                    SquareSizeInPixels = new SizeF(DpmmX * Details.ShapeWidth, DpmmY * Details.ShapeWidth);
                    break;
                default:
                    throw new Exception($"ShapeWidthUnits {Details.ShapeWidthUnits} not supported.");
           }

            GraphicsState gs2 = e.Graphics.Save();
            try
            {
                e.Graphics.PageUnit = GraphicsUnit.Pixel;
                //Size NewSize;
                SizeF LineSizeInPixels2;
                SizeF SquareSizeInPixels2;

                switch (Details.LineWidthUnits)
                {
                    case GraphPaper.Units.Inches:
                        LineSizeInPixels2 = new SizeF(128F * Details.LineWidth, 128F * Details.LineWidth);
                        break;
                    case GraphPaper.Units.Millimeters:
                        LineSizeInPixels2 = new SizeF(128F / 25.4F * Details.LineWidth, 128F / 25.4F * Details.LineWidth);
                        break;
                    default:
                        throw new Exception($"LineWidthUnits {Details.LineWidthUnits.ToString()} not supported.");
                }
                switch (Details.ShapeWidthUnits)
                {
                    case GraphPaper.Units.Inches:
                        SquareSizeInPixels2 = new SizeF(128F * Details.ShapeWidth, 128F * Details.ShapeWidth);
                        break;
                    case GraphPaper.Units.Millimeters:
                        SquareSizeInPixels2 = new SizeF(128F / 25.4F * Details.ShapeWidth, 128F / 25.4F * Details.ShapeWidth);
                        break;
                    default:
                        throw new Exception($"LineWidthUnits {Details.LineWidthUnits.ToString()} not supported.");
                }
                // calculate the size of the page that will contain 10 rows and columns
                // TODO: Use the entire page, don't limit to 10, don't resize the surface
                //switch (Details.Shape)
                //{
                //    case GraphPaper.Shapes.Triangles:
                //    case GraphPaper.Shapes.Diamonds:
                //        NewSize = new Size(
                //            (int)Math.Ceiling(LineSizeInPixels2.Width + 10F * SquareSizeInPixels2.Width),
                //            (int)Math.Ceiling(LineSizeInPixels2.Height + 10F * SquareSizeInPixels2.Height / 2F * (float)Math.Sqrt(3))
                //            );
                //        break;
                //    case GraphPaper.Shapes.Squares:
                //        NewSize = new Size((int)Math.Ceiling(LineSizeInPixels2.Width + 10F * SquareSizeInPixels2.Width),
                //            (int)Math.Ceiling(LineSizeInPixels2.Height + 10F * SquareSizeInPixels2.Height));
                //        break;
                //    case GraphPaper.Shapes.Hexagons:
                //        Single HexHeight = SquareSizeInPixels2.Height * (float)Math.Sin(Math.PI / 3F);
                //        NewSize = new Size(
                //            (int)Math.Ceiling(LineSizeInPixels2.Width + (15F + 15F * Math.PI / 180F) * SquareSizeInPixels2.Width),
                //            (int)Math.Ceiling(LineSizeInPixels2.Height + 10.5F * HexHeight));
                //        break;
                //    default:
                //        throw new Exception($"Shape {Details.Shape.ToString()} not supported.");
                //}
                //switch (BorderStyle)
                //{
                //    case BorderStyle.None:
                //        break;
                //    case BorderStyle.FixedSingle:
                //        NewSize.Width += SystemInformation.BorderSize.Width + 1;
                //        NewSize.Height = SystemInformation.BorderSize.Height + 1;
                //        break;
                //    case BorderStyle.Fixed3D:
                //        NewSize.Width += SystemInformation.Border3DSize.Width + 1;
                //        NewSize.Height = SystemInformation.Border3DSize.Height + 1;
                //        break;
                //}

                //if (!Size.Equals(NewSize))
                //    Size = NewSize;
            }
            catch 
            {
            }
            finally
            {
                e.Graphics.Restore(gs2);
            }

            switch (Details.Shape)
            {
                case GraphPaper.Shapes.Triangles:
                case GraphPaper.Shapes.Diamonds:
                    DrawTrianglesOrDiamonds(e.Graphics, LineSizeInPixels,SquareSizeInPixels);
                    break;
                case GraphPaper.Shapes.Squares:
                    DrawSquares(e.Graphics, LineSizeInPixels, SquareSizeInPixels);
                    break;
                case GraphPaper.Shapes.Hexagons:
                    DrawHexagons(e.Graphics, LineSizeInPixels, SquareSizeInPixels);
                    break;
            }
        }

        private void DrawTrianglesOrDiamonds(Graphics g, SizeF LineSizeInPixels, SizeF SquareSizeInPixels) 
        {
            if (Details != null)
            {
                using Pen LinePen = new Pen(Details.LineColor ?? Color.Black, LineSizeInPixels.Width);
                if (Details.Shape == GraphPaper.Shapes.Triangles)
                {
                    // horizontal lines
                    float y = LineSizeInPixels.Height / 2F;
                    float dy = SquareSizeInPixels.Height / 2F * (float)Math.Sqrt(3);
                    if (Details.Shape == GraphPaper.Shapes.Triangles)
                    {
                        do
                        {
                            g.DrawLine(LinePen, 0, y, Width, y);
                            y += dy;
                        } while (y < Height);
                    }
                }

                // diagonmal lines
                float startX = -(float)Math.Tan(30 * Math.PI / 180) * Height;
                float endX = Width + (float)Math.Tan(30 * Math.PI / 180) * Height;
                Debug.WriteLine($"Diagonals: start = {startX}, end = {endX}, Width = {Width}, Height = {Height}");
                for (float x = startX; x < endX; x+= SquareSizeInPixels.Width)
                {
                    g.DrawLine(LinePen, x, 0, x + (float)Math.Tan(30 * Math.PI / 180) * Height, Height);
                    g.DrawLine(LinePen, x, 0, x - (float)Math.Tan(30 * Math.PI / 180) * Height, Height);
                }
            }
        }
        private void DrawSquares(Graphics g, SizeF LineSizeInPixels, SizeF SquareSizeInPixels)
        {
            if (Details != null)
            {
                using Pen LinePen = new Pen ( Details.LineColor ?? Color.Black, LineSizeInPixels.Width);
                float x = 0F;
                float y = 0F;

                // draw vertical lines
                do
                {
                    g.DrawLine(LinePen, x, 0, x, Height);
                    x += SquareSizeInPixels.Width;
                } while (x < Width);

                // draw horizontal lines
                do
                {
                    g.DrawLine(LinePen, 0, y, Width, y);
                    y += SquareSizeInPixels.Height;
                } while (y < Height);
            }
        }

        private void DrawHexagons(Graphics g, SizeF LineSizeInPixels, SizeF SquareSizeInPixels)
        {
            // create the hexagon with a vertex at the top center
            List<PointF> points = new List<PointF>();
            Single angle = 2F * (float)(Math.PI / 6!);
            for (int i = 0; i < 6; i++)
            {
                points.Add(new PointF(
                    SquareSizeInPixels.Width / 2F * (float)Math.Sin(i * angle),
                    SquareSizeInPixels.Width / 2F * (float)Math.Cos(i * angle)
                    ));
            }
            points.Add(points[0]);

            // create the hexagon with two vertices in the corners at the top
            using GraphicsPath gpOddRows = new GraphicsPath();
            gpOddRows.AddPolygon(points.ToArray());

            Matrix? m = new Matrix();
            m.RotateAt(30F, PointF.Empty);
            gpOddRows.Transform(m);
            m.Dispose();
            m = null;

            // after rotation shift hex to the right by the amount where it will lock into the honeycomb
            m = new Matrix();
            m.Translate(
                LineSizeInPixels.Width / 2 - gpOddRows.PathPoints.Min(p => p.X),
                LineSizeInPixels.Height / 2 - gpOddRows.PathPoints.Min(p => p.Y)
                );
            gpOddRows.Transform(m);
            m.Dispose();
            m = null;

            // find the points that define the dimensions
            PointF p0;      // upper left vertex
            PointF p1;      // upper right vertex
            PointF p2;      // rightmost vertex
            PointF p3;      // lower right vertex
            PointF p4;      // lower left vertex
            PointF p5;      // leftmost vertex

            var pts = gpOddRows.PathPoints.OrderBy(p => Math.Round(p.Y, 2)).ThenBy(p => Math.Round(p.X, 2));
            p0 = pts.First();
            p1 = pts.Skip(1).First();
            pts = gpOddRows.PathPoints.OrderBy(p => Math.Round(p.X, 2));
            p2 = pts.Last();
            p5 = pts.First();
            pts = gpOddRows.PathPoints.OrderByDescending(p => Math.Round(p.Y, 2)).ThenBy(p => Math.Round(p.X, 2));
            p3 = pts.Skip(1).First();
            p4 = pts.First();

            float FullWidth = p2.X - p5.X;
            float PartialWidth = p1.X - p0.X;
            float OnThirdWidth = p0.X - p5.X;
            float TwoThirdsWidth = p2.X - p0.X;
            float FullHeight = p3.Y - p0.Y;
            float PartialHeight = FullHeight / 2;

            using GraphicsPath gpEvenRows = (GraphicsPath)gpOddRows.Clone();
            m = new Matrix();
            m.Translate(gpEvenRows.PathPoints[1].X - gpEvenRows.PathPoints[5].X, gpEvenRows.PathPoints[2].Y - gpEvenRows.PathPoints[3].Y);
            gpEvenRows.Transform(m);
            m.Dispose();
            m = null;

            // offsets
            using Matrix mMoveRight = new Matrix();
            mMoveRight.Translate(gpOddRows.PathPoints[3].X - gpOddRows.PathPoints[4].X + SquareSizeInPixels.Width, 0);
            using Matrix mMoveDown = new Matrix();
            mMoveDown.Translate(0, gpOddRows.PathPoints[1].Y - gpOddRows.PathPoints[3].Y);

            using Pen LinePen = new Pen(Details.LineColor ?? Color.Black, LineSizeInPixels.Width);
            GraphicsPath gpThisOddRow;
            GraphicsPath gpThisEvenRow;
            // draw rows of staggered hexes
            do
            {
                gpThisOddRow = (GraphicsPath)gpOddRows.Clone();
                do
                {
                    g.DrawPath(LinePen, gpThisOddRow);
                    gpThisOddRow.Transform(mMoveRight);
                } while (gpThisOddRow.PathPoints[4].X < Width);
                gpOddRows.Transform(mMoveDown);
                gpThisOddRow.Dispose();
                gpThisOddRow = null;

                gpThisEvenRow = (GraphicsPath)gpEvenRows.Clone();
                do
                {
                    g.DrawPath(LinePen, gpThisEvenRow);
                    gpThisEvenRow.Transform(mMoveRight);
                } while (gpThisEvenRow.PathPoints[4].X < Width);
                gpEvenRows.Transform(mMoveDown);
                gpThisEvenRow.Dispose();
                gpThisEvenRow = null;
            } while (gpOddRows.PathPoints[0].Y < Height);
        }
    }
}
