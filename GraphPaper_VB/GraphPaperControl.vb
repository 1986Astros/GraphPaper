Imports System.Drawing.Printing

Public Class GraphPaperControl
    Public Sub New()
        InitializeComponent()

        'Details = New GraphPaper
        'AddHandler Details.PropertyChanged, AddressOf DetailsChanged
    End Sub
    Private Sub DetailsChanged()
        Invalidate()
    End Sub
    Public Details As GraphPaper    ' = New GraphPaper

    Private Sub GraphPaperControl_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        If Details Is Nothing Then
            Return
        End If
        Dim gs As Drawing2D.GraphicsState = e.Graphics.Save
        Try
            e.Graphics.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
            e.Graphics.PageUnit = GraphicsUnit.Point        ' working with e.graphics.Dpi, but the UserControl Me.Size is incorrect

            Dim DpmmX As Single = e.Graphics.DpiX / 25.4!
            Dim DpmmY As Single = e.Graphics.DpiY / 25.41
            Dim LineSizeInPixels As SizeF
            Dim SquareSizeInPixels As SizeF

            If Details.LineWidthUnits = GraphPaper.Units.Inches Then
                LineSizeInPixels = New SizeF(e.Graphics.DpiX * Details.LineWidth, e.Graphics.DpiY * Details.LineWidth)
            ElseIf Details.LineWidthUnits = GraphPaper.Units.Millimeters Then
                LineSizeInPixels = New SizeF(DpmmX * Details.LineWidth, DpmmY * Details.LineWidth)
            End If

            If Details.ShapeWidthUnits = GraphPaper.Units.Inches Then
                SquareSizeInPixels = New SizeF(e.Graphics.DpiX * Details.ShapeWidth, e.Graphics.DpiY * Details.ShapeWidth)
            ElseIf Details.ShapeWidthUnits = GraphPaper.Units.Millimeters Then
                SquareSizeInPixels = New SizeF(DpmmX * Details.ShapeWidth, DpmmY * Details.ShapeWidth)
            End If

            Dim gs2 As Drawing2D.GraphicsState = e.Graphics.Save
            Try
                e.Graphics.PageUnit = GraphicsUnit.Pixel
                Dim NewSize As Size
                Dim LineSizeInPixels2 As SizeF
                Dim SquareSizeInPixels2 As SizeF

                If Details.LineWidthUnits = GraphPaper.Units.Inches Then
                    LineSizeInPixels2 = New SizeF(128.0! * Details.LineWidth, 128.0! * Details.LineWidth)
                ElseIf Details.LineWidthUnits = GraphPaper.Units.Millimeters Then
                    LineSizeInPixels2 = New SizeF(128.0! / 25.4! * Details.LineWidth, 128.0! / 25.4! * Details.LineWidth)
                End If
                If Details.ShapeWidthUnits = GraphPaper.Units.Inches Then
                    SquareSizeInPixels2 = New SizeF(128.0! * Details.ShapeWidth, 128.0! * Details.ShapeWidth)
                ElseIf Details.ShapeWidthUnits = GraphPaper.Units.Millimeters Then
                    SquareSizeInPixels2 = New SizeF(128.0! / 25.4! * Details.ShapeWidth, 128.0! / 25.4! * Details.ShapeWidth)
                End If
                Select Case Details.Shape
                    Case GraphPaper.Shapes.Triangles, GraphPaper.Shapes.Diamonds
                        NewSize = New Size(CInt(Math.Ceiling(LineSizeInPixels2.Width + 10.0! * SquareSizeInPixels2.Width)),
                                           CInt(Math.Ceiling(LineSizeInPixels2.Height + 10.0! * SquareSizeInPixels2.Height / 2.0! * CSng(Math.Sqrt(3)))))
                    Case GraphPaper.Shapes.Squares
                        NewSize = New Size(CInt(Math.Ceiling(LineSizeInPixels2.Width + 10.0! * SquareSizeInPixels2.Width)), CInt(Math.Ceiling(LineSizeInPixels2.Height + 10.0! * SquareSizeInPixels2.Height)))
                    Case GraphPaper.Shapes.Hexagons
                        Dim HexHeight As Single = SquareSizeInPixels2.Height * Math.Sin(Math.PI / 3.0!)
                        NewSize = New Size(CInt(Math.Ceiling(LineSizeInPixels2.Width + (15.0! + 15.0! * Math.PI / 180.0!) * SquareSizeInPixels2.Width)), CInt(Math.Ceiling(LineSizeInPixels2.Height + 10.5! * HexHeight)))
                End Select
                Select Case Me.BorderStyle
                    Case BorderStyle.None
                    Case BorderStyle.FixedSingle
                        NewSize.Width += SystemInformation.BorderSize.Width + 1
                        NewSize.Height += SystemInformation.BorderSize.Height + 1
                    Case BorderStyle.Fixed3D
                        NewSize.Width += SystemInformation.Border3DSize.Width + 1
                        NewSize.Height += SystemInformation.Border3DSize.Height + 1
                End Select

                If Not Me.Size.Equals(NewSize) Then
                    Me.Size = NewSize
                End If
            Catch ex2 As Exception
            Finally
                e.Graphics.Restore(gs2)
            End Try

            Select Case Details.Shape
                Case GraphPaper.Shapes.Triangles, GraphPaper.Shapes.Diamonds
                    Using LinePen As Pen = New Pen(Details.LineColor, LineSizeInPixels.Width)
                        Dim y As Single = LineSizeInPixels.Height / 2.0!
                        Dim dy As Single = SquareSizeInPixels.Height / 2.0! * CSng(Math.Sqrt(3))
                        If Details.Shape = GraphPaper.Shapes.Triangles Then
                            ' horizontal lines
                            For row As Integer = 1 To 11
                                If (row Mod 2) = 0 Then
                                    e.Graphics.DrawLine(LinePen, SquareSizeInPixels.Width / 2.0!, y, 9.5! * SquareSizeInPixels.Width + LineSizeInPixels.Width / 2.0!, y)
                                Else
                                    e.Graphics.DrawLine(LinePen, 0, y, 10.0! * SquareSizeInPixels.Width + LineSizeInPixels.Width / 2.0!, y)
                                End If
                                y += dy
                            Next
                        End If
                        ' diagonal lines starting at top
                        dy *= 2
                        Dim x As Single = 0!    ' LineSizeInPixels.Width / 2.0!
                        Dim dx As Single = SquareSizeInPixels.Width / 2.0! * CSng(Math.Sqrt(3))
                        For col As Integer = 1 To 10
                            ' left-to-right
                            e.Graphics.DrawLine(LinePen,
                                                x,
                                                LineSizeInPixels.Height / 2.0!,
                                                Math.Min(10.0!, CSng(col + 4)) * SquareSizeInPixels.Width,
                                                IIf(col <= 5, 5.0!, CSng(11 - col)) * dy)
                            x += SquareSizeInPixels.Width
                            ' right-to-left
                            If col < 6 Then
                                e.Graphics.DrawLine(LinePen,
                                                x,
                                                LineSizeInPixels.Height / 2.0!,
                                                LineSizeInPixels.Width / 2,
                                                Math.Min(CSng(col), 5.5!) * dy)
                            Else
                                e.Graphics.DrawLine(LinePen,
                                                    x + LineSizeInPixels.Width / 2.0!,
                                                    LineSizeInPixels.Height / 2.0!,
                                                    (CSng(col) - 5.0!) * SquareSizeInPixels.Width + LineSizeInPixels.Width / 2.0!,
                                                    5.0! * dy)
                            End If
                        Next
                        ' diagonal lines starting from left and right endpoints of each row
                        y = LineSizeInPixels.Height / 2.0!
                        For row As Integer = 2 To 8 Step 2
                            y += dy
                            e.Graphics.DrawLine(LinePen,
                                                LineSizeInPixels.Width / 2.0!,
                                                y,
                                                CSng(10 - row) / 2.0! * SquareSizeInPixels.Width + LineSizeInPixels.Width / 2.0!,
                                                y + CSng(10 - row) / 2.0! * dy)
                            e.Graphics.DrawLine(LinePen,
                                                10.0! * SquareSizeInPixels.Width,
                                                y,
                                                CSng(row + 10) / 2.0! * SquareSizeInPixels.Width + LineSizeInPixels.Width / 2.0!,
                                                y + CSng(10 - row) / 2.0! * dy)
                        Next
                    End Using
                Case GraphPaper.Shapes.Squares
                    Using LinePen As Pen = New Pen(Details.LineColor, LineSizeInPixels.Width)
                        Dim x As Single = 0!
                        Dim y As Single = LineSizeInPixels.Height + 10.0! * SquareSizeInPixels.Height
                        For i As Integer = 1 To 11
                            e.Graphics.DrawLine(LinePen, x, 0!, x, y)
                            x += SquareSizeInPixels.Width
                        Next

                        x = LineSizeInPixels.Width + 10.0! * SquareSizeInPixels.Width
                        y = 0!
                        For i As Integer = 1 To 11
                            e.Graphics.DrawLine(LinePen, 0, y, x, y)
                            y += SquareSizeInPixels.Height
                        Next
                    End Using
                Case GraphPaper.Shapes.Hexagons
                    Dim points As List(Of PointF) = New List(Of PointF)
                    Dim angle As Single = 2.0! * Math.PI / 6.0!
                    For i As Single = 0! To 5.0!
                        points.Add(New PointF(SquareSizeInPixels.Width / 2.0! * Math.Sin(i * angle), SquareSizeInPixels.Width / 2.0! * Math.Cos(i * angle)))
                    Next
                    points.Add(points(0))

                    Using gpOddRows As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath
                        gpOddRows.AddPolygon(points.ToArray)

                        Using m As Drawing2D.Matrix = New Drawing2D.Matrix
                            m.RotateAt(30.0!, PointF.Empty)
                            gpOddRows.Transform(m)
                        End Using

                        Using mOffset As Drawing2D.Matrix = New Drawing2D.Matrix
                            mOffset.Translate(-gpOddRows.PathPoints.Min(Function(p) p.X) + LineSizeInPixels.Width / 2.0!, -gpOddRows.PathPoints.Min(Function(p) p.Y) + LineSizeInPixels.Width / 2.0!)
                            gpOddRows.Transform(mOffset)
                        End Using

                        Using gpEvenRows As Drawing2D.GraphicsPath = gpOddRows.Clone()
                            Using mEvenRows As Drawing2D.Matrix = New Drawing2D.Matrix
                                mEvenRows.Translate(gpEvenRows.PathPoints(1).X - gpEvenRows.PathPoints(5).X, gpEvenRows.PathPoints(2).Y - gpEvenRows.PathPoints(3).Y)
                                gpEvenRows.Transform(mEvenRows)
                            End Using

                            Using mMoveRight As Drawing2D.Matrix = New Drawing2D.Matrix
                                mMoveRight.Translate(gpOddRows.PathPoints(3).X - gpOddRows.PathPoints(4).X + SquareSizeInPixels.Width, 0!)

                                Using mMoveDown As Drawing2D.Matrix = New Drawing2D.Matrix
                                    mMoveDown.Translate(0!, gpOddRows.PathPoints(1).Y - gpOddRows.PathPoints(3).Y)

                                    Using LinePen As Pen = New Pen(Details.LineColor, LineSizeInPixels.Width)
                                        For xx As Integer = 1 To 10
                                            Using gpThisOddRow As Drawing2D.GraphicsPath = gpOddRows.Clone
                                                For i As Integer = 1 To 10
                                                    e.Graphics.DrawPath(LinePen, gpThisOddRow)
                                                    gpThisOddRow.Transform(mMoveRight)
                                                Next
                                            End Using
                                            gpOddRows.Transform(mMoveDown)

                                            Using gpThisEvenRow As Drawing2D.GraphicsPath = gpEvenRows.Clone
                                                For i As Integer = 1 To 10
                                                    e.Graphics.DrawPath(LinePen, gpThisEvenRow)
                                                    gpThisEvenRow.Transform(mMoveRight)
                                                Next
                                            End Using
                                            gpEvenRows.Transform(mMoveDown)
                                        Next
                                    End Using
                                End Using
                            End Using
                        End Using
                    End Using
            End Select
        Catch ex As Exception
            Debug.WriteLine(String.Format("Exception: {0}", ex.Message))
        Finally
            e.Graphics.Restore(gs)
        End Try
    End Sub

    Public Sub BeginPrint(e As PrintEventArgs)
    End Sub

    Public Sub Print(e As PrintPageEventArgs)
        Dim DpmmX As Single = e.Graphics.DpiX / 25.4!
        Dim DpmmY As Single = e.Graphics.DpiY / 25.4!
        Dim LineSizeInPixels As SizeF
        Dim SquareSizeInPixels As SizeF
        Dim Margins As Rectangle = IIf(Globals.UsePrintMargins, e.MarginBounds, e.PageBounds)
        Dim PrintArea As RectangleF = New RectangleF(e.Graphics.DpiX * Margins.Left / 100, e.Graphics.DpiY * Margins.Top / 100, e.Graphics.DpiX * Margins.Width / 100, e.Graphics.DpiY * Margins.Height / 100)

        If Details.LineWidthUnits = GraphPaper.Units.Inches Then
            LineSizeInPixels = New SizeF(e.Graphics.DpiX * Details.LineWidth, e.Graphics.DpiY * Details.LineWidth)
        ElseIf Details.LineWidthUnits = GraphPaper.Units.Millimeters Then
            LineSizeInPixels = New SizeF(DpmmX * Details.LineWidth, DpmmY * Details.LineWidth)
        End If
        If Details.ShapeWidthUnits = GraphPaper.Units.Inches Then
            SquareSizeInPixels = New SizeF(e.Graphics.DpiX * Details.ShapeWidth, e.Graphics.DpiY * Details.ShapeWidth)
        ElseIf Details.ShapeWidthUnits = GraphPaper.Units.Millimeters Then
            SquareSizeInPixels = New SizeF(DpmmX * Details.ShapeWidth, DpmmY * Details.ShapeWidth)
        End If

        Dim g As Graphics = e.Graphics
        Dim gs As Drawing2D.GraphicsState = g.Save
        Try
            g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
            g.PageUnit = GraphicsUnit.Pixel

            Select Case Details.Shape
                Case GraphPaper.Shapes.Triangles, GraphPaper.Shapes.Diamonds
                    Using LinePen As Pen = New Pen(Details.LineColor, LineSizeInPixels.Width)
                        Dim TrianglesPerRow As Integer = CInt(Math.Floor(PrintArea.Width / SquareSizeInPixels.Width))
                        Dim RowsPerPage As Integer = CInt(Math.Floor(PrintArea.Height / (SquareSizeInPixels.Height / 2.0! * CSng(Math.Sqrt(3)))))
                        Dim dy As Single = SquareSizeInPixels.Height / 2.0! * CSng(Math.Sqrt(3))
                        ' center rows and columns
                        PrintArea.Offset((PrintArea.Width - (CSng(TrianglesPerRow) * SquareSizeInPixels.Width) + LineSizeInPixels.Width) \ 2.0!, (PrintArea.Height - (CSng(RowsPerPage) * dy) + LineSizeInPixels.Height) / 2.0!)
                        Dim y As Single = PrintArea.Top + LineSizeInPixels.Height / 2.0!
                        If Details.Shape = GraphPaper.Shapes.Triangles Then
                            ' horizontal lines
                            For row As Integer = 1 To RowsPerPage + 1
                                If (row Mod 2) = 0 Then
                                    e.Graphics.DrawLine(LinePen, PrintArea.Left + SquareSizeInPixels.Width / 2.0!, y, PrintArea.Left + (CSng(TrianglesPerRow) - 0.5!) * SquareSizeInPixels.Width + LineSizeInPixels.Width / 2.0!, y)
                                Else
                                    e.Graphics.DrawLine(LinePen, PrintArea.Left, y, PrintArea.Left + CSng(TrianglesPerRow) * SquareSizeInPixels.Width + LineSizeInPixels.Width / 2.0!, y)
                                End If
                                y += dy
                            Next
                        End If
                        ' diagonal lines starting at top
                        dy *= 2
                        Dim x As Single = PrintArea.Left + LineSizeInPixels.Width / 2.0!
                        Dim dx As Single = SquareSizeInPixels.Width / 2.0! * CSng(Math.Sqrt(3))
                        Dim FullDiagonals As Single = CSng(TrianglesPerRow) - CSng(RowsPerPage) / 2.0!
                        For col As Integer = 0 To TrianglesPerRow - 1
                            ' left-to-right
                            If CSng(col) <= FullDiagonals Then
                                e.Graphics.DrawLine(LinePen,
                                                x,
                                                PrintArea.Top + LineSizeInPixels.Height / 2.0!,
                                                PrintArea.Left + LineSizeInPixels.Width / 2.0! + (CSng(RowsPerPage) / 2.0! + CSng(col)) * SquareSizeInPixels.Width,
                                                PrintArea.Top + LineSizeInPixels.Height / 2.0! + CSng(RowsPerPage) / 2.0! * dy)
                            Else
                                e.Graphics.DrawLine(LinePen,
                                                x,
                                                PrintArea.Top + LineSizeInPixels.Height / 2.0!,
                                                PrintArea.Left + LineSizeInPixels.Width / 2.0! + CSng(TrianglesPerRow) * SquareSizeInPixels.Width,
                                                PrintArea.Top + LineSizeInPixels.Height / 2.0! + (CSng(RowsPerPage) / 2.0! - CSng(col - FullDiagonals)) * dy)
                            End If
                            x += SquareSizeInPixels.Width
                            If True Then
                                ' right-to-left
                                If CSng(col) < CSng(TrianglesPerRow) - FullDiagonals - 0.5! Then
                                    e.Graphics.DrawLine(LinePen,
                                                        x,
                                                        PrintArea.Top + LineSizeInPixels.Height / 2.0!,
                                                        PrintArea.Left + LineSizeInPixels.Width / 2.0!,
                                                        PrintArea.Top + LineSizeInPixels.Height / 2.0! + ((CSng(col) + 1.0!) * dy))
                                Else
                                    e.Graphics.DrawLine(LinePen,
                                                    x - LineSizeInPixels.Width / 2.0!,
                                                    PrintArea.Top + LineSizeInPixels.Height / 2.0!,
                                                    PrintArea.Left + LineSizeInPixels.Width / 2.0! + (CSng(col + 1) - CSng(RowsPerPage) / 2.0!) * SquareSizeInPixels.Width,
                                                    PrintArea.Top + LineSizeInPixels.Height / 2.0! + CSng(RowsPerPage) / 2.0! * dy)
                                End If
                            End If
                        Next
                        ' diagonal lines starting from left and right endpoints of each row
                        y = PrintArea.Top + LineSizeInPixels.Height / 2.0!
                        For row As Integer = 2 To RowsPerPage - 1 Step 2
                            y += dy
                            e.Graphics.DrawLine(LinePen,
                                                    PrintArea.Left + LineSizeInPixels.Width / 2.0!,
                                                    y,
                                                    PrintArea.Left + LineSizeInPixels.Width / 2.0! + (CSng(RowsPerPage - row) / 2.0!) * SquareSizeInPixels.Width,
                                                    PrintArea.Top + LineSizeInPixels.Height / 2.0! + CSng(RowsPerPage) / 2.0! * dy)
                            e.Graphics.DrawLine(LinePen,
                                                    PrintArea.Left + LineSizeInPixels.Width / 2.0! + TrianglesPerRow * SquareSizeInPixels.Width,
                                                    y,
                                                    PrintArea.Left + LineSizeInPixels.Width / 2.0! + (CSng(TrianglesPerRow - CSng(RowsPerPage - row) / 2.0!)) * SquareSizeInPixels.Width,
                                                    PrintArea.Top + LineSizeInPixels.Height / 2.0! + CSng(RowsPerPage) / 2.0! * dy)
                        Next
                    End Using
                Case GraphPaper.Shapes.Squares
                    Dim SquaresPerColumn As Integer = CInt(Math.Ceiling((PrintArea.Width - LineSizeInPixels.Width) / SquareSizeInPixels.Width))
                    Dim SquaresPerRow As Integer = CInt(Math.Ceiling((PrintArea.Height - LineSizeInPixels.Height) / SquareSizeInPixels.Height))
                    PrintArea.Inflate(((LineSizeInPixels.Width + CSng(SquaresPerColumn) * SquareSizeInPixels.Width) - PrintArea.Width) / 2.0!,
                          ((LineSizeInPixels.Height + CSng(SquaresPerRow) * SquareSizeInPixels.Height) - PrintArea.Height) / 2.0!)

                    Using LinePen As Pen = New Pen(Details.LineColor, LineSizeInPixels.Width)
                        ' draw verticle lines
                        Dim x1 As Single = PrintArea.Left
                        Dim x2 As Single = PrintArea.Right
                        Dim y1 As Single = PrintArea.Top
                        Dim y2 As Single = PrintArea.Bottom
                        Do
                            e.Graphics.DrawLine(LinePen, x1, y1, x1, y2)
                            x1 += SquareSizeInPixels.Width
                        Loop While x1 <= x2

                        ' draw horizontal lines
                        x1 = PrintArea.Left
                        Do
                            e.Graphics.DrawLine(LinePen, x1, y1, x2, y1)
                            y1 += SquareSizeInPixels.Height
                        Loop While y1 <= y2
                    End Using
                    e.HasMorePages = False
                Case GraphPaper.Shapes.Hexagons
                    'g.DrawRectangle(Pens.Red, Rectangle.Round(PrintArea))

                    Dim points As List(Of PointF) = New List(Of PointF)
                    Dim angle As Single = 2.0! * Math.PI / 6.0!
                    For i As Single = 0! To 5.0!
                        points.Add(New PointF(SquareSizeInPixels.Width / 2.0! * Math.Sin(i * angle), SquareSizeInPixels.Width / 2.0! * Math.Cos(i * angle)))
                    Next
                    points.Add(points(0))

                    Using gpOddRows As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath
                        gpOddRows.AddPolygon(points.ToArray)

                        ' rotate so that there are two vertices at top
                        Using m As Drawing2D.Matrix = New Drawing2D.Matrix
                            m.RotateAt(30.0!, PointF.Empty)
                            gpOddRows.Transform(m)
                        End Using

                        ' set the origin
                        Using mOffset As Drawing2D.Matrix = New Drawing2D.Matrix
                            mOffset.Translate(CSng(PrintArea.Left) - gpOddRows.PathPoints.Min(Function(p) p.X) + LineSizeInPixels.Width / 2.0!, CSng(PrintArea.Top) - gpOddRows.PathPoints.Min(Function(p) p.Y) + LineSizeInPixels.Width / 2.0!)
                            gpOddRows.Transform(mOffset)
                        End Using

                        ' find the points that define the dimensions
                        Dim p0 As PointF    ' upper left corner
                        Dim p1 As PointF    ' upper right corner
                        Dim p2 As PointF    ' rightmost vertex
                        Dim p3 As PointF    ' lower right vertex
                        Dim p4 As PointF    ' lower left vertex
                        Dim p5 As PointF    ' leftmost vertex
                        With gpOddRows.PathPoints.OrderBy(Function(p) Math.Round(p.Y, 2)).ThenBy(Function(p) Math.Round(p.X, 2))
                            p0 = .First
                            p1 = .Skip(1).First
                        End With
                        With gpOddRows.PathPoints.OrderBy(Function(p) Math.Round(p.X, 2))
                            p2 = .Last
                            p5 = .First
                        End With
                        With gpOddRows.PathPoints.OrderByDescending(Function(p) Math.Round(p.Y, 2)).ThenBy(Function(p) Math.Round(p.X, 2))
                            p3 = .Skip(1).First
                            p4 = .First
                        End With
                        Dim FullWidth As Single = p2.X - p5.X
                        Dim PartialWidth As Single = p1.X - p0.X
                        Dim OneThirdWidth As Single = p0.X - p5.X
                        Dim TwoThirdsWidth As Single = p2.X - p0.X
                        Dim FullHeight As Single = p3.Y - p0.Y
                        Dim PartialHeight As Single = FullHeight / 2.0!
                        Dim HexesPerRow As Integer = CInt(Math.Floor(Math.Floor(PrintArea.Width - OneThirdWidth) / (FullWidth + PartialWidth + LineSizeInPixels.Width)))
                        Dim RowsPerPage As Integer = CInt(Math.Floor(Math.Floor(PrintArea.Height - PartialHeight) / FullHeight))
                        Dim HalfColumn As Boolean = False
                        Dim HalfRow As Boolean = False
                        Dim dx As Single = PrintArea.Width - CSng(HexesPerRow) * (FullWidth + PartialWidth + LineSizeInPixels.Width)
                        Dim dy As Single = PrintArea.Height - PartialHeight - CSng(RowsPerPage) * FullHeight - LineSizeInPixels.Height

                        If PrintArea.Width - CSng(HexesPerRow) * (FullWidth + PartialWidth + LineSizeInPixels.Width) >= TwoThirdsWidth Then
                            HalfColumn = True
                            dx -= PartialWidth       ' TwoThirdsWidth + LineSizeInPixels.Width
                            'Debug.WriteLine(String.Format("Half column, dx = {0}", dx))
                        End If
                        If PrintArea.Height - PartialHeight - CSng(RowsPerPage) * FullHeight >= PartialHeight Then
                            HalfRow = True
                            dy -= PartialHeight
                            'Debug.WriteLine(String.Format("Half row, dy = {0}", dy))
                        End If

                        ' center gpOddRows here in the area that will be printed
                        If dx > 0 OrElse dy > 0 Then
                            Using mOffset As Drawing2D.Matrix = New Drawing2D.Matrix
                                mOffset.Translate(dx / 2, dy / 2)
                                gpOddRows.Transform(mOffset)
                            End Using
                        End If

                        Using gpEvenRows As Drawing2D.GraphicsPath = gpOddRows.Clone()
                            Using mEvenRows As Drawing2D.Matrix = New Drawing2D.Matrix
                                mEvenRows.Translate(gpEvenRows.PathPoints(1).X - gpEvenRows.PathPoints(5).X, gpEvenRows.PathPoints(2).Y - gpEvenRows.PathPoints(3).Y)
                                gpEvenRows.Transform(mEvenRows)
                            End Using

                            Using mMoveRight As Drawing2D.Matrix = New Drawing2D.Matrix
                                mMoveRight.Translate(gpOddRows.PathPoints(3).X - gpOddRows.PathPoints(4).X + SquareSizeInPixels.Width, 0!)

                                Using mMoveDown As Drawing2D.Matrix = New Drawing2D.Matrix
                                    mMoveDown.Translate(0!, gpOddRows.PathPoints(1).Y - gpOddRows.PathPoints(3).Y)

                                    Using LinePen As Pen = New Pen(Details.LineColor, LineSizeInPixels.Width)
                                        ' draw a row of staggered hexes; it's actually two half rows but counts as one in nomenclature
                                        For xx As Integer = 1 To RowsPerPage
                                            Using gpThisOddRow As Drawing2D.GraphicsPath = gpOddRows.Clone
                                                For i As Integer = 1 To HexesPerRow
                                                    e.Graphics.DrawPath(LinePen, gpThisOddRow)
                                                    gpThisOddRow.Transform(mMoveRight)
                                                Next
                                                If HalfColumn Then
                                                    ' one more hex on just the upper half row
                                                    e.Graphics.DrawPath(LinePen, gpThisOddRow)
                                                End If
                                            End Using
                                            gpOddRows.Transform(mMoveDown)

                                            Using gpThisEvenRow As Drawing2D.GraphicsPath = gpEvenRows.Clone
                                                For i As Integer = 1 To HexesPerRow
                                                    e.Graphics.DrawPath(LinePen, gpThisEvenRow)
                                                    gpThisEvenRow.Transform(mMoveRight)
                                                Next
                                            End Using
                                            gpEvenRows.Transform(mMoveDown)
                                        Next
                                        If HalfRow Then
                                            ' one more entire upper half row
                                            Using gpThisOddRow As Drawing2D.GraphicsPath = gpOddRows.Clone
                                                For i As Integer = 1 To HexesPerRow
                                                    e.Graphics.DrawPath(LinePen, gpThisOddRow)
                                                    gpThisOddRow.Transform(mMoveRight)
                                                Next
                                                If HalfColumn Then
                                                    ' one more hex
                                                    e.Graphics.DrawPath(LinePen, gpThisOddRow)
                                                End If
                                            End Using
                                        End If
                                    End Using
                                End Using
                            End Using
                        End Using
                    End Using
            End Select
        Catch ex As Exception
        Finally
            g.Restore(gs)
        End Try
    End Sub

    Public Sub EndPrint()

    End Sub

End Class
