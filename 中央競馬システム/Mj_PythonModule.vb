
Imports Npgsql



Module Mj_PythonModule
    Sub setPyDataForSQLWait(raceId)
        Dim process As New Process()
        process.StartInfo.FileName = "C:\Users\Admin\anaconda3\python.exe"
        process.StartInfo.Arguments = "C:\Users\Admin\Desktop\Python\jra\Main_RaceYoso.py " & raceId
        process.Start()

        ' バックグラウンドスレッドで実行
        Dim myTask = Task.Run(Sub() process.WaitForExit())
        myTask.Wait() ' この行で待機
    End Sub
    Sub setPyDataForSQL(raceId)
        Dim process As New Process()
        process.StartInfo.FileName = "C:\Users\Admin\anaconda3\python.exe"
        process.StartInfo.Arguments = "C:\Users\Admin\Desktop\Python\jra\Main_RaceYoso.py " & raceId
        process.Start()
    End Sub

    Function getTansyoPercentAll()
        Dim tansyoPercentDictionary As Dictionary(Of Integer, Double) = getTansyoPercent()
        If tansyoPercentDictionary.Count = 0 Then
            Class_Jv_Link.UpdateJvRaceData() 'Jv_Linkからリアルタイムデータを取得しデータベースが更新される
            setPyDataForSQLWait(raceId) ' Main_RaceYoso.pyでtansyo_percentテーブルがアップデートされる
            tansyoPercentDictionary = getTansyoPercent()
        End If
        Return tansyoPercentDictionary
    End Function

    Sub pythonAllBookers(race_id)
        Dim process As New Process()
        process.StartInfo.FileName = "C:\Users\Admin\anaconda3\envs\tf\python.exe"
        process.StartInfo.Arguments = "C:\Users\Admin\Desktop\Python\jra\Main_AllYoso_Bookers.py " & race_id
        process.Start()

        ' バックグラウンドスレッドで実行
        Dim myTask = Task.Run(Sub() process.WaitForExit())
        myTask.Wait() ' この行で待機
    End Sub

    Sub upDateSQLPercent()
        Dim tansyoPercentDictionary As Dictionary(Of Integer, Double) = getTansyoPercent()
        If tansyoPercentDictionary.Count = 0 Then
            Class_Jv_Link.UpdateJvRaceData()
            setPyDataForSQL(raceId)
        End If
    End Sub

    Function getTansyoPercent()
        Using conn As New NpgsqlConnection(localConnStr)
            Dim tansyoPercentDictionary As Dictionary(Of Integer, Double) = New Dictionary(Of Integer, Double)
            ' データベース接続の開始
            conn.Open()
            Dim sql As New NpgsqlCommand("SELECT * FROM tansyo_percent WHERE race_id = @raceId LIMIT 1", conn)
            sql.Parameters.AddWithValue("@raceId", CLng(raceId))
            Using reader As NpgsqlDataReader = sql.ExecuteReader()
                If reader.Read() Then
                    Dim ijoDataDictionary As Dictionary(Of Integer, Integer) = Class_Jv_Link.getIjyoData()
                    For i = 1 To 18
                        If Not reader.IsDBNull(i) Then
                            Dim percent As Double = 0
                            Try
                                Dim ijoCheck As Integer = ijoDataDictionary(i)
                                If ijoCheck = 0 Or ijoCheck = 4 Then
                                    percent = reader.GetDouble(i)
                                End If
                            Catch
                                percent = 0
                            End Try
                            tansyoPercentDictionary.Add(i, percent)
                        End If
                    Next i
                    Dim totalPercent As Double = tansyoPercentDictionary.Sum(Function(item) item.Value)
                    For Each key As Integer In tansyoPercentDictionary.Keys.ToList()
                        tansyoPercentDictionary(key) = (tansyoPercentDictionary(key) / totalPercent)
                    Next
                Else
                    reader.Close()
                    conn.Close()
                    Return tansyoPercentDictionary
                End If
                reader.Close()
            End Using
            conn.Close()
            Return tansyoPercentDictionary
        End Using
    End Function

End Module
