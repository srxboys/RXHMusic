Imports System.Data.OleDb
Imports System.IO
Imports System.Random
Imports System.IO.Path

Public Class Form1

    Dim pictureState As Integer = 0 '����굥����״̬��Ϊ�ƶ���׼��
    Dim x, y, x1, x2 As Integer  '�����ƶ�������
    '//////////////////////////////////////////////////////

    Dim topState As Integer '��������pictureBox1�ϵĿؼ� ���� ��״̬
    '����������������������������������������������������������������������

    Dim auto_play As Integer = 0  '�Ƿ��Զ�����
    Public tp As Integer = 0 ' �Ƿ����̻��˳�


    Dim time_left As Integer
    Dim time_right As Integer

    Dim myda As New OleDbDataAdapter("select * from mList", myconn)
    Dim myds As New DataSet
    Dim mybm As BindingManagerBase



    Dim mPlay_play_state As Integer = 0
    Dim mplay_sound_state As Integer = 0  '����״̬���Ƿ�Ϊ������
    Dim mPlay_url As String 'Ϊ����Ƶ�ļ����ж��Ƿ�Ϊ�ոմ򿪵�
    Dim mPlay_volum As Integer   ' ΪmPlay ���������� ��Ϊ ͼƬ���ı�


    Dim pictureBox3_sound_state As Integer = 0

    Dim TrackBar3_state As Integer = 0


    Dim label40_mPlay_IsShow As Integer = 0  'Ĭ���ǹرյ�

    ''  ''���� ��������0������ѭ��1��˳�򲥷�2���б���3���������4  (������707)
    Dim timer3_playSetting As Integer = 0

    Dim mysql As String
    Dim Music_list As BindingManagerBase


    Dim timer2_left As Integer = 0


    Dim list_mouseClick_boolean As Boolean = False
    Dim list_SingleSelectIndex As Integer = 0

    Dim pictureBox6_trueHide As Boolean = False

    'Private Sub Form1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
    'If Me.WindowState = FormWindowState.Minimized Then
    '  Me.WindowState = FormWindowState.Normal   '��ԭ
    ' Else
    '     Me.WindowState = FormWindowState.Minimized
    '  End If
    '  Me.Activate()
    ' End Sub


    '��ݼ�����
    Dim textbox1_Focus As Integer = 0   '�Ƿ���textBox��ý���
    Dim text1 As Integer = 0
    Dim text2 As Integer = 0
    Dim text3 As Integer = 0


    Dim label6_height As Integer = 0
    Dim length As Double = 0.0

    '����ҳ�ĵ���
    Private Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" (ByVal hwngnd As Integer, ByVal lpOperation As String, ByVal lpFile As String, ByVal lpParameters As String, ByVal lpDirectory As String, ByVal nShowCmd As Integer) As Integer





    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' Me.NotifyIcon1.Visible = False


        If tp = 1 Then
            Me.WindowState = FormWindowState.Minimized
            Me.ShowInTaskbar = False
        Else
            Me.NotifyIcon1.Dispose()
            DeskMusic.Close()
            Auther_Message.Close()
            End
        End If
    End Sub


    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        If Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Normal   '��ԭ
        Else
            Me.WindowState = FormWindowState.Minimized
        End If
        Me.Activate()
        Me.ShowInTaskbar = True

    End Sub



    'Private Sub �˳�ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �˳�ToolStripMenuItem.Click
    '    Me.NotifyIcon1.Visible = False
    '    Me.NotifyIcon1.Dispose()
    '    End
    'End Sub

    'Private Sub ��С��ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ��С��ToolStripMenuItem.Click
    '    Me.WindowState = FormWindowState.Minimized
    'End Sub
    'Private Sub ContextMenuStrip3_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip3.Opening
    '    'If Me.WindowState = FormWindowState.Minimized Then
    '    '    Me.��С��ToolStripMenuItem.Enabled = False
    '    '    �ָ�����ToolStripMenuItem.Enabled = True
    '    'Else
    '    '    �ָ�����ToolStripMenuItem.Enabled = False
    '    '    ��С��ToolStripMenuItem.Enabled = True
    '    'End If
    '    'Me.��С��ToolStripMenuItem.Visible = False
    '    '�ָ�����ToolStripMenuItem.Visible = False
    '    '�˳�ToolStripMenuItem.Visible = False
    '    'Me.ContextMenuStrip3.Visible = False

    '    'Me.get_windows_location(sender, e)

    '    'Auther_Message.Show()
    'End Sub

    'Private Sub �ָ�����ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �ָ�����ToolStripMenuItem.Click
    '    Me.WindowState = FormWindowState.Normal
    '    If Me.ShowInTaskbar = False Then
    '        Me.ShowInTaskbar = True
    '        Me.Refresh()
    '    End If
    'End Sub




    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.BackColor = Color.Black
        DeskMusic.Show()
        DeskMusic.Hide()
        Auther_Message.Show()
        Auther_Message.Hide()

        Me.NotifyIcon1.Visible = True
        Me.NotifyIcon1.Icon = ico
        lrc_name = ""    'Ϊ�����ʳ�ʼ��
        Me.Height = 544
        Me.Width = 901

        'Me.StartPosition = FormStartPosition.CenterScreen
        Me.Icon = ico

        'Me.BackgroundImage = System.Drawing.Image.FromFile(Application.StartupPath & "\Skin\MainDialog.gif")
        Me.PictureBox1.Width = Me.Width
        Me.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        Me.PictureBox1.Load(Application.StartupPath + "\Skin\MainDialog.gif")
        'Me.PictureBox1.Load("E:\ͼƬ\����ǽֽ\225159.jpg")
        Me.PictureBox1.Parent = Me
        PictureBox1.Left = 1
        PictureBox1.Top = 1
        PictureBox1.Height = Me.Height - 2
        Me.PictureBox1.Width = Me.Width - 2

        '���Ǹ�״̬�����ñ���ͼƬ
        ' Me.StatusStrip1.BackgroundImage = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\stateImage.jpg")

        Me.PictureBox2.Width = 4
        Me.PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        Me.PictureBox2.Load(Application.StartupPath + "\Skin\eqprob.jpg")

        Me.PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
        Me.PictureBox3.Load(Application.StartupPath + "\beijing\fen-fmPlayer.png")
        Me.PictureBox3.BorderStyle = BorderStyle.FixedSingle
        Me.PictureBox3.Parent = Me.PictureBox1

        'Ƥ��ͼƬ
        Me.Label44.Text = " " & vbCrLf & " "
        Me.Label44.Image = System.Drawing.Image.FromFile(Application.StartupPath & "\beijing\pifu_setting.png")
        Me.Label44.BackColor = Color.Transparent
        Me.Label44.Parent = Me.PictureBox1
        'MsgBox("����Ŀ�ȣ�" & Me.Width & vbCrLf & "����ĸ߶ȣ�" & Me.Height)

        '��picture1�ϵĿؼ�������Ӧ����......................................................
        Me.Label2.Text = " "
        Me.Label3.Text = " "
        Me.Label4.Text = " "
        Me.Label7.Text = " "

        'Me.Label2.Width = 40
        'Me.Label3.Width = 40
        'Me.Label7.Width = 40
        'Me.Label4.Width = 40
        'Me.Label44.Width = 40

        'Me.Label2.Height = 40
        'Me.Label3.Height = 40
        'Me.Label4.Height = 40
        'Me.Label7.Height = 40

        Me.Label7.Left = Me.PictureBox1.Width - 198
        Me.Label44.Left = Me.PictureBox1.Width - 155
        Me.Label2.Left = Me.PictureBox1.Width - 105
        Me.Label3.Left = Me.PictureBox1.Width - 60
        Me.Label4.Left = Me.PictureBox1.Width - 50
        Me.Label44.Top = 11
        Me.Label7.Top = 11
        Me.Label2.Top = 11
        Me.Label3.Top = 11
        Me.Label4.Top = 11

        Me.Label1.ForeColor = Color.Red
        Me.Label1.Font = New Font("����", 15)


        Me.Label2.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\minn.png")
        Me.Label3.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\modn.png")
        Me.Label4.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\closeds.png")
        Me.Label7.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\beijing\chang.png")

        Me.Label1.BackColor = Color.Transparent
        Me.Label2.BackColor = Color.Transparent
        Me.Label3.BackColor = Color.Transparent
        Me.Label4.BackColor = Color.Transparent
        Me.Label7.BackColor = Color.Transparent

        Me.Label27.BackColor = Color.Transparent
        Me.Label31.BackColor = Color.Transparent
        Me.Label33.BackColor = Color.Transparent
        Me.Label34.BackColor = Color.Transparent

        Me.PictureBox8.BackColor = Color.Transparent

        Me.Label32.BackColor = Color.Transparent

        ' Me.Label5.BackColor = Color.Transparent
        'Me.Label6.BackColor = Color.Transparent
        ' Me.Label7.BackColor = Color.Transparent
        Me.Label8.BackColor = Color.Transparent
        Me.Label9.BackColor = Color.Transparent

        Me.Label10.BackColor = Color.Transparent
        Me.Label46.BackColor = Color.Transparent
        'Me.PictureBox5.BackColor = Color.Transparent
        Me.Label12.BackColor = Color.Transparent
        Me.Label13.BackColor = Color.Transparent
        Me.Label14.BackColor = Color.Transparent
        Me.Label15.BackColor = Color.Transparent
        Me.Label16.BackColor = Color.Transparent

        ' TrackBar1.Parent = Me.PictureBox3
        'TrackBar1.BackColor = Color.Transparent
        'Me.TrackBar1.BackColor = Color.Transparent
        ' Me.TrackBar1.Parent = Me.PictureBox3

        Me.Label1.Parent = Me.PictureBox1
        Me.Label2.Parent = Me.PictureBox1
        Me.Label3.Parent = Me.PictureBox1
        Me.Label4.Parent = Me.PictureBox1
        Me.Label7.Parent = Me.PictureBox1
        Me.Label8.Parent = Me.PictureBox1
        Me.Label9.Parent = Me.PictureBox1

        'Me.PictureBox5.Parent = Me.PictureBox3
        Me.Label12.Parent = Me.PictureBox3
        Me.Label13.Parent = Me.PictureBox3
        Me.Label14.Parent = Me.PictureBox3
        Me.Label15.Parent = Me.PictureBox3
        Me.Label16.Parent = Me.PictureBox3
        Me.Label27.Parent = Me.PictureBox3
        Me.Label34.Parent = Me.PictureBox3 '��������������������������������
        Me.Label33.Parent = Me.PictureBox3
        Me.TrackBar3.Parent = Me.PictureBox3

        Me.PictureBox8.Parent = Me.PictureBox3

        Me.Label37.BackColor = Color.Transparent
        Me.Label37.Text = "   " & vbCrLf & "  "   ' ���ͼƬ      ���ͼƬ      ���ͼƬ      ���ͼƬ      ���ͼƬ     
        Me.Label37.Left = Me.PictureBox3.Width + Me.PictureBox3.Left - Me.Label37.Width - 30
        Me.Label37.Top = 90
        Me.Label37.Parent = Me.PictureBox3
        Me.Label37.Image = System.Drawing.Image.FromFile(Application.StartupPath & "\beijing\gc.png")

        Me.Label32.Parent = Me.PictureBox3
        Me.Label31.Parent = Me.PictureBox3
        Me.Label10.Parent = Me.PictureBox3
        Me.Label46.Parent = Me.PictureBox3

        Me.Label10.Top = 124
        Me.Label10.Left = Me.PictureBox2.Left
        Me.Label10.Text = "   �����б� "
        Me.Label10.ForeColor = Color.Red
        Me.Label46.Top = 124
        Me.Label46.Left = Me.PictureBox2.Left + Me.Label10.Width + 20
        Me.Label46.Text = " " & vbCrLf & " "
        Me.Label46.Image = System.Drawing.Image.FromFile(Application.StartupPath & "\beijing\dwo.png")
        Me.Label27.Text = ""
        Me.Label27.Left = Me.PictureBox2.Left + Me.PictureBox2.Width
        Me.Label27.Top = 20
        Me.Label27.ForeColor = Color.Red

        Me.Label16.Text = "00:00"
        Me.Label12.Text = "00:00"

        Label8.Text = "         "
        Label8.Image = Image.FromFile(Application.StartupPath & "\beijing\tjwj.png")
        Label9.Text = "            "
        Label9.Image = Image.FromFile(Application.StartupPath & "\beijing\tjwjj.png")

        '������   ��picture�ϵĿؼ�������Ӧ����......................................................

        'me.Label10.Location =19, 160


        '�ֿᡢ��ʡ�MV ����ؼ������á����£�����������������������������������������������������������������������������
        'Me.TabPage1.BackgroundImage = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\leku.jpg")

        '3 3 3������''''''ΪMV ����ؼ����á���������������������������

        Me.Opacity = 1 '����͸���ȣ�0~1��
        Me.Label21.Text = ""

        ' Me.ContextMenuStrip1.AllowTransparency = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\FrameTipImage.png")

        ' Me.TabControl1.Top = Me.PictureBox1.Top + 38
        ' Me.TabControl1.Height = 480
        ' Me.TabControl1.BackColor = Color.Transparent
        ' Me.TabControl1.Parent = Me.PictureBox1


        Me.PictureBox2.Top = 0
        Me.PictureBox2.Height = Me.Height

        Me.PictureBox3.Left = Me.PictureBox2.Left + Me.PictureBox2.Width + 1
        Me.PictureBox3.Top = Me.PictureBox1.Top + 38
        Me.ListBox1.Left = Me.PictureBox2.Left + Me.PictureBox2.Width + 1
        Me.ListBox1.Top = Me.PictureBox2.Left + Me.PictureBox2.Width + 175
        Me.ListBox1.Height = 339



        Me.Label11.Text = " "
        Me.Label11.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\playn.png")
        Me.Label19.Text = " "
        Me.Label19.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\spn.gif")
        Me.Label17.Text = " "
        Me.Label17.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\stopn.png")
        Me.Label20.Visible = False
        Me.Label20.Text = "���Ž���  +"


        Me.OpenFileDialog1.FileName = ""  'Ĭ�ϴ򿪵��ļ���Ϊ�� 

        Me.TrackBar2.Maximum = 100  'ΪmPlay ���������� �����ֵ
        Me.TrackBar2.Visible = False
        Me.Label5.BackColor = Color.Transparent  '''''''''''''''����ģʽ�����á�����������������������
        Me.Label5.Parent = Me.PictureBox3

        '3 3 3������''''''ΪMV ����ؼ����á�������������������������������������������
        Me.Label26.Text = "00:00"
        Me.Label22.Text = "00:00"
        Me.Label26.Left = Me.TrackBar1.Left - Me.Label26.Width
        Me.Label26.ForeColor = Color.Red
        Me.Label22.ForeColor = Color.Red


        '�ֿᡢ��ʡ�MV ����ռ�����á��������������������������������������������������������������������������������������������������� 



        '�������ÿ�è
        'me.PictureBox6 .Location =59, 343
        Me.PictureBox6.BackColor = Color.SaddleBrown
        pic6_childen_hide()
        Me.PictureBox6.Visible = False

        '����ļ�������ļ���  ��������ɫ��
        Me.Label8.ForeColor = Color.Red
        Me.Label9.ForeColor = Color.Red

        '�����õ�
        Me.Label28.Text = "������"
        Label30.Text = ""

        '��ʾ�����б�
        list_cls_add()

        If Me.ListBox1.Items.Count > 0 Then
            Me.ListBox1.SelectedIndex = list_SingleSelectIndex
            label24_show_len(Me.ListBox1.SelectedItem)
        Else
            Me.ContextMenuStrip2.Enabled = False
        End If


        '  Me.Label24.SetBounds(Nothing, Nothing, 5, Nothing)
        'Me.Label24.Width = 10


        'Me.Label24.AutoSize = True



        '��pictureBox3 �ϵĿؼ�������Ӧ���ã���һ��������/��ͣ����һ����������(��1496�м����� �ɿ����ǵ���Ӧ�¼�)
        Me.Label13.Top = 93
        Me.Label13.Text = "       " & vbCrLf & "       "
        Me.Label13.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\prevn.png")
        Me.Label14.Text = "       " & vbCrLf & "       "
        Me.Label14.Top = 93
        Me.Label14.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\playn.png")
        Me.Label15.Text = "       " & vbCrLf & "       "
        Me.Label15.Top = 93
        Me.Label15.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\nextn.png")
        Me.Label31.Text = "       " & vbCrLf & "       "
        Me.Label31.Top = 93
        Me.Label31.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\stopn.png")
        Me.Label32.Text = "  "
        Me.Label32.Left = 165
        Me.Label32.Top = 98
        Me.Label32.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\spn.gif")

        Me.Label33.Text = "  "

        Me.Label33.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\spn.gif")
        Me.Label33.Visible = False
        Me.Label36.Left = Me.Label31.Left
        Me.Label36.Top = Me.Label31.Top
        Me.Label36.Text = ""
        ' Me.Label36.Text = "                          "
        'Me.Label13.Height = 40
        ' me.PictureBox8 .Location =155, 93
        Me.PictureBox8.Left = 155
        Me.PictureBox8.Top = 93

        Me.PictureBox8.BackColor = Color.Orange

        Me.TrackBar3.BackColor = Color.Orange
        Me.PictureBox8.Width = 100 + 30

        Me.Label34.Left = Me.PictureBox8.Left
        Me.Label34.Top = Me.Label10.Top - Me.Label34.Height
        Me.Label34.Width = Me.PictureBox8.Width
        Me.Label34.Text = "                              " & vbCrLf & "                         " & vbCrLf & "                          " '�ڸ�trackBar3
        Me.Label35.Text = "                                     " & vbCrLf & "                                      " '�ڸ�trackBar4
        Me.Label35.Top = 105 - Me.Label35.Height
        Me.Label35.BackColor = Color.Transparent
        Me.Label35.Parent = Me.PictureBox3
        Me.Label36.BackColor = Color.Transparent
        Me.Label36.Parent = Me.PictureBox3
        Me.TrackBar4.Parent = Me.PictureBox3
        Me.TrackBar4.Top = Me.Label12.Top - 5
        Me.TrackBar4.Minimum = 0
        'Me.Label12.Width = 16
        Me.TrackBar4.Left = 60

        '�˵���ʾ��ʽ
        �Զ��л��б�ToolStripMenuItem.Visible = False
        '�б���ToolStripMenuItem.Visible = False




        '����mv �Լ��������
        pictureBox4_hide()
        'Me.Label38.BorderStyle = BorderStyle.FixedSingle
        ' me.Label38.Location =402, 35
        Me.Label38.Left = 402 + 40
        Me.Label38.Top = Me.PictureBox3.Top
        Me.Label38.BackColor = Color.Transparent
        Me.Label38.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\beijing\mv.png")
        Me.Label38.Parent = Me.PictureBox1
        Me.Label38.Text = "     " & vbCrLf & "   "
        Me.Label38.BorderStyle = BorderStyle.None


        Me.PictureBox4.Top = 38
        Me.PictureBox4.Left = Me.ListBox1.Left + Me.ListBox1.Width + 1
        Me.PictureBox4.BorderStyle = BorderStyle.Fixed3D

        Me.AxWindowsMediaPlayer1.Width = 588
        Me.AxWindowsMediaPlayer1.Height = 413
        Me.Label40.Text = " �Ƿ���ʾ��Ƶ���"
        Me.Label40.BackColor = Color.Transparent
        Me.Label40.Parent = Me.PictureBox1
        'Me.Label40.BorderStyle = BorderStyle.FixedSingle
        Label41.ForeColor = Color.Red
        Label41.BackColor = Color.Transparent
        Label41.Parent = Me.PictureBox1
        ' Me.Label41.BorderStyle = BorderStyle.FixedSingle
        Me.Label21.BackColor = Color.Transparent
        Me.Label21.BorderStyle = BorderStyle.None
        Me.Label21.Parent = Me.PictureBox1
        Me.Label21.Top = 76
        Me.Label42.Text = "     " & vbCrLf & "   "
        'me.Label42 .Location =479, 37
        Me.Label42.Left = 479 + 40
        Me.Label42.Top = Me.PictureBox3.Top
        Me.Label42.BackColor = Color.Transparent
        Me.Label42.Parent = Me.PictureBox1
        Me.Label42.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\beijing\leku.png")
        Me.Label42.BorderStyle = BorderStyle.None

        Me.Label43.Text = "     " & vbCrLf & "   "
        'me.Label42 .Location =479, 37
        Me.Label43.Left = 568 + 40
        Me.Label43.Top = Me.PictureBox3.Top
        Me.Label43.BackColor = Color.Transparent
        Me.Label43.Parent = Me.PictureBox1
        Me.Label43.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\beijing\geci.png")
        Me.Label43.BorderStyle = BorderStyle.None

        Me.PictureBox4.BorderStyle = BorderStyle.None
        Me.PictureBox4.BackColor = Color.Transparent
        Me.PictureBox4.Parent = Me.PictureBox1
        Me.PictureBox4.Top = 0
        Me.PictureBox4.Height = 90

        Me.PictureBox4.Left = Me.PictureBox3.Left + Me.PictureBox3.Width + 2
        Me.PictureBox4.Width = Me.PictureBox1.Width - Me.PictureBox3.Left - Me.PictureBox3.Width - 15

        Me.AxWindowsMediaPlayer1.Left = Me.PictureBox4.Left
        Me.AxWindowsMediaPlayer1.Top = Me.PictureBox4.Top + Me.PictureBox4.Height + 2




        'Me.PictureBox3.Visible = False
        ' Me.TextBox1.Visible = False
        ' Me.Label37.Visible = False  '���������������ظ��
        Me.Label39.Visible = False

        Me.Label5.Text = "   " & vbCrLf & "  "
        Me.Label5.Left = Me.Label32.Left + Me.Label33.Width + 15
        'Me.Label5.SendToBack()
        Me.Label5.Top = 92


        '��ݼ�����
        '   Me.����ToolStripMenuItem.ShortcutKeys = Keys.Alt + Keys.B
        TextBox1.Focus()
        Me.TextBox1.Parent = Me.PictureBox1
        Me.MonthCalendar1.Visible = False

        'listbox!���ý���ʱ�Ŀ�ݼ�.,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,��ݼ������Ƿ���ʾ
        'Me.TextBox1.Visible = False

        ''���� ��������0������ѭ��1��˳�򲥷�2���б���3���������4  ͼƬ�仯 (������754)
        Try
            myconn.Open()
            Dim myda1 As New OleDbDataAdapter("select tp,autoPlay,playHello,sound_int,sound_mute,playSetting,next_play,id_diaoyong from kmSetting  where id_diaoyong=" & 1, myconn)
            myda1.Fill(myds, "kmSet")
            myconn.Close()
            If myds.Tables("kmSet").Rows.Count = 1 Then
                timer3_playSetting = myds.Tables("kmSet").Rows(0).Item("playSetting") '���� ��������0������ѭ��1��˳��....

                If myds.Tables("kmSet").Rows(0).Item("playHello") = 1 Then
                    Me.AxWindowsMediaPlayer1.URL = Application.StartupPath & "\login.wav"
                    Me.AxWindowsMediaPlayer1.Ctlcontrols.play()
                End If
                If myds.Tables("kmSet").Rows(0).Item("autoPlay") = 1 Then  '�Զ�����
                    auto_play = myds.Tables("kmSet").Rows(0).Item("autoPlay")
                    Me.Timer4.Enabled = True
                End If



                If myds.Tables("kmSet").Rows(0).Item("tp") = 1 Then   '����
                    tp = 1
                End If


                If myds.Tables("kmSet").Rows(0).Item("sound_mute") > 0 Then  '����
                    Me.AxWindowsMediaPlayer1.settings.mute = True
                    Me.Label33.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\muten.gif")
                    Me.Label32.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\muten.gif")
                    pictureBox8_sound_state = 1
                Else
                    Me.TrackBar1.Value = myds.Tables("kmSet").Rows(0).Item("sound_int")
                    Me.TrackBar3.Value = Me.TrackBar1.Value
                    Me.AxWindowsMediaPlayer1.settings.volume = Me.TrackBar1.Value

                End If

            End If
            myds.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
            debug_write("keSetting�����ݿ��ȡ->����ģʽ���� ��572 " & ex.Message)
            myconn.Close()
            myds.Clear()
        End Try
        ' Setting_boolean = False   'û����


        startKM_play_moshi() ''���� ��������0������ѭ��1��˳�򲥷�2���б���3���������4  �������Ҽ��仯������



        PictureBox8_hidePic()


        Label5_pic_show()

        pictureBox5_9_where()
        Me.PictureBox5.Visible = False
        Me.PictureBox9.Visible = False

        'Ĭ�ϴ򿪸��
        Me.Label43_Click(Nothing, Nothing)
        Me.Label43.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\beijing\geci-o.png")


        Me.��С��ToolStripMenuItem.Visible = False
        �ָ�����ToolStripMenuItem.Visible = False
        �˳�ToolStripMenuItem.Visible = False
        ToolStripMenuItem5.Visible = False


    End Sub



    'һ��3�δ������ƶ�picture�ͻ��ƶ�����

    '�ⲻ�����뵽�ģ���л�ٶȣ���������ܺã������ܿ������ұ�̻��ǲ����ͨ��

    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        Me.TextBox1.Focus()
        Me.pictureState = 1
        x = e.X
        y = e.Y
    End Sub

    Private Sub PictureBox1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseHover
        textbox1_Focus = 0
        Me.TextBox1.Focus()
        Me.PictureBox8_hidePic()
    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        ' TextBox1.Focus()
        textbox1_Focus = 1
        If Me.pictureState = 1 Then
            Me.Left = Me.Left + e.X - x
            Me.Top = Me.Top + e.Y - y
        End If
    End Sub

    Private Sub PictureBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        Me.pictureState = 0
    End Sub
    Private Sub PictureBox4_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox4.MouseDown

        Me.pictureState = 1
        x = e.X
        y = e.Y
    End Sub

    Private Sub PictureBox4_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox4.MouseHover
        textbox1_Focus = 0
        Me.TextBox1.Focus()
        Me.PictureBox8_hidePic()
        textbox1_Focus = 0
    End Sub

    Private Sub PictureBox4_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox4.MouseMove
        ' TextBox1.Focus()
        textbox1_Focus = 1
        If Me.pictureState = 1 Then
            Me.Left = Me.Left + e.X - x
            Me.Top = Me.Top + e.Y - y
        End If
    End Sub

    Private Sub PictureBox4_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox4.MouseUp
        Me.pictureState = 0
    End Sub


    '�ƶ�����������
    '��������������������������������������������������������������������������������������������������������������������������������������������

    '�����ǵ��ó���
    '��������������������������������������������������������������������������������������������������������������������������������������������

    '�����ǵ��ó���
    '��������������������������������������������������������������������������������������������������������������������������������������������

    '�����ǵ��ó���
    '��������������������������������������������������������������������������������������������������������������������������������������������

    '�����ǵ��ó���
    '��������������������������������������������������������������������������������������������������������������������������������������������

    '�����ǵ��ó���
    '��������������������������������������������������������������������������������������������������������������������������������������������

    '�����ǵ��ó���

    Private Sub pictureBox5_9_where()

        '''''''''''''''''''''''''''''
        '''''''''''''���''''''''''''
        '''''''''''''''''''''''''''''
        Me.PictureBox5.BackColor = Color.Transparent
        'Me.PictureBox5.BackColor = Color.Yellow
        Me.PictureBox5.Parent = Me.PictureBox1
        Me.PictureBox5.Left = Me.PictureBox4.Left
        Me.PictureBox5.Top = Me.Height - Me.PictureBox4.Left - Me.PictureBox4.Height - 80
        Me.PictureBox5.Width = Me.PictureBox4.Width
        Me.PictureBox5.Height = Me.Height - Me.PictureBox4.Height - 25




        Me.TextBox2.BackColor = Color.MistyRose
        Me.TextBox2.ForeColor = Color.Orange
        Me.TextBox2.Text = ""
        Me.textbox2.Parent = Me.PictureBox5
        Me.textbox2.Left = 0
        Me.TextBox2.Top = 80
        Me.TextBox2.Width = 0
        Me.TextBox2.Height = 21


        Me.Label45.BackColor = Color.MistyRose
        Me.Label45.Parent = Me.PictureBox5
        Me.Label45.Top = 80
        Me.Label45.Height = 22
        Me.Label45.Text = "�����֣��ĸ�����"
        Me.Label45.Left = (PictureBox4.Width - Me.Label45.Width) / 2


        'Me.ListBox2.BackColor = Color.Transparent
        Me.ListBox2.Parent = Me.PictureBox5
        Me.ListBox2.Left = 0
        Me.ListBox2.Top = 50
        Me.ListBox2.Width = 0
        Me.ListBox2.Height = 100
        Me.TextBox2.Text = ""

        'Me.ListBox3.BackColor = Color.Transparent
        Me.ListBox3.Parent = Me.PictureBox5
        Me.ListBox3.Left = 102
        Me.ListBox3.Top = 50
        Me.ListBox3.Width = 100
        Me.ListBox3.Height = 100
        Me.ListBox3.Items.Add("���Ǻ���")

        'Me.Label6.BackColor = Color.Transparent
        Me.Label6.BackColor = Color.MistyRose
        Me.Label6.Parent = Me.PictureBox5
        Me.Label6.Left = 0
        Me.Label6.Top = 0
        Me.Label6.Width = Me.PictureBox4.Width
        Me.Label6.Height = Me.PictureBox5.Height

        'Me.Label6.Text = "�����֣��ĸ�����"
        ListBox3.Visible = False
        ListBox2.Visible = False




        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ''''''''''''''''''''''��һ��ͼƬ(��������)'''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.PictureBox9.BackColor = Color.Transparent
        Me.PictureBox9.Parent = Me.PictureBox1
        Me.PictureBox9.Left = 0
        Me.PictureBox9.Top = 0
        Me.PictureBox9.Width = 0
        Me.PictureBox9.Height = 0
    End Sub



    Private Sub pictureBox4_show()
        'Me.AxWindowsMediaPlayer1.Visible = True
        Label41.Visible = True
        Me.Label11.Visible = False
        Me.Label17.Visible = False
        Me.Label19.Visible = False
        Me.Label20.Visible = False
        Me.Label21.Visible = True
        Me.Label22.Visible = False
        Me.Label26.Visible = False
        Me.TrackBar1.Visible = False
        Me.TrackBar2.Visible = False
        'Me.PictureBox4.Visible = False
        Me.Label40.Visible = True
    End Sub
    Private Sub pictureBox4_hide()
        Me.AxWindowsMediaPlayer1.Visible = False
        Label41.Visible = False
        Me.Label11.Visible = False
        Me.Label17.Visible = False
        Me.Label19.Visible = False
        Me.Label20.Visible = False
        Me.Label21.Visible = False
        Me.Label22.Visible = False
        Me.Label26.Visible = False
        Me.TrackBar1.Visible = False
        Me.TrackBar2.Visible = False
        'Me.PictureBox4.Visible = False
        Me.Label40.Visible = False
        Me.Label40.ForeColor = Color.Red


    End Sub
    Public Sub common_key(ByVal key_value As Integer)

        If key_value = 32 Or key_value = 120 Or key_value = 13 Then  '��ݼ� Space �� F9 �� Enter(����/��ͣ)
            Me.Label14_Click(Nothing, Nothing)
            Me.Label14_MouseLeave(Nothing, Nothing)
            '  MsgBox("list")
        ElseIf key_value = 123 Or key_value = 176 Or key_value = 34 Then '��ݼ� ��һ��(F12��Fn+F12��PgDn)
            Me.Label15_Click(Nothing, Nothing)
        ElseIf key_value = 122 Or key_value = 177 Or key_value = 33 Then '��ݼ� ��һ��(F11��Fn+F12��PgDn)
            Me.Label13_Click(Nothing, Nothing)
        ElseIf key_value = 178 Or key_value = 121 Then '��ݼ� ֹͣ F10
            'Me.Label13_Click(Nothing, Nothing)
            Label17_Click(Nothing, Nothing)
        ElseIf key_value = 36 Then  '��ݼ� listbox1 ѡ��ͷĿ¼
            If Me.ListBox1.Items.Count - 1 >= 0 Then
                Me.ListBox1.SelectedIndex = 0
            End If
        ElseIf key_value = 35 Then '��ݼ� listbox1 ѡ��βĿ¼
            If Me.ListBox1.Items.Count - 1 >= 0 Then
                Me.ListBox1.SelectedIndex = Me.ListBox1.Items.Count - 1
            End If
        ElseIf key_value = 116 Then
            Setting.ShowDialog()
        ElseIf key_value = 115 Then
            Me.MonthCalendar1.Left = (Me.Left + Me.Width) / 2
            Me.MonthCalendar1.Top = Me.Height / 2
            Me.MonthCalendar1.Visible = True
        End If

        If pictureBox3_play_state = 0 Then
            Auther_Message.Label5.Text = "����"
        ElseIf pictureBox3_play_state = 1 Then
            Auther_Message.Label5.Text = "��ͣ"
        ElseIf pictureBox3_play_state = 2 Then
            Auther_Message.Label5.Text = "����"
        End If
    End Sub

    Private Sub PictureBox8_showPic()
        'TextBox1.Focus()
        Me.textbox1_Focus = 1
        Me.Label33.Left = Me.Label32.Left
        Me.Label33.Top = Me.Label32.Top
        Me.PictureBox8.Visible = True
        Me.Label33.Visible = True


        Me.TrackBar3.Visible = True
    End Sub
    Private Sub PictureBox8_hidePic()

        Me.Label33.Left = 157
        Me.Label33.Top = 86
        Me.PictureBox8.Visible = False
        Me.Label33.Visible = False

        Me.TrackBar3.Top = 93
        Me.TrackBar3.Left = 179
        Me.TrackBar3.Visible = False

        '  Me.MonthCalendar1.Visible = False
    End Sub

    '�����֣��ÿ�è ������ʾ������ �Լ���Ӧ��λ��
    Private Sub pic6_childen_show()
        'me.PictureBox7 .Location =75, 361
        Me.PictureBox7.Left = Me.PictureBox6.Left + 16
        Me.PictureBox7.Top = Me.PictureBox6.Top + 18
        ' Me.PictureBox7.Parent = Me.PictureBox6
        ' Me.PictureBox7.BackColor = Color.Transparent
        Me.PictureBox7.BackColor = Me.PictureBox6.BackColor

        'me.PictureBox6 .Location =59, 343
        'me.Label23.Location =     75, 468
        Me.Label23.Left = Me.PictureBox6.Left + 16
        Me.Label23.Top = Me.PictureBox6.Top + 125
        '  Me.Label23.Parent = Me.PictureBox6
        Me.Label23.BackColor = Me.PictureBox6.BackColor

        'me.PictureBox6 .Location =59, 343
        'me.Label24.Location =    178, 361
        Me.Label28.Left = Me.PictureBox6.Left + 110
        Me.Label28.Top = Me.PictureBox6.Top + 18
        'Me.Label24.Parent = Me.PictureBox6
        Me.Label28.BackColor = Me.PictureBox6.BackColor
        Me.Label28.Width = Me.PictureBox6.Width - Me.Label24.Left




        'me.PictureBox6 .Location =59, 343
        'me.Label25.Location =    178, 448
        Me.Label25.Left = Me.PictureBox6.Left + 110
        Me.Label25.Top = Me.PictureBox6.Top + 125
        '  Me.Label25.Parent = Me.PictureBox6
        Me.Label25.BackColor = Me.PictureBox6.BackColor

        'me.PictureBox6 .Location =59, 343
        'me.Label29.Location =    75, 450
        Me.Label29.Left = Me.PictureBox6.Left + 16
        Me.Label29.Top = Me.PictureBox6.Top + 107
        '  Me.Label29.Parent = Me.PictureBox6
        Me.Label29.BackColor = Me.PictureBox6.BackColor




        Me.PictureBox7.Visible = True
        Me.Label23.Visible = True
        Me.Label28.Visible = True
        Me.Label25.Visible = True
        Me.Label29.Visible = True

    End Sub
    Private Sub pic6_childen_hide()
        Me.PictureBox7.Visible = False
        Me.Label23.Visible = False
        Me.Label24.Visible = False
        Me.Label25.Visible = False
        Me.Label28.Visible = False
        Label18.Visible = False
        Me.Label29.Visible = False
        Me.Label30.Visible = False


        '�����֣��ÿ�è����
    End Sub

    Private Sub label24_show_len(ByVal ss As String)   '��pictureBox6 �ϵĸ�������ͬ��
        'Dim text_len As Integer = 1
        'Dim text_text As String = ""
        'Dim text_add_int As Integer
        '' Dim label18text_aa As String = ""
        'text_text = ss
        'Label24.Text = ""
        'For text_len = 1 To Len(text_text)

        '    If text_len < 8 * text_add_int Then
        '        Label24.Text &= Mid(text_text, text_len, 1)
        '    Else
        '        Label24.Text &= vbCrLf & Mid(text_text, text_len, 1)
        '        text_add_int += 1
        '    End If
        'Next
        ''MsgBox(text_text)
        ''  Me.Label24.Text = text_text
        'Me.Label28.Text = Me.Label24.Text
        Me.Label28.Text = ss
        label18_show_date(ss) '��pictureBox6 �ϵ����ڡ� ���Ŵ�������ͬ��

    End Sub

    Private Sub label18_show_date(ByVal aa As String) '��pictureBox6 �ϵ����ڡ� ���Ŵ�������ͬ��
        Dim label18text As String = ""
        Try

            Dim i, j As Integer
            Dim select_item As String
            'myconn.Close()
            j = 0
            select_item = ""
            select_item = aa
            For i = 1 To Len(ListBox1.SelectedItem)
                j = j + 1
                select_item = Mid(ListBox1.SelectedItem, i, 1)

                If select_item = " " Then
                    select_item = Mid(ListBox1.SelectedItem, i + 2)

                    Exit For
                End If
            Next

            Dim mycmd As New OleDbCommand
            mysql = "select * from mlist where Music_name='" & Trim(select_item) & "'"

            'MsgBox(mysql)  '��������������Ϊ��������

            myconn.Open()
            Dim myda1 As New OleDbDataAdapter(mysql, myconn)
            myda1.Fill(myds, "student1")
            myconn.Close()
            If myds.Tables("student1").Rows.Count = 1 Then
                Me.Label18.Text = myds.Tables("student1").Rows(0).Item(9)
                Me.Label30.Text = myds.Tables("student1").Rows(0).Item(4)
            End If
            Me.Label25.Text = "������" & Me.Label18.Text
            Me.Label29.Text = "���Ŵ�����" & Me.Label30.Text
            Auther_Message.Auther_Message_change(1, False)
            myds.Clear()
        Catch ex As Exception
            'MsgBox(ex.Message)
            debug_write("label18_show_date�е�pictureBox6 ����ʱ��label25  ����  ���Ŵ���label29�� �� 968 " & ex.Message.ToString)
            myconn.Close()
            myds.Clear()
        End Try


    End Sub

    ''���� ��������0������ѭ��1��˳�򲥷�2���б���3���������4  (������707)
    Private Sub mplay_play_moshi()


        pictureBox3_play_state = 0
        Try


            Select Case timer3_playSetting
                Case 0
                    Me.AxWindowsMediaPlayer1.Ctlcontrols.stop()
                    Me.mplay_time_end()   '����ʾʱ�����
                    Me.Timer1.Enabled = False
                    Me.Timer2.Enabled = False

                    Exit Select
                Case 1
                    Me.Label14_Click(Nothing, Nothing)

                Case 2
                    '  MsgBox("�б�")
                    If Me.ListBox1.SelectedIndex + 1 <= Me.ListBox1.Items.Count - 1 Then
                        Me.Label15_Click(Nothing, Nothing)
                    Else
                        If Me.ListBox1.Items.Count - 1 >= 0 Then
                            Me.ListBox1.SelectedIndex = 0
                            Me.Label27.Text = ""
                            Me.AxWindowsMediaPlayer1.Ctlcontrols.stop()
                            Me.mplay_time_end()   '����ʾʱ�����
                            Me.Timer1.Enabled = False
                            Me.Timer2.Enabled = False
                        End If
                    End If

                Case 3
                    Me.Label15_Click(Nothing, Nothing)

                Case 4

                    Me.Label15_Click(Nothing, Nothing)

            End Select
        Catch ex As Exception
            'MsgBox("���ó��� mplay_play_moshi()" & vbCrLf & ex.Message)
            debug_write("����ģʽmplay_play_moshi() ��1014 " & ex.Message.ToString)
        End Try
        Label5_pic_show()
    End Sub
    Private Sub startKM_play_moshi()
        Try

            'picturebox 1   ���һ�
            ��������ToolStripMenuItem.CheckState = CheckState.Unchecked
            ����ѭ��ToolStripMenuItem.CheckState = CheckState.Unchecked
            ˳�򲥷�ToolStripMenuItem.CheckState = CheckState.Unchecked
            �б���ToolStripMenuItem.CheckState = CheckState.Unchecked
            �������ToolStripMenuItem.CheckState = CheckState.Unchecked


            'listbox1 ���һ�

            ��������ToolStripMenuItem1.CheckState = CheckState.Unchecked
            ����ѭ��ToolStripMenuItem1.CheckState = CheckState.Unchecked
            ˳�򲥷�ToolStripMenuItem1.CheckState = CheckState.Unchecked
            �б���ToolStripMenuItem1.CheckState = CheckState.Unchecked
            �������ToolStripMenuItem1.CheckState = CheckState.Unchecked

            Select Case timer3_playSetting
                Case 0
                    'Me.AxWindowsMediaPlayer1.Ctlcontrols.stop()
                    'Me.mplay_time_end()   '����ʾʱ�����
                    'Me.Timer1.Enabled = False
                    'Me.Timer2.Enabled = False
                    ��������ToolStripMenuItem.CheckState = CheckState.Checked
                    ��������ToolStripMenuItem1.CheckState = CheckState.Checked
                    'Exit Select
                Case 1
                    'Me.Label14_Click(Nothing, Nothing)
                    ����ѭ��ToolStripMenuItem.CheckState = CheckState.Checked
                    ����ѭ��ToolStripMenuItem1.CheckState = CheckState.Checked
                Case 2
                    ''  MsgBox("�б�")
                    'If Me.ListBox1.SelectedIndex + 1 <= Me.ListBox1.Items.Count - 1 Then
                    '    Me.Label15_Click(Nothing, Nothing)
                    'Else
                    '    If Me.ListBox1.Items.Count - 1 >= 0 Then
                    '        Me.ListBox1.SelectedIndex = 0
                    '        Me.Label27.Text = ""
                    '        Me.AxWindowsMediaPlayer1.Ctlcontrols.stop()
                    '        Me.mplay_time_end()   '����ʾʱ�����
                    '        Me.Timer1.Enabled = False
                    '        Me.Timer2.Enabled = False
                    '    End If
                    'End If
                    ˳�򲥷�ToolStripMenuItem.CheckState = CheckState.Checked
                    ˳�򲥷�ToolStripMenuItem1.CheckState = CheckState.Checked
                Case 3
                    ' Me.Label15_Click(Nothing, Nothing)
                    �б���ToolStripMenuItem.CheckState = CheckState.Checked
                    �б���ToolStripMenuItem1.CheckState = CheckState.Checked
                Case 4

                    ' Me.Label15_Click(Nothing, Nothing)
                    �������ToolStripMenuItem.CheckState = CheckState.Checked
                    �������ToolStripMenuItem1.CheckState = CheckState.Checked
            End Select
        Catch ex As Exception
            'MsgBox("���ó��� mplay_play_moshi()" & vbCrLf & ex.Message)
            debug_write("startKM_play_moshi() ��1110 " & ex.Message.ToString)
        End Try
    End Sub
    ''���� ��������0������ѭ��1��˳�򲥷�2���б���3���������4  ͼƬ�仯 (������754)
    Private Sub Label5_pic_show()
        Label5.Image = System.Drawing.Image.FromFile(Application.StartupPath & "\beijing\" & timer3_playSetting & ".png")

        '�ѱ仯д�����ݿ�
        Try
            ' Setting_boolean = False
            Dim mysql As String
            Dim mycmd As New OleDbCommand
            myconn.Open()
            mysql = "update kmSetting set " & "playSetting=" & timer3_playSetting & " where id_diaoyong=" & 1
            mycmd.Connection = myconn
            mycmd.CommandText = mysql
            mycmd.ExecuteNonQuery()
            myconn.Close()
            myds.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
            debug_write("Label5_pic_show �� ����ģʽmplay_play_moshi()д�����ݿ� ��1037 " & ex.Message.ToString)
            myconn.Close()
            myds.Clear()
        End Try

    End Sub
    Private Sub mplay_time_end()
        Me.Label26.Text = "00:00"
        Me.Label22.Text = "00:00"
        Me.Label16.Text = "00:00"
        Me.Label12.Text = "00:00"
        Me.Label21.Text = ""
        Me.TrackBar1.Value = 0
        Me.TrackBar4.Value = 0
        ' Me.AxWindowsMediaPlayer1.Ctlcontrols.currentPosition = 0
    End Sub
    Private Sub Random_play()
        If Me.ListBox1.Items.Count > 0 Then
            Dim random As Random = New Random()
            If Me.ListBox1.Items.Count - 1 >= 0 Then
                Randomize()
                Me.ListBox1.SelectedIndex = random.Next(Me.ListBox1.Items.Count - 1)
                list_SingleSelectIndex = ListBox1.SelectedIndex

            End If
        End If

    End Sub
    'ˢ����ʾ�����б�
    Private Sub list_cls_add()
        Me.ListBox1.Items.Clear()
        Dim mycmd As New OleDbCommand

        Try
            mysql = "select * from mlist"

            myconn.Open()
            Dim myda1 As New OleDbDataAdapter(mysql, myconn)
            myda1.Fill(myds, "mlist")
            myconn.Close()
            If myds.Tables("mlist").Rows.Count > 0 Then
                For i As Integer = 0 To myds.Tables("mlist").Rows.Count - 1
                    Me.ListBox1.Items.Add(i & "  " & myds.Tables("mlist").Rows(i).Item(1))
                Next
            End If
            myds.Clear()
        Catch ex As Exception
            '
            MsgBox("��ر�����򿪵����ݿ�")
            myconn.Close()
            myds.Clear()
        End Try
        Me.ListBox1.Refresh()

        If Me.ListBox1.Items.Count > 0 Then
            If list_SingleSelectIndex > Me.ListBox1.Items.Count - 1 Then
                list_SingleSelectIndex = 0
            End If
            Me.ListBox1.SelectedIndex = list_SingleSelectIndex



            Me.ContextMenuStrip2.Enabled = True
            Me.Label24.Text = Me.ListBox1.SelectedItem
        End If
    End Sub



    ' ���ú�������
    '������������������������������������������������������������������������������������������������������������������������������������������

    ' ���ú�������
    '������������������������������������������������������������������������������������������������������������������������������������������

    ' ���ú�������
    '������������������������������������������������������������������������������������������������������������������������������������������

    ' ���ú�������
    '������������������������������������������������������������������������������������������������������������������������������������������

    ' ���ú�������
    '������������������������������������������������������������������������������������������������������������������������������������������

    ' ���ú�������
    '������������������������������������������������������������������������������������������������������������������������������������������
    Public Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        Me.Form1_FormClosing(Nothing, Nothing)
    End Sub
    Private Sub Label4_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label4.MouseDown
        Me.Label4.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\closen.png")
    End Sub

    Private Sub Label4_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label4.MouseHover
        Me.Label4.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\closeo.png")
        Me.ToolTip1.SetToolTip(Label4, "�ر�")
        Me.TextBox1.Focus()
    End Sub

    Private Sub Label4_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label4.MouseLeave
        Me.Label4.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\closeds.png")

    End Sub

    Private Sub Label4_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label4.MouseUp
        Me.Label4.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\closed.png")
    End Sub




    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Label2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseDown
        Me.Label2.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\mind.png")
    End Sub

    Private Sub Label2_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label2.MouseHover
        Me.Label2.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\mino.png")
        Me.ToolTip1.SetToolTip(Label2, "��С��")
        Me.TextBox1.Focus()
    End Sub

    Private Sub Label2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label2.MouseLeave
        Me.Label2.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\minn.png")

    End Sub

    Private Sub Label2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseUp
        Me.Label2.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\mino.png")
    End Sub




    Private Sub Label3_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label3.MouseDown
        Me.Label3.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\modd.png")
    End Sub

    Private Sub Label3_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label3.MouseHover
        Me.Label3.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\modo.png")
        Me.ToolTip1.SetToolTip(Label3, "�˵�ѡ��")
        Me.TextBox1.Focus()
    End Sub

    Private Sub Label3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label3.MouseLeave
        Me.Label3.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\modn.png")

    End Sub

    Private Sub Label3_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label3.MouseUp
        Me.Label3.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\modo.png")
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        ' Setting.ShowDialog()
        Me.ContextMenuStrip1.Show()
        ' Me.ContextMenuStrip1.Left = Label3.Left
        Me.ContextMenuStrip1.Top = Me.Top + Label3.Top + 20

        Me.ContextMenuStrip1.Left = Me.Left + Me.Label3.Left - 15
    End Sub

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click
        ' MsgBox(sender.ToString & "   \\\   " & e.ToString)
        If Me.mPlay_play_state < 1 And Me.OpenFileDialog1.FileName <> "" Then
            '  MsgBox(Me.OpenFileDialog1.FileNames)            
            ' MsgBox(Me.AxWindowsMediaPlayer1.settings.volume)
            mPlay_url = Me.AxWindowsMediaPlayer1.URL

            ' Me.Label16.Text = Me.TrackBar1.Maximum �������ʱ��
            'If Me.AxWindowsMediaPlayer1.currentMedia.duration > 3600 Then
            '    Me.Label16.Text = Format(Me.AxWindowsMediaPlayer1.currentMedia.duration \ 3600, "00") & ":" & Format((Me.AxWindowsMediaPlayer1.currentMedia.duration Mod 3600) \ 60, "00")
            'Else
            '    Me.Label16.Text = Format(Me.AxWindowsMediaPlayer1.currentMedia.duration \ 60, "00")
            'End If
            'Me.Label16.Text = Me.Label16.Text & ":" & Format(Me.AxWindowsMediaPlayer1.currentMedia.duration Mod 60, "00")

            ' Me.Label16.Text = Format(Me.AxWindowsMediaPlayer1.currentMedia.duration \ 60, "00") & ":" & Format(Me.AxWindowsMediaPlayer1.currentMedia.duration Mod 60, "00")

            ' MsgBox(mPlay_url)



            Me.Label11.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\playn.png")
            'Me.AxWindowsMediaPlayer1.Ctlcontrols.play()
            'MsgBox("open")
            Me.Timer1.Enabled = False
            Me.Timer1.Enabled = True
            Me.mPlay_play_state += 1
            Me.AxWindowsMediaPlayer1.Ctlcontrols.play()
            ' Label43_Click(Nothing, Nothing)  '�����������������������������������������������������Ƿ���ø�� 
            ' Me.Timer3.Enabled = True
        ElseIf Me.mPlay_play_state >= 1 Then

            If Me.AxWindowsMediaPlayer1.currentMedia.duration > 0 Then  '��ע�� ����˫�� ����ȫ������............................................................
                Me.TrackBar1.Maximum = Me.AxWindowsMediaPlayer1.currentMedia.duration
                Me.TrackBar4.Maximum = Me.AxWindowsMediaPlayer1.currentMedia.duration
                Me.TrackBar3.Value = Me.AxWindowsMediaPlayer1.settings.volume
                Me.TrackBar2.Value = Me.AxWindowsMediaPlayer1.settings.volume

                Me.Timer1.Enabled = True

            End If


            If AxWindowsMediaPlayer1.playState <> WMPLib.WMPPlayState.wmppsPlaying Then
                Me.AxWindowsMediaPlayer1.Ctlcontrols.play()
                Me.Timer1.Enabled = True
                Me.Label11.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\playn.png")
            Else
                Me.AxWindowsMediaPlayer1.Ctlcontrols.pause()
                Me.Label11.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\pausen.png")
                Me.Timer1.Enabled = False
                Me.mPlay_play_state = 0
            End If
            Me.mPlay_play_state = 2
        End If



        'km_yxSetting.checkEQ()  '�����Ч

        pictureBox3_play_state = 1
    End Sub
    Private Sub Label11_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label11.MouseHover
        If Me.mPlay_play_state > 1 Then
            If AxWindowsMediaPlayer1.playState <> WMPLib.WMPPlayState.wmppsPlaying Then

                Me.Label20.Text = "��ͣ"
                Me.Label11.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\paused.png")

            Else
                Me.Label20.Text = "����"
                Me.Label11.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\playd.png")
            End If
        Else
            Me.Label20.Text = "����"
            Me.Label11.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\playd.png")
        End If
        Me.Label20.Visible = True
        Me.Label20.Left = Me.Label11.Left
        Me.Label20.Top = Me.Label11.Top - Me.Label20.Height - 7
        'MsgBox(Me.AxWindowsMediaPlayer1.currentMedia.duration)
    End Sub

    Private Sub Label11_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label11.MouseLeave
        If Me.mPlay_play_state > 1 Then
            If AxWindowsMediaPlayer1.playState <> WMPLib.WMPPlayState.wmppsPlaying Then


                Me.Label11.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\pausen.png")
            Else

                Me.Label11.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\playn.png")

            End If
        Else
            Me.Label11.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\playn.png")
        End If
        Me.Label20.Visible = False

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try

            If Me.AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsReady Then
                Me.AxWindowsMediaPlayer1.Ctlcontrols.play()
            End If
            Me.TrackBar3.Value = Me.AxWindowsMediaPlayer1.settings.volume
            Me.TrackBar2.Value = Me.AxWindowsMediaPlayer1.settings.volume

            Me.TrackBar1.Maximum = Me.AxWindowsMediaPlayer1.currentMedia.duration
            Me.TrackBar4.Maximum = Me.AxWindowsMediaPlayer1.currentMedia.duration
            Label12.Text = Me.AxWindowsMediaPlayer1.Ctlcontrols.currentPositionString
            Label16.Text = Me.AxWindowsMediaPlayer1.currentMedia.durationString


            If Me.AxWindowsMediaPlayer1.settings.mute = True Then
                Me.Label33.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\muten.gif")
                Me.Label32.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\muten.gif")
                pictureBox8_sound_state = 1
            Else
                Me.Label33.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\spd.gif")
                Me.Label32.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\spn.gif")
                pictureBox8_sound_state = 0
            End If

            If Me.TrackBar1.Value = Fix(Me.AxWindowsMediaPlayer1.currentMedia.duration) Or Me.TrackBar1.Value = Fix(Me.AxWindowsMediaPlayer1.currentMedia.duration + 0.999) Then
                ' Me.AxWindowsMediaPlayer1.Ctlcontrols.stop()
                ' MsgBox(Me.AxWindowsMediaPlayer1.currentMedia.duration)
                Me.mplay_time_end()   '����ʾʱ�����
                Me.Timer3.Enabled = True
                Me.Timer1.Enabled = False
                Exit Sub
                'ElseIf AxWindowsMediaPlayer1.Ctlcontrols.currentPosition + 1 = Me.AxWindowsMediaPlayer1.currentMedia.duration Then
                '    Me.AxWindowsMediaPlayer1.Ctlcontrols.stop()
                '    Me.mplay_time_end()   '����ʾʱ�����
                '    Me.Timer3.Enabled = True
                '    Me.Timer1.Enabled = False


            ElseIf AxWindowsMediaPlayer1.playState <> WMPLib.WMPPlayState.wmppsStopped Then
                Me.TrackBar1.Value = AxWindowsMediaPlayer1.Ctlcontrols.currentPosition
                Me.TrackBar4.Value = AxWindowsMediaPlayer1.Ctlcontrols.currentPosition
                Me.Label20.Text = "���Ž��� +" & Me.TrackBar1.Value & "%"

                Me.Label26.Left = Me.TrackBar1.Left - Me.Label26.Width

            End If




            Me.Label12.Left = Me.TrackBar4.Left - Me.Label12.Width
        Catch ex As Exception
            MsgBox(ex.Message)
            debug_write("Timer1_Tick ʱ��ؼ����� ��1357 " & ex.Message.ToString)
            Me.Timer1.Enabled = False

        End Try

    End Sub

    Private Sub Label17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label17.Click

        Me.AxWindowsMediaPlayer1.Ctlcontrols.stop()
        Me.Timer1.Enabled = False

        Me.mPlay_play_state = 0
        'Me.Timer1.Enabled = False
        Me.TrackBar1.Value = 0
        Me.mplay_time_end()   '����ʾʱ�����
    End Sub

    Private Sub Label17_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label17.MouseHover
        Me.Label17.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\stopd.png")
        Me.Label20.Text = "ֹͣ"
        Me.Label20.Visible = True
        Me.Label20.Left = Me.Label17.Left - 12
        Me.Label20.Top = Me.Label17.Top - Me.Label20.Height - 7
    End Sub

    Private Sub Label17_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label17.MouseLeave
        Me.Label17.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\stopn.png")
        Me.Label20.Visible = False
    End Sub

    Private Sub TrackBar1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TrackBar1.MouseDown
        Me.Timer1.Enabled = False
        ' MsgBox(Me.TrackBar1.Value)
    End Sub

    Private Sub TrackBar1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBar1.MouseHover
        Me.Label20.Left = Me.TrackBar1.Left + Me.TrackBar1.Value
        Me.Label20.Top = Me.TrackBar1.Top - Me.Label20.Height
        Me.Label20.Visible = True
        Me.Label20.Text = "���Ž��� +" & Me.TrackBar1.Value

        textbox1_Focus = 1  '��textBox ʧȥ����
    End Sub

    Private Sub TrackBar1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBar1.MouseLeave
        Me.Label20.Visible = False
        textbox1_Focus = 0  '��textBox ��ý���
    End Sub

    Private Sub TrackBar1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TrackBar1.MouseUp
        Me.Timer1.Enabled = True
        Me.AxWindowsMediaPlayer1.Ctlcontrols.currentPosition = Me.TrackBar1.Value
    End Sub

    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        If Me.TrackBar1.Value = Me.AxWindowsMediaPlayer1.currentMedia.duration Then
            Me.AxWindowsMediaPlayer1.Ctlcontrols.stop()
            Me.Timer1.Enabled = False
            Me.mplay_time_end()   '����ʾʱ�����
            Me.Timer2.Enabled = False
            Me.Label27.Left = Me.Label10.Left + Me.Label10.Width + 2
        Else

            If Me.AxWindowsMediaPlayer1.URL <> "" Then
                Try
                    Me.AxWindowsMediaPlayer1.Ctlcontrols.currentPosition = Me.TrackBar1.Value
                    Me.TrackBar4.Value = Me.TrackBar1.Value
                Catch ex As Exception
                    'MsgBox(ex.Message)
                    debug_write("me.TrackBar1_Scroll ���� ��1427 " & ex.Message)
                End Try
            End If
        End If

    End Sub


    Private Sub Label19_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label19.MouseHover
        Me.Label19.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\spo.gif")
        Me.Label20.Visible = True
        Me.Label20.Text = "��������"
        Me.Label20.Left = Me.Label19.Left
        Me.Label20.Top = Me.Label19.Top - Me.Label20.Height - 7
    End Sub

    Private Sub Label19_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label19.MouseLeave
        Me.Label19.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\spn.gif")
        Me.Label20.Visible = False
    End Sub

    Private Sub Label19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label19.Click
        'mplay_sound_state 
        Me.Label20.Visible = False
        Me.TrackBar2.Visible = True
    End Sub

    Private Sub Label21_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Label20.Visible = False

    End Sub
    Private Sub label21_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.Label21.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\eqbn.gif")
    End Sub

    Private Sub label21_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Me.Label21.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\eqbo.gif")
    End Sub
    Private Sub label21_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Me.mplay_sound_state = 0
        y = e.Y

    End Sub
    Private Sub label21_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If Me.mplay_sound_state = 1 Then
            ' Me.Label21.Top = e.Y + Me.PictureBox5.Top - y
        End If

    End Sub

    Private Sub label21_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Me.mplay_sound_state = 0
    End Sub

    Private Sub TrackBar2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TrackBar2.KeyPress
        MsgBox(e.KeyChar)
    End Sub

    Private Sub TrackBar2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBar2.MouseLeave
        Me.TrackBar2.Visible = False

        textbox1_Focus = 0 '��textBox ��ý���

    End Sub

    Private Sub TrackBar2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TrackBar2.MouseMove
        If Me.TrackBar2.Value = 0 Then
            Me.Label19.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\muten.gif")
        Else
            Me.Label19.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\spn.gif")
        End If
    End Sub


    Private Sub TrackBar2_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar2.Scroll
        If Me.AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsPlaying Then
            Me.AxWindowsMediaPlayer1.settings.volume = Me.TrackBar2.Value
            Me.TrackBar3.Value = Me.TrackBar2.Value
        End If

        textbox1_Focus = 1  '��textBox ʧȥ����
    End Sub





    Private Sub TabPage3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.TrackBar2.Visible = False
        Me.Label20.Visible = False
    End Sub



    Private Sub ����ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ����ToolStripMenuItem.Click
        Setting.ShowDialog()
    End Sub

    Private Sub ListBox1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListBox1.DragDrop
        ' �Ͻ�����Ĳ���
        Try

            Dim Music_name, Music_playTime, Music_zj, music_type, Music_auther As String
            Dim Music_M As Long
            Dim a() As String = {"*.mp3", "*.ac3", " *.dts", " *.ddp", " *.ec3", "*.mka", "*.mpa", "*.mp2", "*.m1a", "*.m2a", "*.wma", "*.ape", " *.flac", "*.shn", "*.tta", " *.wav", " *.wv", "1"}



            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                Dim myfiles() As String
                'myds.Clear()
                myfiles = e.Data.GetData(DataFormats.FileDrop)

                Dim f As Integer


                For f = 0 To myfiles.Length - 1


                    ''���ļ��� ������һ���ļ����������ݿ�(����)
                    If myfiles(f).Trim <> "" Then
                        Music_name = ""


                        Dim s As String
                        Dim j As Integer = 0
                        ' MsgBox(Len(Me.OpenFileDialog1.FileName))

                        Dim i As Integer
                        For i = Len(myfiles(f).Trim) To 1 Step -1

                            s = Mid(myfiles(f).Trim, i, 1)
                            j = j + 1
                            'MsgBox(Music_name & "��   ��ȡ���ȣ�" & Len(Me.OpenFileDialog1.FileName) - j & "��  ��ȡ������" & j)
                            '   MsgBox("s=" & s)
                            If s = "\" Then
                                ' Music_name = Mid(Me.OpenFileDialog1.FileName, i, j)
                                '  MsgBox(Music_name & vbCrLf & "��   ��ȡ���ȣ�"i & "��  ��ȡ������" & j )
                                Exit For
                            End If
                        Next
                        '  MsgBox("i=" & i)
                        ' msgbox( Mid(Me.OpenFileDialog1.FileName, i + 1, j))


                        If j < Len(myfiles(f).Trim) Then
                            Music_name = Trim(Mid(myfiles(f).Trim, i + 1, j))
                        End If



                        '�����ȡ�ĸ���������


                        Music_auther = ""  '      Ϊ�˷�ֹ����������
                        For i = Len(Music_name) To 1 Step -1
                            s = Mid(Music_name, i, 1)
                            If s = "-" Then
                                Music_auther = Trim(Mid(Music_name, 1, i - 1))
                                'MsgBox(Music_auther)
                                Exit For
                            End If
                        Next
                        '�����ȡ���Ǹ���

                        Music_playTime = ""

                        ' Music_auther = Split(Me.OpenFileDialog1.FileName, "-")
                        Music_zj = ""

                        Music_M = 0
                        Dim fi As New FileInfo(myfiles(f).Trim)
                        Music_M = fi.Length

                        music_type = "" '      Ϊ�˷�ֹ����������

                        'MsgBox(fi.Length.ToString)



                        '���������ͣ���Ƶ����Ƶ��
                        j = 0
                        For i = Len(Music_name) To 1 Step -1
                            s = Mid(Music_name, i, 1)
                            j = j + 1
                            If s = "." Then
                                music_type = Trim(Mid(Music_name, i, j))
                                ' MsgBox(music_type)
                                Exit For
                            End If

                        Next
                        'music_type = Mid(myfiles(0).Trim, Len(myfiles(0).Trim) - 2, 3)


                        For j = 0 To UBound(a) - 1
                            If ("*" & music_type) = a(j) Then
                                Exit For
                            End If
                        Next
                        If j > UBound(a) - 1 Then
                            MsgBox("�������Ƶ�ļ�")
                            Exit Try
                        End If

                        ' Exit Sub
                        Dim mycmd As New OleDbCommand
                        mysql = "select * from mlist where Music_path='" & myfiles(f).Trim & "'"

                        'MsgBox(mysql)  '��������������Ϊ��������

                        myconn.Open()
                        Dim myda1 As New OleDbDataAdapter(mysql, myconn)
                        myda1.Fill(myds, "student1")
                        myconn.Close()
                        If myds.Tables("student1").Rows.Count = 1 Then
                            'MsgBox("���ܲ�����ͬѧ�ŵļ�¼", MsgBoxStyle.OkOnly, "��Ϣ��ʾ")
                        Else
                            myconn.Open()

                            mysql = "insert into mlist (Music_name,Music_path,Music_playTime,Music_auther,Music_zj,Music_M,Music_type) values(" _
                            & "'" & Music_name & "','" & myfiles(f).Trim & "','" & Music_playTime & "','" & Music_auther & _
                             "','" & Music_zj & "'," & Music_M & ",'" & music_type & "')"
                            mycmd.Connection = myconn
                            mycmd.CommandText = mysql
                            mycmd.ExecuteNonQuery()
                            myconn.Close()

                        End If
                        myds.Clear()

                    End If


                Next

            End If
            list_cls_add()
            Me.ListBox1.SelectedIndex = list_SingleSelectIndex
        Catch ex As Exception
            myconn.Close()
            myds.Clear()
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub ListBox1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListBox1.DragEnter
        '�ϵ� �Ĳ���
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub




    Private Sub ListBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox1.MouseMove
        'Me.PictureBox6.Visible = True
        'Me.PictureBox6.Left = Me.ListBox1.Width + Me.ListBox1.Left
        ' Auther_Message.Show()
        Auther_Message.Left = Me.ListBox1.Width + Me.ListBox1.Left + Me.Left + Me.PictureBox1.Left - 1
        ' MsgBox(e.Y.ToString)
        'If e.Y + Me.ListBox1.Top + Me.PictureBox6.Height >= Me.Height Then
        If e.Y + Me.ListBox1.Top + Auther_Message.Height + Me.PictureBox1.Top >= Me.Height Then
            ' Me.PictureBox6.Top = Me.Height - Me.PictureBox6.Height
            Auther_Message.Top = Me.Top + Me.Height - Auther_Message.Height + Me.PictureBox1.Top
        Else
            ' Me.PictureBox6.Top = e.Y + Me.ListBox1.Top - 3
            Auther_Message.Top = e.Y + Me.ListBox1.Top - 3 + Me.PictureBox1.Top + Me.Top
        End If
        'pic6_childen_show()

        Auther_Message.Auther_Message_change(1, True)

    End Sub



    Private Sub ListBox1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.MouseHover

        textbox1_Focus = 1 '��textBox ʧȥ����

        'Me.PictureBox8_hidePic()

        If Me.ListBox1.SelectedItem <> "" Then
            Label24.Text = Me.ListBox1.SelectedItem
            ' label24_show_len()
        End If

    End Sub

    Private Sub ListBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.MouseLeave
        textbox1_Focus = 0 '��textBox ��ý���

        Me.TextBox1.Focus()
        ' Me.PictureBox6.Visible = False
        'pic6_childen_hide()

        Auther_Message.Hide()
    End Sub





    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click



        Dim Music_name, Music_playTime, Music_zj, music_type, Music_auther As String
        Dim Music_M As Long


        Try
            Me.OpenFileDialog1.Title = "��ӵ���"
            'Me.OpenFileDialog1.Filter = "(*.��Ƶ)|*.mpg; *.mpeg;*.mpe;*.m1v; *.m2p; *.m2v; *.mpv2; *.mp2v; *.dat; *.ts; *.tp;*.tpr; *.pva; *.pss;*.mp3;*.mkv;*.mid;*.wmv;*.avi;*.mp4;*.rmvb|All file(*.*)|*.*"
            Me.OpenFileDialog1.Filter = "*.����|*.mp3;*.ac3; *.dts; *.ddp; *.ec3;*.mka;*.mpa;*.mp2;*.m1a;*.m2a;*.wma;*.ape; *.flac;*.shn;*.tta; *.wav; *.wv|����|*.*"
            ' Me.OpenFileDialog1.FilterIndex = 2  'Ĭ�ϴ򿪸�ʽ

            Me.OpenFileDialog1.InitialDirectory = My.Application.Info.DirectoryPath & "\����\"
            Me.OpenFileDialog1.RestoreDirectory = True
            Me.OpenFileDialog1.ShowDialog()

            ''���ļ��� ������һ���ļ����������ݿ�(����)
            If Me.OpenFileDialog1.FileName.ToString <> "" Then
                Music_name = ""

                'Dim mPath As String = Me.OpenFileDialog1.FileName
                ' Dim mDir As New System.IO.DirectoryInfo(mPath)
                ' For Each sFile As System.IO.FileInfo In mDir.GetFiles("*.mp3"
                ' Me.ListBox1.Items.Add(sFile.Name)
                ' Next sFile
                ' MsgBox(New FileStream(Me.OpenFileDialog1.FileName))
                ' Exit Sub
                ' sFile = mDir.GetFiles("*.mp3")
                'MsgBox("��ʼ����")
                Dim s As String
                Dim j As Integer = 0
                ' MsgBox(Len(Me.OpenFileDialog1.FileName))

                Dim i As Integer
                For i = Len(Me.OpenFileDialog1.FileName) To 1 Step -1

                    s = Mid(Me.OpenFileDialog1.FileName, i, 1)
                    j = j + 1
                    'MsgBox(Music_name & "��   ��ȡ���ȣ�" & Len(Me.OpenFileDialog1.FileName) - j & "��  ��ȡ������" & j)
                    '   MsgBox("s=" & s)
                    If s = "\" Then
                        ' Music_name = Mid(Me.OpenFileDialog1.FileName, i, j)
                        '  MsgBox(Music_name & vbCrLf & "��   ��ȡ���ȣ�"i & "��  ��ȡ������" & j )
                        Exit For
                    End If
                Next
                '  MsgBox("i=" & i)
                ' msgbox( Mid(Me.OpenFileDialog1.FileName, i + 1, j))


                If j < Len(Me.OpenFileDialog1.FileName) Then
                    Music_name = Trim(Mid(Me.OpenFileDialog1.FileName, i + 1, j))
                End If



                '�����ȡ�ĸ���������


                Music_auther = ""  '      Ϊ�˷�ֹ����������
                For i = Len(Music_name) To 1 Step -1
                    s = Mid(Music_name, i, 1)
                    If s = "-" Then
                        Music_auther = Trim(Mid(Music_name, 1, i - 1))
                        'MsgBox(Music_auther)
                        Exit For
                    End If
                Next
                '�����ȡ���Ǹ���

                Music_playTime = ""

                ' Music_auther = Split(Me.OpenFileDialog1.FileName, "-")
                Music_zj = ""

                Music_M = 0
                Dim fi As New FileInfo(Me.OpenFileDialog1.FileName)
                Music_M = fi.Length

                music_type = "" '      Ϊ�˷�ֹ����������

                'MsgBox(fi.Length.ToString)
                j = 0
                For i = Len(Music_name) To 1 Step -1
                    s = Mid(Music_name, i, 1)
                    j = j + 1
                    If s = "." Then
                        music_type = Trim(Mid(Music_name, i, j))
                        ' MsgBox(music_type)
                        Exit For
                    End If

                Next
                'music_type = Mid(Me.OpenFileDialog1.FileName.ToString, Len(Me.OpenFileDialog1.FileName.ToString) - 2, 3)





                ' Exit Sub
                Dim mycmd As New OleDbCommand
                mysql = "select * from mlist where Music_path='" & Me.OpenFileDialog1.FileName.ToString & "'"

                'MsgBox(mysql)  '��������������Ϊ��������

                myconn.Open()
                Dim myda1 As New OleDbDataAdapter(mysql, myconn)
                myda1.Fill(myds, "student1")
                myconn.Close()
                If myds.Tables("student1").Rows.Count = 1 Then
                    'MsgBox("���ܲ�����ͬѧ�ŵļ�¼", MsgBoxStyle.OkOnly, "��Ϣ��ʾ")
                Else
                    myconn.Open()

                    mysql = "insert into mlist (Music_name,Music_path,Music_playTime,Music_auther,Music_zj,Music_M,Music_type) values(" _
                    & "'" & Music_name & "','" & Me.OpenFileDialog1.FileName.ToString & "','" & Music_playTime & "','" & Music_auther & _
                     "','" & Music_zj & "'," & Music_M & ",'" & music_type & "')"
                    mycmd.Connection = myconn
                    mycmd.CommandText = mysql
                    mycmd.ExecuteNonQuery()
                    myconn.Close()

                End If
                myds.Clear()
                list_cls_add()
                Me.ListBox1.SelectedIndex = list_SingleSelectIndex
            End If
            ''�ļ�д��ĸ�ʽ   �ļ���������������·��\...mp3�����ų���
            ''
            '
            'Ĭ�ϲ����б���ĵ�һ�׸�
            '
            '
            '

            ' list_cls_add()
        Catch ex As Exception
            ' MsgBox(Me.OpenFileDialog1.DefaultExt & ex.Message)
            debug_write(" Label8_Click ��ӵ�������  ��1717 " & ex.Message)
            myconn.Close()
            myds.Clear()
        End Try

    End Sub

    Private Sub Label8_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label8.MouseDown
        Me.Label8.BorderStyle = BorderStyle.Fixed3D
    End Sub
    Private Sub Label8_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label8.MouseHover
        Me.Label8.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\beijing\tjwj-o.png")
    End Sub

    Private Sub Label8_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label8.MouseLeave

        Me.Label8.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\beijing\tjwj.png")

        Me.Label8.BorderStyle = BorderStyle.None

    End Sub


    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click
        Dim i As Integer
        Dim Music_name, Music_type, Music_playTime As String
        'Dim sql As String
        Music_name = ""
        Music_type = ""
        Music_playTime = ""




        i = 0
        Try
            ' list_SingleSelectIndex = Me.ListBox1.SelectedIndex
            Dim s As String
            Dim j As Integer = 0
            Me.FolderBrowserDialog1.ShowDialog()
            If Me.FolderBrowserDialog1.SelectedPath <> "" Then
                Dim mPath As String = Me.FolderBrowserDialog1.SelectedPath
                Dim mDir As New System.IO.DirectoryInfo(mPath)
                For Each sFile As System.IO.FileInfo In mDir.GetFiles("*.mp3")
                    'System.Diagnostics.Process.Start(sFile.FullName)
                    '���ļ�
                    Dim mycmd As New OleDbCommand
                    mysql = "select * from mlist where Music_name='" & sFile.Name & "'"

                    myconn.Open()
                    Dim myda1 As New OleDbDataAdapter(mysql, myconn)
                    myda1.Fill(myds, "student1")
                    myconn.Close()
                    If myds.Tables("student1").Rows.Count = 1 Then

                    Else
                        Dim Music_auther, Music_zj As String

                        Music_zj = ""



                        ' MsgBox(Len(Me.OpenFileDialog1.FileName))



                        Music_name = sFile.Name
                        Music_auther = ""  '      Ϊ�˷�ֹ����������
                        For i = Len(Music_name) To 1 Step -1
                            s = Mid(Music_name, i, 1)
                            If s = "-" Then
                                Music_auther = Trim(Mid(Music_name, 1, i - 1))
                                'MsgBox(Music_auther)
                                Exit For
                            End If
                        Next
                        '�����ȡ���Ǹ���

                        Music_playTime = ""

                        ' Music_auther = Split(Me.OpenFileDialog1.FileName, "-")
                        Music_zj = ""

                        Music_type = "" '      Ϊ�˷�ֹ����������
                        j = 0
                        For i = Len(Music_name) To 1 Step -1
                            s = Mid(Music_name, i, 1)
                            j = j + 1
                            If s = "." Then
                                Music_type = Trim(Mid(Music_name, i, j))
                                ' MsgBox(music_type)
                                Exit For
                            End If

                        Next


                        myconn.Open()
                        mysql = "insert into mlist (Music_name,Music_path,Music_auther,Music_zj,Music_M,Music_type) values(" _
                        & "'" & sFile.Name & "','" & sFile.FullName & "','" & Music_auther & "','" & Music_zj & "','" & sFile.Length & "','" & sFile.Extension & "')"
                        mycmd.Connection = myconn
                        mycmd.CommandText = mysql
                        mycmd.ExecuteNonQuery()
                        myconn.Close()
                        i = i + 1
                        Me.ListBox1.Items.Add(i & " " & sFile.Name)
                    End If
                    myds.Clear()



                Next sFile

                If j = 0 Then
                    MsgBox("��Ŀ¼û�и���")
                    Exit Sub
                End If
                ' Me.ListBox1.Items.Add(Me.FolderBrowserDialog1.SelectedPath)
                ''���ļ��� ������һ���ļ���list.lst ����ʲô
                ''
                ''�ļ�д��ĸ�ʽ   �ļ���������������·��\...mp3�����ų���
                ''
                '
                'Ĭ�ϲ����б���ĵ�һ�׸�
                '
                '
                Me.ListBox1.SelectedIndex = list_SingleSelectIndex
                list_cls_add()

            End If

        Catch ex As Exception
            'MsgBox(Me.OpenFileDialog1.DefaultExt & ex.Message)
            debug_write("me.Label9_Click  ����ļ��д��� ��1843 " & ex.Message)
            myconn.Close()
        End Try
    End Sub
    Private Sub Label9_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label9.MouseDown
        Me.Label9.BorderStyle = BorderStyle.Fixed3D
    End Sub

    Private Sub Label9_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label9.MouseHover
        Me.Label9.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\beijing\tjwjj-o.png")
    End Sub

    Private Sub Label9_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label9.MouseLeave

        Me.Label9.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\beijing\tjwjj.png")

        Me.Label9.BorderStyle = BorderStyle.None
    End Sub



    Private Sub ListBox1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox1.MouseDoubleClick
        label24_show_len(Me.ListBox1.SelectedItem)


        Dim Music_PlayCi As Integer = 0

        ' Me.AxWindowsMediaPlayer1.Ctlcontrols.stop()

        Dim i, j As Integer
        Dim select_item As String
        'myconn.Close()

        Try


            select_item = ""
            For i = 1 To Len(ListBox1.SelectedItem)
                j = j + 1
                select_item = Mid(ListBox1.SelectedItem, i, 1)

                If select_item = " " Then
                    select_item = Mid(ListBox1.SelectedItem, i + 2)

                    Exit For
                End If
            Next
            ' MsgBox(select_item)
            ' lrc_name = Trim(select_item)

            If select_item <> "" Then
                'MsgBox("ok")
                mysql = "select * from mlist where Music_name='" & Trim(select_item) & "'"

                myconn.Open()
                Dim myda1 As New OleDbDataAdapter(mysql, myconn)
                myda1.Fill(myds, "Music1")
                myconn.Close()
                'MsgBox(myds.Tables("Music1").Rows.Count)
                If myds.Tables("Music1").Rows.Count = 1 Then


                    '���ж��Ƿ� �д��ļ����ھ�������
                    '����
                    'Dim mPath As String = myds.Tables("Music1").Rows(0).Item(2).ToString
                    'Dim mDir As New System.IO.DirectoryInfo(mPath)
                    'Dim mwj As New System.IO.FileAttributes(mDir)

                    ' MsgBox(myds.Tables("Music1").Rows(0).Item(2).ToString)
                    If File.Exists(myds.Tables("Music1").Rows(0).Item(2).ToString) Then


                        Me.mPlay_play_state = 0
                        Me.OpenFileDialog1.FileName = myds.Tables("Music1").Rows(0).Item(2).ToString
                        Music_PlayCi = myds.Tables("Music1").Rows(0).Item(4)
                        Music_PlayCi = Music_PlayCi + 1
                        Me.AxWindowsMediaPlayer1.URL = Me.OpenFileDialog1.FileName
                        '  MsgBox("ok")
                        Me.Label21.Text = Trim(select_item)
                        Me.Label27.Text = Trim(select_item)
                        Auther_Message.Auther_Message_change(1, False)
                        Me.Label14.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\playn.png")
                        Me.Timer2.Interval = 500
                        'Me.Timer2.Enabled = True

                        list_SingleSelectIndex = Me.ListBox1.SelectedIndex
                        Call Me.Label11_Click(Nothing, Nothing)
                        myds.Clear()

                        Dim mycmd As New OleDbCommand
                        myconn.Open()
                        mysql = "update mlist set " & "Music_playCi=" & Music_PlayCi & "  where Music_name='" & Trim(select_item) & "'"
                        mycmd.Connection = myconn
                        mycmd.CommandText = mysql
                        mycmd.ExecuteNonQuery()
                        myconn.Close()


                        list_mouseClick_boolean = True '��picturebox6��ĸ����� ��ʾ�ĳ��ȣ����ܴ���picturebox6�Ĵ�
                    Else
                        If (MsgBox("���ݿ��еĸ���·������  �Ƿ�ɾ���˸���", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok) Then
                            Dim mycmd As New OleDbCommand
                            myconn.Open()
                            mysql = "delete * from mlist  where Music_name='" & Trim(select_item) & "'"
                            mycmd.Connection = myconn
                            mycmd.CommandText = mysql
                            mycmd.ExecuteNonQuery()
                            myconn.Close()
                            myds.Clear()

                            ListBox1.Items.Remove(Me.ListBox1.SelectedItem)
                            Me.list_cls_add() '

                        End If
                    End If
                    '  Music_list = Me.BindingContext(myds, "Music1")
                    ' Me.AxWindowsMediaPlayer1.Play()
                    myds.Clear()

                End If
            End If
        Catch ex As Exception
            ' MsgBox(ex.Message)
            debug_write("me.ListBox1_MouseDoubleClick �����б������Ÿ������� ��1947 " & ex.Message)
            myconn.Close()
            myds.Clear()
        End Try

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick

        '���� ��ʾ ������ �����б����ģ������Ҷ�̬����

        If Me.Label27.Left + Me.Label27.Width + 10 > Me.PictureBox3.Left + Me.PictureBox3.Width And Me.timer2_left = 0 Then
            Me.Label27.Left -= 1
        Else
            Me.timer2_left = 1
        End If

        If Me.timer2_left = 1 And Me.Label27.Left - 10 <= Me.PictureBox3.Left Then
            Me.Label27.Left += 1
        Else
            Me.timer2_left = 0
        End If

    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        Label8_Click(Nothing, Nothing)
    End Sub

    Private Sub ����ļ���ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ����ļ���ToolStripMenuItem.Click
        Me.Label9_Click(Nothing, Nothing)
    End Sub



    Private Sub ListBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox1.MouseUp

        label24_show_len(Me.ListBox1.SelectedItem)  'pictureBox�ϵĸ��� �仯


        '....................................ListBox1 �һ� �˵� �����˵��仯 
        Dim i, j As Integer
        Dim select_item As String
        'myconn.Close()
        j = 0
        Try
            select_item = ""
            For i = 1 To Len(ListBox1.SelectedItem)
                j = j + 1
                select_item = Mid(ListBox1.SelectedItem, i, 1)

                If select_item = " " Then
                    select_item = Mid(ListBox1.SelectedItem, i + 2)

                    Exit For
                End If
            Next
            Me.��������ToolStripMenuItem.Text = "��������  '" & Trim(select_item) & "'  "
            Me.�������ToolStripMenuItem.Text = "�������  '" & Trim(select_item) & "'  "
            'MsgBox(Me.��������ToolStripMenuItem.Text)
            ' MsgBox(Me.�������ToolStripMenuItem.Text)
            ' Me.Label24.Text = Me.ListBox1.SelectedItem
        Catch ex As Exception
            'MsgBox(ex.Message)
            debug_write("me.ListBox1_MouseUp �������� ��2011 " & ex.Message.ToString)
        End Try
        '....................................ListBox1 �һ� �˵� �����˵��仯 

    End Sub

    Private Sub ����ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ����ToolStripMenuItem1.Click
        ListBox1_MouseDoubleClick(Nothing, Nothing)
    End Sub

    Private Sub ���ļ�Ŀ¼ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ���ļ�Ŀ¼ToolStripMenuItem.Click
        If Me.ListBox1.SelectedItem <> "" Then
            Dim i, j As Integer
            Dim select_item As String
            'myconn.Close()
            j = 0
            Try
                select_item = ""
                For i = 1 To Len(ListBox1.SelectedItem)
                    j = j + 1
                    select_item = Mid(ListBox1.SelectedItem, i, 1)

                    If select_item = " " Then
                        select_item = Mid(ListBox1.SelectedItem, i + 2)

                        Exit For
                    End If
                Next
                ' MsgBox(select_item)


                If select_item <> "" Then
                    'MsgBox("ok")
                    mysql = "select * from mlist where Music_name='" & Trim(select_item) & "'"

                    myconn.Open()
                    Dim myda1 As New OleDbDataAdapter(mysql, myconn)
                    myda1.Fill(myds, "Music1")
                    myconn.Close()
                    'MsgBox(myds.Tables("Music1").Rows.Count)
                    If myds.Tables("Music1").Rows.Count = 1 Then

                        '���ļ��ķ��������£����ļ����ͣ�ֻҪϵͳ�ϵã��Ϳ��ԣ��������·�������Ǵ�·�����ļ���
                        System.Diagnostics.Process.Start(Mid(myds.Tables("Music1").Rows(0).Item(2), 1, Len(myds.Tables("Music1").Rows(0).Item(2)) - Len(Trim(select_item))))
                        'System.Diagnostics.Process
                    End If
                    myds.Clear()
                End If
            Catch ex As Exception
                'MsgBox(ex.Message)
                debug_write("me.���ļ�Ŀ¼ToolStripMenuItem_Click ���� ��2061  " & ex.Message.ToString)
                myconn.Close()
                myds.Clear()
            End Try
        End If


    End Sub


    Private Sub ɾ��ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ɾ��ToolStripMenuItem1.Click
        If Me.ListBox1.SelectedItem <> "" Then
            Dim i, j As Integer
            Dim select_item As String
            'myconn.Close()
            j = 0
            Try
                select_item = ""
                For i = 1 To Len(ListBox1.SelectedItem)
                    j = j + 1
                    select_item = Mid(ListBox1.SelectedItem, i, 1)

                    If select_item = " " Then
                        select_item = Mid(ListBox1.SelectedItem, i + 2)

                        Exit For
                    End If
                Next
                ' MsgBox(select_item)
                If Me.list_SingleSelectIndex > ListBox1.SelectedIndex Then
                    Me.list_SingleSelectIndex -= 1
                End If

                If select_item <> "" Then
                    'MsgBox("ok")
                    Dim mycmd As New OleDbCommand
                    myconn.Open()
                    mysql = "delete from mlist where Music_name='" & Trim(select_item) & "'"
                    mycmd.Connection = myconn
                    mycmd.CommandText = mysql
                    mycmd.ExecuteNonQuery()
                    myconn.Close()
                    myds.Clear()



                    list_cls_add()
                End If
            Catch ex As Exception
                ' MsgBox(ex.Message)
                debug_write("ɾ��ToolStripMenuItem1_Click ���� ��2111  " & ex.Message.ToString)
                myconn.Close()
                myds.Clear()
            End Try


        End If
    End Sub

    Private Sub ����ɾ�����������ļ�ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ����ɾ�����������ļ�ToolStripMenuItem.Click



        If Me.ListBox1.SelectedItem <> "" Then
            Dim i, j As Integer
            Dim select_item As String
            'myconn.Close()
            j = 0
            Try
                select_item = ""
                For i = 1 To Len(ListBox1.SelectedItem)
                    j = j + 1
                    select_item = Mid(ListBox1.SelectedItem, i, 1)

                    If select_item = " " Then
                        select_item = Mid(ListBox1.SelectedItem, i + 2)

                        Exit For
                    End If
                Next
                ' MsgBox(select_item)
                If Me.list_SingleSelectIndex > ListBox1.SelectedIndex Then
                    Me.list_SingleSelectIndex -= 1
                End If

                If select_item <> "" Then
                    If MsgBox("ȷ��ɾ���ļ� '" & Me.ListBox1.SelectedItem & "'", 1 + 48, "����ɾ���ļ�") = MsgBoxResult.Ok Then
                        mysql = "select * from mlist where Music_name='" & Trim(select_item) & "'"

                        myconn.Open()
                        Dim myda1 As New OleDbDataAdapter(mysql, myconn)
                        myda1.Fill(myds, "Music1")
                        myconn.Close()
                        'MsgBox(myds.Tables("Music1").Rows.Count)
                        If myds.Tables("Music1").Rows.Count = 1 Then


                            File.Delete(myds.Tables("Music1").Rows(0).Item(2))

                            ' MsgBox(myds.Tables("Music1").Rows(0).Item(2))
                        End If
                        myds.Clear()


                        Dim mycmd As New OleDbCommand
                        myconn.Open()
                        mysql = "delete from mlist where Music_name='" & Trim(select_item) & "'"
                        mycmd.Connection = myconn
                        mycmd.CommandText = mysql
                        mycmd.ExecuteNonQuery()
                        myconn.Close()
                        myds.Clear()
                    End If
                    list_cls_add()

                    If Me.AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsPlaying Then
                        Me.AxWindowsMediaPlayer1.Ctlcontrols.stop()
                        Me.AxWindowsMediaPlayer1.URL = ""
                        Call Me.ListBox1_MouseDoubleClick(Nothing, Nothing)
                    Else
                        Call Me.ListBox1_MouseDoubleClick(Nothing, Nothing)
                        Me.AxWindowsMediaPlayer1.Ctlcontrols.stop()
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                debug_write("����ɾ�����������ļ�ToolStripMenuItem_Click ��2187 " & ex.Message.ToString)
                myconn.Close()
                myds.Clear()
            End Try


        End If



    End Sub

    Private Sub ��������ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ��������ToolStripMenuItem.Click

    End Sub

    Private Sub �������ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �������ToolStripMenuItem.Click

    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick

        ''���� ��������0������ѭ��1��˳�򲥷�2���б���3���������4
        'Dim timer3_playSetting As Integer = 0
        '���ݿ��е��ֶ�ΪplaySetting

        Me.Timer2.Enabled = False


        mplay_play_moshi()

        Me.Timer3.Enabled = False

    End Sub

    Private Sub ��������ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ��������ToolStripMenuItem.Click
        timer3_playSetting = 0
        Me.Label5_pic_show()
    End Sub

    Private Sub ����ѭ��ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ����ѭ��ToolStripMenuItem.Click
        timer3_playSetting = 1
        Me.Label5_pic_show()
    End Sub

    Private Sub ˳�򲥷�ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ˳�򲥷�ToolStripMenuItem.Click
        timer3_playSetting = 2
        Me.Label5_pic_show()
    End Sub

    Private Sub �б���ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �б���ToolStripMenuItem.Click
        timer3_playSetting = 3
        Me.Label5_pic_show()
    End Sub

    Private Sub �������ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �������ToolStripMenuItem.Click
        timer3_playSetting = 4
        Me.Label5_pic_show()
    End Sub

    Private Sub �Զ��л��б�ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �Զ��л��б�ToolStripMenuItem.Click

    End Sub

    '��һ��
    Private Sub Label13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label13.Click
        ' Me.Label13.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\prevo.png")
        If Me.ListBox1.Items.Count > 0 Then
            Me.ListBox1.SelectedIndex = list_SingleSelectIndex

            If Me.ListBox1.SelectedItem <> "" Then
                If timer3_playSetting = 4 Then
                    Random_play()
                Else

                    If Me.ListBox1.SelectedIndex - 1 >= 0 Then
                        Me.ListBox1.SelectedIndex -= 1
                    Else
                        Me.ListBox1.SelectedIndex = Me.ListBox1.Items.Count - 1
                    End If
                End If

                pictureBox3_play_state = 0
                Me.Label14.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\playn.png")
                Label14_Click(Nothing, Nothing)
            End If
        End If


    End Sub

    Private Sub Label13_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label13.MouseDown
        Me.Label13.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\prevds.png")
    End Sub


    Private Sub Label13_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label13.MouseHover
        Me.Label13.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\prevd.png")
        Me.PictureBox8_hidePic()
        Me.ToolTip1.SetToolTip(Label13, "��һ��")
    End Sub

    Private Sub Label13_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label13.MouseLeave
        Me.Label13.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\prevn.png")
    End Sub
    Private Sub Label13_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label13.MouseUp
        Me.Label13.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\prevd.png")
    End Sub

    '����/��ͣ
    ' Dim pictureBox3_play_state As Integer = 0
    'Dim pictureBox3_sound_state As Integer = 0
    Public Sub Label14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label14.Click

        ' Me.Label13.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\prevo.png")
        Dim i, j As Integer
        Dim select_item As String
        select_item = ""
        For i = 1 To Len(ListBox1.SelectedItem)
            j = j + 1
            select_item = Mid(ListBox1.SelectedItem, i, 1)

            If select_item = " " Then
                select_item = Mid(ListBox1.SelectedItem, i + 2)

                Exit For
            End If
        Next i
        If pictureBox3_play_state = 0 Then
            Me.ListBox1_MouseDoubleClick(Nothing, Nothing)
            Me.Label14.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\playn.png")
        Else
            If Me.AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsPlaying And pictureBox3_play_state >= 1 Then
                Me.AxWindowsMediaPlayer1.Ctlcontrols.pause()
                pictureBox3_play_state = 2
                'Me.Label14.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\pausen.png")
            Else
                Me.AxWindowsMediaPlayer1.Ctlcontrols.play()
                ' Me.Label14.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\playn.png")
                '��ע�� ����˫�� ����ȫ������............................................................
                Me.TrackBar1.Maximum = Me.AxWindowsMediaPlayer1.currentMedia.duration
                Me.TrackBar2.Value = Me.AxWindowsMediaPlayer1.settings.volume
                Me.Timer1.Enabled = True

                pictureBox3_play_state = 1
            End If
        End If


        'MsgBox(Me.Label27.Text)
    End Sub

    Public Sub Label14_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label14.MouseDown
        If pictureBox3_play_state <= 1 Then
            Me.Label14.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\playds.png")
        Else
            Me.Label14.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\pauseds.png")
        End If

    End Sub
    Private Sub Label14_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label14.MouseUp
        If pictureBox3_play_state <= 1 Then
            Me.Label14.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\playd.png")
        Else
            Me.Label14.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\paused.png")
        End If

    End Sub

    Private Sub Label14_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label14.MouseHover
        If pictureBox3_play_state <= 1 Then
            Me.Label14.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\playd.png")
            Me.ToolTip1.SetToolTip(Label14, "��ͣ")
        Else
            Me.Label14.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\paused.png")
            Me.ToolTip1.SetToolTip(Label14, "����")
        End If
        Me.PictureBox8_hidePic()

    End Sub

    Public Sub Label14_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label14.MouseLeave
        If pictureBox3_play_state <= 1 Then
            Me.Label14.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\playn.png")
        Else
            Me.Label14.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\pausen.png")
        End If

    End Sub

    '��һ��
    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click
        If Me.ListBox1.Items.Count > 0 Then
            Me.ListBox1.SelectedIndex = list_SingleSelectIndex
        End If

        '��һ��,,,,,,��form1_load 245��  ������Ӧ��λ�á�ͼƬ����
        ' Me.Label13.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\prevo.png")

        If Me.ListBox1.SelectedItem <> "" Then
            If timer3_playSetting = 4 Then
                Random_play()
            Else
                If Me.ListBox1.SelectedIndex + 1 <= Me.ListBox1.Items.Count - 1 Then
                    Me.ListBox1.SelectedIndex += 1
                Else
                    Me.ListBox1.SelectedIndex = 0
                End If
            End If


            pictureBox3_play_state = 0
            Me.Label14.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\playn.png")
            Label14_Click(Nothing, Nothing)

        End If
    End Sub

    Private Sub Label15_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label15.MouseDown
        Me.Label15.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\nextds.png")
    End Sub

    Private Sub Label15_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label15.MouseHover
        Me.Label15.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\nextd.png")
        Me.PictureBox8_hidePic()
        Me.ToolTip1.SetToolTip(Label15, "��һ��")
    End Sub

    Private Sub Label15_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label15.MouseLeave
        Me.Label15.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\nextn.png")
    End Sub

    Private Sub Label15_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label15.MouseUp
        Me.Label15.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\nextd.png")
    End Sub

    'ֹͣ����
    Private Sub Label31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label31.Click
        ' Me.Label31.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\nextd.png")
        Label17_Click(Nothing, Nothing)
        lrc_name = ""
    End Sub

    Private Sub Label31_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label31.MouseDown
        Me.Label31.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\stopds.png")
    End Sub

    Private Sub Label31_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label31.MouseHover
        Me.Label31.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\stopo.png")
        Me.PictureBox8_hidePic()
        Me.ToolTip1.SetToolTip(Label31, "ֹͣ")
    End Sub

    Private Sub Label31_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label31.MouseLeave
        Me.Label31.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\stopn.png")
    End Sub

    Private Sub Label31_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label31.MouseUp
        Me.Label31.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\stopd.png")
    End Sub

    '��������
    ' Dim pictureBox3_play_state As Integer = 0
    ' Dim pictureBox3_sound_state As Integer = 0
    Private Sub Label32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label32.Click
        ' Me.Label32.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\nextd.png")
    End Sub

    Private Sub Label32_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label32.MouseDown
        If mplay_sound_state = 0 Then
            Me.Label32.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\muted.gif")
            mplay_sound_state = 1
        Else
            Me.Label32.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\spd.gif")
            mplay_sound_state = 0
        End If

    End Sub

    Private Sub Label32_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label32.MouseHover
        If mplay_sound_state = 1 Then
            Me.Label32.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\muteo.gif")
        Else
            Me.Label32.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\spo.gif")
        End If

        Me.PictureBox8_showPic()
    End Sub

    Private Sub Label32_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label32.MouseLeave
        If mplay_sound_state = 1 Then
            Me.Label32.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\muten.gif")
        Else
            Me.Label32.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\spn.gif")
        End If

    End Sub

    Private Sub Label32_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label32.MouseUp
        If mplay_sound_state = 1 Then
            Me.Label32.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\muteo.gif")
        Else
            Me.Label32.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\spo.gif")
        End If

    End Sub

    Private Sub ��������ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ��������ToolStripMenuItem1.Click
        timer3_playSetting = 0
        Me.Label5_pic_show()
    End Sub

    Private Sub ����ѭ��ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ����ѭ��ToolStripMenuItem1.Click
        timer3_playSetting = 1
        Me.Label5_pic_show()
    End Sub

    Private Sub ˳�򲥷�ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ˳�򲥷�ToolStripMenuItem1.Click
        timer3_playSetting = 2
        Me.Label5_pic_show()
    End Sub

    Private Sub �б���ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �б���ToolStripMenuItem1.Click
        timer3_playSetting = 3
        Me.Label5_pic_show()
    End Sub

    Private Sub �������ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �������ToolStripMenuItem1.Click
        timer3_playSetting = 4
        Me.Label5_pic_show()
    End Sub



    Private Sub PictureBox9_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.PictureBox8_showPic()
    End Sub

    Private Sub PictureBox3_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseHover
        Me.PictureBox8_hidePic()
    End Sub

    Private Sub TabControl1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.PictureBox8_hidePic()
    End Sub

    Public Sub Label33_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label33.MouseClick
        If pictureBox8_sound_state = 0 Then

            Me.AxWindowsMediaPlayer1.settings.mute = True
            pictureBox8_sound_state = 1
        Else

            Me.AxWindowsMediaPlayer1.settings.mute = False
            pictureBox8_sound_state = 0
        End If

        Try
            ' Setting_boolean = False
            Dim mysql As String
            Dim mycmd As New OleDbCommand
            myconn.Open()
            mysql = "update kmSetting set " & "sound_mute=" & pictureBox8_sound_state & " where id_diaoyong=" & 1
            mycmd.Connection = myconn
            mycmd.CommandText = mysql
            mycmd.ExecuteNonQuery()
            myconn.Close()
            myds.Clear()
        Catch ex As Exception
            debug_write("Label33_MouseClick ��2554 ���� " & ex.Message)
            myconn.Close()
            myds.Clear()
        End Try
    End Sub



    Private Sub Label33_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label33.MouseDown
        If pictureBox8_sound_state = 0 Then
            Me.Label33.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\spd.gif")
            Me.Label32.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\spd.gif")


        Else
            Me.Label33.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\muted.gif")
            Me.Label32.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\muted.gif")


        End If
    End Sub

    Private Sub Label33_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label33.MouseHover
        If pictureBox8_sound_state = 0 Then
            Me.Label33.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\spo.gif")
            Me.Label32.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\spo.gif")

        Else
            Me.Label33.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\muteo.gif")
            Me.Label32.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\muteo.gif")
        End If



        textbox1_Focus = 1  '��textBox ʧȥ����
    End Sub

    Private Sub Label33_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label33.MouseLeave
        If pictureBox8_sound_state = 0 Then
            Me.Label32.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\spn.gif")
            Me.Label33.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\spn.gif")

        Else
            Me.Label32.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\muten.gif")
            Me.Label33.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\muten.gif")

        End If


        textbox1_Focus = 0 '��textBox ��ý���

    End Sub

    Private Sub Label33_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label33.MouseUp
        If pictureBox8_sound_state = 0 Then
            Me.Label33.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\spn.gif")
        Else
            Me.Label33.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\muten.gif")
        End If
    End Sub


    Private Sub TrackBar3_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBar3.MouseHover
        textbox1_Focus = 1  '��textBox ʧȥ����
    End Sub

    Private Sub TrackBar3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBar3.MouseLeave
        textbox1_Focus = 0 '��textBox ��ý���

    End Sub


    Private Sub TrackBar3_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar3.Scroll
        If Me.AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsPlaying Then
            Me.AxWindowsMediaPlayer1.settings.volume = Me.TrackBar3.Value
            Me.TrackBar2.Value = Me.TrackBar3.Value
            Me.ToolTip1.SetToolTip(Me.TrackBar3, "���� +" & Me.TrackBar3.Value)
        End If

        textbox1_Focus = 1  '��textBox ʧȥ����
    End Sub

    Private Sub TabPage1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.PictureBox8_hidePic()
    End Sub

    Private Sub TabPage2_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.PictureBox8_hidePic()
    End Sub

    Private Sub TabPage3_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.PictureBox8_hidePic()
        textbox1_Focus = 1  '��textBox ʧȥ����
    End Sub

    Private Sub TrackBar4_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBar4.MouseHover
        Me.PictureBox8_hidePic()
    End Sub

    Private Sub TrackBar4_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBar4.MouseLeave
        textbox1_Focus = 0 '��textBox ��ý���

    End Sub

    Private Sub TrackBar4_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar4.Scroll
        Me.TrackBar1.Value = Me.TrackBar4.Value
        Me.ToolTip1.UseFading = True
        Me.ToolTip1.SetToolTip(Me.TrackBar4, Me.TrackBar4.Value)
        AxWindowsMediaPlayer1.Ctlcontrols.currentPosition = Me.TrackBar4.Value

        textbox1_Focus = 1  '��textBox ʧȥ����
    End Sub

    Private Sub ��ʾ����ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ��ʾ����ToolStripMenuItem.Click
        Me.MonthCalendar1.Left = Me.PictureBox1.Width - Me.MonthCalendar1.Width - 10
        Me.MonthCalendar1.Top = Me.Label3.Top + Me.Label3.Height + 5
        Me.MonthCalendar1.Visible = True
    End Sub

    Public Sub Label37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label37.Click
        If label37_desk = 0 Then
            label37_desk = 1
            DeskMusic.Show()
        Else
            label37_desk = 0
            DeskMusic.Hide()
        End If
    End Sub
    Private Sub Label37_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label37.MouseDown
        ' Me.Label37.BorderStyle = BorderStyle.Fixed3D
        Me.Label37.Image = System.Drawing.Image.FromFile(Application.StartupPath & "\beijing\gc_d.png")
    End Sub


    Private Sub Label37_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label37.MouseHover
        'Me.Label37.BorderStyle = BorderStyle.FixedSingle
        Me.Label37.Image = System.Drawing.Image.FromFile(Application.StartupPath & "\beijing\gc_o.png")
    End Sub

    Private Sub Label37_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label37.MouseLeave
        'Me.Label37.BorderStyle = BorderStyle.None
        If label37_desk = 0 Then
            Me.Label37.Image = System.Drawing.Image.FromFile(Application.StartupPath & "\beijing\gc.png")
        Else
            Me.Label37.Image = System.Drawing.Image.FromFile(Application.StartupPath & "\beijing\gc_o.png")
        End If

    End Sub

    Private Sub ��ͣToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ����ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ListBox1_MouseDoubleClick(Nothing, Nothing)
    End Sub
    Private Sub ListBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox1.KeyDown
        common_key(e.KeyCode)
        ' Me.TextBox1.Text = ""
        'MsgBox(e.KeyCode)
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        'MsgBox(e.KeyCode)
        common_key(e.KeyCode)


        Me.TextBox1.Text = ""
    End Sub

    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        Me.ContextMenuStrip2.Close()
        Me.ContextMenuStrip1.Close()
        If textbox1_Focus = 0 Then '��textBox ��ý��� 
            TextBox1.Focus()
        End If
        'textbox1_Focus = 1  '��textBox ʧȥ����
    End Sub




    Public Sub Label39_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label39.Click

        Try

            Me.OpenFileDialog2.FileName = ""
            Me.OpenFileDialog2.Title = "��ӱ���ͼƬ"

            Me.OpenFileDialog2.Filter = "*.ͼƬ|*.jpg;*.gif; *.png|����|*.*"
            '  Me.OpenFileDialog1.FilterIndex = 2  'Ĭ�ϴ򿪸�ʽ

            Me.OpenFileDialog2.RestoreDirectory = True
            Me.OpenFileDialog2.ShowDialog()

            ''���ļ��� ������һ���ļ����������ݿ�(����)
            If Me.OpenFileDialog2.FileName.ToString <> "" Then
                Me.PictureBox1.Load(Me.OpenFileDialog2.FileName)
                Me.PictureBox3.BackColor = Color.Transparent
                Me.PictureBox3.ImageLocation = ""
                Me.PictureBox3.Parent = Me.PictureBox1
                Me.Refresh()
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
            debug_write(" Label39_Click ���ı���ͼƬ ��2758 " & ex.Message.ToString)
        End Try
    End Sub

    Private Sub Label40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label40.Click
        If label40_mPlay_IsShow = 0 Then
            Me.AxWindowsMediaPlayer1.Visible = True
            label40_mPlay_IsShow = 1
        Else
            Me.AxWindowsMediaPlayer1.Visible = False
            label40_mPlay_IsShow = 0
        End If
    End Sub

    Private Sub Label40_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label40.MouseDown
        If label40_mPlay_IsShow = 0 Then
            Me.Label40.BorderStyle = BorderStyle.FixedSingle
        Else
            Me.Label40.BorderStyle = BorderStyle.Fixed3D
        End If

    End Sub

    Private Sub Label40_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label40.MouseHover
        If Me.label40_mPlay_IsShow = 0 Then
            Me.Label40.BorderStyle = BorderStyle.Fixed3D
        Else
            Me.Label40.BorderStyle = BorderStyle.FixedSingle
        End If

    End Sub

    Private Sub Label40_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label40.MouseLeave

        Me.Label40.BorderStyle = BorderStyle.None


    End Sub



    Private Sub Label41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label41.Click
        '49����Ƶ�ļ�����(���ע��������û�������)����Ҫʵ�ֵ��ǵ��� �� ��ť �ж��ǲ�����Ƶ�ļ������Ǿ�mPlayer ����ʾ��
        ' Dim AxWindowsMediaPlayer1_name_ex() As String = {"flv", "ivf", "mkv", "mp4", "m4v", "m4p", "m4b", "3gp", "3gpp", "3g2", "3gp2", "hdmov", "mpg", "mpeg", "mpe", "m1v", "m2p", "m2v", "mpv2", "mp2v", "dat", "ts", "tp", "tpr", "pva", "pss", "ogm", "rm", "ram", "rmvb", "rpm", "rv", "rmm", "rnx", "roq", "wmv", "wmp", "wm", "sf", "amv", "avi", "divx", "gvi", "mpq", "pmp", "scm", "vid", "vp6", "vp7"}
        'Dim AxWindowsMediaPlayer1_name_index As Integer = 0
        ' Dim AxWindowsMediaPlayer1_name_string As String = ""
        ' Dim AxWindowsMediaPlayer1_insert1_string As String = ""

        Try
            Me.OpenFileDialog1.Title = "��ý��"
            Me.OpenFileDialog1.Filter = "(*.��ý��)|*.mpg; *.mpeg;*.mpe;*.m1v; *.m2p; *.m2v; *.mpv2; *.mp2v; *.dat; *.ts; *.tp;*.tpr; *.pva; *.pss;*.mp3;*.mkv;*.mid;*.wmv;*.avi;*.mp4;*.rmvb|All file(*.*)|*.*"
            ' Me.OpenFileDialog1.FilterIndex = 2  'Ĭ�ϴ򿪸�ʽ

            Me.OpenFileDialog1.RestoreDirectory = False
            Me.OpenFileDialog1.ShowDialog()

            If OpenFileDialog1.FileName <> "" And Me.OpenFileDialog1.FileName <> "OpenFileDialog1" And Me.OpenFileDialog1.FileName <> mPlay_url Then

                Me.AxWindowsMediaPlayer1.Ctlcontrols.stop()
                Me.AxWindowsMediaPlayer1.URL = Me.OpenFileDialog1.FileName
                Me.mPlay_play_state = 0

                Me.Label27.Text = Me.OpenFileDialog1.FileName
                timer3_playSetting = 0
                Me.Label11_Click(Nothing, Nothing)
                If Not (Me.AxWindowsMediaPlayer1.Visible) Then
                    Me.AxWindowsMediaPlayer1.Visible = True
                End If
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
            debug_write("Label41_Click �򿪶�ý�� ��2829 " & ex.Message.ToString)
            Exit Sub
        End Try
    End Sub

    Private Sub Label41_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label41.MouseDown
        Me.Label41.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub Label41_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label41.MouseHover
        Me.Label41.BorderStyle = BorderStyle.Fixed3D
    End Sub

    Private Sub Label41_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label41.MouseLeave
        Me.Label41.BorderStyle = BorderStyle.None
    End Sub


    Private Sub Label44_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label44.Click
        ' km_BackColor_select.ShowDialog()
        km_backImage_select.ShowDialog()
    End Sub



    Private Sub Label44_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label44.MouseHover
        Me.ToolTip1.SetToolTip(Me.Label44, "����Ƥ��")
        Me.Label44.BorderStyle = BorderStyle.FixedSingle
        ' Me.TextBox1.Focus()
    End Sub
    Private Sub Label44_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label44.MouseLeave
        Me.Label44.BorderStyle = BorderStyle.None
    End Sub

    Private Sub Label27_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label27.TextChanged
        Me.Timer2.Enabled = True
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Me.TextBox1.Focus()
    End Sub



    Private Sub PictureBox3_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox3.MouseMove
        textbox1_Focus = 1
    End Sub

    Private Sub Label5_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label5.MouseDown
        Me.Label5.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub Label5_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label5.MouseHover
        Me.Label5.BorderStyle = BorderStyle.FixedSingle
        Select Case timer3_playSetting
            Case 0
                Me.ToolTip1.SetToolTip(Label5, "��������")
            Case 1
                Me.ToolTip1.SetToolTip(Label5, "����ѭ��")
            Case 2
                Me.ToolTip1.SetToolTip(Label5, "˳�򲥷�")
            Case 3
                Me.ToolTip1.SetToolTip(Label5, "�б���")
            Case 4
                Me.ToolTip1.SetToolTip(Label5, "�������")
        End Select

    End Sub

    Private Sub Label5_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label5.MouseLeave
        Me.Label5.BorderStyle = BorderStyle.None
    End Sub
    Private Sub Label5_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label5.MouseUp
        Me.Label5.BorderStyle = BorderStyle.Fixed3D
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        If timer3_playSetting + 1 <= 4 Then
            timer3_playSetting += 1
        Else
            timer3_playSetting = 0
        End If

        Me.Label5_pic_show()
        startKM_play_moshi() ''���� ��������0������ѭ��1��˳�򲥷�2���б���3���������4  �������Ҽ��仯������
    End Sub

    Private Sub MonthCalendar1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MonthCalendar1.LostFocus
        Me.MonthCalendar1.Visible = False

    End Sub



    Private Sub MonthCalendar1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MonthCalendar1.MouseLeave
        Me.MonthCalendar1.Visible = False

    End Sub

    Private Sub Timer4_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer4.Tick
        If AxWindowsMediaPlayer1.Ctlcontrols.currentPosition = 0 Then
            auto_play = 2
            Me.ListBox1_MouseDoubleClick(Nothing, Nothing)
            Me.Timer4.Enabled = False
        End If

    End Sub


    Private Sub PictureBox8_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox8.LostFocus
        Me.PictureBox8_hidePic()
    End Sub




    Private Sub ����б�ToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ����б�ToolStripMenuItem.Click
        If Me.ListBox1.Items.Count > 0 Then
            Try
                Dim mycmd As New OleDbCommand
                myconn.Open()
                mysql = "delete * from mlist "
                mycmd.Connection = myconn
                mycmd.CommandText = mysql
                mycmd.ExecuteNonQuery()
                myconn.Close()
                myds.Clear()


                Me.AxWindowsMediaPlayer1.Ctlcontrols.stop()
                Me.Timer1.Enabled = False
                Me.mPlay_play_state = 0
                'Me.Timer1.Enabled = False
                Me.TrackBar1.Value = 0
                Me.mplay_time_end()   '����ʾʱ�����

                list_cls_add()

                '��ԭ���ݿ�(��Ȼ  ����ʲô��Ҳ����ԭ��)
                File.Copy(Application.StartupPath & "\���ݿⱸ��\kmplay.mdb", Application.StartupPath & "\kmplay.mdb", True)
                Label30.Text = ""
                Me.Label31_Click(Nothing, Nothing)

            Catch ex As Exception
                ' MsgBox(ex.Message)
                debug_write("����б�ToolStripMenuItem_Click_1 ��2967 " & ex.Message.ToString)
            End Try

        End If
    End Sub



    Public Sub gc_show()

        Try

            Me.Label6.Height = Me.PictureBox5.Height
            Me.Label6.Top = 0
            Dim j As Integer
            j = 0
            Label6.Text = ""
            '�հ�
            For j = 1 To 10
                Me.Label6.Text = Me.Label6.Text & vbCrLf
                'Me.Label6.Height += 16

            Next
            'label6_height = 0
            '������
            For j = 0 To DeskMusic.ListBox1.Items.Count - 1
                Label6.Text = Label6.Text & Chr(13) & Chr(10) & Chr(13) & Chr(10) & ListBox2.Items(j)
                'Me.Label6.Height += 16
            Next

            '�հ�
            For j = 1 To 10
                Me.Label6.Text = Me.Label6.Text & vbCrLf
                'Me.Label6.Height += 16
            Next

            Me.Label45.Top = 10 * 16
            Me.TextBox2.Top = 10 * 16
            Me.Refresh()
            Timer5.Enabled = False
            Timer5.Enabled = True

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub Timer5_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer5.Tick
        '���ͬ��ʵ��

        For i As Integer = 1 To ListBox2.Items.Count - 1
            If AxWindowsMediaPlayer1.Ctlcontrols.currentPosition - Val(ListBox3.Items(i)) < 0.01 Then
                If Label45.Text <> ListBox2.Items(i - 1) Then
                    Label45.Text = ListBox2.Items(i - 1)
                    TextBox2.Text = Label45.Text
                    length = Val(ListBox3.Items(i)) - Val(ListBox3.Items(i - 1))
                    'length = Fix(length) * 1000 + (length - Fix(length))
                    Me.Label45.Left = (Me.PictureBox5.Width - Label45.Width) / 2
                    TextBox2.Width = 0
                    TextBox2.Left = Label45.Left + 5
                    Me.Label6.Top = 0 - (i * 16) * 2
                    Me.Label6.Height = Me.PictureBox5.Height + (i * 16) * 2
                    ListBox2.SelectedIndex = i - 1
                    ListBox3.SelectedIndex = i - 1
                End If
                Exit For
            End If
        Next
        If AxWindowsMediaPlayer1.currentPlaylist.count <> 0 Then
            If AxWindowsMediaPlayer1.Ctlcontrols.currentPosition > Val(ListBox3.Items(ListBox3.Items.Count - 1)) Then
                Label45.Text = ListBox2.Items(ListBox2.Items.Count - 1)
                TextBox2.Text = Label45.Text
                Me.Label45.Left = (Me.PictureBox5.Width - Label45.Width) / 2
                TextBox2.Left = Label45.Left + 5
                length = AxWindowsMediaPlayer1.currentMedia.duration - Val(ListBox3.Items(ListBox3.Items.Count - 1))
                Me.Label6.Top = 0 - ((ListBox3.Items.Count) * 16) * 2
                Me.Label6.Height = Me.PictureBox5.Height + ((ListBox3.Items.Count) * 16) * 2
                ListBox2.SelectedIndex = ListBox3.Items.Count - 1
                ListBox3.SelectedIndex = ListBox3.Items.Count - 1
            End If

            If TextBox2.Width > Label45.Width Then TextBox2.Width = Label45.Width

            If length <> 0 And AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsPlaying Then
                TextBox2.Width = TextBox2.Width + 0.1 * Label45.Width / length
            End If

        End If
    End Sub

    Private Sub AxWindowsMediaPlayer1_KeyDownEvent(ByVal sender As Object, ByVal e As AxWMPLib._WMPOCXEvents_KeyDownEvent) Handles AxWindowsMediaPlayer1.KeyDownEvent
        common_key(e.nKeyCode)
    End Sub

    Private Sub AxWindowsMediaPlayer1_MouseMoveEvent1(ByVal sender As Object, ByVal e As AxWMPLib._WMPOCXEvents_MouseMoveEvent) Handles AxWindowsMediaPlayer1.MouseMoveEvent
        textbox1_Focus = 1
    End Sub


    Private Sub AxWindowsMediaPlayer1_PlaylistChange(ByVal sender As Object, ByVal e As AxWMPLib._WMPOCXEvents_PlaylistChangeEvent) Handles AxWindowsMediaPlayer1.PlaylistChange
        'Me.OpenFileDialog1.FileName.Split(Me.OpenFileDialog1.FileName, "\")
        ' Me.Label20.Text = Right(Me.Label20.Text, 1, 3)
        ' Me.OpenFileDialog1.FileName.s()
        Me.Label21.Text = ""
        Dim FileName_insert As String = ""
        Dim insert_filename_index As Integer = 0

        For insert_filename_index = Len(Me.OpenFileDialog1.FileName) To 1 Step -1
            FileName_insert = Mid(Me.OpenFileDialog1.FileName, insert_filename_index, 1)
            If FileName_insert = "\" Then
                Exit For
            Else
                Me.Label21.Text = FileName_insert + Me.Label21.Text
            End If
        Next
        ' Me.Label21.Text = Mid(Me.OpenFileDialog1.FileName, Len(Me.OpenFileDialog1.FileName) - 17, 18)

    End Sub

    Private Sub AxWindowsMediaPlayer1_PlayStateChange(ByVal sender As Object, ByVal e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent) Handles AxWindowsMediaPlayer1.PlayStateChange


        '���ǵ�����һ������ʱ��ֹͣ�����ţ��᲻���������ţ����Ҫ��������ֵ
        If Me.AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsPlaying Then
            ' Me.AxWindowsMediaPlayer1.Ctlcontrols.currentPosition = 0.1
            lrc_name = Trim(Me.Label21.Text)
        End If

        If Me.AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsStopped Then
            lrc_name = "����״̬=ֹͣ.�����֣��ĸ�"
        End If


        If Me.AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsReady Then
            Me.AxWindowsMediaPlayer1.Ctlcontrols.play()
        End If
    End Sub

    Private Sub �������°汾ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �������°汾ToolStripMenuItem.Click
        ShellExecute(0, "open", "http://pan.baidu.com/s/1sjz5tIt ", CStr(0), CStr(0), 1)
    End Sub


    'Private Sub Label6_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label6.MouseHover

    '    textbox1_Focus = 0
    '    TextBox1.Focus()
    '    Me.ToolTip1.SetToolTip(Label6, Label27.Text)
    '    PictureBox8_hidePic()

    'End Sub

    'Private Sub Label6_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label6.MouseMove
    '    If DeskMusic_state = 0 Then
    '        textbox1_Focus = 0
    '        TextBox1.Focus()
    '        PictureBox8_hidePic()
    '    End If
    'End Sub



    Private Sub TextBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.GotFocus
        textbox1_Focus = 0
        Me.TextBox2.DeselectAll()
        Me.TextBox1.Focus()
    End Sub

    Private Sub TrackBar3_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBar3.ValueChanged
        Try
            ' Setting_boolean = False
            Dim mysql As String
            Dim mycmd As New OleDbCommand
            myconn.Open()
            mysql = "update kmSetting set " & "sound_int=" & TrackBar3.Value & " where id_diaoyong=" & 1
            mycmd.Connection = myconn
            mycmd.CommandText = mysql
            mycmd.ExecuteNonQuery()
            myconn.Close()
            myds.Clear()
        Catch ex As Exception
            debug_write("TrackBar3_ValueChanged ��3151 " & ex.Message.ToString)
            myconn.Close()
            myds.Clear()
        End Try
    End Sub

    Private Sub PictureBox5_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox5.MouseHover
        PictureBox8_hidePic()

    End Sub

    Private Sub Label38_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label38.MouseDown
        Me.Label38.BorderStyle = BorderStyle.Fixed3D
    End Sub

    Private Sub Label38_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label38.MouseHover
        Me.Label38.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\beijing\mv-o.png")
    End Sub

    Private Sub Label38_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label38.MouseLeave
        If Me.Label21.Visible = False Then
            Me.Label38.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\beijing\mv.png")
        Else
            Me.Label38.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\beijing\mv-o.png")
        End If

    End Sub

    Private Sub Label38_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label38.MouseUp
        Me.Label38.BorderStyle = BorderStyle.None
    End Sub

    Private Sub Label42_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label42.MouseDown
        Me.Label42.BorderStyle = BorderStyle.Fixed3D
    End Sub

    Private Sub Label42_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label42.MouseHover
        Me.Label42.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\beijing\leku-o.png")
    End Sub

    Private Sub Label42_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label42.MouseLeave
        If Me.PictureBox9.Visible = False Then
            Me.Label42.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\beijing\leku.png")
        Else
            Me.Label42.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\beijing\leku-o.png")
        End If
    End Sub

    Private Sub Label42_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label42.MouseUp
        Me.Label42.BorderStyle = BorderStyle.None
    End Sub

    Private Sub Label43_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label43.MouseDown
        Me.Label43.BorderStyle = BorderStyle.Fixed3D
    End Sub

    Private Sub Label43_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label43.MouseHover
        Me.Label43.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\beijing\geci-o.png")
    End Sub

    Private Sub Label43_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label43.MouseLeave
        If Me.PictureBox5.Visible = False Then
            Me.Label43.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\beijing\geci.png")
        Else
            Me.Label43.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\beijing\geci-o.png")
        End If
    End Sub

    Private Sub Label43_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label43.MouseUp
        Me.Label43.BorderStyle = BorderStyle.None
    End Sub

    Private Sub Label38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label38.Click
        If Me.Label21.Visible = False Then
            Me.pictureBox4_show()

            '���ظ��
            Me.PictureBox5.Visible = False
            Me.Label43.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\beijing\geci.png")

            '����-��������
            Me.Label42.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\beijing\leku.png")
            Me.PictureBox9.Visible = False
        End If

    End Sub

    Private Sub Label42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label42.Click

        Me.PictureBox9.Visible = True

        '���ظ��
        Me.PictureBox5.Visible = False
        Me.Label43.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\beijing\geci.png")

        '����mv
        Me.Label38.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\beijing\mv.png")
        Me.Label21.Visible = False
        Me.AxWindowsMediaPlayer1.Visible = False
        Me.Label40.Visible = False
        Me.Label41.Visible = False
        label40_mPlay_IsShow = 0
        Me.Label40.BorderStyle = BorderStyle.None
    End Sub

    Private Sub Label43_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label43.Click

        Try
            '��ʾ���
            If Not (Me.PictureBox5.Visible) Then

                '���
                Me.PictureBox5.Visible = True
                Me.Label6.Visible = True


                '����-mv
                Me.Label21.Visible = False
                Me.AxWindowsMediaPlayer1.Visible = False
                Me.Label40.Visible = False
                Me.Label41.Visible = False
                label40_mPlay_IsShow = 0
                Me.Label40.BorderStyle = BorderStyle.None
                Me.Label38.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\beijing\mv.png")

                '����-��������
                Me.Label42.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\beijing\leku.png")
                Me.PictureBox9.Visible = False
            End If


        Catch ex As Exception
            ' MsgBox("label43_click ��ʿؼ� 2808��" & ex.Message)
            debug_write("Label43_Click �򿪸�� ��3284" & ex.Message.ToString)
        End Try

    End Sub

    'һ��   20141010 ����

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        '
        Me.ContextMenuStrip4.Show()
        ' 
        Me.ContextMenuStrip4.Top = Me.Top + Label7.Top + 20

        Me.ContextMenuStrip4.Left = Me.Left + Me.Label7.Left - 15
    End Sub

    Private Sub Label7_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label7.MouseEnter
        Me.Label7.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub Label7_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label7.MouseHover
        Me.ToolTip1.SetToolTip(Label7, "�ı������")
        Me.Label7.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub Label7_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label7.MouseLeave
        Me.Label7.BorderStyle = BorderStyle.None
    End Sub

    Private Sub Label7_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label7.MouseUp
        Me.Label7.BorderStyle = BorderStyle.Fixed3D
        Label7_MouseLeave(Nothing, Nothing)
    End Sub

    Private Sub ��С����ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ��С����ToolStripMenuItem.Click
        Me.Height = Me.PictureBox3.Height - 46
        Me.Width = Me.PictureBox3.Width + 10
        Me.Label7.Left = 302 - Me.Label4.Width - Label3.Width - Label2.Width - 22
        Me.Label2.Left = 302 - Me.Label4.Width - Label3.Width - 25
        Me.Label4.Left = 302 - Me.Label4.Width - 8

        Me.Label3.Visible = False
        Me.Label44.Visible = False
        Me.Label38_Click(Nothing, Nothing)
        Me.Label38.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\beijing\mv-o.png")

    End Sub

    Private Sub ���׽���ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ���׽���ToolStripMenuItem.Click
        Me.Height = 544
        Me.Width = Me.PictureBox3.Width + 10

        Me.Label7.Left = 302 - Me.Label4.Width - Label3.Width - Label2.Width - 22
        Me.Label2.Left = 302 - Me.Label4.Width - Label3.Width - 25
        Me.Label4.Left = 302 - Me.Label4.Width - 8

        Me.Label3.Visible = False
        Me.Label44.Visible = False

        Me.Label43_Click(Nothing, Nothing)
        Me.Label38_Click(Nothing, Nothing)
        Me.Label38.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\beijing\mv-o.png")
    End Sub

    Private Sub ��������ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ��������ToolStripMenuItem.Click
        Me.Height = 544
        Me.Width = 901
        Me.PictureBox1.Height = 544
        Me.PictureBox1.Width = 901
        Me.Label7.Left = Me.PictureBox1.Width - 198
        Me.Label44.Left = Me.PictureBox1.Width - 155
        Me.Label2.Left = Me.PictureBox1.Width - 105
        Me.Label3.Left = Me.PictureBox1.Width - 60
        Me.Label4.Left = Me.PictureBox1.Width - 50
        Me.Label3.Visible = True
        Me.Label44.Visible = True
    End Sub
    Private Sub NotifyIcon1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseClick

        If (e.Button = Windows.Forms.MouseButtons.Right) Then
            Auther_Message.Auther_Message_change(2, True)
            Auther_Message.Show()
        End If

    End Sub

    Private Sub Label46_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label46.Click
        If Me.ListBox1.Items.Count - 1 > 0 Then
            Me.ListBox1.SelectedIndex = list_SingleSelectIndex
        End If
    End Sub

    Private Sub Label46_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label46.MouseHover
        Me.Label46.Image = System.Drawing.Image.FromFile(Application.StartupPath & "\beijing\dw.png")
        Me.ToolTip1.SetToolTip(Label46, "��λ����ǰ���Ÿ���")
    End Sub

    Private Sub Label46_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label46.MouseLeave
        Me.Label46.Image = System.Drawing.Image.FromFile(Application.StartupPath & "\beijing\dwo.png")
    End Sub
End Class
