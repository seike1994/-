Module Mj_ChangeKaisaiCode

    Function getChangeCode(cd)
        Select Case cd
            Case "札幌"
                cd = "01"
            Case "函館"
                cd = "02"
            Case "福島"
                cd = "03"
            Case "新潟"
                cd = "04"
            Case "東京"
                cd = "05"
            Case "中山"
                cd = "06"
            Case "中京"
                cd = "07"
            Case "京都"
                cd = "08"
            Case "阪神"
                cd = "09"
            Case "小倉"
                cd = "10"
        End Select
        Return cd
    End Function
    Function getChangeIpatCode(iCode)
        Select Case iCode
            Case "01"
                iCode = "SAPPORO"
            Case "02"
                iCode = "HAKODATE"
            Case "03"
                iCode = "FUKUSHIMA"
            Case "04"
                iCode = "NIIGATA"
            Case "05"
                iCode = "TOKYO"
            Case "06"
                iCode = "NAKAYAMA"
            Case "07"
                iCode = "CHUKYO"
            Case "08"
                iCode = "KYOTO"
            Case "09"
                iCode = "HANSHIN"
            Case "10"
                iCode = "KOKURA"
        End Select
        Return iCode
    End Function

    Function getChangeShikibetsuCode(sikibetu)
        Select Case sikibetu
            Case "単勝"
                sikibetu = "TANSYO"
            Case "複勝"
                sikibetu = "FUKUSYO"
            Case "枠連"
                sikibetu = "WAKUREN"
            Case "馬連"
                sikibetu = "UMAREN"
            Case "ワイド"
                sikibetu = "WIDE"
            Case "馬単"
                sikibetu = "UMATAN"
            Case "3連複"
                sikibetu = "SANRENPUKU"
            Case "3連単"
                sikibetu = "SANRENTAN"
        End Select
        Return sikibetu
    End Function
    Function getChangeKaisai(cd)
        Select Case cd
            Case "01"
                cd = "札幌"
            Case "02"
                cd = "函館"
            Case "03"
                cd = "福島"
            Case "04"
                cd = "新潟"
            Case "05"
                cd = "東京"
            Case "06"
                cd = "中山"
            Case "07"
                cd = "中京"
            Case "08"
                cd = "京都"
            Case "09"
                cd = "阪神"
            Case "10"
                cd = "小倉"
        End Select
        Return cd
    End Function
    Function getChangeArea(cd)
        Select Case cd
            Case "01"
                Return sapporoTable
            Case "02"
                Return hakodateTable
            Case "03"
                Return fukushimaTable
            Case "04"
                Return niigataTable
            Case "05"
                Return tokyoTable
            Case "06"
                Return nakayamaTable
            Case "07"
                Return chukyoTable
            Case "08"
                Return kyotoTable
            Case "09"
                Return hanshinTable
            Case "10"
                Return kokuraTable
        End Select
        Return cd
    End Function

End Module
