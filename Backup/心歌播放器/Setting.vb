

'酷猫播放器 设置（父窗口）
'       作者：srxboys
'       说明：此处的界面设计，完全按照“酷狗——设置界面”为参考
'       日期：20140722

Imports System.Data.OleDb
Public Class Setting


    Dim pictureState As Integer = 0 '让鼠标单机的状态，为移动做准备
    Dim x, y, x1, x2 As Integer  '这是移动的坐标
    '//////////////////////////////////////////////////////


    Private Sub Setting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.IsMdiContainer = True '表示这是父窗体
        Me.Icon = ico
        '； Me.BackColor = Color.CadetBlue
        'Me.BackgroundImage = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\setting.jpg")
        Me.PictureBox1.Left = 1
        Me.PictureBox1.Height = 40
        Me.PictureBox1.Width = Me.Width - 2
        Me.PictureBox1.Top = 1
        Me.PictureBox1.Load(Application.StartupPath + "\Skin\setting.jpg")

        Me.Label1.BackColor = Color.Transparent
        Me.Label1.Parent = Me.PictureBox1
        Me.Label2.Left = Me.Width - Me.Label2.Width
        Me.Label2.Text = "  " & vbCrLf & "  "
        Me.Label2.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\closeds.png")
        Me.Label2.Parent = Me.PictureBox1
        Me.Label2.BackColor = Color.Transparent


        Me.GroupBox1.Left = 0
        Me.GroupBox1.Width = 173
        Me.GroupBox1.Height = Me.Height - Me.PictureBox1.Left - Me.PictureBox1.Height + 7
        Me.GroupBox1.Top = Me.PictureBox1.Top + Me.PictureBox1.Height - 8


        '以下是：先打开他们（子窗口），否则，会卡屏。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。
        '.........................................................
        If OpenOnce(km_yxSetting) = False Then
            km_yxSetting.MdiParent = Me
            km_yxSetting.Show()
            show_style(km_yxSetting)
        End If

        '.........................................................
        If OpenOnce(km_windowsSetting) = False Then
            km_windowsSetting.MdiParent = Me
            km_windowsSetting.Show()
            show_style(km_windowsSetting)
        End If
        '.........................................................
        If OpenOnce(km_rjSetting) = False Then
            km_rjSetting.MdiParent = Me
            km_rjSetting.Show()
            show_style(km_rjSetting)
        End If

        '.........................................................
        If OpenOnce(km_gcPathSetting) = False Then
            km_gcPathSetting.MdiParent = Me
            km_gcPathSetting.Show()
            show_style(km_gcPathSetting)
        End If
        '.........................................................
        If OpenOnce(km_DeskSetting) = False Then
            km_DeskSetting.MdiParent = Me
            km_DeskSetting.Show()
            show_style(km_DeskSetting)
        End If
        '.........................................................
        If OpenOnce(km_cgSetting) = False Then
            km_cgSetting.MdiParent = Me
            km_cgSetting.Show()
            show_style(km_cgSetting)
        End If

        '此处会调用数据库
        '因为上面已经把所有子窗体先打开了，就可以给每个窗体赋值

        Call Me.Label4_Click(Nothing, Nothing)


        Me.Button1.Visible = False
        Me.Button2.Visible = False
        '结束了   以上是：先打开他们（子窗口），否则，会卡屏。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。

        Me.Label4.BackColor = Color.Blue
        Me.Label4.ForeColor = Color.White

    End Sub


    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        Me.pictureState = 1
        x = e.X
        y = e.Y
    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If Me.pictureState = 1 Then
            Me.Left = Me.Left + e.X - x
            Me.Top = Me.Top + e.Y - y
        End If
    End Sub

    Private Sub PictureBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        Me.pictureState = 0
    End Sub

    'label2的定义必须是 公共类  方便别的子窗体 关闭是，可调用此事件
    Public Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

        Setting_boolean = False

        '表示关闭所有子窗体
        closeForm(km_cgSetting)
        closeForm(km_DeskSetting)
        closeForm(km_gcPathSetting)
        closeForm(km_rjSetting)
        closeForm(km_windowsSetting)
        closeForm(km_yxSetting)

        Me.Dispose(True)   '这是非常重要的，关闭并不是销毁，这样就是处于下次打开，会认为是第一次打开一样
        Me.Close()
        ' Me.Hide()
    End Sub


    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        Dim formtoShow As New km_cgSetting
        If OpenOnce(formtoShow) = False Then
            formtoShow.MdiParent = Me
            formtoShow.Show()
            show_style(formtoShow)


        End If
        ' Me.Label4.BackColor = Color.Red



      

    End Sub

    Private Sub Label4_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label4.MouseDown
        Me.Label4.BackColor = Color.Blue
        Me.Label4.ForeColor = Color.White

        Me.Label5.BackColor = Color.Transparent
        Me.Label7.BackColor = Color.Transparent
        Me.Label8.BackColor = Color.Transparent
        Me.Label9.BackColor = Color.Transparent
        Me.Label11.BackColor = Color.Transparent

        Me.Label5.ForeColor = Color.Black
        Me.Label7.ForeColor = Color.Black
        Me.Label8.ForeColor = Color.Black
        Me.Label9.ForeColor = Color.Black
        Me.Label11.ForeColor = Color.Black
    End Sub

    Private Sub Label4_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label4.MouseHover
        If Me.Label4.BackColor <> Color.Blue Then
            Me.Label4.BackColor = Color.CornflowerBlue
        End If

    End Sub

    Private Sub Label4_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label4.MouseLeave
        'Me.Label4.BackColor = Color.Transparent
        If Me.Label4.BackColor <> Color.Blue Then
            Me.Label4.BackColor = Color.Transparent
        End If
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        Dim formtoShow As New km_rjSetting
        If OpenOnce(formtoShow) = False Then
            formtoShow.MdiParent = Me
            formtoShow.Show()
            show_style(formtoShow)
        End If
        ' Me.Label5.BackColor = Color.Red


    End Sub

    Private Sub Label5_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label5.MouseDown
        Me.Label5.BackColor = Color.Blue
        Me.Label4.BackColor = Color.Transparent
        Me.Label7.BackColor = Color.Transparent
        Me.Label8.BackColor = Color.Transparent
        Me.Label9.BackColor = Color.Transparent
        Me.Label11.BackColor = Color.Transparent


        Me.Label5.ForeColor = Color.White
        Me.Label4.ForeColor = Color.Black
        Me.Label7.ForeColor = Color.Black
        Me.Label8.ForeColor = Color.Black
        Me.Label9.ForeColor = Color.Black
        Me.Label11.ForeColor = Color.Black
    End Sub

    Private Sub Label5_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label5.MouseHover
        If Me.Label5.BackColor <> Color.Blue Then
            Me.Label5.BackColor = Color.CornflowerBlue
        End If

    End Sub

    Private Sub Label5_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label5.MouseLeave
        ' Me.Label5.BackColor = Color.Transparent
        If Me.Label5.BackColor <> Color.Blue Then
            Me.Label5.BackColor = Color.Transparent
        End If
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        Dim formtoShow As New km_gcPathSetting
        If OpenOnce(formtoShow) = False Then
            formtoShow.MdiParent = Me
            formtoShow.Show()
            show_style(formtoShow)
        End If
        

    End Sub

    Private Sub Label7_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label7.MouseDown
        Me.Label7.BackColor = Color.Blue
        Me.Label5.BackColor = Color.Transparent
        Me.Label4.BackColor = Color.Transparent
        Me.Label8.BackColor = Color.Transparent
        Me.Label9.BackColor = Color.Transparent
        Me.Label11.BackColor = Color.Transparent

        Me.Label7.ForeColor = Color.White
        Me.Label5.ForeColor = Color.Black
        Me.Label4.ForeColor = Color.Black
        Me.Label8.ForeColor = Color.Black
        Me.Label9.ForeColor = Color.Black
        Me.Label11.ForeColor = Color.Black
    End Sub

    Private Sub Label7_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label7.MouseHover
        If Me.Label7.BackColor <> Color.Blue Then
            Me.Label7.BackColor = Color.CornflowerBlue
        End If

    End Sub

    Private Sub Label7_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label7.MouseLeave
        ' Me.Label7.BackColor = Color.Transparent
        If Me.Label7.BackColor <> Color.Blue Then
            Me.Label7.BackColor = Color.Transparent
        End If

    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click
        Dim formtoShow As New km_DeskSetting
        If OpenOnce(formtoShow) = False Then
            formtoShow.MdiParent = Me
            formtoShow.Show()
            show_style(formtoShow)
        End If
        

    End Sub

    Private Sub Label8_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label8.MouseDown
        Me.Label8.BackColor = Color.Blue
        Me.Label5.BackColor = Color.Transparent
        Me.Label7.BackColor = Color.Transparent
        Me.Label4.BackColor = Color.Transparent
        Me.Label9.BackColor = Color.Transparent
        Me.Label11.BackColor = Color.Transparent

        Me.Label8.ForeColor = Color.White
        Me.Label5.ForeColor = Color.Black
        Me.Label7.ForeColor = Color.Black
        Me.Label4.ForeColor = Color.Black
        Me.Label9.ForeColor = Color.Black
        Me.Label11.ForeColor = Color.Black
    End Sub

    Private Sub Label8_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label8.MouseHover
        If Me.Label8.BackColor <> Color.Blue Then
            Me.Label8.BackColor = Color.CornflowerBlue
        End If

    End Sub

    Private Sub Label8_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label8.MouseLeave
        ' Me.Label8.BackColor = Color.Transparent
        If Me.Label8.BackColor <> Color.Blue Then
            Me.Label8.BackColor = Color.Transparent
        End If
    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click
        Dim formtoShow As New km_windowsSetting
        If OpenOnce(formtoShow) = False Then
            formtoShow.MdiParent = Me
            formtoShow.Show()
            show_style(formtoShow)

        End If
        

    End Sub

    Private Sub Label9_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label9.MouseDown
        Me.Label9.BackColor = Color.Blue
        Me.Label5.BackColor = Color.Transparent
        Me.Label7.BackColor = Color.Transparent
        Me.Label8.BackColor = Color.Transparent
        Me.Label4.BackColor = Color.Transparent
        Me.Label11.BackColor = Color.Transparent

        Me.Label9.ForeColor = Color.White
        Me.Label5.ForeColor = Color.Black
        Me.Label7.ForeColor = Color.Black
        Me.Label8.ForeColor = Color.Black
        Me.Label4.ForeColor = Color.Black
        Me.Label11.ForeColor = Color.Black
    End Sub

    Private Sub Label9_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label9.MouseHover
        If Me.Label9.BackColor <> Color.Blue Then
            Me.Label9.BackColor = Color.CornflowerBlue
        End If

    End Sub

    Private Sub Label9_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label9.MouseLeave
        'Me.Label9.BackColor = Color.Transparent
        If Me.Label9.BackColor <> Color.Blue Then
            Me.Label9.BackColor = Color.Transparent
        End If
    End Sub

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click
        Dim formtoShow As New km_yxSetting
        If OpenOnce(formtoShow) = False Then
            formtoShow.MdiParent = Me
            formtoShow.Show()
            show_style(formtoShow)
        End If
        



    End Sub

    Private Sub Label11_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label11.MouseDown
        Me.Label11.BackColor = Color.Blue
        Me.Label5.BackColor = Color.Transparent
        Me.Label7.BackColor = Color.Transparent
        Me.Label8.BackColor = Color.Transparent
        Me.Label9.BackColor = Color.Transparent
        Me.Label4.BackColor = Color.Transparent

        Me.Label11.ForeColor = Color.White
        Me.Label5.ForeColor = Color.Black
        Me.Label7.ForeColor = Color.Black
        Me.Label8.ForeColor = Color.Black
        Me.Label9.ForeColor = Color.Black
        Me.Label4.ForeColor = Color.Black
    End Sub

    Private Sub Label11_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label11.MouseHover
        If Me.Label11.BackColor <> Color.Blue Then
            Me.Label11.BackColor = Color.CornflowerBlue
        End If

    End Sub

    Private Sub Label11_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label11.MouseLeave
        'Me.Label11.BackColor = Color.Transparent

        If Me.Label11.BackColor <> Color.Blue Then
            Me.Label11.BackColor = Color.Transparent
        End If
    End Sub

    Private Function OpenOnce(ByVal myform As Form) As Boolean
        Dim frm As Form

        For Each frm In Me.MdiChildren
            If InStr(frm.Text, myform.Text) > 0 Then
                frm.Activate()
                Return True
            End If
        Next
        ' myform.WindowState = FormWindowState.Maximized
        Return False
    End Function

    Private Sub show_style(ByVal formShow As Form)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''此为，在父窗口中打开的子窗口的样式（normal,没有边框，位置及大小）
        formShow.WindowState = FormWindowState.Normal
        formShow.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        formShow.Left = Me.GroupBox1.Left + Me.GroupBox1.Width - 1
        formShow.Top = Me.PictureBox1.Top + Me.PictureBox1.Height - 1
        formShow.Width = Me.Width - Me.GroupBox1.Width - Me.GroupBox1.Left - 4
        formShow.Height = Me.Height - Me.PictureBox1.Left - Me.PictureBox1.Height - 4
        'MsgBox("高：" & formShow.Height.ToString & "    。宽：" & formShow.Width.ToString)
    End Sub

    '关闭所有子窗口
    Public Sub closeForm(ByVal myform As Form)
        Dim frm As Form

        For Each frm In Me.MdiChildren
            If InStr(frm.Text, myform.Text) > 0 Then

                frm.Dispose()  '这是非常重要的，关闭并不是销毁，这样就是处于下次打开，会认为是第一次打开一样
                frm.Close()
            End If
        Next
    End Sub

    Public Sub close_me(ByVal myform As Form)

        myform.Close()

        myform.Dispose()

        Me.Dispose(True)   '这是非常重要的，关闭并不是销毁，这样就是处于下次打开，会认为是第一次打开一样

        Me.Close()

     
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Setting_boolean = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

    End Sub

    Private Sub Label2_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label2.MouseHover
        Me.Label2.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\closeo.png")
    End Sub

    Private Sub Label2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label2.MouseLeave
        Me.Label2.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\Skin\closeds.png")
    End Sub
End Class

