
'酷猫播放器 音效设置（Setting的子窗口）
'       作者：srxboys
'       说明：此处的界面设计，完全按照“酷狗——设置界面”为参考
'       日期：20140722


Public Class km_yxSetting



    Dim AxWindowsMediaPlayer1Eq As Integer = 0


    Private Sub km_yxSetting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '按键位置设置（防止用户无意拖动，而对不齐，产生视觉的不美观）

        Me.Button1.Text = "确定"
        Me.Button2.Text = "取消"
        Me.Button3.Text = "应用"

        'Me.Button1.Location =(208, 324)
        Me.Button1.Left = 208
        Me.Button1.Top = 324
        'me.Button2.Location =(305, 324)
        Me.Button2.Left = 305
        Me.Button2.Top = 324
        'me.Button3.Location =(402, 324)
        Me.Button3.Left = 402
        Me.Button3.Top = 324

        '定义频率范围
        Me.TrackBar1.Tag = 60
        Me.TrackBar2.Tag = 170
        TrackBar3.Tag = 310
        Me.TrackBar4.Tag = 600
        Me.TrackBar5.Tag = 1000
        Me.TrackBar6.Tag = 3000
        Me.TrackBar7.Tag = 6000
        Me.TrackBar8.Tag = 12000
        Me.TrackBar9.Tag = 14000
        Me.TrackBar10.Tag = 16000

        Me.TrackBar1.Value = 0
        Me.TrackBar2.Value = 0
        TrackBar3.Value = 0
        Me.TrackBar4.Value = 0
        Me.TrackBar5.Value = 0
        Me.TrackBar6.Value = 0
        Me.TrackBar7.Value = 0
        Me.TrackBar8.Value = 0
        Me.TrackBar9.Value = 0
        Me.TrackBar10.Value = 0

        '  Me.Label13.Text = "关闭"
        Me.RadioButton3.Checked = True


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Me.RadioButton1.Checked = True Then
            Form1.AxWindowsMediaPlayer1.settings.balance = -10000
        ElseIf Me.RadioButton2.Checked = True Then
            Form1.AxWindowsMediaPlayer1.settings.balance = 10000
        ElseIf Me.RadioButton3.Checked = True Then
            Form1.AxWindowsMediaPlayer1.settings.balance = 0
        End If
    End Sub

    'Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
    '    Form1.AxWindowsMediaPlayer1.settings.rate(Me.TrackBar1.Tag, Me.TrackBar1.Value)
    '    Me.ToolTip1.SetToolTip(Me.TrackBar1, Me.TrackBar1.Value)
    'End Sub

    'Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
    '    Me.RadioButton3.Checked = True

    '    ' 频率还原
    '    Me.TrackBar1.Value = 0
    '    Me.TrackBar2.Value = 0
    '    TrackBar3.Value = 0
    '    Me.TrackBar4.Value = 0
    '    Me.TrackBar5.Value = 0
    '    Me.TrackBar6.Value = 0
    '    Me.TrackBar7.Value = 0
    '    Me.TrackBar8.Value = 0
    '    Me.TrackBar9.Value = 0
    '    Me.TrackBar10.Value = 0
    '    Form1.AxWindowsMediaPlayer1.SetEq(Me.TrackBar1.Tag, 0)
    '    Form1.AxWindowsMediaPlayer1.SetEq(Me.TrackBar2.Tag, 0)
    '    Form1.AxWindowsMediaPlayer1.SetEq(TrackBar3.Tag, 0)
    '    Form1.AxWindowsMediaPlayer1.SetEq(Me.TrackBar4.Tag, 0)
    '    Form1.AxWindowsMediaPlayer1.SetEq(Me.TrackBar5.Tag, 0)
    '    Form1.AxWindowsMediaPlayer1.SetEq(Me.TrackBar6.Tag, 0)
    '    Form1.AxWindowsMediaPlayer1.SetEq(Me.TrackBar7.Tag, 0)
    '    Form1.AxWindowsMediaPlayer1.SetEq(Me.TrackBar8.Tag, 0)
    '    Form1.AxWindowsMediaPlayer1.SetEq(Me.TrackBar9.Tag, 0)
    '    Form1.AxWindowsMediaPlayer1.SetEq(Me.TrackBar10.Tag, 0)
    'End Sub

    'Private Sub TrackBar2_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar2.Scroll
    '    Form1.AxWindowsMediaPlayer1.SetEq(Me.TrackBar2.Tag, Me.TrackBar2.Value)
    '    Me.ToolTip1.SetToolTip(Me.TrackBar2, Me.TrackBar2.Value)
    'End Sub

    'Private Sub TrackBar3_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar3.Scroll
    '    Form1.AxWindowsMediaPlayer1.SetEq(TrackBar3.Tag, TrackBar3.Value)
    '    Me.ToolTip1.SetToolTip(Me.TrackBar3, Me.TrackBar3.Value)
    'End Sub

    'Private Sub TrackBar4_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar4.Scroll
    '    Form1.AxWindowsMediaPlayer1.SetEq(Me.TrackBar4.Tag, Me.TrackBar4.Value)
    '    Me.ToolTip1.SetToolTip(Me.TrackBar4, Me.TrackBar4.Value)
    'End Sub

    'Private Sub TrackBar5_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar5.Scroll
    '    Form1.AxWindowsMediaPlayer1.SetEq(Me.TrackBar5.Tag, Me.TrackBar5.Value)
    '    Me.ToolTip1.SetToolTip(Me.TrackBar5, Me.TrackBar5.Value)
    'End Sub

    'Private Sub TrackBar6_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar6.Scroll
    '    Form1.AxWindowsMediaPlayer1.SetEq(Me.TrackBar6.Tag, Me.TrackBar6.Value)
    'End Sub

    'Private Sub TrackBar7_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar7.Scroll
    '    Form1.AxWindowsMediaPlayer1.SetEq(Me.TrackBar7.Tag, Me.TrackBar7.Value)
    '    Me.ToolTip1.SetToolTip(Me.TrackBar7, Me.TrackBar7.Value)
    'End Sub

    'Private Sub TrackBar8_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar8.Scroll
    '    Form1.AxWindowsMediaPlayer1.SetEq(Me.TrackBar8.Tag, Me.TrackBar8.Value)
    '    Me.ToolTip1.SetToolTip(Me.TrackBar8, Me.TrackBar8.Value)
    'End Sub

    'Private Sub TrackBar9_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar9.Scroll
    '    Form1.AxWindowsMediaPlayer1.settings .(Me.TrackBar9.Tag, Me.TrackBar9.Value)
    '    Me.ToolTip1.SetToolTip(Me.TrackBar9, Me.TrackBar9.Value)
    'End Sub

    'Private Sub TrackBar10_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar10.Scroll
    '    ' Form1.AxWindowsMediaPlayer1.SetEq(Me.TrackBar10.Tag, Me.TrackBar10.Value)
    '    Me.ToolTip1.SetToolTip(Me.TrackBar10, Me.TrackBar10.Value)
    '    Me.ToolTip1.UseFading = True
    'End Sub





    'Public Sub checkEQ()
    '    If Me.AxWindowsMediaPlayer1Eq = 1 Then
    '        Form1.AxWindowsMediaPlayer1.EnableEQ = True
    '        Form1.AxWindowsMediaPlayer1.SetEq(Me.TrackBar1.Tag, Me.TrackBar1.Value)
    '        Form1.AxWindowsMediaPlayer1.SetEq(Me.TrackBar2.Tag, Me.TrackBar2.Value)
    '        Form1.AxWindowsMediaPlayer1.SetEq(TrackBar3.Tag, TrackBar3.Value)
    '        Form1.AxWindowsMediaPlayer1.SetEq(Me.TrackBar4.Tag, Me.TrackBar4.Value)
    '        Form1.AxWindowsMediaPlayer1.SetEq(Me.TrackBar5.Tag, Me.TrackBar5.Value)
    '        Form1.AxWindowsMediaPlayer1.SetEq(Me.TrackBar6.Tag, Me.TrackBar6.Value)
    '        Form1.AxWindowsMediaPlayer1.SetEq(Me.TrackBar7.Tag, Me.TrackBar7.Value)
    '        Form1.AxWindowsMediaPlayer1.SetEq(Me.TrackBar8.Tag, Me.TrackBar8.Value)
    '        Form1.AxWindowsMediaPlayer1.SetEq(Me.TrackBar9.Tag, Me.TrackBar9.Value)
    '        Form1.AxWindowsMediaPlayer1.SetEq(Me.TrackBar10.Tag, Me.TrackBar10.Value)
    '        ' MsgBox(Me.TrackBar10.Tag & "   " & Me.TrackBar10.Value)
    '    Else
    '        Form1.AxWindowsMediaPlayer1.EnableEQ = False
    '    End If

    'End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        ' 频率还原
        Me.TrackBar1.Value = 0
        Me.TrackBar2.Value = 0
        TrackBar3.Value = 0
        Me.TrackBar4.Value = 0
        Me.TrackBar5.Value = 0
        Me.TrackBar6.Value = 0
        Me.TrackBar7.Value = 0
        Me.TrackBar8.Value = 0
        Me.TrackBar9.Value = 0
        Me.TrackBar10.Value = 0
        'Form1.AxWindowsMediaPlayer1.SetEq(Me.TrackBar1.Tag, 0)
        'Form1.AxWindowsMediaPlayer1.SetEq(Me.TrackBar2.Tag, 0)
        'Form1.AxWindowsMediaPlayer1.SetEq(TrackBar3.Tag, 0)
        'Form1.AxWindowsMediaPlayer1.SetEq(Me.TrackBar4.Tag, 0)
        'Form1.AxWindowsMediaPlayer1.SetEq(Me.TrackBar5.Tag, 0)
        'Form1.AxWindowsMediaPlayer1.SetEq(Me.TrackBar6.Tag, 0)
        'Form1.AxWindowsMediaPlayer1.SetEq(Me.TrackBar7.Tag, 0)
        'Form1.AxWindowsMediaPlayer1.SetEq(Me.TrackBar8.Tag, 0)
        'Form1.AxWindowsMediaPlayer1.SetEq(Me.TrackBar9.Tag, 0)
        'Form1.AxWindowsMediaPlayer1.SetEq(Me.TrackBar10.Tag, 0)
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If Me.AxWindowsMediaPlayer1Eq = 0 Then
            Me.CheckBox1.Checked = True
            Me.AxWindowsMediaPlayer1Eq = 1
            'checkEQ()
        Else
            Me.CheckBox1.Checked = False
            Me.AxWindowsMediaPlayer1Eq = 0
            'checkEQ()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call Setting.Label2_Click(Nothing, Nothing)
    End Sub
End Class