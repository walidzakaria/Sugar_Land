Imports System.IO
Public Class CashDrawer
    Public Shared Sub open_cashdrawer()
        If Not IO.File.Exists(Application.StartupPath & "\escapes.txt") Then
            IO.File.Create(Application.StartupPath & "\escapes.txt")
        End If
        Dim intFileNo As Integer = FreeFile()
        FileOpen(1, Application.StartupPath & "\escapes.txt", OpenMode.Output)
        PrintLine(1, Chr(27) & "p" & Chr(0) & Chr(25) & Chr(250))
        FileClose(1)
        Shell("print /d:lpt1 " & Application.StartupPath & "\escapes.txt", vbNormalFocus)
    End Sub
End Class
