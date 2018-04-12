Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors
Imports System.Data.SqlClient

Partial Public Class frmTracker
    Public Shared myConn As New SqlConnection(GV.myConn)
    Public Sub New()
        InitializeComponent()

    End Sub

    Private Sub fillData()
        CashierNew.SplashScreenManager1.ShowWaitForm()
        Dim Query As String = "SELECT tblOut2.Serial AS Invoice, tblOut1.[Date], tblOut1.[Time], tblOut1.CardCode, tblAgency.Company," _
                              & " tblAgency.Agent, tblItems.Serial AS Code, tblItems.Name AS ItemName, tblOut2.Qnty, tblOut2.UnitPrice, tblOut2.Discount, tblOut2.Price AS [Value]," _
                              & " tblLogin.UserName AS Cashier" _
                              & " FROM tblOut2" _
                              & " INNER JOIN tblItems ON tblOut2.Item = tblItems.PrKey" _
                              & " INNER JOIN tblOut1 ON tblOut2.Serial = tblOut1.Serial" _
                              & " INNER JOIN tblAgency ON tblOut1.Agent = tblAgency.Code" _
                              & " INNER JOIN tblLogin ON tblOut1.[User] = tblLogin.Sr;"

        Dim dt As New DataTable
        Using cmd = New SqlCommand(Query, myConn)
            If myConn.State = ConnectionState.Closed Then
                myConn.Open()
            End If
            Using dr As SqlDataReader = cmd.ExecuteReader
                dt.Load(dr)
            End Using
            myConn.Close()
        End Using

        gridControl.DataSource = dt
        gridView.BestFitColumns()
        gridView.MoveLast()

        CashierNew.SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub windowsUIButtonPanel_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.Docking2010.ButtonEventArgs) Handles windowsUIButtonPanel.ButtonClick
        If e.Button.Properties.Caption = "Print" Then
            gridControl.ShowRibbonPrintPreview()
        ElseIf e.Button.Properties.Caption = "Refresh" Then
            fillData()
        End If
    End Sub
    
    Private Sub frmTracker_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        fillData()
    End Sub
End Class
