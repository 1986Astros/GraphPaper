Public Class Console
    Public Sub New()
        InitializeComponent()

        Dim path As String = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Shark In Seine")
        If Not System.IO.Directory.Exists(path) Then
            System.IO.Directory.CreateDirectory(path)
        End If
        path = System.IO.Path.Combine(path, "Settings")
        If Not System.IO.Directory.Exists(path) Then
            System.IO.Directory.CreateDirectory(path)
        End If
        Settings = New SharkInSeine.Settings("GraphPaper", path)

        lbShape.Items.Clear()
        lbShape.Items.Add(GraphPaper.Shapes.Triangles)
        lbShape.Items.Add(GraphPaper.Shapes.Squares)
        lbShape.Items.Add(GraphPaper.Shapes.Diamonds)
        lbShape.Items.Add(GraphPaper.Shapes.Hexagons)
        'lbShape.SelectedItem = Details.Shape
        'GraphPaperControl1.Details = Details
    End Sub

    Private Details As GraphPaper ' = New GraphPaper

    Private Sub Console_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Settings.AddForm(Me)

    End Sub

    Private Sub lbShape_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbShape.SelectedIndexChanged
        Details.Shape = lbShape.SelectedItems(0)
    End Sub
End Class

'Public Class Test
'    Public Property ColorStuff As Color
'End Class
