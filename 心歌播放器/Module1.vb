
'
'酷猫播放器
'       title：图标定义
'              数据库的外部引用
'              设置选项的应用、确定 按钮实现事件的修改数据库
'
'       作者:srxboys
'       日期：20140723

Imports System.Data.OleDb
Imports System.IO

Module Module1

    '定义窗口在任务栏上的图标
    Public ico As New Icon(Application.StartupPath + "\Skin\music.ico", 32, 32)

    Public pictureBox8_sound_state As Integer = 0  'form1  中的  是否为静音（1为静音）
    Public pictureBox3_play_state As Integer = 0  'form1  是否正在  播放/暂停
    Public label37_desk As Integer = 0  '歌词显示0/关闭1

    Public DeskMusic_state As Integer = 0   '桌面歌词是否关闭

    '数据库
    Public myconn As New OleDbConnection("provider=Microsoft.jet.oledb.4.0;" & "Data Source='" & Application.StartupPath & "\kmplay.mdb" & "'")

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


    Public Sub debug_write(ByVal txt As String)
        Try
            Dim fs As FileStream
            fs = New FileStream(Application.StartupPath & "\debug.txt", FileMode.Append, FileAccess.Write)
            Dim s As StreamWriter
            s = New StreamWriter(fs)
            s.AutoFlush = False
            ' s.NewLine
            s.Write(" " & Chr(13) & Chr(10) & Chr(13) & Chr(10) & txt & "。 日期：" & Now())
            s.Close()
            fs.Close()
        Catch ex As Exception

            MsgBox("debug 没有写入" & ex.Message)
        End Try
    End Sub

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
            'MsgBox(ex.Message & vbCrLf & "getword获取歌词")
            debug_write("模块   getword获取歌词 'GetWord() ' 行 112 " & ex.Message & vbCrLf)

        End Try

    End Sub
    '提取某句歌词
    Public Function Sentence(ByVal word As String) As String
        Try
            Dim n As Integer
            Sentence = ""
            n = 1
            Do While (1)
                n = InStr(n + 1, word, "]")
                If InStr(n + 1, word, "]") = 0 Then
                    Sentence = Trim(Mid(word, n + 1))
                    Exit Do
                End If
            Loop
        Catch ex As Exception
            'MsgBox(ex.Message)
            debug_write("模块   Sentence获取歌词  行 131 " & ex.Message & vbCrLf)
        End Try
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


End Module
