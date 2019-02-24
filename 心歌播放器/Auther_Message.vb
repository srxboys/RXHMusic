
'酷猫播放器
'       title：托盘右击窗口
'              
'              对歌曲、歌词的控制
'
'       作者:srxboys
'       日期：20141017
Imports System.IO
Public Class Auther_Message
    Dim moshi_1 As Integer = 0
    Dim photo() As String = {".jpg", ".png", ".bmp", ".gif"}

    Private Sub Auther_Message_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.TextBox1.Focus()
    End Sub
    Private Sub Auther_Message_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Label2.Text = "播放次数:"
    End Sub


    Public Sub Auther_Message_change(ByVal moshi As Integer, ByVal tf As Boolean)
        Me.TextBox1.Focus()

        If (moshi = 1) Then
            moshi_1 = 1
            Auther_Message_1()
            Me.TextBox1.Enabled = False

            If tf Then

                Me.PictureBox2.Visible = True
                Me.PictureBox3.Visible = False
                'Me.Show()
            Else
                Me.PictureBox2.Visible = False
                Me.PictureBox3.Visible = False
                Me.Hide()
            End If

        ElseIf (moshi = 2) Then
            Me.TextBox1.Enabled = True
            moshi_1 = 2
            Auther_Message_2()
            If tf Then
                Me.PictureBox3.Visible = True
                Me.PictureBox2.Visible = False
                'Me.Show()
            Else
                Me.PictureBox2.Visible = False
                Me.PictureBox3.Visible = False
                Me.Hide()
            End If
        Else
            moshi_1 = 0
            Me.PictureBox2.Visible = False
            Me.PictureBox3.Visible = False
            Me.Hide()
        End If

    End Sub


    Private Sub Auther_Message_1()



        Me.PictureBox2.Left = 0
        Me.PictureBox2.Top = 0
        Me.Height = Me.PictureBox2.Height
        Me.Width = Me.PictureBox2.Width

        Me.Label1.Parent = Me.PictureBox2
        Me.Label2.Parent = Me.PictureBox2
        Me.Label3.Parent = Me.PictureBox2
        Me.PictureBox1.Parent = Me.PictureBox2

        Me.Label1.Text = Form1.Label28.Text
        Me.Label3.Text = Form1.Label30.Text

        'Me.PictureBox2.Parent = Me
        show_photo()
        Me.Show()

        '292  161
    End Sub


    Private Sub show_photo()

        Try

       
            Dim i As Integer = 0
            Dim s As String
            Dim txt As String

            txt = ""
            i = 0
            s = ""
            For i = Len(Form1.Label28.Text) To 1 Step -1
                s = Mid(Form1.Label28.Text, i, 1)
                If s = "-" Then
                    s = Trim(Mid(Form1.Label28.Text, 1, i - 1))   '结果为【编号  歌名】
                    'MsgBox(Music_auther)
                    Exit For
                End If
            Next

            For i = Len(s) To 1 Step -1
                txt = Mid(s, i, 1)
                If txt = " " Then
                    s = Trim(Mid(s, i + 1)) '结果为【歌名】
                    Exit For
                End If
            Next

            Me.PictureBox1.Image = System.Drawing.Image.FromFile(Application.StartupPath & "\beijing\no-pic.png")

            For i = 0 To UBound(photo)
                If File.Exists(Application.StartupPath & "\歌者\" & s & photo(i)) = True Then
                    Me.PictureBox1.Image = System.Drawing.Image.FromFile(Application.StartupPath & "\歌者\" & s & photo(i))
                    Exit For
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Auther_Message_2()



        Me.PictureBox3.Left = 2
        Me.PictureBox3.Top = 2

        Me.PictureBox3.Parent = Me

        Me.Height = Me.PictureBox3.Height + 4
        Me.Width = Me.PictureBox3.Width + 4

        Me.Left = Windows.Forms.Screen.PrimaryScreen.Bounds.Width - Me.Width - 10

        Me.Top = Windows.Forms.Screen.PrimaryScreen.Bounds.Height - Me.Height - 50
        'Me.TextBox1.Parent = Me.PictureBox3
        Me.Label4.Parent = Me.PictureBox3
        Me.Label5.Parent = Me.PictureBox3
        Me.Label6.Parent = Me.PictureBox3
        Me.Label7.Parent = Me.PictureBox3
        Me.Label8.Parent = Me.PictureBox3
        Me.Label9.Parent = Me.PictureBox3
        Me.Label10.Parent = Me.PictureBox3
        Me.TrackBar1.Parent = Me.PictureBox3

        Me.TrackBar1.Value = Form1.TrackBar2.Value
        If pictureBox8_sound_state = 1 Then  '1 为静音
            Me.Label10.BackColor = Color.Gray
        Else
            Me.Label10.BackColor = Color.LightGray
        End If

        If label37_desk = 0 Then
            Label8.Text = "显示歌词"
        Else
            Label8.Text = "关闭歌词"
        End If

        If pictureBox3_play_state = 0 Then
            Label5.Text = "播放"
        ElseIf pictureBox3_play_state = 1 Then
            Label5.Text = "暂停"
        ElseIf pictureBox3_play_state = 2 Then
            Label5.Text = "播放"
        End If

        'Me.PictureBox3.Location=28, 172

        Me.Label4.Top = 13  '185-172
        Me.Label5.Top = 5
        Me.Label6.Top = 13

        Me.Label4.Left = 6 '34 - 28
        Me.Label5.Left = 69 '97-43
        Me.Label6.Left = 150 '183-43


        Me.Label7.Top = 51 '223 - 172
        Me.TrackBar1.Top = 79   '251 - 172
        Me.Label8.Top = 115 '287 - 172
        Me.Label9.Top = 159 '331 - 172
        Me.Label10.Top = 251 - 172

        Me.Label7.Left = 15 '43 - 28
        Me.TrackBar1.Left = 52 '67- 28
        Me.Label8.Left = 1 '43 - 28
        Me.Label9.Left = 1 '43 - 28
        Me.Label8.Width = Me.PictureBox3.Width - 2
        Me.Label9.Width = Me.PictureBox3.Width - 2
        Me.Label10.Left = 9 '34-28

        Me.TextBox1.Left = 4 '45 - 28
        Me.TextBox1.Top = 4 '313 - 21

        Me.Label7.Text = Form1.Label27.Text
        Me.Label7.Refresh()
        Me.PictureBox3.Parent = Me
        Me.Show()
    End Sub

    Private Sub TrackBar1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TrackBar1.MouseDown
        Me.moshi_1 = 3
    End Sub

    Private Sub TrackBar1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBar1.MouseEnter
        Me.moshi_1 = 3
    End Sub

    Private Sub TrackBar1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBar1.MouseLeave
        Me.moshi_1 = 2
    End Sub



    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        Me.TextBox1.Focus()
        If pictureBox8_sound_state = 0 Then
            Me.TrackBar1.Enabled = True
            Me.ToolTip1.SetToolTip(TrackBar1, "音量 +" & TrackBar1.Value)
            Form1.AxWindowsMediaPlayer1.settings.volume = Me.TrackBar1.Value
            Form1.Label32.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\spn.gif")
        Else

            '1 为静音
            Me.TrackBar1.Enabled = False
        End If

    End Sub

    'Private Sub Auther_Message_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
    '    Auther_Message_change(4, False)
    '    ' MsgBox("e")
    'End Sub

    'Private Sub PictureBox3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.LostFocus
    '    Auther_Message_change(4, False)
    '    MsgBox("f")
    'End Sub


    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click
        If label37_desk = 1 Then
            Label8.Text = "显示歌词"
        Else
            Label8.Text = "关闭歌词"
        End If
        Form1.Label37_Click(Nothing, Nothing)
        If label37_desk = 0 Then
            Form1.Label37.Image = System.Drawing.Image.FromFile(Application.StartupPath & "\beijing\gc.png")
        Else
            Form1.Label37.Image = System.Drawing.Image.FromFile(Application.StartupPath & "\beijing\gc_o.png")
        End If
        Me.moshi_1 = 2
        Me.TextBox1.Focus()
    End Sub





    Private Sub Label8_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label8.MouseDown
        moshi_1 = 3
        Me.Label8.BackColor = Color.White
    End Sub
    Private Sub Label8_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label8.MouseUp
        Me.Label8.BackColor = Color.Gray
    End Sub

    Private Sub Label8_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label8.MouseHover
        Me.TextBox1.Focus()
        Me.Label8.BackColor = Color.Gray
    End Sub

    Private Sub Label8_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label8.MouseLeave
        Me.Label8.BackColor = Color.LightGray
        moshi_1 = 2
    End Sub






    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click
        Form1.Label4_Click(Nothing, Nothing)
    End Sub

    Private Sub Label9_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label9.MouseDown
        Me.Label9.BackColor = Color.White
        moshi_1 = 2
    End Sub
    Private Sub Label9_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label9.MouseUp
        Me.Label9.BackColor = Color.Gray
    End Sub

    Private Sub Label9_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label9.MouseHover
        Me.TextBox1.Focus()
        Me.Label9.BackColor = Color.Gray

    End Sub

    Private Sub Label9_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label9.MouseLeave
        Me.Label9.BackColor = Color.LightGray
        moshi_1 = 3
    End Sub





    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click
        If pictureBox8_sound_state = 0 Then
            '1 为静音
            Me.TrackBar1.Enabled = False
            Form1.Label32.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\muten.gif")
        Else
            Form1.Label32.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\spn.gif")
            Me.TrackBar1.Enabled = True
        End If
        Form1.Label33_MouseClick(Nothing, Nothing)
        Form1.Refresh()
    End Sub

    Private Sub Label10_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label10.MouseDown
        Me.Label10.BackColor = Color.WhiteSmoke
    End Sub

    Private Sub Label10_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label10.MouseUp
        If pictureBox8_sound_state = 0 Then
            Me.Label10.BackColor = Color.LightGray
        Else
            Me.Label10.BackColor = Color.Gray
        End If

    End Sub

    Private Sub Auther_Message_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        If moshi_1 = 2 Then
            Me.Refresh()
            Me.TextBox1.Text = 3
            Auther_Message_change(4, False)

        End If
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        Form1.common_key(e.KeyCode)
    End Sub

    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        Me.TextBox1.Focus()
        If Me.moshi_1 = 2 Then
            Auther_Message_LostFocus(Nothing, Nothing)
        End If

    End Sub




    Private Sub Label4_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label4.MouseDown
        Me.moshi_1 = 3
        Me.Label4.BackColor = Color.White
    End Sub
    Private Sub Label4_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label4.MouseLeave
        Me.Label4.BackColor = Color.LightGray
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        'Me.Label4.BackColor = Color.LightGray
        Form1.common_key(122)
        Me.TrackBar1.Value = Form1.TrackBar2.Value
    End Sub

    Private Sub Label4_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label4.MouseHover
        'Me.TextBox1.Focus()
        Me.Label4.BackColor = Color.Gray

    End Sub
    Private Sub Label4_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label4.MouseUp
        Me.Label4.BackColor = Color.Gray
        'Me.moshi_1 = 2
    End Sub




    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        Me.moshi_1 = 3
        ' Me.Label5.BackColor = Color.LightGray
        Form1.Label14_Click(sender, e)
        If pictureBox3_play_state <= 1 Then
            Form1.Label14.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\playn.png")
        Else
            Form1.Label14.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\pausen.png")
        End If

        If pictureBox3_play_state = 0 Then
            Label5.Text = "播放"
        ElseIf pictureBox3_play_state = 1 Then
            Label5.Text = "暂停"
        ElseIf pictureBox3_play_state = 2 Then
            Label5.Text = "播放"
        End If
        Me.TrackBar1.Value = Form1.TrackBar2.Value
    End Sub
    Private Sub Label5_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label5.MouseDown
        Me.moshi_1 = 3
        Me.Label5.BackColor = Color.White

    End Sub

    Private Sub Label5_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label5.MouseHover
        Me.Label5.BackColor = Color.Gray
        Me.TextBox1.Focus()
    End Sub

    Private Sub Label5_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label5.MouseLeave
        Me.Label5.BackColor = Color.LightGray
        Me.moshi_1 = 2
    End Sub
    Private Sub Label5_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label5.MouseUp
        Me.Label5.BackColor = Color.LightGray

    End Sub
    '............................................................
    '.............................................................




    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        'Me.Label6.BackColor = Color.LightGray
        Form1.common_key(123)
        Me.TrackBar1.Value = Form1.TrackBar2.Value
    End Sub

    Private Sub Label6_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label6.MouseDown
        Me.Label6.BackColor = Color.White
        Me.moshi_1 = 3
    End Sub

    Private Sub Label6_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label6.MouseHover
        Me.Label6.BackColor = Color.Gray
        Me.TextBox1.Focus()
    End Sub

    Private Sub Label6_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label6.MouseLeave
        Me.Label6.BackColor = Color.LightGray
        Me.moshi_1 = 2
    End Sub
    Private Sub Label6_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label6.MouseUp
        Me.Label6.BackColor = Color.Gray
    End Sub

    Private Sub Auther_Message_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseHover
        moshi_1 = 2
        Me.TextBox1.Focus()
    End Sub
End Class