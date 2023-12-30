Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing

Public Class GraphPaperControl
    Public Sub New()
        InitializeComponent()
        DoubleBuffered = True
    End Sub
    Private Sub DetailsChanged()
        Invalidate()
    End Sub
    Public Details As GraphPaper    ' = New GraphPaper

    Private Sub GraphPaperControl_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        If Details Is Nothing Then
            Return
        End If
        Dim gs = e.Graphics.Save
        e.Graphics.CompositingQuality = CompositingQuality.HighQuality
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        e.Graphics.PageUnit = GraphicsUnit.Point        ' working with e.graphics.Dpi, but the UserControl Me.Size is incorrect

        Dim DpmmX = e.Graphics.DpiX / 25.4!
        Dim DpmmY = e.Graphics.DpiY / 25.4!
        Dim LineSizeInPixels As SizeF
        Dim ShapeSizeInPixels As SizeF

        If Details.LineWidthUnits = GraphPaper.Units.Inches Then
            LineSizeInPixels = New SizeF(e.Graphics.DpiX * Details.LineWidth, e.Graphics.DpiY * Details.LineWidth)
        ElseIf Details.LineWidthUnits = GraphPaper.Units.Millimeters Then
            LineSizeInPixels = New SizeF(DpmmX * Details.LineWidth, DpmmY * Details.LineWidth)
        End If

        If Details.ShapeWidthUnits = GraphPaper.Units.Inches Then
            ShapeSizeInPixels = New SizeF(e.Graphics.DpiX * Details.ShapeWidth, e.Graphics.DpiY * Details.ShapeWidth)
        ElseIf Details.ShapeWidthUnits = GraphPaper.Units.Millimeters Then
            ShapeSizeInPixels = New SizeF(DpmmX * Details.ShapeWidth, DpmmY * Details.ShapeWidth)
        End If

        Select Case Details.Shape
            Case GraphPaper.Shapes.Circles
                DrawCircles(e.Graphics, LineSizeInPixels, ShapeSizeInPixels, ClientRectangle)
            Case GraphPaper.Shapes.Triangles, GraphPaper.Shapes.Diamonds
                DrawTrianglesOrDiamonds(e.Graphics, LineSizeInPixels, ShapeSizeInPixels, ClientRectangle)
            Case GraphPaper.Shapes.Squares
                DrawSquares(e.Graphics, LineSizeInPixels, ShapeSizeInPixels, ClientRectangle)
            Case GraphPaper.Shapes.Hexagons
                DrawHexagons(e.Graphics, LineSizeInPixels, ShapeSizeInPixels, ClientRectangle)
        End Select
    End Sub

    Private Sub DrawCircles(g As Graphics, LineSizeInPixels As SizeF, CircleSizeInPixels As SizeF, SurfaceArea As RectangleF)
        Using LinePen = New Pen(Details.LineColor, LineSizeInPixels.Width)
            Dim r As RectangleF = New RectangleF(SurfaceArea.Location, CircleSizeInPixels)
            Do
                Do
                    g.DrawEllipse(LinePen, r)
                    r.Offset(CircleSizeInPixels.Width, 0)
                Loop While (r.Left < SurfaceArea.Right)
                r = New RectangleF(SurfaceArea.Left, r.Bottom, CircleSizeInPixels.Width, CircleSizeInPixels.Height)
            Loop While (r.Top < SurfaceArea.Bottom)
        End Using
    End Sub
    Private Sub DrawTrianglesOrDiamonds(g As Graphics, LineSizeInPixels As SizeF, ShapeSizeInPixels As SizeF, SurfaceArea As RectangleF)
        Dim LinePen As Pen = New Pen(Details.LineColor, LineSizeInPixels.Width)
        Try
            If Details.Shape = GraphPaper.Shapes.Triangles Then
                ' horizontal lines
                Dim y As Single = LineSizeInPixels.Height / 2.0!
                Dim dy As Single = ShapeSizeInPixels.Height / 2.0! * Math.Sqrt(3)
                Do
                    g.DrawLine(LinePen, SurfaceArea.Left, y, SurfaceArea.Right, y)
                    y += dy
                Loop While (y < SurfaceArea.Height)
            End If

            ' diagonal lines
            Dim dx As Single = Math.Tan(30 * Math.PI / 180) * SurfaceArea.Height
            Dim xyz As Single = Math.Round(dx / ShapeSizeInPixels.Width, 0) ' ensure the first vertical stroke
            Dim startx As Single = -xyz * ShapeSizeInPixels.Width           ' starts at the same location regardless of height
            Dim endx = SurfaceArea.Width + dx
            Dim x As Single = startx
            While x < endx
                g.DrawLine(LinePen, x, SurfaceArea.Top, x + dx, SurfaceArea.Height)
                g.DrawLine(LinePen, x, SurfaceArea.Top, x - dx, SurfaceArea.Height)
                x += ShapeSizeInPixels.Width
            End While
        Catch e As Exception
        Finally
            LinePen.Dispose()
            LinePen = Nothing
        End Try
    End Sub
    Private Sub DrawSquares(g As Graphics, LineSizeInPixels As SizeF, SquareSizeInPixels As SizeF, SurfaceArea As RectangleF)
        Dim LinePen = New Pen(Details.LineColor, LineSizeInPixels.Width)
        Try
            Dim x As Single = SurfaceArea.Left
            Dim y As Single = SurfaceArea.Top

            ' draw vertical lines
            Do
                g.DrawLine(LinePen, x, SurfaceArea.Top, x, SurfaceArea.Bottom)
                x += SquareSizeInPixels.Width
            Loop While x < SurfaceArea.Right

            ' draw horizontal lines
            Do
                g.DrawLine(LinePen, SurfaceArea.Left, y, SurfaceArea.Right, y)
                y += SquareSizeInPixels.Height
            Loop While y < SurfaceArea.Bottom
        Catch ex As Exception
        Finally
            LinePen.Dispose()
            LinePen = Nothing
        End Try
    End Sub
    Private Sub DrawHexagons(g As Graphics, LineSizeInPixels As SizeF, HexagonSizeInPixels As SizeF, SurfaceArea As RectangleF)
        ' create a hexagon with a vertex at top center
        Dim points As List(Of PointF) = New List(Of PointF)
        Dim angle As Single = 2.0! * Math.PI / 6.0!
        For i As Integer = 0 To 5
            points.Add(New PointF(
                       HexagonSizeInPixels.Width / 2.0! * Math.Sin(i * angle),
                       HexagonSizeInPixels.Width / 2.0! * Math.Cos(i * angle)
                       ))
        Next
        points.Add(points(0))

        ' create the hexagon with two vertices in the corners at the top
        Dim gpOddRows As GraphicsPath = New GraphicsPath()
        gpOddRows.AddPolygon(points.ToArray())

        Dim m As Matrix = New Matrix()
        m.RotateAt(30, PointF.Empty)
        gpOddRows.Transform(m)
        m.Dispose()
        m = Nothing

        ' after rotation, shift hex to the right by the amount where it will lock into the honeycomb
        m = New Matrix()
        m.Translate(
            LineSizeInPixels.Width / 2 - gpOddRows.PathPoints.Min(Function(p) p.X),
            LineSizeInPixels.Height / 2 - gpOddRows.PathPoints.Min(Function(p) p.Y)
            )
        gpOddRows.Transform(m)
        m.Dispose()
        m = Nothing

        ' find the points that define the dimensions
        Dim p0 As PointF    ' upper left vertex
        Dim p1 As PointF    ' upper right vertex
        Dim p2 As PointF    ' rightmost vertex
        Dim p3 As PointF    ' lower right vertex
        Dim p4 As PointF    ' lower left vertex
        Dim p5 As PointF    ' leftmost vertex

        Dim pts = gpOddRows.PathPoints.OrderBy(Function(p) Math.Round(p.Y, 2)).ThenBy(Function(p) Math.Round(p.X, 2))
        p0 = pts.First()
        p1 = pts.Skip(1).First()
        pts = gpOddRows.PathPoints.OrderBy(Function(p) Math.Round(p.X, 2))
        p2 = pts.Last
        p5 = pts.First()
        pts = gpOddRows.PathPoints.OrderByDescending(Function(p) Math.Round(p.Y, 2)).ThenBy(Function(p) Math.Round(p.X, 2))
        p3 = pts.Skip(1).First
        p4 = pts.First()

        Dim FullWidth As Single = p2.X - p5.X
        Dim PartialWidth As Single = p1.X - p0.X
        Dim OnThirdWidth As Single = p0.X - p5.X
        Dim TwoThirdsWidth As Single = p2.X - p0.X
        Dim FullHeight As Single = p3.Y - p0.Y
        Dim PartialHeight As Single = FullHeight / 2

        Dim gpEvenRows As GraphicsPath = gpOddRows.Clone()
        m = New Matrix
        m.Translate(gpEvenRows.PathPoints(1).X - gpEvenRows.PathPoints(5).X, gpEvenRows.PathPoints(2).Y - gpEvenRows.PathPoints(3).Y)
        gpEvenRows.Transform(m)
        m.Dispose()
        m = Nothing

        ' shift both hexes to fit inside the margins
        m = New Matrix()
        m.Translate(SurfaceArea.Left, SurfaceArea.Top)
        gpEvenRows.Transform(m)
        gpOddRows.Transform(m)
        m.Dispose()
        m = Nothing

        ' offsets
        Dim mMoveRight As Matrix = New Matrix()
        mMoveRight.Translate(gpOddRows.PathPoints(3).X - gpOddRows.PathPoints(4).X + HexagonSizeInPixels.Width, 0)
        Dim mMoveDown As Matrix = New Matrix()
        mMoveDown.Translate(0, gpOddRows.PathPoints(1).Y - gpOddRows.PathPoints(3).Y)

        Using LinePen As Pen = New Pen(Details.LineColor, LineSizeInPixels.Width)
            Dim gpThisOddRow As GraphicsPath
            Dim gpThisEvenRow As GraphicsPath
            ' draw rows of staggered hexes
            Do
                gpThisOddRow = gpOddRows.Clone()
                Do
                    g.DrawPath(LinePen, gpThisOddRow)
                    gpThisOddRow.Transform(mMoveRight)
                Loop While (gpThisOddRow.PathPoints(4).X < SurfaceArea.Right)
                gpOddRows.Transform(mMoveDown)
                gpThisOddRow.Dispose()
                gpThisOddRow = Nothing

                gpThisEvenRow = gpEvenRows.Clone()
                Do
                    g.DrawPath(LinePen, gpThisEvenRow)
                    gpThisEvenRow.Transform(mMoveRight)
                Loop While (gpThisEvenRow.PathPoints(4).X < SurfaceArea.Right)
                gpEvenRows.Transform(mMoveDown)
                gpThisEvenRow.Dispose()
                gpThisEvenRow = Nothing
            Loop While gpOddRows.PathPoints(0).Y < SurfaceArea.Bottom
        End Using

        mMoveRight.Dispose()
        mMoveRight = Nothing
        mMoveDown.Dispose()
        mMoveDown = Nothing
        gpEvenRows.Dispose()
        gpEvenRows = Nothing
        gpOddRows.Dispose()
        gpOddRows = Nothing
    End Sub

    Public Sub PrintWithDialog()
        If PrintDialog1.ShowDialog() = DialogResult.OK Then
            PrintDocument1.Print()
        End If
    End Sub

    Public Sub DoPageSetup()
        PageSetupDialog1.ShowDialog()
    End Sub

    Public Sub BeginPrint(sender As Object, e As PrintEventArgs) Handles PrintDocument1.BeginPrint
    End Sub

    Public Sub Print(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim DpmmX As Single = e.Graphics.DpiX / 25.4!
        Dim DpmmY As Single = e.Graphics.DpiY / 25.4!
        Dim LineSizeInPixels As SizeF
        Dim ShapeSizeInPixels As SizeF
        Dim Margins As Rectangle = IIf(Globals.UsePrintMargins, e.MarginBounds, e.PageBounds)
        Dim PrintArea As RectangleF = New RectangleF(e.Graphics.DpiX * Margins.Left / 100, e.Graphics.DpiY * Margins.Top / 100, e.Graphics.DpiX * Margins.Width / 100, e.Graphics.DpiY * Margins.Height / 100)

        If Details.LineWidthUnits = GraphPaper.Units.Inches Then
            LineSizeInPixels = New SizeF(e.Graphics.DpiX * Details.LineWidth, e.Graphics.DpiY * Details.LineWidth)
        ElseIf Details.LineWidthUnits = GraphPaper.Units.Millimeters Then
            LineSizeInPixels = New SizeF(DpmmX * Details.LineWidth, DpmmY * Details.LineWidth)
        End If
        If Details.ShapeWidthUnits = GraphPaper.Units.Inches Then
            ShapeSizeInPixels = New SizeF(e.Graphics.DpiX * Details.ShapeWidth, e.Graphics.DpiY * Details.ShapeWidth)
        ElseIf Details.ShapeWidthUnits = GraphPaper.Units.Millimeters Then
            ShapeSizeInPixels = New SizeF(DpmmX * Details.ShapeWidth, DpmmY * Details.ShapeWidth)
        End If

        Dim gs As GraphicsState = e.Graphics.Save
        e.Graphics.CompositingQuality = CompositingQuality.HighQuality
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        e.Graphics.PageUnit = GraphicsUnit.Pixel

        Select Case Details.Shape
            Case GraphPaper.Shapes.Circles
                DrawCircles(e.Graphics, LineSizeInPixels, ShapeSizeInPixels, PrintArea)
            Case GraphPaper.Shapes.Triangles, GraphPaper.Shapes.Diamonds
                DrawTrianglesOrDiamonds(e.Graphics, LineSizeInPixels, ShapeSizeInPixels, PrintArea)
            Case GraphPaper.Shapes.Squares
                DrawSquares(e.Graphics, LineSizeInPixels, ShapeSizeInPixels, PrintArea)
            Case GraphPaper.Shapes.Hexagons
                DrawHexagons(e.Graphics, LineSizeInPixels, ShapeSizeInPixels, PrintArea)
        End Select
        e.Graphics.Restore(gs)
        e.HasMorePages = False
    End Sub

    Public Sub EndPrint(sender As Object, e As EventArgs)
    End Sub

End Class
