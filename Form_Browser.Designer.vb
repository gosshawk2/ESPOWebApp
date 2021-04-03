<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WebBrowserForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.btnGRAB = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnForward = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnSEARCH = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.myBrowser = New System.Windows.Forms.WebBrowser()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.stsLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.stsLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.stsLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.pnlButtons.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlButtons
        '
        Me.pnlButtons.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlButtons.BackColor = System.Drawing.Color.Silver
        Me.pnlButtons.Controls.Add(Me.btnTest)
        Me.pnlButtons.Controls.Add(Me.btnGRAB)
        Me.pnlButtons.Controls.Add(Me.btnRefresh)
        Me.pnlButtons.Controls.Add(Me.btnForward)
        Me.pnlButtons.Controls.Add(Me.btnBack)
        Me.pnlButtons.Controls.Add(Me.btnSEARCH)
        Me.pnlButtons.Controls.Add(Me.btnClose)
        Me.pnlButtons.Controls.Add(Me.txtSearch)
        Me.pnlButtons.Controls.Add(Me.btnHome)
        Me.pnlButtons.Location = New System.Drawing.Point(2, 0)
        Me.pnlButtons.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(1190, 134)
        Me.pnlButtons.TabIndex = 0
        '
        'btnGRAB
        '
        Me.btnGRAB.Location = New System.Drawing.Point(502, 18)
        Me.btnGRAB.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnGRAB.Name = "btnGRAB"
        Me.btnGRAB.Size = New System.Drawing.Size(112, 35)
        Me.btnGRAB.TabIndex = 6
        Me.btnGRAB.Text = "Grab HTML"
        Me.btnGRAB.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnRefresh.Location = New System.Drawing.Point(381, 18)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(112, 35)
        Me.btnRefresh.TabIndex = 5
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnForward
        '
        Me.btnForward.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnForward.Location = New System.Drawing.Point(260, 18)
        Me.btnForward.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnForward.Name = "btnForward"
        Me.btnForward.Size = New System.Drawing.Size(112, 35)
        Me.btnForward.TabIndex = 4
        Me.btnForward.Text = "Forward"
        Me.btnForward.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnBack.Location = New System.Drawing.Point(138, 18)
        Me.btnBack.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(112, 35)
        Me.btnBack.TabIndex = 3
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnSEARCH
        '
        Me.btnSEARCH.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSEARCH.BackColor = System.Drawing.Color.LimeGreen
        Me.btnSEARCH.Location = New System.Drawing.Point(1028, 80)
        Me.btnSEARCH.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSEARCH.Name = "btnSEARCH"
        Me.btnSEARCH.Size = New System.Drawing.Size(93, 35)
        Me.btnSEARCH.TabIndex = 1
        Me.btnSEARCH.Text = "Search"
        Me.btnSEARCH.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(906, 18)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(112, 35)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Location = New System.Drawing.Point(16, 85)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(1000, 26)
        Me.txtSearch.TabIndex = 0
        '
        'btnHome
        '
        Me.btnHome.Location = New System.Drawing.Point(16, 18)
        Me.btnHome.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(112, 35)
        Me.btnHome.TabIndex = 2
        Me.btnHome.Text = "Home"
        Me.btnHome.UseVisualStyleBackColor = True
        '
        'myBrowser
        '
        Me.myBrowser.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.myBrowser.Location = New System.Drawing.Point(2, 143)
        Me.myBrowser.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.myBrowser.MinimumSize = New System.Drawing.Size(30, 31)
        Me.myBrowser.Name = "myBrowser"
        Me.myBrowser.Size = New System.Drawing.Size(1190, 511)
        Me.myBrowser.TabIndex = 1
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.stsLabel1, Me.stsLabel2, Me.stsLabel3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 670)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(2, 0, 21, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1200, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'stsLabel1
        '
        Me.stsLabel1.Name = "stsLabel1"
        Me.stsLabel1.Size = New System.Drawing.Size(0, 15)
        '
        'stsLabel2
        '
        Me.stsLabel2.Name = "stsLabel2"
        Me.stsLabel2.Size = New System.Drawing.Size(1177, 15)
        Me.stsLabel2.Spring = True
        '
        'stsLabel3
        '
        Me.stsLabel3.Name = "stsLabel3"
        Me.stsLabel3.Size = New System.Drawing.Size(0, 15)
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(705, 18)
        Me.btnTest.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(112, 35)
        Me.btnTest.TabIndex = 8
        Me.btnTest.Text = "Test"
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'WebBrowserForm
        '
        Me.AcceptButton = Me.btnSEARCH
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnRefresh
        Me.ClientSize = New System.Drawing.Size(1200, 692)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.myBrowser)
        Me.Controls.Add(Me.pnlButtons)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "WebBrowserForm"
        Me.Text = "ESPO Web Browser"
        Me.pnlButtons.ResumeLayout(False)
        Me.pnlButtons.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlButtons As Panel
    Friend WithEvents btnHome As Button
    Friend WithEvents WebBrowser1 As WebBrowserForm
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents myBrowser As Windows.Forms.WebBrowser
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnForward As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents btnSEARCH As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnGRAB As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents stsLabel1 As ToolStripStatusLabel
    Friend WithEvents stsLabel2 As ToolStripStatusLabel
    Friend WithEvents stsLabel3 As ToolStripStatusLabel
    Friend WithEvents btnTest As Button
End Class
