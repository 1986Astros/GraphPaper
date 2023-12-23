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
        Settings = New SettingsVB.SharkInSeine.Settings("GraphPaper", path)
    End Sub

End Class
