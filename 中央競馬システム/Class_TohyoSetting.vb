
Public Class Class_TohyoSetting
    Private Sub tohyoSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If tohyoMode = True Then
            ipatCb.Checked = True
        Else
            smnCb.Checked = True

        End If
        minPercentNud.Value = minPercent
        remainingFunds.Value = remainingFund
        tansyoCb.Checked = tansyoCbV
        tansyoExpectLow.Value = tansyoExpectLowV
        tansyoExpectHigh.Value = tansyoExpectHighV
        tansyoOddsLow.Value = tansyoOddsLowV
        tansyoOddsHigh.Value = tansyoOddsHighV
        tansyoParse.Value = tansyoPerceV

        fukusyoCb.Checked = fukusyoCbV
        fukusyoExpectLow.Value = fukusyoExpectLowV
        fukusyoExpectHigh.Value = fukusyoExpectHighV
        fukusyoOddsLow.Value = fukusyoOddsLowV
        fukusyoOddsHigh.Value = fukusyoOddsHighV
        fukusyoParse.Value = fukusyoPerceV

        wakurenCb.Checked = wakurenCbV
        wakurenExpectLow.Value = wakurenExpectLowV
        wakurenExpectHigh.Value = wakurenExpectHighV
        wakurenOddsLow.Value = wakurenOddsLowV
        wakurenOddsHigh.Value = wakurenOddsHighV
        wakurenParse.Value = wakurenPerceV

        umarenCb.Checked = umarenCbV
        umarenExpectLow.Value = umarenExpectLowV
        umarenExpectHigh.Value = umarenExpectHighV
        umarenOddsLow.Value = umarenOddsLowV
        umarenOddsHigh.Value = umarenOddsHighV
        umarenParse.Value = umarenPerceV

        wideCb.Checked = wideCbV
        wideExpectLow.Value = wideExpectLowV
        wideExpectHigh.Value = wideExpectHighV
        wideOddsLow.Value = wideOddsLowV
        wideOddsHigh.Value = wideOddsHighV
        wideParse.Value = widePerceV

        umatanCb.Checked = umatanCbV
        umatanExpectLow.Value = umatanExpectLowV
        umatanExpectHigh.Value = umatanExpectHighV
        umatanOddsLow.Value = umatanOddsLowV
        umatanOddsHigh.Value = umatanOddsHighV
        umatanParse.Value = umatanPerceV

        sanrenpukuCb.Checked = sanrenpukuCbV
        sanrenpukuExpectLow.Value = sanrenpukuExpectLowV
        sanrenpukuExpectHigh.Value = sanrenpukuExpectHighV
        sanrenpukuOddsLow.Value = sanrenpukuOddsLowV
        sanrenpukuOddsHigh.Value = sanrenpukuOddsHighV
        sanrenpukuParse.Value = sanrenpukuPerceV

        sanrentanCb.Checked = sanrentanCbV
        sanrentanExpectLow.Value = sanrentanExpectLowV
        sanrentanExpectHigh.Value = sanrentanExpectHighV
        sanrentanOddsLow.Value = sanrentanOddsLowV
        sanrentanOddsHigh.Value = sanrentanOddsHighV
        sanrentanParse.Value = sanrentanPerceV

        postHpCb.Checked = postHp
        postXcb.Checked = postXis
        postErCb.Checked = postEr
        postHitCb.Checked = postHit

        bTansyoCb.Checked = bTansyo
        bookersExpectValue.Value = bookersExpect

        bFukusyoCb.Checked = bFukusyo

        bWakurenCb.Checked = bWakuren

        bUmarenCb.Checked = bUmaren

        bWideCb.Checked = bWide

        bUmatanCb.Checked = bUmatan

        bSanrenpukuCb.Checked = bSanrenpuku

        bSanrentanCb.Checked = bSanrentan

        bTohyoCount.Value = bTohyoCountV

        pyMin.Value = pyMinV
        pySec.Value = pySecV
        tohyoMin.Value = tohyoMinV
        tohyoSec.Value = tohyoSecV
        postHpMin.Value = postHpMinV
        postHpSec.Value = postHpSecV
        postHpWinPercentCb.Checked = postHpWinPercent
        postBuyCb.Checked = postBuy
        setRaceNumNud.Value = setRaceNum




    End Sub

    Private Sub tohyoSetting_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        closeSave()

    End Sub

    Sub closeSave()
        minPercent = minPercentNud.Value
        remainingFund = remainingFunds.Value
        tohyoMode = ipatCb.Checked
        tansyoCbV = tansyoCb.Checked
        tansyoExpectLowV = tansyoExpectLow.Value
        tansyoExpectHighV = tansyoExpectHigh.Value
        tansyoOddsLowV = tansyoOddsLow.Value
        tansyoOddsHighV = tansyoOddsHigh.Value
        tansyoPerceV = tansyoParse.Value

        fukusyoCbV = fukusyoCb.Checked
        fukusyoExpectLowV = fukusyoExpectLow.Value
        fukusyoExpectHighV = fukusyoExpectHigh.Value
        fukusyoOddsLowV = fukusyoOddsLow.Value
        fukusyoOddsHighV = fukusyoOddsHigh.Value
        fukusyoPerceV = fukusyoParse.Value

        wakurenCbV = wakurenCb.Checked
        wakurenExpectLowV = wakurenExpectLow.Value
        wakurenExpectHighV = wakurenExpectHigh.Value
        wakurenOddsLowV = wakurenOddsLow.Value
        wakurenOddsHighV = wakurenOddsHigh.Value
        wakurenPerceV = wakurenParse.Value

        umarenCbV = umarenCb.Checked
        umarenExpectLowV = umarenExpectLow.Value
        umarenExpectHighV = umarenExpectHigh.Value
        umarenOddsLowV = umarenOddsLow.Value
        umarenOddsHighV = umarenOddsHigh.Value
        umarenPerceV = umarenParse.Value

        wideCbV = wideCb.Checked
        wideExpectLowV = wideExpectLow.Value
        wideExpectHighV = wideExpectHigh.Value
        wideOddsLowV = wideOddsLow.Value
        wideOddsHighV = wideOddsHigh.Value
        widePerceV = wideParse.Value

        umatanCbV = umatanCb.Checked
        umatanExpectLowV = umatanExpectLow.Value
        umatanExpectHighV = umatanExpectHigh.Value
        umatanOddsLowV = umatanOddsLow.Value
        umatanOddsHighV = umatanOddsHigh.Value
        umatanPerceV = umatanParse.Value

        sanrenpukuCbV = sanrenpukuCb.Checked
        sanrenpukuExpectLowV = sanrenpukuExpectLow.Value
        sanrenpukuExpectHighV = sanrenpukuExpectHigh.Value
        sanrenpukuOddsLowV = sanrenpukuOddsLow.Value
        sanrenpukuOddsHighV = sanrenpukuOddsHigh.Value
        sanrenpukuPerceV = sanrenpukuParse.Value

        sanrentanCbV = sanrentanCb.Checked
        sanrentanExpectLowV = sanrentanExpectLow.Value
        sanrentanExpectHighV = sanrentanExpectHigh.Value
        sanrentanOddsLowV = sanrentanOddsLow.Value
        sanrentanOddsHighV = sanrentanOddsHigh.Value
        sanrentanPerceV = sanrentanParse.Value

        postHp = postHpCb.Checked
        postXis = postXcb.Checked
        postEr = postErCb.Checked
        postHit = postHitCb.Checked

        bTansyo = bTansyoCb.Checked
        bookersExpect = bookersExpectValue.Value

        bFukusyo = bFukusyoCb.Checked

        bWakuren = bWakurenCb.Checked

        bUmaren = bUmarenCb.Checked

        bWide = bWideCb.Checked

        bUmatan = bUmatanCb.Checked

        bSanrenpuku = bSanrenpukuCb.Checked

        bSanrentan = bSanrentanCb.Checked

        bTohyoCountV = bTohyoCount.Value

        pyMinV = pyMin.Value
        pySecV = pySec.Value
        tohyoMinV = tohyoMin.Value
        tohyoSecV = tohyoSec.Value
        postHpMinV = postHpMin.Value
        postHpSecV = postHpSec.Value
        postBuy = postBuyCb.Checked
        postHpWinPercent = postHpWinPercentCb.Checked

        setRaceNum = setRaceNumNud.Value
    End Sub

    Private Sub BookersBtn_Click(sender As Object, e As EventArgs) Handles pastRaceBtn.Click
        closeSave()
        startBookers()
    End Sub

    Sub startBookers()
        yyyymmdd = bookersDay.Value.ToString("yyyy年MM月dd日")
        Dim idyyyymmdd As String = bookersDay.Value.ToString("yyyyMMdd")
        kaisai = bookKaisai.SelectedItem
        Code = getChangeCode(kaisai)
        raceNumberCode = bookRaceNum.SelectedItem
        raceId = idyyyymmdd & Code & raceNumberCode
        If kaisai = "" Or raceNumberCode = "" Then
            MsgBox("開催日を入力してください")
            Exit Sub
        End If
        Dim bookersTitle As String = yyyymmdd & "_" & kaisai & raceNumberCode & "R【競馬AI 買い目】"
        Try
            getTansyoPercentAll()
        Catch
            MsgBox("エラー : 開催日程を確認してください")
            Exit Sub
        End Try
        Dim bookersArticle As String = Create_Baken("bookers")
        Dim sptBookersArticle = Split(bookersArticle, vbLf)
        Dim tohyoCount As Integer = sptBookersArticle.Count
        If tohyoCount > bTohyoCountV Then
            postBookers(bookersTitle, bookersArticle)
        Else
            MsgBox("投票馬券数が " & tohyoCount & " 個のため投稿していません")
        End If
        MsgBox("X & Bookers 投稿完了")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        closeSave()
        Dim yyyymmdd As String = bookersDay.Value.ToString("yyyyMMdd")
        kaisai = bookKaisai.SelectedItem
        Code = getChangeCode(kaisai)
        raceNumberCode = bookRaceNum.SelectedItem
        raceId = yyyymmdd & Code & raceNumberCode
        If kaisai = "" Or raceNumberCode = "" Then
            MsgBox("開催日を入力してください")
            Exit Sub
        End If
        Try
            getTansyoPercentAll()
        Catch
            MsgBox("エラー : 開催日程を確認してください")
            Exit Sub
        End Try
        Try
            postHpKaime()
            MsgBox("ホームページ更新完了")
        Catch ex As Exception
            MsgBox("エラー　:" & ex.Message)
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        allPercentBookers()
        todayPercentDelete()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub
End Class