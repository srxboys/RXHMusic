
'
'酷猫播放器
'       title：图标定义
'              数据库的外部引用
'              设置选项的应用、确定 按钮实现事件的修改数据库
'
'       作者:srxboys
'       日期：20140723


Module Module1

    '定义窗口在任务栏上的图标
    Public ico As New Icon(Application.StartupPath + "\Skin\music.ico", 32, 32)

    Public pictureBox8_sound_state As Integer = 0  'form1  中的  是否为静音（1为静音）
    Public pictureBox3_play_state As Integer = 0  'form1  是否正在  播放/暂停
    Public label37_desk As Integer = 0  '歌词显示0/关闭1

    Public DeskMusic_state As Integer = 0   '桌面歌词是否关闭

    '数据库 access
    'Public myconn As New OleDbConnection("provider=Microsoft.jet.oledb.4.0;" & "Data Source='" & Application.StartupPath & "\kmplay.mdb" & "'")

    Public Setting_boolean As Boolean = False

    Public lrc_name As String

    Public a(100) As String '每一行的歌词
    Public b(100) As Integer '每一行的长度
    Public c(100) As Integer '每一行的开头时间

    Public d(100) As Integer  '商
    Public e(100) As Integer  '余数

    Public lrc_index As Integer = 0  '歌词行数

    '////////////////////////////////////////////////////////局部变量
    Dim i, j As Integer


    '读取文件歌词
    Public Sub GetWord(ByVal path As String, ByVal WordList As ListBox, ByVal TimeList As ListBox)
        Dim m As Double
        Dim word As String
        Dim S As Integer
        Dim E As Integer
        Dim number As Integer

        Try
            If path <> "" Then
                FileOpen(1, path, OpenMode.Input)  '打开文件
                Do Until EOF(1)      '使用Do Until语句和EOF函数来确定是否读到了文件内容的最后，如果读到最后则跳出循环
                    word = LineInput(1)    '使用LineInput函数为Line变量赋值
                    If word <> "" Then
                        If Asc(Mid(word, 2, 1)) > 60 Then
                            If Mid(word, 5, InStr(word, "]") - 5) <> "" Then
                                WordList.Items.Add(Mid(word, 5, InStr(word, "]") - 5))
                                Form1.ListBox2.Items.Add(Mid(word, 5, InStr(word, "]") - 5))

                                TimeList.Items.Add(Trim(Str(0)))
                                Form1.ListBox3.Items.Add(Trim(Str(0)))
                            End If
                        Else
                            S = 1
                            E = 1
                            Do While S <> 0
                                E = InStr(S, word, "]")
                                m = Val(Mid(word, S + 1, 2)) * 60 + Val(Mid(word, S + 4, E - S - 4))
                                number = InsertNum(m, TimeList)
                                TimeList.Items.Insert(number, Trim(Str(m)))
                                Form1.ListBox3.Items.Insert(number, Trim(Str(m)))
                                If Sentence(word) <> "" Then
                                    WordList.Items.Insert(number, Sentence(word))
                                    Form1.ListBox2.Items.Insert(number, Sentence(word))
                                Else
                                    WordList.Items.Insert(number, "☆☆")
                                    Form1.ListBox2.Items.Insert(number, "☆☆")
                                End If
                                S = InStr(E, word, "[")
                            Loop
                        End If

                    End If
                Loop
                FileClose()

                DeskMusic.Timer5.Enabled = True
                'Form1.Timer5.Enabled = True

                Form1.gc_show()
            End If
        Catch ex As Exception
            FileClose()
            DeskMusic.Timer5.Enabled = False
            Form1.Timer5.Enabled = False
            ReportError(ex)
        End Try

    End Sub
    '提取某句歌词
    Public Function Sentence(ByVal word As String) As String
        Dim Result As String = ""
        Try
            Dim n As Integer
            n = 1
            Do While (1)
                n = InStr(n + 1, word, "]")
                If InStr(n + 1, word, "]") = 0 Then
                    Result = Trim(Mid(word, n + 1))
                    Exit Do
                End If
            Loop
        Catch ex As Exception
            ReportError(ex)
        End Try
        Return Result
    End Function

    '插入位置
    Public Function InsertNum(ByVal length As Double, ByVal list As ListBox) As Integer

        If Val(list.Items(list.Items.Count - 1)) <= length Then InsertNum = list.Items.Count : Exit Function
        For i = 2 To list.Items.Count - 1
            If length < Val(list.Items(i)) Then
                InsertNum = i
                Exit For
            End If
        Next
    End Function

    Public Function StrReplace(ByVal CurrentString As String, ByVal SearchString As String, ByVal ReplaceWith As String) As String

        Dim result As String = ""
        result = Replace(CurrentString, SearchString, ReplaceWith, 1, -1, 0)
        Return result
        'Replace(expression, find, ReplaceWith[, start[, count[, compare]]])
        'Replace函数语法有如下几部分：

        '部分 描述 
        'expression 必需的。字符串表达式， 包含要替换的子字符串。 
        'find 必需的。要搜索到的子字符串。 
        'ReplaceWith 必需的。用来替换的子字符串。 
        'start 可选的。在表达式中子字符串搜索的开始位置。如果忽略， 假定从1开始。 
        'count 可选的。子字符串进行替换的次数。如果忽略， 缺省值是 –1， 它表明进行所有可能的替换。 
        'compare 可选的。数字值， 表示判别子字符串时所用的比较方式。关于其值， 请参阅“设置值”部分。 



        '设置值

        'compare参数的设置值如下：
        '        常数 值 描述 
        'vbUseCompareOption –1 使用Option Compare语句的设置值来执行比较。 
        'vbBinaryCompare 0 执行二进制比较。 
        'vbTextCompare 1 执行文字比较。 
        ' 不可用 vbDatabaseCompare 2 仅用于Microsoft Access。基于您的数据库的信息执行比较。 

    End Function

    Public Function TextChangeSqlValue(ByVal Value As String) As String
        Dim text_space = StrReplace(Value, " ", "￥")
        Dim text_comma = StrReplace(text_space, ",", "_")
        Dim text_single_mark = StrReplace(text_comma, "'", "`")
        Dim text_double_mark = StrReplace(text_single_mark, Chr(34), "``")
        Dim text_start = StrReplace(text_double_mark, "*", "^")
        'debug_write("replace" & Value & "=>" & text_start)
        Return text_start
    End Function

    Public Function TextRecoveryName(ByVal Value As String) As String
        Dim text_space = StrReplace(Value, "￥", " ")
        Dim text_comma = StrReplace(text_space, "_", ",")
        Dim text_single_mark = StrReplace(text_comma, "`", "'")
        Dim text_double_mark = StrReplace(text_single_mark, "``", Chr(34))
        Dim text_start = StrReplace(text_double_mark, "^", "*")
        'debug_write("replace" & Value & "=>" & text_start)
        Return text_start
    End Function



End Module
