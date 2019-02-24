

'酷猫播放器 桌面歌词窗口
'       作者：srxboys
'       说明：此处的界面设计，完全按照“酷狗——设置界面”为参考
'       写代码日期：20140727（没有具体实现，只是界面）

'   设置为透明窗体步骤：(在窗口编辑模式下 操作)
'               1、 TransparencyKey  =Transparent
'               2、 BackColor =window
'

Imports System.IO

Public Class DeskMusic

    Dim DeskMusic_x, deskMusic_y As Integer


    Dim timer1_len As Integer = 0
    Dim timer2_len As Integer = 0

    Dim fff As Integer = 0
    Dim lrc_next As Boolean = True

    Dim lrc_path As String = ""
    Dim Txt As String = "1"
    Dim Line As String = ""
    Dim i, j As Integer
    Dim gc_number As Integer = 0 '歌词的行数

    Dim txt1 As String = ""

    Dim length As Double

    Dim a() As String = {"*.mp3", "*.ac3", " *.dts", " *.ddp", " *.ec3", "*.mka", "*.mpa", "*.mp2", "*.m1a", "*.m2a", "*.wma", "*.ape", " *.flac", "*.shn", "*.tta", " *.wav", " *.wv", "1"}
   

    Private Sub DeskMusic_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Height = 99
        Me.Width = 727
        Me.Top = Windows.Forms.Screen.PrimaryScreen.Bounds.Height - Me.Height - 50
        Me.Left = (Windows.Forms.Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        Me.TextBox1.Width = 0
        Me.PictureBox1.Visible = False
        Me.PictureBox1.BorderStyle = BorderStyle.FixedSingle
        ' Me.Label2.Visible = False
        ' lrc_show_windows()
        Me.Timer2.Enabled = True


        'Me.TextBox1.Visible = False
        'Me.Label1.Visible = False
        Me.Label2.Text = ""
        Me.TextBox2.Text = ""
        Me.TextBox1.Text = ""
        Me.Label1.Top = (99 - Label1.Top) / 2
        Me.TextBox1.Top = Me.Label1.Top

        Me.Label1.Text = "听音乐，心歌最炫"
        Me.Label1.Left = (Me.Width - Label1.Width) / 2


    End Sub
    '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Sub picturebox1_show(ByVal show_b As Boolean)
        If show_b Then
            Me.PictureBox1.Visible = True
        Else
            Me.PictureBox1.Visible = False
        End If

    End Sub
    '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Sub DeskMusic_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        DeskMusic_state = 1

        DeskMusic_x = e.X
        deskMusic_y = e.Y

    End Sub

    Private Sub DeskMusic_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseHover
        picturebox1_show(True)
    End Sub

    Private Sub DeskMusic_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
        picturebox1_show(False)

    End Sub

    Private Sub DeskMusic_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If DeskMusic_state = 1 Then
            If (Me.Left + e.X - DeskMusic_x + Me.Width <= Windows.Forms.Screen.PrimaryScreen.Bounds.Width And Me.Left + e.X - DeskMusic_x >= 0) And (Me.Top + e.Y - deskMusic_y + Me.Height <= Windows.Forms.Screen.PrimaryScreen.Bounds.Height And Me.Top + e.Y - deskMusic_y >= 0) Then
                Me.Left += e.X - DeskMusic_x
                Me.Top += e.Y - deskMusic_y
            Else
                Exit Sub
            End If
        End If
    End Sub

    Private Sub DeskMusic_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        DeskMusic_state = 0

    End Sub

    '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
        Me.TextBox1.DeselectAll()
        Me.TextBox2.Focus()

    End Sub

    Private Sub TextBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox1.MouseDown
        DeskMusic_state = 1

        DeskMusic_x = e.X
        deskMusic_y = e.Y

    End Sub


    Private Sub TextBox1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.MouseHover
        picturebox1_show(True)
    End Sub

    Private Sub TextBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.MouseLeave
        'picturebox1_show(False)
    End Sub

    Private Sub TextBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox1.MouseMove
        If DeskMusic_state = 1 Then
            If (Me.Left + e.X - DeskMusic_x + Me.Width <= Windows.Forms.Screen.PrimaryScreen.Bounds.Width And Me.Left + e.X - DeskMusic_x >= 0) And (Me.Top + e.Y - deskMusic_y + Me.Height <= Windows.Forms.Screen.PrimaryScreen.Bounds.Height And Me.Top + e.Y - deskMusic_y >= 0) Then
                Me.Left += e.X - DeskMusic_x
                Me.Top += e.Y - deskMusic_y
            End If
        End If

    End Sub

    Private Sub TextBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox1.MouseUp
        DeskMusic_state = 0
        TextBox1.Left = (Me.Width - Label1.Width) / 2 + 5
        Me.Label1.Left = (Me.Width - Label1.Width) / 2
    End Sub
    '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        DeskMusic_state = 1

        DeskMusic_x = e.X
        deskMusic_y = e.Y
    End Sub

    Private Sub PictureBox1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseHover
        'Me.PictureBox1.Focus()
        'Form1.Enabled = False
    End Sub

    Private Sub PictureBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave
        Me.picturebox1_show(False)
        ' Form1.Enabled = True
    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If DeskMusic_state = 1 Then
            If (Me.Left + e.X - DeskMusic_x + Me.Width <= Windows.Forms.Screen.PrimaryScreen.Bounds.Width And Me.Left + e.X - DeskMusic_x >= 0) And (Me.Top + e.Y - deskMusic_y + Me.Height <= Windows.Forms.Screen.PrimaryScreen.Bounds.Height And Me.Top + e.Y - deskMusic_y >= 0) Then
                Me.Left += e.X - DeskMusic_x
                Me.Top += e.Y - deskMusic_y
            End If
        End If
    End Sub

    Private Sub PictureBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        DeskMusic_state = 0
        TextBox1.Left = (Me.Width - Label1.Width) / 2 + 5
        Me.Label1.Left = (Me.Width - Label1.Width) / 2
    End Sub
    '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    Private Sub Label1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseDown
        DeskMusic_state = 1

        DeskMusic_x = e.X
        deskMusic_y = e.Y
    End Sub

    
    Private Sub Label1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.MouseHover
        picturebox1_show(True)
    End Sub

    Private Sub Label1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.MouseLeave
        ' picturebox1_show(False)
    End Sub

    Private Sub Label1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseMove
        If DeskMusic_state = 1 Then
            If (Me.Left + e.X - DeskMusic_x + Me.Width <= Windows.Forms.Screen.PrimaryScreen.Bounds.Width And Me.Left + e.X - DeskMusic_x >= 0) And (Me.Top + e.Y - deskMusic_y + Me.Height <= Windows.Forms.Screen.PrimaryScreen.Bounds.Height And Me.Top + e.Y - deskMusic_y >= 0) Then
                Me.Left += e.X - DeskMusic_x
                Me.Top += e.Y - deskMusic_y
            End If
        End If
    End Sub

    Private Sub Label1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseUp
        DeskMusic_state = 0
        TextBox1.Left = (Me.Width - Label1.Width) / 2 + 5
        Me.Label1.Left = (Me.Width - Label1.Width) / 2
    End Sub

    '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
   
    Private Sub Timer5_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer5.Tick

        '歌词同步实现
        For i = 1 To ListBox1.Items.Count - 1
            If Form1.AxWindowsMediaPlayer1.Ctlcontrols.currentPosition - Val(ListBox2.Items(i)) < 0.01 Then
                If Label1.Text <> ListBox1.Items(i - 1) Then
                    Label1.Text = ListBox1.Items(i - 1)
                    ListBox1.SelectedIndex = i - 1
                    ListBox2.SelectedIndex = i - 1
                    TextBox1.Text = Label1.Text
                    length = Val(ListBox2.Items(i)) - Val(ListBox2.Items(i - 1))
                    'length = Fix(length) * 1000 + (length - Fix(length))
                    Me.Label1.Left = (Me.Width - Label1.Width) / 2
                    TextBox1.Width = 0
                    TextBox1.Left = Label1.Left + 5
                    'Label2.Text = Me.Label1.Text
                End If
                Exit For
            End If
        Next
        If Form1.AxWindowsMediaPlayer1.currentPlaylist.count <> 0 Then
            If Form1.AxWindowsMediaPlayer1.Ctlcontrols.currentPosition > Val(ListBox2.Items(ListBox2.Items.Count - 1)) Then
                Label1.Text = ListBox1.Items(ListBox1.Items.Count - 1)
                TextBox1.Text = Label1.Text
                Me.Label1.Left = (Me.Width - Label1.Width) / 2
                TextBox1.Left = Label1.Left + 5
                length = Form1.AxWindowsMediaPlayer1.currentMedia.duration - Val(ListBox2.Items(ListBox2.Items.Count - 1))
            End If

            If TextBox1.Width > Label1.Width Then TextBox1.Width = Label1.Width

            If length <> 0 And Form1.AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsPlaying Then

                TextBox1.Width = TextBox1.Width + 0.1 * Label1.Width / length
            End If

        End If
        'TextBox1.Left = Label1.Left + 5
        Label2.Text = Form1.AxWindowsMediaPlayer1.Ctlcontrols.currentPosition
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Try
            If lrc_name <> Txt Then
                Txt = lrc_name
                ' lrc_show_windows()
                If lrc_name = "" Then
                    Exit Sub
                End If

                
                txt1 = ""
                '再去掉扩展名
                For i = Len(lrc_name) To 1 Step -1
                    txt1 = Mid(lrc_name, i, 1)
                    If txt1 = "." Then
                        lrc_path = Application.StartupPath & "\歌词\" & Mid(lrc_name, 1, i - 1) & ".lrc"
                        Exit For
                    End If
                Next

                Me.Timer5.Enabled = False
                Form1.Timer5.Enabled = False

                ListBox1.Items.Clear()
                ListBox2.Items.Clear()
                Form1.ListBox3.Items.Clear()
                Form1.ListBox2.Items.Clear()
                Form1.Label6.Text = ""
                Form1.Label45.Text = "歌词正在下载中"
                Form1.Label45.Left = (Form1.PictureBox4.Width - Form1.Label45.Width) / 2
                Form1.TextBox2.Text = ""
                Form1.TextBox2.Width = 0

                Me.Label1.Text = "歌词正在下载中"
                Me.TextBox1.Width = 0
                Me.Label1.Left = (Me.Width - Label1.Width) / 2

                ' MsgBox(Mid(lrc_name, i))

                '打开视频文件时，歌词就不显示
                For j = 0 To UBound(a)
                    If ("*" & Mid(lrc_name, i)) = a(j) Then
                        Exit For
                    End If
                Next

                If j > UBound(a) Then
                    Me.Label1.Text = "听音乐，心歌最炫"
                    Me.Label1.Left = (Me.Width - Label1.Width) / 2
                    Form1.Label45.Text = "听音乐，心歌最炫"
                    Form1.Label45.Left = (Form1.PictureBox4.Width - Form1.Label45.Width) / 2
                    Form1.Refresh()
                    Exit Sub
                End If

                If File.Exists(lrc_path) = False Then
                    FileClose()
                    Exit Sub
                End If
                FileClose()



                GetWord(lrc_path, ListBox1, ListBox2)
            End If
        Catch ex As Exception
            MsgBox("timer2 " & ex.Message)
            debug_write("DeskMusic.vb 桌面歌词 行316 " & ex.Message.ToString)
        End Try

    End Sub
End Class