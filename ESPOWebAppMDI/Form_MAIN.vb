Public Class MAIN
    Dim GlobalSession As ESPOParms.Session
    Dim p As System.Security.Principal.WindowsPrincipal = CType(System.Threading.Thread.CurrentPrincipal, System.Security.Principal.WindowsPrincipal)
    Dim userID As String = p.Identity.Name
    Dim WinCount As Integer
    Private Sub MAIN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GlobalSession = New ESPOParms.Session
        GlobalSession.CurrentUser = userID
        GlobalSession.CurrentUserShort = GlobalSession.CurrentUser.Split("\")(1)

        Dim StartupArgs() As String
        StartupArgs = System.Environment.GetCommandLineArgs
        Me.WindowState = FormWindowState.Maximized
        Try
            If StartupArgs(1).ToString = "123456" Then
                GlobalSession.CurrentMode = StartupArgs(2).ToString
                GlobalSession.CurrentServer = StartupArgs(3).ToString
            Else
                'Error Loading Frameworks...
                'ModeSelect.ShowDialog()
                'GlobalSession.CurrentMode = ModeSelect.GetMode()
                GlobalSession.CurrentServer = "PARAGON"
                GlobalSession.CurrentMode = "LIVE"
            End If
        Catch ex As Exception
            'Normally ModeSelect called here:
        End Try
        Dim espoConnect As New ESPOCommon1.ESPOConnect
        GlobalSession.ConnectString = espoConnect.GetConnectString(GlobalSession.CurrentMode, GlobalSession.CurrentServer)
        GlobalSession.MDIParentHandle = Me.Handle

        stsLabel3.Text = "   User: " & GlobalSession.CurrentUserShort & "   "
        stsLabel4.Text = "   Server: " & GlobalSession.CurrentServer & "   "
        stsLabel5.Text = "   Environment: " & GlobalSession.CurrentMode & "   "
        stsLabel6.Text = String.Format("   Version {0}", My.Application.Info.Version.ToString) & "   "

        ShowWebBrowser()

        For Each c As Control In Controls
            AddHandler c.MouseClick, AddressOf ClickHandler
        Next

    End Sub

    Private Sub ClickHandler(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        Select Case e.Button
            Case MouseButtons.Left
                Me.BringToFront()
        End Select
    End Sub

    Sub ShowWebBrowser()
        Dim App As New ESPOWebApp.WebBrowserForm

        Cursor = Cursors.Default
        stsLabel1.Text = "Loading ..."
        Cursor = Cursors.WaitCursor
        Refresh()
        'App.Visible = False
        App.GetParms(GlobalSession)
        App.Show()
        stsLabel1.Text = ""
        Cursor = Cursors.Default
    End Sub

    Private Sub BrowserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BrowserToolStripMenuItem.Click
        ShowWebBrowser()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CascadeToolStripMenuItem.Click
        LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub ArrangeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArrangeToolStripMenuItem.Click
        LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private Sub RestoreAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestoreAllToolStripMenuItem.Click
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.WindowState = FormWindowState.Normal
        Next
    End Sub

    Private Sub MinimiseAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MinimiseAllToolStripMenuItem.Click
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.WindowState = FormWindowState.Minimized
        Next
    End Sub
End Class