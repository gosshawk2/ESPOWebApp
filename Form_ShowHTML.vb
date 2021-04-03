Public Class ShowHTML
    Private _HTMLOutput As String
    Private _BrowserControl As New WebBrowser

    Dim GlobalSession As ESPOParms.Session

    Public Property HTMLOutput As String
        Get
            Return _HTMLOutput
        End Get
        Set(value As String)
            _HTMLOutput = value
        End Set
    End Property

    Public Property BrowserControl As WebBrowser
        Get
            Return _BrowserControl
        End Get
        Set(value As WebBrowser)
            _BrowserControl = value
        End Set
    End Property

    Public Sub GetParms(Session As ESPOParms.Session)
        GlobalSession = Session
    End Sub

    Private Sub ShowHTML_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(1, 1)
        KeyPreview = True
        MdiParent = FromHandle(GlobalSession.MDIParentHandle)
        txtHTML.Text = HTMLOutput
        'WBHTMLOutput.DocumentText = HTMLOutput
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


    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()

    End Sub

    Sub UndockChild()
        If MdiParent Is Nothing Then
            Me.MdiParent = FromHandle(GlobalSession.MDIParentHandle)
        Else
            Me.MdiParent = Nothing
        End If
    End Sub

    Private Sub ShowHTML_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.F5 Then
            btnRefresh.PerformClick()
        ElseIf e.KeyValue = Keys.F7 Then
            UndockChild()
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Refresh()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim SearchID As String
        Dim Title As String
        Dim TagPos As Integer
        Dim InnerHTML As String
        Dim images() As String
        Dim TagNames() As String
        Dim ImageIDX As Integer
        Dim TagNameIDX As Integer
        Dim LoopIDX As Integer

        ReDim images(0)
        ReDim TagNames(0)
        ImageIDX = 0
        TagNameIDX = 0
        LoopIDX = 0
        SearchID = txtSearch.Text
        For Each Element As HtmlElement In BrowserControl.Document.All
            InnerHTML = Element.InnerHtml
            If Not IsNothing(InnerHTML) Then
                TagPos = InStr(InnerHTML.ToUpper, "JPG")
                stsLabel1.Text = String.Empty
                If TagPos > 0 Then
                    'grab whole text between tag and get the .jpg address:
                    images(ImageIDX) = InnerHTML
                    ReDim Preserve images(UBound(images) + 1)
                    ImageIDX += 1
                    TagNames(TagNameIDX) = Element.TagName
                    ReDim Preserve TagNames(UBound(TagNames) + 1)
                    TagNameIDX += 1
                Else
                    stsLabel1.Text = "Not Found"
                End If
            End If

            LoopIDX += 1
        Next
        'For Each element In BrowserControl.Document.GetElementById("a")
        Title = BrowserControl.DocumentTitle
        ParseHTML(txtHTML.Text)
        'MsgBox("Title = " & Title)
        'Next
    End Sub

    Sub SearchTag()
        Dim InsideOpenAngleBracket As Boolean = False
        Dim InsideClosedAngleBracket As Boolean = False
        Dim WholeText As String

        WholeText = txtHTML.Text
        For i As Int64 = 0 To WholeText.Length - 1

        Next

    End Sub

    Sub ParseHTML(HTML As String)
        'Modified: Daniel Goss - APR 2021
        Dim Word As String = ""
        Dim blnInsideOpenAngleBracketMode As Boolean = False
        Dim blnInsideClosedAngleBracketMode As Boolean = False
        Dim blnInsideHREF_TAGMode As Boolean = False
        Dim blnInsideA_TAGMode As Boolean = False
        Dim blnInsideIMG_TAGMode As Boolean = False
        Dim blnFound_JPG As Boolean = False
        Dim blnFetchMode As Boolean = False
        Dim blnInsideQuote As Boolean = False
        Dim blnInsideTrim As Boolean = False
        Dim int2 As Int64 = 0
        Dim intTAGIDX As Int64 = 0
        Dim intImageIDX As Int64 = 0
        Dim intInnerHTMLIDX As Int64 = 0
        Dim intJPG As Int64 = 0
        Dim wrkChar As Char
        Dim closedBracket As String
        Dim InnerHTML As String
        Dim OuterHTML As String
        Dim arrTags() As String
        Dim arrImages() As String
        Dim arrJPG_HTTP() As String
        Dim arrHREFs() As String
        Dim arrATAGS() As String
        Dim arrInnerHTML() As String
        Dim strHTTP As String = ""
        Dim strTRIM As String = ""
        Dim strTAG As String = ""
        Dim intFetchRecords = 0

        'SQLStatement = SQLStatement.ToUpper
        'SQLStatement = Replace(SQLStatement, "ORDER BY", "ORDERBY", 1, -1, CompareMethod.Text)
        ReDim arrTags(0)
        ReDim arrImages(0)
        ReDim arrJPG_HTTP(0)
        ReDim arrHREFs(0)
        ReDim arrATAGS(0)
        ReDim arrInnerHTML(0)

        '<title></title>
        For int1 As Int64 = 1 To Len(HTML)
            wrkChar = Mid(HTML, int1, 1)
            If int1 < Len(HTML) - 2 Then
                closedBracket = Mid(HTML, int1 + 1, 2) '</
            End If
            blnFound_JPG = False
            If (wrkChar = " " And Not blnInsideOpenAngleBracketMode And Not blnInsideClosedAngleBracketMode And Not blnInsideQuote) Or wrkChar = vbCr Or wrkChar = vbLf Or wrkChar = "," Then ' Blank, CR, LF or , encountered
                If Trim(Word) <> "" Then
                    If Word.ToUpper = "<IMG" Then ' SQL Clause, flag that we are SELECT Mode
                        blnInsideIMG_TAGMode = True
                        blnInsideHREF_TAGMode = False
                        blnInsideA_TAGMode = False
                        arrInnerHTML(intInnerHTMLIDX) = InnerHTML
                        ReDim Preserve arrInnerHTML(UBound(arrInnerHTML) + 1)
                        intInnerHTMLIDX += 1
                        int2 = 0
                    ElseIf Word.ToUpper = "JPG" And blnInsideIMG_TAGMode Then
                        'arrJoins(intJoins) = Word
                        'ReDim Preserve _arrJoins(UBound(_arrJoins) + 1)
                        'intJoins += 1
                        arrImages(intImageIDX) = Word
                        ReDim Preserve arrImages(UBound(arrImages) + 1)
                        intImageIDX += 1
                    End If
                    Word = ""
                End If
            Else '<title></title>
                Word += wrkChar

                ' Check for quotes and brackets and flag if we are inside or outside at this point
                If wrkChar = "<" Then
                    blnInsideOpenAngleBracketMode = True
                    blnInsideClosedAngleBracketMode = False
                    InnerHTML = String.Empty
                ElseIf wrkChar = ">" Then
                    blnInsideOpenAngleBracketMode = False
                    blnInsideClosedAngleBracketMode = False
                    InnerHTML += wrkChar
                ElseIf wrkChar = """" And Not blnInsideQuote Then
                    blnInsideQuote = True
                ElseIf closedBracket = "</" Then
                    blnInsideClosedAngleBracketMode = True
                    blnInsideOpenAngleBracketMode = False
                    InnerHTML = String.Empty
                End If
            End If
        Next int1
        MsgBox("Completed")
        ' Process last word
        'If blnFromMode = True And Word <> "AS" And Word.Contains("""") = False Then ' We have a word we want
        'strFROM = Word
        'End If
        'lstFields.Items.Clear()
        'chklstOrderBY.Items.Clear()

        'For Each item As String In arrSELECTColumn
        'If item IsNot Nothing Then
        'lstFields.Items.Add(item)
        'End If
        'Next
        'For Each item As String In arrWHERE
        'If item IsNot Nothing Then
        'lstConditions.Items.Add(item)
        'End If
        'Next
        'For Each item As String In arrORDERBY
        'If item IsNot Nothing Then
        'chklstOrderBY.Items.Add(item)
        'End If
        'Next
        'lstFields.Items.AddRange(New List(Of String)(arrSELECTColumn))
        'chklstOrderBY.Items.AddRange(arrORDERBY)
        'lstConditions.Items.AddRange(arrWHERE)
        'txtTablename.Text = strFROM
        'txtFirstRows.Text = CStr(intFetchRecords)
        'FieldAttributes.FetchRecords = intFetchRecords
        'If InStr(strFROM, ".") > 0 Then
        'FieldAttributes.TableName = Mid(strFROM, InStr(strFROM, ".") + 1, Len(strFROM))
        'Else
        'FieldAttributes.TableName = strFROM
        'End If

        'New List(Of String)(array) 'captures ALL elements including nothing...
        'New List(Of String)(arrSELECTColumn)
        'FieldAttributes.ClearAllDics()
        'FieldAttributes.ClearALLLists()
        'FieldAttributes.ClearConditionsList()
        'FieldAttributes.SelectedFields = PopulateListWithoutNothings(arrSELECTColumn)
        'FieldAttributes.SelectedAlias = PopulateListWithoutNothings(arrSELECTColumnText)
        'FieldAttributes.lbConditions = PopulateListWithoutNothings(arrWHERE)
        'FieldAttributes.lstHavings = PopulateListWithoutNothings(arrHAVING)
        'FieldAttributes.GroupByList = PopulateListWithoutNothings(arrGROUPBY)
        'FieldAttributes.OrderByList = PopulateListWithoutNothings(arrORDERBY)
        'FieldAttributes.SortedList = PopulateListWithoutNothings(arrSorted)
        'FieldAttributes.GetFullQuery = ""

    End Sub

End Class