Module Mj_Result
    Public totalPayMoney As Long
    Sub setResult(Henkanflag, HenkanUmabanArray, tansyoPayDictionary, fukusyoPayDictionary, wakurenPayDictionary,
                                    umarenPayDictionary, widePayDictionary, umatanPayDictionary, sanrenpukuPayDictionary, sanrentanPayDictionary)


        '的中の検索、dgv記載をしていく


        Dim pay
        Dim umaban
        Dim sikibetu = ""
        Dim area As DataTable = getChangeArea(Code)
        dgvSave()
        kaisai = getChangeKaisai(Code)
        totalPayMoney = 0

        For Each tansyo In tansyoPayDictionary
            umaban = tansyo.Key
            pay = tansyo.value
            areaDgvWriteResult("単勝", umaban, pay)
        Next

        For Each fukusyo In fukusyoPayDictionary
            umaban = fukusyo.Key
            pay = fukusyo.value
            areaDgvWriteResult("複勝", umaban, pay)
        Next

        For Each wakuren In wakurenPayDictionary
            umaban = wakuren.Key
            pay = wakuren.value
            areaDgvWriteResult("枠連", umaban, pay)
        Next

        For Each umaren In umarenPayDictionary
            umaban = umaren.Key
            pay = umaren.value
            areaDgvWriteResult("馬連", umaban, pay)
        Next

        For Each wide In widePayDictionary
            umaban = wide.Key
            pay = wide.value
            areaDgvWriteResult("ワイド", umaban, pay)
        Next

        For Each umatan In umatanPayDictionary
            umaban = umatan.Key
            pay = umatan.value
            areaDgvWriteResult("馬単", umaban, pay)
        Next

        For Each sanrenpuku In sanrenpukuPayDictionary
            umaban = sanrenpuku.Key
            pay = sanrenpuku.value
            areaDgvWriteResult("3連複", umaban, pay)
        Next

        For Each sanrentan In sanrentanPayDictionary
            umaban = sanrentan.Key
            pay = sanrentan.value
            areaDgvWriteResult("3連単", umaban, pay)
        Next

        If Henkanflag = 1 Then
            henkanAreaDgvWriteResult(HenkanUmabanArray)
        End If

        If totalPayMoney > 0 Then
            dgv.rows(raceNumber - 1)(1) = 2
            Dim lineMsg As String = Now & vbLf & kaisai & raceNumber & "R 的中しました"
            If postHit = True Then
                postLine(lineMsg)
            End If
        Else
            dgv.rows(raceNumber - 1)(1) = 3
        End If
        Dim dgvTotalPay As Long = dgv.rows(12)(4)
        dgv.rows(12)(4) = dgvTotalPay + totalPayMoney
        remainingFund += totalPayMoney
        dayDgvWriteResult(totalPayMoney)
        writeTopDgvTotal()
    End Sub

    Sub writeTopDgvTotal()
        Dim dgvTotalBuy As Long = dgv.rows(12)(3)
        Dim dgvTotalPay As Long = dgv.rows(12)(4)

        dgv.rows(12)(5) = dgvTotalPay - dgvTotalBuy
        Dim raceRecoveryRate As Double = 0
        raceRecoveryRate = (dgvTotalPay / dgvTotalBuy) * 100
        raceRecoveryRate = Math.Ceiling(raceRecoveryRate)
        dgv.rows(12)(6) = Str(raceRecoveryRate) & "%"
    End Sub

    Sub areaDgvWriteResult(sikibetu, umaban, pay)
        Dim area = getChangeArea(Code)
        Dim dateTime As String
        If isPastRace = True Then
            dateTime = Class_MainForm.DateTimePicker1.Value.ToString("yyyyMMdd")
        Else
            dateTime = Now.ToString("yyyyMMdd")
        End If
        For i = 0 To area.rows.count - 1
            Dim areaDate = area.rows(i)(0)
            If IsDBNull(area.Rows(i)(0)) Then
                Continue For
            End If
            If areaDate = "" Then
                Continue For
            End If
            Dim areaRaceNum = area.rows(i)(2)
            Dim areaSikibetu = area.rows(i)(3)
            Dim areaUmaban = area.rows(i)(4)
            If areaDate = dateTime And areaRaceNum = raceNumber And areaSikibetu = sikibetu And areaUmaban = umaban Then
                Dim buyMoney = area.rows(i)(9)
                Dim payMoney As Long = (pay * buyMoney) / 100
                area.rows(i)(10) = payMoney
                totalPayMoney += payMoney
            End If
        Next
    End Sub

    Sub dayDgvWriteResult(totalPayMoney)
        Dim buyMoney As Long = dgv.rows(raceNumber - 1)(3)
        dgv.rows(raceNumber - 1)(4) = totalPayMoney
        dgv.rows(raceNumber - 1)(5) = (totalPayMoney - buyMoney)
        Dim raceRecoveryRate As Double = 0
        raceRecoveryRate = (totalPayMoney / buyMoney) * 100
        raceRecoveryRate = Math.Ceiling(raceRecoveryRate)

        dgv.rows(raceNumber - 1)(6) = Str(raceRecoveryRate) & "%"


    End Sub

    Sub henkanAreaDgvWriteResult(henkanUmabanArray)
        Dim area = getChangeArea(Code)
        Dim dateTime As String
        If isPastRace = True Then
            dateTime = Class_MainForm.DateTimePicker1.Value.ToString("yyyyMMdd")
        Else
            dateTime = Now.ToString("yyyyMMdd")
        End If
        For i = 0 To henkanUmabanArray.count - 1
            Dim umaban = henkanUmabanArray(i)
            For j = 0 To area.rows.count - 1
                Dim areaDate = area.rows(j)(0)
                If IsDBNull(area.Rows(j)(0)) Then
                    Continue For
                End If
                If areaDate = "" Then
                    Continue For
                End If
                Dim areaRaceNum = area.rows(j)(2)
                Dim areaSikibetu = area.rows(j)(3)
                Dim areaUmaban = area.rows(j)(4)
                If areaDate = dateTime And areaRaceNum = raceNumber And InStr(areaUmaban, umaban) > 0 Then
                    Dim buyMoney = area.rows(j)(9)
                    Dim payMoney As Long = buyMoney
                    area.rows(j)(10) = payMoney
                    totalPayMoney += payMoney
                End If
            Next j
        Next i
    End Sub
End Module
