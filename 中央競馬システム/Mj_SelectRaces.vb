Module SelectRace
    Public dgv
    Public datatime As DateTime
    Public kaisai
    Public iCode
    Public yyyymmdd As String
    Public kaisaiPaturn
    Public hassoTime As DateTime
    Public nowTime As DateTime


    Sub RaceSelect()
        '-3 = python完了 , -2 = 勝率ブログ完了 , -1 = 何もなし(予備)  0 >= 投票待ち , 1 = 結果待ち , 2 = 的中 , 3 = 不的中 , 9 = 初期 , 10 = 投票対象なし
        If Class_MainForm.kaisai1.Text <> "---" Then

            Dim dgvCount As Integer
            Dim hassoUpDate As Boolean = False

            If isPastRace = True Then
                hassoUpDate = True
            End If

            If Class_MainForm.kaisai3.Text = "---" Then
                dgvCount = 2
            Else
                dgvCount = 3
            End If
reStart:
            For i = 1 To dgvCount
                For j = 0 To 11
                    setSelectDgvInfo(i, j)
                    Dim tohyoHantei As Integer = dgv.Rows(j)(1)
                    If tohyoHantei = -3 Or tohyoHantei = -2 Or tohyoHantei = 1 Or tohyoHantei = 9 Or tohyoHantei = -1 Then

                        If dgv.Rows(j)(1) = 9 Then
                            'If pythonCheckCount() = 0 Then


                            Dim pyTime As DateTime = hassoTime.AddMinutes(-pyMinV).AddSeconds(-pySecV)
                            If pyTime < nowTime Then
                                If tohyoMode = False Or isPastRace = True Then
                                    nowTime = hassoTime.AddMinutes(-1)
                                End If
                                If hassoTime > nowTime Then
                                    Dim trackCode As Integer = Class_Jv_Link.getTrackCode()
                                    If trackCode < 50 Then
                                        dgv.Rows(j)(1) = -3
                                        upDateSQLPercent()
                                        tohyoHantei = -3
                                        changeDgvColor()
                                        Exit Sub
                                    Else
                                        dgv.Rows(j)(1) = 10
                                        tohyoHantei = 10
                                        Exit Sub
                                    End If
                                End If
                                setNowTime()
                            End If
                            ' End If
                        End If

                        If isPastRace = False Then
                            If tohyoHantei = -3 Then

                                Dim blogTime As DateTime = hassoTime.AddMinutes(-postHpMinV).AddSeconds(-postHpSecV)
                                If blogTime < nowTime Then
                                    If tohyoMode = False Or isPastRace = True Then
                                        nowTime = hassoTime.AddMinutes(-1)
                                    End If
                                    If hassoTime > nowTime Then
                                        If getTansyoPercent().count > 0 Then
                                            If postHp = True Then
                                                postHpKaime()
                                                dgv.Rows(j)(1) = -2
                                                tohyoHantei = -2
                                                changeDgvColor()
                                            End If
                                            If postHpWinPercent = True Then
                                                If j >= setRaceNum Then

                                                    postHpPercent()
                                                    dgv.Rows(j)(1) = -1
                                                    tohyoHantei = -1
                                                    changeDgvColor()
                                                    Exit Sub
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                                setNowTime()
                            End If
                        End If

                        If tohyoHantei <= 0 Then
                            Dim tohyoStartTime As DateTime = hassoTime.AddMinutes(-tohyoMinV).AddSeconds(-tohyoSecV)
                            If tohyoStartTime < nowTime Then
                                If tohyoMode = False Or isPastRace = True Then
                                    nowTime = hassoTime.AddMinutes(-1)
                                End If
                                If hassoTime > nowTime Then
                                    If hassoUpDate = False And isPastRace = False Then

                                        Class_Jv_Link.getHassoTime()
                                        hassoUpDate = True
                                        GoTo reStart

                                    Else
                                        dgv.rows(raceNumber - 1)(3) = 0
                                        If execute() > 0 Then
                                            tohyoHantei = 1
                                            changeDgvColor()
                                        End If
                                        Exit Sub
                                    End If
                                Else
                                    dgv.Rows(j)(1) = 10
                                    tohyoHantei = 10
                                End If
                            End If
                        End If
                        setNowTime()

                        If tohyoHantei = 1 Then
                            raceNumber = j + 1
                            If raceNumber < 10 Then
                                raceNumberCode = "0" & raceNumber
                            Else
                                raceNumberCode = raceNumber
                            End If
                            dgv.rows(j)(5) = 0
                            Code = getChangeCode(kaisai)
                            Class_Jv_Link.getResult()
                            If tohyoHantei <> 1 Then
                                dgvSave()
                            End If
                            changeDgvColor()
                        End If
                    End If
                Next j
            Next i
        End If
    End Sub

    Sub changeDgvColor()
        Dim dgvC
        For nowDgvCnt = 1 To 3
            If nowDgvCnt = 1 Then
                dgvC = Class_MainForm.dayResultDgv1
            End If
            If nowDgvCnt = 2 Then
                dgvC = Class_MainForm.dayResultDgv2
            End If
            If nowDgvCnt = 3 Then
                dgvC = Class_MainForm.dayResultDgv3
            End If
            For i = 0 To dgvC.rows.count - 2
                Dim dgvIndex = dgvC.rows(i).cells(1).value
                Dim inputColor
                Select Case dgvIndex
                    Case -3
                        inputColor = Color.Pink
                    Case -2
                        inputColor = Color.SkyBlue
                    Case 1
                        inputColor = Color.Red
                    Case 2
                        inputColor = Color.GreenYellow
                    Case 3
                        inputColor = Color.Gray
                    Case Else
                        inputColor = Color.White
                End Select
                If dgvIndex = 2 Or dgvIndex = 3 Then
                    dgvC.rows(i).DefaultCellStyle.backcolor = inputColor
                    dgvC.Rows(i).Cells(1).Style.ForeColor = inputColor
                    dgvC.Rows(i).Cells(0).Style.backColor = inputColor
                Else
                    dgvC.rows(i).cells(0).Style.backcolor = inputColor
                    dgvC.Rows(i).Cells(1).Style.ForeColor = Color.White
                End If
            Next i
            If dgvC.Rows.Count > 0 Then
                dgvC.Rows(dgvC.rows.count - 1).DefaultCellStyle.backcolor = Color.Yellow
            End If
            dgvC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Next nowDgvCnt

    End Sub

    Function pythonCheckCount()
        Dim excuteCheckCount As Integer = 0

        For k = 0 To dayDgvTable1.Rows.Count - 2
            If dayDgvTable1.Rows(k)(1) = -3 Then
                excuteCheckCount += 1
                Return 1
            End If
        Next k
        For k = 0 To dayDgvTable2.Rows.Count - 2
            If dayDgvTable1.Rows(k)(1) = -3 Then
                excuteCheckCount += 1
                Return 1
            End If
        Next k
        For k = 0 To dayDgvTable3.Rows.Count - 2
            If dayDgvTable1.Rows(k)(1) = -3 Then
                excuteCheckCount += 1
                Return 1
            End If
        Next k
        Return excuteCheckCount
    End Function

    Sub setSelectDgvInfo(nowDgvCnt, nowRowCnt)

        If nowDgvCnt = 1 Then
            dgv = dayDgvTable1
            kaisai = Class_MainForm.kaisai1.Text
        End If
        If nowDgvCnt = 2 Then
            dgv = dayDgvTable2
            kaisai = Class_MainForm.kaisai2.Text
        End If
        If nowDgvCnt = 3 Then
            dgv = dayDgvTable3
            kaisai = Class_MainForm.kaisai3.Text
        End If


        kaisai = Split(kaisai, " ")
        kaisai = kaisai(1)
        raceNumber = nowRowCnt + 1
        raceNumberCode = raceNumber.ToString("00")
        Code = getChangeCode(kaisai)
        iCode = getChangeIpatCode(Code)
        setNowTime()
        yyyymmdd = nowTime.ToString("yyyyMMdd")
        raceId = yyyymmdd & Code & raceNumberCode
        Dim nowDate As String = nowTime.ToString("yyyy/M/d")
        hassoTime = nowDate & " " & dgv.rows(nowRowCnt)(2)

    End Sub

    Sub setNowTime()
        If isPastRace = False Then
            nowTime = Now()
        Else
            nowTime = Class_MainForm.DateTimePicker1.Value
            nowTime = New DateTime(nowTime.Year, nowTime.Month, nowTime.Day, 21, 0, 0)
        End If
    End Sub


End Module
