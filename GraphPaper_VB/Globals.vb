Imports System.ComponentModel

Module Globals
    Public Settings As SharkInSeine.Settings
    Public DesignMode As Boolean = LicenseManager.UsageMode = LicenseUsageMode.Designtime
    Public Sub WriteSettings()
        If Settings IsNot Nothing AndAlso Not DesignMode Then
            Settings.Write()
        End If
    End Sub
    Public Property UsePrintMargins
        Get
            If Settings Is Nothing OrElse DesignMode Then
                Return True
            Else
                Return Settings.GetValueBoolean("Main", "UsePrintMargins", True)
            End If
        End Get
        Set(value)
            If value <> UsePrintMargins Then
                If Settings IsNot Nothing Then
                    Settings.SetValue("Main", "UsePrintMargins", value)
                    WriteSettings()
                End If
            End If
        End Set
    End Property
End Module
