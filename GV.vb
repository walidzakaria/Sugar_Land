Public Class GV

    'Public Shared myConn As String = "Data Source=WALID-PC\MASTER;Initial Catalog=MasterProSugar;Integrated Security=True"
    Public Shared myConn As String = "Data Source=192.168.0.200\Master;Initial Catalog=MasterPro;User ID=Master01;Password=Master123"
    'Public Shared myConn As String = "Data Source=192.168.0.200\Master;Initial Catalog=Old_MasterPro;User ID=Master01;Password=Master123"
    
    Public Shared MarketName As String = "Sugar Land"
    Public Shared AppDemo As Boolean = False
    Public Shared DemoDate As Date = #11/24/2028#
    Public Shared InvoiceLimits As Integer = 28000000
    Public Shared BackupDays As Integer = 7
    ''''to reset db
    ''    --dbcc checkident ('tblOut1', reseed)

    ''delete from tblcash;
    ''delete from tblCompounds;
    ''delete from tblDebit;
    ''delete from tblIn2;
    ''delete from tblin1;
    ''delete from tblOut2;
    ''delete from tblOut1;
    ''delete from tblInInvoice;
    ''delete from tblRate;
    ''delete from tblVendors;
    ''delete from tblLogin;

End Class
