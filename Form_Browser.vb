Public Class WebBrowserForm

    Dim GlobalSession As ESPOParms.Session

    Public Sub GetParms(Session As ESPOParms.Session)
        GlobalSession = Session
    End Sub

    Private Sub WebBrowser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(1, 1)
        KeyPreview = True

        MdiParent = FromHandle(GlobalSession.MDIParentHandle)
        myBrowser.GoHome()
        Refresh()

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

    Sub PopulateForm()
        'This can only be called after the web page has finished rendering.
        Me.Text = "Browse: " & myBrowser.Document.Title
        Refresh()

    End Sub

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        myBrowser.GoHome()
    End Sub

    Private Sub myBrowser_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles myBrowser.DocumentCompleted
        PopulateForm()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnGO_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        myBrowser.GoBack()
    End Sub

    Private Sub btnForward_Click(sender As Object, e As EventArgs) Handles btnForward.Click
        myBrowser.GoForward()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        myBrowser.Refresh()
    End Sub

    Sub ShowHTML()
        Dim App As New ESPOWebApp.ShowHTML

        Cursor = Cursors.Default
        stsLabel1.Text = "Loading ..."
        Cursor = Cursors.WaitCursor
        Refresh()
        'App.Visible = False
        App.GetParms(GlobalSession)
        App.HTMLOutput = myBrowser.DocumentText
        App.BrowserControl = myBrowser
        App.Text = "HTML Output: " & myBrowser.DocumentTitle
        App.Show()
        stsLabel1.Text = ""
        Cursor = Cursors.Default
    End Sub

    Private Sub btnGRAB_Click(sender As Object, e As EventArgs) Handles btnGRAB.Click
        'Grab HTML from Browser control and paste into new control:
        'TEXT BOX control or RTF control ?
        ShowHTML()


    End Sub

    Private Sub btnSEARCH_Click(sender As Object, e As EventArgs) Handles btnSEARCH.Click

        myBrowser.Navigate(txtSearch.Text)
        Refresh()
        Me.Text = "Browse" & ": " & myBrowser.Document.Title
        Refresh()
    End Sub

    Sub UndockChild()
        If MdiParent Is Nothing Then
            Me.MdiParent = FromHandle(GlobalSession.MDIParentHandle)
        Else
            Me.MdiParent = Nothing
        End If
    End Sub

    Private Sub WebBrowser_MouseHover(sender As Object, e As EventArgs) Handles MyBase.MouseHover

    End Sub

    Private Sub WebBrowser_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        stsLabel1.Text = e.X & "," & e.Y
        stsLabel2.Text = myBrowser.Document.ActiveElement.ToString

    End Sub

    Private Sub WebBrowserForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.F5 Then
            btnRefresh.PerformClick()
        ElseIf e.KeyValue = Keys.F7 Then
            UndockChild()
        End If
    End Sub

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click
        txtSearch.Text = "https://mcprod.espo.org/catalogsearch/result/?q=96520"
    End Sub
End Class
