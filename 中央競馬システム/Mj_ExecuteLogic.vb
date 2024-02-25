Imports System.Threading
Imports Npgsql
Module Mj_ExeCuteLogic
    Function execute()
        Dim count As Integer = 0
        Dim tansyoParsentDictionary As Dictionary(Of Integer, Double) = getTansyoPercent()
        count = tansyoParsentDictionary.Count
        If count = 0 Then
            Return count
        End If

        Dim buyMoney = Create_Baken("tohyo")

        If buyMoney = 0 Then
            logTxt += Now() & " " & kaisai & raceNumber & "R 投票予定がありません" & ControlChars.CrLf
            dgv.rows(raceNumber - 1)(1) = 10
        Else
            dgv.rows(raceNumber - 1)(1) = 1
            remainingFund -= buyMoney
            Class_IPAT.GetZandaka()
        End If
        dgv.rows(raceNumber - 1)(3) = buyMoney
        dgv.rows(12)(3) += buyMoney
        writeTopDgvTotal()
        dgvSave()
        Return count
    End Function
    Function Create_Baken(isTohyo)
        Dim tansyoPercentDictionarys As Dictionary(Of Integer, Double) = getTansyoPercent()
        Dim tansyoOddsDictionary = Class_Jv_Link.getTansyoOdds()
        Dim fukusyoOddsDictionary = Class_Jv_Link.getFukusyoOdds()
        Dim wakurenOddsDictionary = Class_Jv_Link.getWakurenOdds()
        Dim umarenOddsDictionary = Class_Jv_Link.getUmarenOdds()
        Dim wideOddsDictionary = Class_Jv_Link.getWideOdds()
        Dim umatanOddsDictionary = Class_Jv_Link.getUmatanOdds()
        Dim sanrenpukuOddsDictionary = Class_Jv_Link.getSanrenpukuOdds()
        Dim sanrentanOddsDictionary = Class_Jv_Link.getSanrentanOdds()
        Dim tousu As Integer = Class_Jv_Link.horseCount
        Dim tansyoPercentDictionary As Dictionary(Of Integer, Double) = New Dictionary(Of Integer, Double)
        For Each pair In tansyoPercentDictionarys
            Dim umaban As Integer = pair.Key
            Dim value As Double = pair.Value
            If minPercent / 100 > value Then
                value = 0
            End If
            tansyoPercentDictionary.Add(umaban, value)
        Next

        Dim fukusyoPercentDictionary As Dictionary(Of String, Double) = New Dictionary(Of String, Double)
        Dim wakurenPercentDictionary As Dictionary(Of String, Double) = New Dictionary(Of String, Double)
        Dim umarenPercentDictionary As Dictionary(Of String, Double) = New Dictionary(Of String, Double)
        Dim widePercentDictionary As Dictionary(Of String, Double) = New Dictionary(Of String, Double)
        Dim umatanPercentDictionary As Dictionary(Of String, Double) = New Dictionary(Of String, Double)
        Dim sanrenpukuPercentDictionary As Dictionary(Of String, Double) = New Dictionary(Of String, Double)
        Dim sanrentanPercentDictionary As Dictionary(Of String, Double) = New Dictionary(Of String, Double)

        '馬単
        For i = 1 To tousu
            For j = 1 To tousu
                If i <> j Then
                    Dim p1 As Double = 0
                    tansyoPercentDictionary.TryGetValue(i, p1)
                    Dim p2 As Double = 0
                    tansyoPercentDictionary.TryGetValue(j, p2)
                    Dim umatanPerce As Double = p1 * (p2 / (1 - p1))
                    Dim umaban1 As String = i.ToString("00")
                    Dim umaban2 As String = j.ToString("00")
                    Dim umatanUmaban As String = umaban1 & "-" & umaban2
                    umatanPercentDictionary.Add(umatanUmaban, umatanPerce)
                End If
            Next j
        Next i


        '馬連
        For i = 1 To tousu - 1
            For j = i To tousu
                If i <> j Then
                    Dim umaban1 As String = i.ToString("00")
                    Dim umaban2 As String = j.ToString("00")
                    Dim umarenUmaban As String = umaban1 & "-" & umaban2
                    Dim umatanPerce1 As Double = 0
                    Dim umatanPerce2 As Double = 0
                    umatanPercentDictionary.TryGetValue(umaban1 & "-" & umaban2, umatanPerce1)
                    umatanPercentDictionary.TryGetValue(umaban2 & "-" & umaban1, umatanPerce2)
                    Dim umarenParse As Double = umatanPerce1 + umatanPerce2
                    Dim umatanUmaban As String = umaban1 & "-" & umaban2
                    umarenPercentDictionary.Add(umarenUmaban, umarenParse)
                End If
            Next j
        Next i

        '枠連
        If tousu > 8 Then
            For i As Integer = 1 To 8
                Dim str_wakuban1 As String = i.ToString("0")
                For j As Integer = i To 8
                    Dim str_wakuban2 As String = j.ToString("0")
                    wakurenPercentDictionary.Add(str_wakuban1 & "-" & str_wakuban2, 0)
                Next j
            Next i

            Dim wakubanKumiDictionary As Dictionary(Of Integer, List(Of Integer)) = WakurenHorsesToFramesCorrect(tousu)

            For Each umarenUmaban As KeyValuePair(Of String, Double) In umarenPercentDictionary
                Dim sptUmaban As String() = umarenUmaban.Key.Split("-")
                Dim umaban1 As Integer = Integer.Parse(sptUmaban(0))
                Dim umaban2 As Integer = Integer.Parse(sptUmaban(1))
                Dim waku1 As Integer = 0
                Dim waku2 As Integer = 0

                For Each kvp As KeyValuePair(Of Integer, List(Of Integer)) In wakubanKumiDictionary
                    Dim wakuban As Integer = kvp.Key
                    Dim umabanArrays As List(Of Integer) = kvp.Value

                    For Each element As Integer In umabanArrays
                        If element = umaban1 Then
                            waku1 = wakuban
                        End If
                        If element = umaban2 Then
                            waku2 = wakuban
                        End If
                    Next

                    If waku1 <> 0 AndAlso waku2 <> 0 Then
                        Dim strWakuban As String = waku1.ToString("0") & "-" & waku2.ToString("0")
                        wakurenPercentDictionary(strWakuban) += umarenUmaban.Value
                        Exit For
                    End If
                Next
            Next
        End If



        '3連単
        For i = 1 To tousu
            For j = 1 To tousu
                For k = 1 To tousu
                    If i <> j AndAlso j <> k AndAlso i <> k Then
                        Dim p1 As Double = 0
                        tansyoPercentDictionary.TryGetValue(i, p1)
                        Dim p2 As Double = 0
                        tansyoPercentDictionary.TryGetValue(j, p2)
                        Dim p3 As Double = 0
                        tansyoPercentDictionary.TryGetValue(k, p3)
                        Dim sanrentanParse As Double = p1 * (p2 / (1 - p1)) * (p3 / (1 - p1 - p2))
                        Dim umaban1 As String = i.ToString("00")
                        Dim umaban2 As String = j.ToString("00")
                        Dim umaban3 As String = k.ToString("00")
                        Dim sanrentanUmaban As String = umaban1 & "-" & umaban2 & "-" & umaban3
                        sanrentanPercentDictionary.Add(sanrentanUmaban, sanrentanParse)
                    End If
                Next k
            Next j
        Next i


        '3連複
        For i = 1 To tousu - 2
            For j = i To tousu - 1
                For k = j To tousu
                    If i <> j AndAlso j <> k AndAlso i <> k Then
                        Dim umaban1 As String = i.ToString("00")
                        Dim umaban2 As String = j.ToString("00")
                        Dim umaban3 As String = k.ToString("00")
                        Dim sanrenpukuUmaban As String = umaban1 & "-" & umaban2 & "-" & umaban3
                        Dim sanrentanParse1 As Double = 0
                        Dim sanrentanParse2 As Double = 0
                        Dim sanrentanParse3 As Double = 0
                        Dim sanrentanParse4 As Double = 0
                        Dim sanrentanParse5 As Double = 0
                        Dim sanrentanParse6 As Double = 0
                        sanrentanPercentDictionary.TryGetValue(umaban1 & "-" & umaban2 & "-" & umaban3, sanrentanParse1)
                        sanrentanPercentDictionary.TryGetValue(umaban1 & "-" & umaban3 & "-" & umaban2, sanrentanParse2)
                        sanrentanPercentDictionary.TryGetValue(umaban2 & "-" & umaban1 & "-" & umaban3, sanrentanParse3)
                        sanrentanPercentDictionary.TryGetValue(umaban2 & "-" & umaban3 & "-" & umaban1, sanrentanParse4)
                        sanrentanPercentDictionary.TryGetValue(umaban3 & "-" & umaban1 & "-" & umaban2, sanrentanParse5)
                        sanrentanPercentDictionary.TryGetValue(umaban3 & "-" & umaban2 & "-" & umaban1, sanrentanParse6)
                        Dim sanrenpukuParse As Double = sanrentanParse1 + sanrentanParse2 + sanrentanParse3 + sanrentanParse4 + sanrentanParse5 + sanrentanParse6
                        sanrenpukuPercentDictionary.Add(sanrenpukuUmaban, sanrenpukuParse)
                    End If
                Next k
            Next j
        Next i

        'ワイド

        For i = 1 To tousu - 1
            For j = i + 1 To tousu
                Dim umaban1 As String = i.ToString("00")
                Dim umaban2 As String = j.ToString("00")
                Dim wideUmaban As String = umaban1 & "-" & umaban2
                Dim wideParse As Double = 0

                ' すべての馬に対して3連複の組み合わせを探索
                For k = 1 To tousu
                    ' kがiまたはjと異なる場合のみ処理
                    If k <> i AndAlso k <> j Then
                        ' 3連複の組み合わせを生成
                        Dim combinations As List(Of String) = New List(Of String) From {
                        umaban1 & "-" & umaban2 & "-" & k.ToString("00"),
                        umaban1 & "-" & k.ToString("00") & "-" & umaban2,
                        k.ToString("00") & "-" & umaban1 & "-" & umaban2
                    }

                        ' 各組み合わせについて的中率を加算
                        For Each combo As String In combinations
                            Dim wideP As Double = 0
                            If sanrenpukuPercentDictionary.TryGetValue(combo, wideP) Then
                                wideParse += wideP
                            End If
                        Next
                    End If
                Next k

                ' ワイドの的中率をDictionaryに追加
                widePercentDictionary.Add(wideUmaban, wideParse)
            Next j
        Next i
        Dim total As Double = widePercentDictionary.Values.Sum()

        '複勝

        If tousu > 7 Then
            ' 全馬に対するループ
            For i = 1 To tousu
                Dim fukusyoPercent As Double = 0

                ' i番の馬が含まれる全ての3連複組み合わせをチェック
                For j = 1 To tousu
                    For k = j + 1 To tousu
                        If j = i Or k = i Or j = k Then
                            ' i, j, k は異なる必要がある
                            Continue For
                        End If

                        ' 3連複の組み合わせのキーを生成
                        Dim keySanrenpukuUmaban As String = $"{Math.Min(i, Math.Min(j, k)).ToString("00")}-{Math.Max(Math.Min(i, j), Math.Min(Math.Max(i, j), k)).ToString("00")}-{Math.Max(i, Math.Max(j, k)).ToString("00")}"

                        ' この組み合わせの的中率を取得し、複勝の的中率に加算
                        If sanrenpukuPercentDictionary.ContainsKey(keySanrenpukuUmaban) Then
                            fukusyoPercent += sanrenpukuPercentDictionary(keySanrenpukuUmaban)
                        End If
                    Next
                Next

                ' 複勝の的中率をディクショナリに格納
                fukusyoPercentDictionary.Add(i.ToString("00"), fukusyoPercent)
            Next
        Else
            For i = 1 To tousu
                Dim fukusyoParse As Double = 0
                Dim umaban1 As String = i.ToString("00")
                Dim umarenUmaban As String = ""
                For j = 1 To tousu
                    If i <> j Then
                        Dim umaban2 As String = j.ToString("00")
                        If i < j Then
                            umarenUmaban = umaban1 & "-" & umaban2
                        Else
                            umarenUmaban = umaban2 & "-" & umaban1
                        End If
                        Dim umarenP As Double = 0

                        umarenPercentDictionary.TryGetValue(umarenUmaban, umarenP)

                        fukusyoParse += umarenP
                    End If
                Next j
                fukusyoPercentDictionary.Add(umaban1, fukusyoParse)
            Next i

        End If

        Dim sikibetuArray As ArrayList = New ArrayList
        Dim umabanArray As ArrayList = New ArrayList
        Dim oddsArray As ArrayList = New ArrayList
        Dim exceptArray As ArrayList = New ArrayList
        Dim buyMoneyArray As ArrayList = New ArrayList
        Dim totalBuy As Long = 0

        For i = 1 To 8
            Dim oddsDictionary As Dictionary(Of String, Double) = New Dictionary(Of String, Double)
            Dim percentDictionary As Dictionary(Of String, Double) = New Dictionary(Of String, Double)
            Dim sikibetu As String = ""
            Dim oddsLow As Double = 0
            Dim oddsHigh As Double = 0
            Dim exceptLow As Double = 0
            Dim exceptHigh As Double = 0
            Dim bairitu As Double = 0
            Dim buyCb As Boolean = False
            Select Case i
                Case 1
                    For Each kvp As KeyValuePair(Of Integer, Double) In tansyoOddsDictionary
                        oddsDictionary.Add(kvp.Key.ToString("00"), kvp.Value)
                    Next

                    For Each kvp As KeyValuePair(Of Integer, Double) In tansyoPercentDictionary
                        percentDictionary.Add(kvp.Key.ToString("00"), kvp.Value)
                    Next
                    oddsLow = tansyoOddsLowV
                    oddsHigh = tansyoOddsHighV
                    sikibetu = "単勝"
                    exceptLow = tansyoExpectLowV
                    exceptHigh = tansyoExpectHighV
                    bairitu = tansyoPerceV
                    buyCb = tansyoCbV

                Case 2
                    oddsDictionary = fukusyoOddsDictionary
                    percentDictionary = fukusyoPercentDictionary
                    oddsLow = fukusyoOddsLowV
                    oddsHigh = fukusyoOddsHighV
                    sikibetu = "複勝"
                    exceptLow = fukusyoExpectLowV
                    exceptHigh = fukusyoExpectHighV
                    bairitu = fukusyoPerceV
                    buyCb = fukusyoCbV
                Case 3
                    oddsDictionary = wakurenOddsDictionary
                    percentDictionary = wakurenPercentDictionary
                    oddsLow = wakurenOddsLowV
                    oddsHigh = wakurenOddsHighV
                    exceptLow = wakurenExpectLowV
                    exceptHigh = wakurenExpectHighV
                    bairitu = wakurenPerceV
                    buyCb = wakurenCbV
                    sikibetu = "枠連"
                Case 4
                    oddsDictionary = umarenOddsDictionary
                    percentDictionary = umarenPercentDictionary
                    oddsLow = umarenOddsLowV
                    oddsHigh = umarenOddsHighV
                    exceptLow = umarenExpectLowV
                    exceptHigh = umarenExpectHighV
                    bairitu = umarenPerceV
                    buyCb = umarenCbV
                    sikibetu = "馬連"
                Case 5
                    oddsDictionary = wideOddsDictionary
                    percentDictionary = widePercentDictionary
                    oddsLow = wideOddsLowV
                    oddsHigh = wideOddsHighV
                    exceptLow = wideExpectLowV
                    exceptHigh = wideExpectHighV
                    bairitu = widePerceV
                    buyCb = wideCbV
                    sikibetu = "ワイド"
                Case 6
                    oddsDictionary = umatanOddsDictionary
                    percentDictionary = umatanPercentDictionary
                    oddsLow = umatanOddsLowV
                    oddsHigh = umatanOddsHighV
                    exceptLow = umatanExpectLowV
                    exceptHigh = umatanExpectHighV
                    bairitu = umatanPerceV
                    buyCb = umatanCbV
                    sikibetu = "馬単"
                Case 7
                    oddsDictionary = sanrenpukuOddsDictionary
                    percentDictionary = sanrenpukuPercentDictionary
                    oddsLow = sanrenpukuOddsLowV
                    oddsHigh = sanrenpukuOddsHighV
                    exceptLow = sanrenpukuExpectLowV
                    exceptHigh = sanrenpukuExpectHighV
                    bairitu = sanrenpukuPerceV
                    buyCb = sanrenpukuCbV
                    sikibetu = "3連複"
                Case 8
                    oddsDictionary = sanrentanOddsDictionary
                    percentDictionary = sanrentanPercentDictionary
                    oddsLow = sanrentanOddsLowV
                    oddsHigh = sanrentanOddsHighV
                    exceptLow = sanrentanExpectLowV
                    exceptHigh = sanrentanExpectHighV
                    bairitu = sanrentanPerceV
                    buyCb = sanrentanCbV
                    sikibetu = "3連単"
            End Select

            If isTohyo = "bookers" Then
                bairitu = 50
                exceptHigh = 1000
                exceptLow = bookersExpect
                buyCb = chengeBookers(i)
                oddsLow = 1
                oddsHigh = 999999
            End If

            If buyCb = True Then
                For Each od In oddsDictionary
                    Dim umaban As String = od.Key
                    Dim odds As Double = od.Value
                    Dim except As Double = 0
                    If oddsLow <= odds And oddsHigh >= odds Then
                        Dim percent As Double = 0
                        If percentDictionary.TryGetValue(umaban, percent) = True Then
                            except = odds * percent
                            If exceptLow <= except And exceptHigh >= except Then
                                Dim returnPay As Double = remainingFund * bairitu / 100
                                Dim buyMoney = returnPay / odds
                                buyMoney = Math.Ceiling(buyMoney / 100) * 100
                                If buyMoney < 100 Then
                                    buyMoney = 100
                                End If
                                oddsArray.Add(odds)
                                buyMoneyArray.Add(buyMoney)
                                umabanArray.Add(umaban)
                                sikibetuArray.Add(sikibetu)
                                exceptArray.Add(except)
                                totalBuy += buyMoney
                            End If
                        End If
                    End If
                Next
            End If
        Next i


        Dim bookersArticle As String = ""
        If totalBuy > 0 Then
            Dim sw As New System.IO.StreamWriter("C:\umagen\ipatgo\JRA購入ツール.txt", False, System.Text.Encoding.GetEncoding("shift_jis"))
            For i = 0 To umabanArray.Count - 1
                Dim umaban As String = umabanArray(i)
                Dim buyMoney As Long = buyMoneyArray(i)
                Dim sikibetu As String = sikibetuArray(i)
                Dim iSikibetu As String = getChangeShikibetsuCode(sikibetu)
                iCode = getChangeIpatCode(Code)
                sw.Write(yyyymmdd & "," & iCode & "," & raceNumber & "," & iSikibetu & ",NORMAL,," & umaban & "," & buyMoney & vbCrLf)
                bookersArticle += sikibetu & ":" & umaban & "_" & buyMoney & "円" & vbLf
            Next i
            sw.Close()
            If isTohyo = "bookers" Then
                Return bookersArticle
            End If

            Dim buyHantei As Boolean = False

            If tohyoMode = True Then
                buyHantei = Class_IPAT.IpatgoBuy()

                If buyHantei = False Then
                    totalBuy = 0
                End If

            End If
            Dim tohyoTime As String = Now.ToString("HH:mm:ss")

            Dim area As DataTable = getChangeArea(Code)
            Dim dgvHantei As String
            If buyHantei = False Then
                dgvHantei = "×"
            Else
                dgvHantei = "〇"
            End If
            If tohyoMode = False Then
                dgvHantei = "S"
            End If

            For i = 0 To umabanArray.Count - 1
                area.Rows.Add()
                Dim rowCount As Integer = area.Rows.Count - 1
                Dim lastRow As Integer = area.Rows.Count
                Dim umaban As String = umabanArray(i)
                Dim buyMoney As Long = buyMoneyArray(i)
                Dim odds As Double = oddsArray(i)
                If totalBuy = 0 And tohyoMode = True Then
                    buyMoney = 0
                End If
                Dim sikibetu As String = sikibetuArray(i)
                Dim except As Double = exceptArray(i)
                area.Rows(rowCount)(0) = yyyymmdd
                area.Rows(rowCount)(1) = kaisai
                area.Rows(rowCount)(2) = raceNumber
                area.Rows(rowCount)(3) = sikibetu
                area.Rows(rowCount)(4) = umaban
                area.Rows(rowCount)(5) = odds
                area.Rows(rowCount)(6) = except.ToString("0.00")
                area.Rows(rowCount)(7) = tohyoTime
                area.Rows(rowCount)(8) = dgvHantei
                area.Rows(rowCount)(9) = buyMoney
            Next i
        End If
        If isTohyo = "tohyo" Then
            Return totalBuy
        Else
            Return bookersArticle
        End If
    End Function

    Function WakurenHorsesToFramesCorrect(ByVal numHorses As Integer) As Dictionary(Of Integer, List(Of Integer))
        Dim frames As New Dictionary(Of Integer, List(Of Integer))()
        For i As Integer = 1 To 8
            frames.Add(i, New List(Of Integer)())
        Next

        Dim horseNumber As Integer = 1

        Select Case numHorses
            Case 9
                For i As Integer = 1 To 7
                    frames(i).Add(horseNumber)
                    horseNumber += 1
                Next
                frames(8).AddRange(New Integer() {8, 9})

            Case 10
                For i As Integer = 1 To 6
                    frames(i).Add(horseNumber)
                    horseNumber += 1
                Next
                frames(7).AddRange(New Integer() {7, 8})
                frames(8).AddRange(New Integer() {9, 10})

            Case 11
                For i As Integer = 1 To 5
                    frames(i).Add(horseNumber)
                    horseNumber += 1
                Next
                frames(6).AddRange(New Integer() {6, 7})
                frames(7).AddRange(New Integer() {8, 9})
                frames(8).AddRange(New Integer() {10, 11})

            Case 12
                For i As Integer = 1 To 4
                    frames(i).Add(horseNumber)
                    horseNumber += 1
                Next
                frames(5).AddRange(New Integer() {5, 6})
                frames(6).AddRange(New Integer() {7, 8})
                frames(7).AddRange(New Integer() {9, 10})
                frames(8).AddRange(New Integer() {11, 12})

            Case 13
                For i As Integer = 1 To 3
                    frames(i).Add(horseNumber)
                    horseNumber += 1
                Next
                frames(4).AddRange(New Integer() {4, 5})
                frames(5).AddRange(New Integer() {6, 7})
                frames(6).AddRange(New Integer() {8, 9})
                frames(7).AddRange(New Integer() {10, 11})
                frames(8).AddRange(New Integer() {12, 13})

            Case 14
                For i As Integer = 1 To 2
                    frames(i).Add(horseNumber)
                    horseNumber += 1
                Next
                frames(3).AddRange(New Integer() {3, 4})
                frames(4).AddRange(New Integer() {5, 6})
                frames(5).AddRange(New Integer() {7, 8})
                frames(6).AddRange(New Integer() {9, 10})
                frames(7).AddRange(New Integer() {11, 12})
                frames(8).AddRange(New Integer() {13, 14})

            Case 15
                frames(1).Add(1)
                For i As Integer = 2 To 8
                    frames(i).AddRange(New Integer() {2 * i - 1, 2 * i})
                Next

            Case 16
                For i As Integer = 1 To 8
                    frames(i).AddRange(New Integer() {2 * i - 1, 2 * i})
                Next

            Case 17
                For i As Integer = 1 To 7
                    frames(i).AddRange(New Integer() {2 * i - 1, 2 * i})
                Next
                frames(8).AddRange(New Integer() {15, 16, 17})

            Case 18
                For i As Integer = 1 To 6
                    frames(i).AddRange(New Integer() {2 * i - 1, 2 * i})
                Next
                frames(7).AddRange(New Integer() {13, 14, 15})
                frames(8).AddRange(New Integer() {16, 17, 18})

        End Select

        Return frames
    End Function

End Module
