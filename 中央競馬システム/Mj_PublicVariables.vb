Imports System.IO

Module Mj_PublicVariables

    '--------------------------SQL & SNS----------------------------------
    Public localHost As String
    Public localUser As String
    Public localPw As String
    Public localDb As String
    Public awsHost As String
    Public awsPort As String
    Public awsUser As String
    Public awsPw As String
    Public awsDb As String
    Public localConnStr As String
    Public awsConnStr As String

    Public LineToken As String
    Public HpUrl As String
    Public BookersToken As String
    Public xUserId As String
    Public xApiKey As String
    Public xApiKeyS As String
    Public xAccessToken As String
    Public xAccessTokenS As String
    Public xBearerToken As String

    '--------------------------DGV----------------------------------
    Public nowPath As String = Directory.GetCurrentDirectory()
    Public allDayPath As String = nowPath & "\dgv\allDay.txt"
    Public allAreaPath As String = nowPath & "\dgv\allArea.txt"
    Public dayDgvPath1 As String = nowPath & "\dgv\dayDgv1.txt"
    Public dayDgvPath2 As String = nowPath & "\dgv\dayDgv2.txt"
    Public dayDgvPath3 As String = nowPath & "\dgv\dayDgv3.txt"
    Public sapporoPath As String = nowPath & "\dgv\sapporoArea.txt"
    Public hakodatePath As String = nowPath & "\dgv\hakodateArea.txt"
    Public fukushimaPath As String = nowPath & "\dgv\fukushimaArea.txt"
    Public niigataPath As String = nowPath & "\dgv\niigataArea.txt"
    Public tokyoPath As String = nowPath & "\dgv\tokyoArea.txt"
    Public nakayamaPath As String = nowPath & "\dgv\nakayamaArea.txt"
    Public chukyoPath As String = nowPath & "\dgv\chukyoArea.txt"
    Public kyotoPath As String = nowPath & "\dgv\kyotoArea.txt"
    Public hanshinPath As String = nowPath & "\dgv\hanshinArea.txt"
    Public kokuraPath As String = nowPath & "\dgv\kokuraArea.txt"

    Public allDayTable As DataTable
    Public allAreaTable As DataTable
    Public sapporoTable As DataTable
    Public hakodateTable As DataTable
    Public fukushimaTable As DataTable
    Public niigataTable As DataTable
    Public tokyoTable As DataTable
    Public nakayamaTable As DataTable
    Public chukyoTable As DataTable
    Public kyotoTable As DataTable
    Public hanshinTable As DataTable
    Public kokuraTable As DataTable
    Public dayDgvTable1 As DataTable
    Public dayDgvTable2 As DataTable
    Public dayDgvTable3 As DataTable
    '---------------------------------------------------------------



    '-----------MainForm----------------
    Public dayTotalBuy As Long
    Public dayTotalPay As Long
    Public dayTotalBalance As Long
    Public dayTotalParse As Double

    '-----------------------------------


    '----------Jv_Link------------------
    Public tansyoOddsArray As ArrayList
    Public tansyoUmabanArray As ArrayList
    Public tansyoNinkiArray As ArrayList
    Public fukusyoOddsArray As ArrayList
    Public fukusyoUmabanArray As ArrayList
    Public fukusyoNinkiArray As ArrayList
    Public wakurenOddsArray As ArrayList
    Public wakurenUmabanArray As ArrayList
    Public wakurenNinkiArray As ArrayList
    Public wideOddsArray As ArrayList
    Public wideUmabanArray As ArrayList
    Public wideNinkiArray As ArrayList
    Public umarenOddsArray As ArrayList
    Public umarenUmabanArray As ArrayList
    Public umarenNinkiArray As ArrayList
    Public umatanOddsArray As ArrayList
    Public umatanUmabanArray As ArrayList
    Public umatanNinkiArray As ArrayList
    Public sanrenpukuOddsArray As ArrayList
    Public sanrenpukuUmabanArray As ArrayList
    Public sanrenpukuNinkiArray As ArrayList
    Public sanrentanOddsArray As ArrayList
    Public sanrentanUmabanArray As ArrayList
    Public sanrentanNinkiArray As ArrayList
    '-------------------------------------


    '------------tohyoSetting-------------
    Public minPercent As Double = 1
    Public setRaceNum As Integer = 1
    Public remainingFund As Long = 0

    Public tohyoMode As Boolean

    Public tansyoCbV As Boolean
    Public tansyoExpectLowV As Double = 1
    Public tansyoExpectHighV As Double = 1
    Public tansyoOddsLowV As Double = 1
    Public tansyoOddsHighV As Double = 1
    Public tansyoPerceV As Double = 1

    Public fukusyoCbV As Boolean
    Public fukusyoExpectLowV As Double = 1
    Public fukusyoExpectHighV As Double = 1
    Public fukusyoOddsLowV As Double = 1
    Public fukusyoOddsHighV As Double = 1
    Public fukusyoPerceV As Double = 1

    Public wakurenCbV As Boolean
    Public wakurenExpectLowV As Double = 1
    Public wakurenExpectHighV As Double = 1
    Public wakurenOddsLowV As Double = 1
    Public wakurenOddsHighV As Double = 1
    Public wakurenPerceV As Double = 1

    Public umarenCbV As Boolean
    Public umarenExpectLowV As Double = 1
    Public umarenExpectHighV As Double = 1
    Public umarenOddsLowV As Double = 1
    Public umarenOddsHighV As Double = 1
    Public umarenPerceV As Double = 1

    Public wideCbV As Boolean
    Public wideExpectLowV As Double = 1
    Public wideExpectHighV As Double = 1
    Public wideOddsLowV As Double = 1
    Public wideOddsHighV As Double = 1
    Public widePerceV As Double = 1

    Public umatanCbV As Boolean
    Public umatanExpectLowV As Double = 1
    Public umatanExpectHighV As Double = 1
    Public umatanOddsLowV As Double = 1
    Public umatanOddsHighV As Double = 1
    Public umatanPerceV As Double = 1

    Public sanrenpukuCbV As Boolean
    Public sanrenpukuExpectLowV As Double = 1
    Public sanrenpukuExpectHighV As Double = 1
    Public sanrenpukuOddsLowV As Double = 1
    Public sanrenpukuOddsHighV As Double = 1
    Public sanrenpukuPerceV As Double = 1

    Public sanrentanCbV As Boolean
    Public sanrentanExpectLowV As Double = 1
    Public sanrentanExpectHighV As Double = 1
    Public sanrentanOddsLowV As Double = 1
    Public sanrentanOddsHighV As Double = 1
    Public sanrentanPerceV As Double = 1

    Public postHp As Boolean
    Public postXis As Boolean
    Public postBks As Boolean
    Public postEr As Boolean
    Public postBuy As Boolean
    Public postHit As Boolean
    Public postBksLine As Boolean
    Public postHpWinPercent As Boolean

    Public bTansyo As Boolean
    Public bookersExpect As Double = 1
    Public bFukusyo As Boolean
    Public bWakuren As Boolean
    Public bUmaren As Boolean
    Public bWide As Boolean
    Public bUmatan As Boolean
    Public bSanrenpuku As Boolean
    Public bSanrentan As Boolean
    Public bTohyoCountV As Integer = 1

    Public pyMinV As Integer = 1
    Public pySecV As Integer = 1
    Public tohyoMinV As Integer = 1
    Public tohyoSecV As Integer = 1
    Public postHpMinV As Integer = 1
    Public postHpSecV As Integer = 1
    Public postBksMinV As Integer = 1
    Public postBksSecV As Integer = 1


    '------------IPAT-------------------
    Public inetId As String
    Public kanyusyaNum As String
    Public secretNum As String
    Public pars As String
    Public inMoney As Long
    Public autoInMoney As Long = 100
    Public autoNyukin As Boolean
    Public zandaka As Long


    '----------レース中-----------------
    Public Code As String
    Public raceNumber As Integer
    Public raceNumberCode As String
    Public raceId As String
    Public isPastRace As Boolean = False
    '-----------------------------------

    '------------ログ--------------------
    Public logTxt As String
    '------------------------------------


    Sub mySettingLoad()

        '------------MainForm-----------------

        Class_MainForm.kaisai1.Text = My.Settings.kaisai1
        Class_MainForm.kaisai2.Text = My.Settings.kaisai2
        Class_MainForm.kaisai3.Text = My.Settings.kaisai3
        Class_MainForm.kaisai1Day.Text = My.Settings.kaisai1Day
        Class_MainForm.kaisai2Day.Text = My.Settings.kaisai2Day
        Class_MainForm.kaisai3Day.Text = My.Settings.kaisai3Day



        '------------tohyoSetting-------------
        postHpWinPercent = My.Settings.postHpWinPercent
        setRaceNum = My.Settings.setRaceNum
        minPercent = My.Settings.minPercent

        remainingFund = My.Settings.remainingFunds

        tohyoMode = My.Settings.tohyoMode

        tansyoCbV = My.Settings.tansyoCbV
        tansyoExpectLowV = My.Settings.tansyoExpectLowV
        tansyoExpectHighV = My.Settings.tansyoExpectHighV
        tansyoOddsLowV = My.Settings.tansyoOddsLowV
        tansyoOddsHighV = My.Settings.tansyoOddsHighV
        tansyoPerceV = My.Settings.tansyoParseV

        fukusyoCbV = My.Settings.fukusyoCbV
        fukusyoExpectLowV = My.Settings.fukusyoExpectLowV
        fukusyoExpectHighV = My.Settings.fukusyoExpectHighV
        fukusyoOddsLowV = My.Settings.fukusyoOddsLowV
        fukusyoOddsHighV = My.Settings.fukusyoOddsHighV
        fukusyoPerceV = My.Settings.fukusyoParseV

        wakurenCbV = My.Settings.wakurenCbV
        wakurenExpectLowV = My.Settings.wakurenExpectLowV
        wakurenExpectHighV = My.Settings.wakurenExpectHighV
        wakurenOddsLowV = My.Settings.wakurenOddsLowV
        wakurenOddsHighV = My.Settings.wakurenOddsHighV
        wakurenPerceV = My.Settings.wakurenParseV

        umarenCbV = My.Settings.umarenCbV
        umarenExpectLowV = My.Settings.umarenExpectLowV
        umarenExpectHighV = My.Settings.umarenExpectHighV
        umarenOddsLowV = My.Settings.umarenOddsLowV
        umarenOddsHighV = My.Settings.umarenOddsHighV
        umarenPerceV = My.Settings.umarenParseV

        wideCbV = My.Settings.wideCbV
        wideExpectLowV = My.Settings.wideExpectLowV
        wideExpectHighV = My.Settings.wideExpectHighV
        wideOddsLowV = My.Settings.wideOddsLowV
        wideOddsHighV = My.Settings.wideOddsHighV
        widePerceV = My.Settings.wideParseV

        umatanCbV = My.Settings.umatanCbV
        umatanExpectLowV = My.Settings.umatanExpectLowV
        umatanExpectHighV = My.Settings.umatanExpectHighV
        umatanOddsLowV = My.Settings.umatanOddsLowV
        umatanOddsHighV = My.Settings.umatanOddsHighV
        umatanPerceV = My.Settings.umatanParseV

        sanrenpukuCbV = My.Settings.sanrenpukuCbV
        sanrenpukuExpectLowV = My.Settings.sanrenpukuExpectLowV
        sanrenpukuExpectHighV = My.Settings.sanrenpukuExpectHighV
        sanrenpukuOddsLowV = My.Settings.sanrenpukuOddsLowV
        sanrenpukuOddsHighV = My.Settings.sanrenpukuOddsHighV
        sanrenpukuPerceV = My.Settings.sanrenpukuParseV

        sanrentanCbV = My.Settings.sanrentanCbV
        sanrentanExpectLowV = My.Settings.sanrentanExpectLowV
        sanrentanExpectHighV = My.Settings.sanrentanExpectHighV
        sanrentanOddsLowV = My.Settings.sanrentanOddsLowV
        sanrentanOddsHighV = My.Settings.sanrentanOddsHighV
        sanrentanPerceV = My.Settings.sanrentanParseV

        postHp = My.Settings.postHp
        postXis = My.Settings.postX
        postBks = My.Settings.postBks
        postEr = My.Settings.postEr
        postBuy = My.Settings.postBuy
        postHit = My.Settings.postHit
        postBksLine = My.Settings.postBksLine

        bTansyo = My.Settings.bTansyo
        bFukusyo = My.Settings.bFukusyo
        bWakuren = My.Settings.bWakuren
        bUmaren = My.Settings.bUmaren
        bWide = My.Settings.bWide
        bUmatan = My.Settings.bUmatan
        bSanrenpuku = My.Settings.bSanrenpuku
        bSanrentan = My.Settings.bSanrentan
        bTohyoCountV = My.Settings.bTohyoCountV

        pyMinV = My.Settings.pyMinV
        pySecV = My.Settings.pySecV
        tohyoMinV = My.Settings.tohyoMinV
        tohyoSecV = My.Settings.tohyoSecV
        postHpMinV = My.Settings.postHpMinV
        postHpSecV = My.Settings.postHpSecV
        postBksMinV = My.Settings.postBksMinV
        postBksSecV = My.Settings.postBksSecV

        '------------IPAT-------------------
        inetId = My.Settings.inetId
        kanyusyaNum = My.Settings.kanyusyaNum
        secretNum = My.Settings.secretNum
        pars = My.Settings.pars
        inMoney = My.Settings.inMoney
        autoInMoney = My.Settings.autoInMoney
        autoNyukin = My.Settings.autoNyukin
        zandaka = My.Settings.zandaka

        '------------ログ--------------------
        logTxt = My.Settings.logTxt

        '-----------ユーザー設定-------------
        ' 変数の宣言を省略して、設定値を直接使用
        localHost = My.Settings.localHost
        localUser = My.Settings.localUser
        localPw = My.Settings.localPw
        localDb = My.Settings.localDb
        awsHost = My.Settings.awsHost
        awsPort = My.Settings.awsPort
        awsUser = My.Settings.awsUser
        awsPw = My.Settings.awsPw
        awsDb = My.Settings.awsDb
        LineToken = My.Settings.LineToken
        HpUrl = My.Settings.HpUrl
        BookersToken = My.Settings.BookersToken
        xUserId = My.Settings.xUserId
        xApiKey = My.Settings.xApiKey
        xApiKeyS = My.Settings.xApiKeyS
        xAccessToken = My.Settings.xAccessToken
        xAccessTokenS = My.Settings.xAccessTokenS
        xBearerToken = My.Settings.xBearerToken
        localConnStr = "Host=" & localHost & ";Username=" & localUser & ";Password=" & localPw & ";Database=" & localDb
        awsConnStr = "Host=" & awsHost & ";Port=" & awsPort & ";Username=" & awsUser & ";Password=" & awsPw & ";Database=" & awsDb


    End Sub

    Sub mySettingSave()

        My.Settings.kaisai1 = Class_MainForm.kaisai1.Text
        My.Settings.kaisai2 = Class_MainForm.kaisai2.Text
        My.Settings.kaisai3 = Class_MainForm.kaisai3.Text
        My.Settings.kaisai1Day = Class_MainForm.kaisai1Day.Text
        My.Settings.kaisai2Day = Class_MainForm.kaisai2Day.Text
        My.Settings.kaisai3Day = Class_MainForm.kaisai3Day.Text


        My.Settings.remainingFunds = remainingFund

        My.Settings.tohyoMode = tohyoMode

        My.Settings.tansyoCbV = tansyoCbV
        My.Settings.tansyoExpectLowV = tansyoExpectLowV
        My.Settings.tansyoExpectHighV = tansyoExpectHighV
        My.Settings.tansyoOddsLowV = tansyoOddsLowV
        My.Settings.tansyoOddsHighV = tansyoOddsHighV
        My.Settings.tansyoParseV = tansyoPerceV

        My.Settings.fukusyoCbV = fukusyoCbV
        My.Settings.fukusyoExpectLowV = fukusyoExpectLowV
        My.Settings.fukusyoExpectHighV = fukusyoExpectHighV
        My.Settings.fukusyoOddsLowV = fukusyoOddsLowV
        My.Settings.fukusyoOddsHighV = fukusyoOddsHighV
        My.Settings.fukusyoParseV = fukusyoPerceV

        My.Settings.wakurenCbV = wakurenCbV
        My.Settings.wakurenExpectLowV = wakurenExpectLowV
        My.Settings.wakurenExpectHighV = wakurenExpectHighV
        My.Settings.wakurenOddsLowV = wakurenOddsLowV
        My.Settings.wakurenOddsHighV = wakurenOddsHighV
        My.Settings.wakurenParseV = wakurenPerceV

        My.Settings.umarenCbV = umarenCbV
        My.Settings.umarenExpectLowV = umarenExpectLowV
        My.Settings.umarenExpectHighV = umarenExpectHighV
        My.Settings.umarenOddsLowV = umarenOddsLowV
        My.Settings.umarenOddsHighV = umarenOddsHighV
        My.Settings.umarenParseV = umarenPerceV

        My.Settings.wideCbV = wideCbV
        My.Settings.wideExpectLowV = wideExpectLowV
        My.Settings.wideExpectHighV = wideExpectHighV
        My.Settings.wideOddsLowV = wideOddsLowV
        My.Settings.wideOddsHighV = wideOddsHighV
        My.Settings.wideParseV = widePerceV

        My.Settings.umatanCbV = umatanCbV
        My.Settings.umatanExpectLowV = umatanExpectLowV
        My.Settings.umatanExpectHighV = umatanExpectHighV
        My.Settings.umatanOddsLowV = umatanOddsLowV
        My.Settings.umatanOddsHighV = umatanOddsHighV
        My.Settings.umatanParseV = umatanPerceV

        My.Settings.sanrenpukuCbV = sanrenpukuCbV
        My.Settings.sanrenpukuExpectLowV = sanrenpukuExpectLowV
        My.Settings.sanrenpukuExpectHighV = sanrenpukuExpectHighV
        My.Settings.sanrenpukuOddsLowV = sanrenpukuOddsLowV
        My.Settings.sanrenpukuOddsHighV = sanrenpukuOddsHighV
        My.Settings.sanrenpukuParseV = sanrenpukuPerceV

        My.Settings.sanrentanCbV = sanrentanCbV
        My.Settings.sanrentanExpectLowV = sanrentanExpectLowV
        My.Settings.sanrentanExpectHighV = sanrentanExpectHighV
        My.Settings.sanrentanOddsLowV = sanrentanOddsLowV
        My.Settings.sanrentanOddsHighV = sanrentanOddsHighV
        My.Settings.sanrentanParseV = sanrentanPerceV

        My.Settings.postHp = postHp
        My.Settings.postX = postXis
        My.Settings.postBks = postBks
        My.Settings.postEr = postEr
        My.Settings.postBuy = postBuy
        My.Settings.postHit = postHit
        My.Settings.postBksLine = postBksLine
        My.Settings.postHpWinPercent = postHpWinPercent
        My.Settings.setRaceNum = setRaceNum
        My.Settings.minPercent = minPercent

        My.Settings.bTansyo = bTansyo
        My.Settings.bFukusyo = bFukusyo
        My.Settings.bWakuren = bWakuren
        My.Settings.bUmaren = bUmaren
        My.Settings.bWide = bWide
        My.Settings.bUmatan = bUmatan
        My.Settings.bSanrenpuku = bSanrenpuku
        My.Settings.bSanrentan = bSanrentan
        My.Settings.bTohyoCountV = bTohyoCountV

        My.Settings.pyMinV = pyMinV
        My.Settings.pySecV = pySecV
        My.Settings.tohyoMinV = tohyoMinV
        My.Settings.tohyoSecV = tohyoSecV
        My.Settings.postHpMinV = postHpMinV
        My.Settings.postHpSecV = postHpSecV
        My.Settings.postBksMinV = postBksMinV
        My.Settings.postBksSecV = postBksSecV

        '------------IPAT-------------------
        My.Settings.inetId = inetId
        My.Settings.kanyusyaNum = kanyusyaNum
        My.Settings.secretNum = secretNum
        My.Settings.pars = pars
        My.Settings.inMoney = inMoney
        My.Settings.autoInMoney = autoInMoney
        My.Settings.autoNyukin = autoNyukin
        My.Settings.zandaka = zandaka

        '------------ログ--------------------
        My.Settings.logTxt = logTxt



        My.Settings.localHost = localHost
        My.Settings.localUser = localUser
        My.Settings.localPw = localPw
        My.Settings.localDb = localDb
        My.Settings.awsHost = awsHost
        My.Settings.awsPort = awsPort
        My.Settings.awsUser = awsUser
        My.Settings.awsPw = awsPw
        My.Settings.awsDb = awsDb
        My.Settings.LineToken = LineToken
        My.Settings.HpUrl = HpUrl
        My.Settings.BookersToken = BookersToken
        My.Settings.xUserId = xUserId
        My.Settings.xApiKey = xApiKey
        My.Settings.xApiKeyS = xApiKeyS
        My.Settings.xAccessToken = xAccessToken
        My.Settings.xAccessTokenS = xAccessTokenS
        My.Settings.xBearerToken = xBearerToken


    End Sub

End Module