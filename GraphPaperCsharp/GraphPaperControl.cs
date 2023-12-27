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
            DoubleBuffered = true;
        }
        public GraphPaper? Details;

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

            switch (Details.Shape)
            {
                case GraphPaper.Shapes.Triangles:
                case GraphPaper.Shapes.Diamonds:
                    DrawTrianglesOrDiamonds(e.Graphics, LineSizeInPixels, SquareSizeInPixels, ClientRectangle);
                    break;
                case GraphPaper.Shapes.Squares:
                    DrawSquares(e.Graphics, LineSizeInPixels, SquareSizeInPixels, ClientRectangle);
                    break;
                case GraphPaper.Shapes.Hexagons:
                    DrawHexagons(e.Graphics, LineSizeInPixels, SquareSizeInPixels, ClientRectangle);
                    break;
            }
        }

        private void DrawTrianglesOrDiamonds(Graphics g, SizeF LineSizeInPixels, SizeF ShapeSizeInPixels, RectangleF SurfaceArea)
        {
            if (Details != null)
            {
                using Pen LinePen = new Pen(Details.LineColor ?? Color.Black, LineSizeInPixels.Width);
                if (Details.Shape == GraphPaper.Shapes.Triangles)
                {
                    // horizontal lines
                    float y = LineSizeInPixels.Height / 2F;
                    float dy = ShapeSizeInPixels.Height / 2F * (float)Math.Sqrt(3);
                    if (Details.Shape == GraphPaper.Shapes.Triangles)
                    {
                        do
                        {
                            g.DrawLine(LinePen, SurfaceArea.Left, y, SurfaceArea.Right, y);
                            y += dy;
                        } while (y < SurfaceArea.Height);  //Height);
                    }
                }

                // diagonmal lines
                float dx = (float)Math.Tan(30 * Math.PI / 180) * SurfaceArea.Height;
                float xyz = (float)Math.Round(dx / ShapeSizeInPixels.Width, 0); // ensure the first vertical stroke
                float startX = -xyz * ShapeSizeInPixels.Width;                  // starts at the same location regardless of height
                float endX = SurfaceArea.Width + dx; 
                for (float x = startX; x < endX; x += ShapeSizeInPixels.Width)
                {
                    g.DrawLine(LinePen, x, SurfaceArea.Top, x + dx, SurfaceArea.Height);
                    g.DrawLine(LinePen, x, SurfaceArea.Top, x - dx, SurfaceArea.Height);
                }
            }
        }
        private void DrawSquares(Graphics g, SizeF LineSizeInPixels, SizeF SquareSizeInPixels, RectangleF SurfaceArea)
        {
            if (Details != null)
            {
                using Pen LinePen = new Pen(Details.LineColor ?? Color.Black, LineSizeInPixels.Width);
                float x = SurfaceArea.Left;    // 0F;
                float y = SurfaceArea.Top;

                // draw vertical lines
                do
                {
                    g.DrawLine(LinePen, x, SurfaceArea.Top, x, SurfaceArea.Bottom);
                    x += SquareSizeInPixels.Width;
                } while (x < SurfaceArea.Right);

                // draw horizontal lines
                do
                {
                    g.DrawLine(LinePen, SurfaceArea.Left, y, SurfaceArea.Right, y);
                    y += SquareSizeInPixels.Height;
                } while (y < SurfaceArea.Bottom);   // Height);
            }
        }
        private void DrawHexagons(Graphics g, SizeF LineSizeInPixels, SizeF HexagonSizeInPixels, RectangleF SurfaceArea)
        {
            // create the hexagon with a vertex at the top center
            List<PointF> points = new List<PointF>();
            Single angle = 2F * (float)(Math.PI / 6!);
            for (int i = 0; i < 6; i++)
            {
                points.Add(new PointF(
                    HexagonSizeInPixels.Width / 2F * (float)Math.Sin(i * angle),
                    HexagonSizeInPixels.Width / 2F * (float)Math.Cos(i * angle)
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

            // shift both hexes to fit inside the margins
            m = new Matrix();
            m.Translate(SurfaceArea.Left, SurfaceArea.Top);
            gpEvenRows.Transform(m);
            gpOddRows.Transform(m);
            m.Dispose();
            m = null;

            // offsets
            using Matrix mMoveRight = new Matrix();
            mMoveRight.Translate(gpOddRows.PathPoints[3].X - gpOddRows.PathPoints[4].X + HexagonSizeInPixels.Width, 0);
            using Matrix mMoveDown = new Matrix();
            mMoveDown.Translate(0, gpOddRows.PathPoints[1].Y - gpOddRows.PathPoints[3].Y);

            using Pen LinePen = new Pen(Details?.LineColor ?? Color.Black, LineSizeInPixels.Width);
            GraphicsPath? gpThisOddRow;
            GraphicsPath? gpThisEvenRow;
            // draw rows of staggered hexes
            do
            {
                gpThisOddRow = (GraphicsPath)gpOddRows.Clone();
                do
                {
                    g.DrawPath(LinePen, gpThisOddRow);
                    gpThisOddRow.Transform(mMoveRight);
                } while (gpThisOddRow.PathPoints[4].X < SurfaceArea.Right);     // Width);
                gpOddRows.Transform(mMoveDown);
                gpThisOddRow.Dispose();
                gpThisOddRow = null;

                gpThisEvenRow = (GraphicsPath)gpEvenRows.Clone();
                do
                {
                    g.DrawPath(LinePen, gpThisEvenRow);
                    gpThisEvenRow.Transform(mMoveRight);
                } while (gpThisEvenRow.PathPoints[4].X < SurfaceArea.Right);    // Width);
                gpEvenRows.Transform(mMoveDown);
                gpThisEvenRow.Dispose();
                gpThisEvenRow = null;
            } while (gpOddRows.PathPoints[0].Y < SurfaceArea.Bottom);   // Height);
        }

        public void PrintWithDialog()
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (Details == null)
                return;

            float DpmmX = e.Graphics.DpiX / 25.4F;
            float DpmmY = e.Graphics.DpiY / 25.4F;
            SizeF LineSizeInPixels = SizeF.Empty;
            SizeF SquareSizeInPixels = SizeF.Empty;
            Rectangle Margins = Globals.UsePrintMargins ? e.MarginBounds : e.PageBounds;
            Margins = e.PageBounds;
            RectangleF PrintArea = new RectangleF(e.Graphics.DpiX * Margins.Left / 100F, e.Graphics.DpiY * Margins.Top / 100F,                e.Graphics.DpiX * Margins.Width / 100F,                e.Graphics.DpiY * Margins.Height / 100F);

            if (Details.LineWidthUnits == GraphPaper.Units.Inches)
            {
                LineSizeInPixels = new SizeF(e.Graphics.DpiX * Details.LineWidth, e.Graphics.DpiY * Details.LineWidth);
            }
            else if (Details.LineWidthUnits == GraphPaper.Units.Millimeters)
            {
                LineSizeInPixels = new SizeF(DpmmX * Details.LineWidth, DpmmY * Details.LineWidth);
            }
            if (Details.ShapeWidthUnits == GraphPaper.Units.Inches)
            {
                SquareSizeInPixels = new SizeF(e.Graphics.DpiX * Details.ShapeWidth, e.Graphics.DpiY * Details.ShapeWidth);
            }
            else if (Details.ShapeWidthUnits == GraphPaper.Units.Millimeters)
            {
                SquareSizeInPixels = new SizeF(DpmmX * Details.ShapeWidth, DpmmY * Details.ShapeWidth);
            }

            GraphicsState gs = e.Graphics.Save();
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PageUnit = GraphicsUnit.Pixel;
            switch (Details.Shape)
            {
                case GraphPaper.Shapes.Triangles:
                case GraphPaper.Shapes.Diamonds:
                    DrawTrianglesOrDiamonds(e.Graphics, LineSizeInPixels, SquareSizeInPixels, PrintArea);
                    break;
                case GraphPaper.Shapes.Squares:
                    DrawSquares(e.Graphics, LineSizeInPixels, SquareSizeInPixels, PrintArea);
                    break;
                case GraphPaper.Shapes.Hexagons:
                    DrawHexagons(e.Graphics, LineSizeInPixels, SquareSizeInPixels, PrintArea);
                    break;
            }
            e.Graphics.Restore(gs);
        }

        private void printDocument1_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
        }
    }
}
