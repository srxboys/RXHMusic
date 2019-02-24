'
'酷猫播放器 换皮肤窗口
'       作者：srxboys
'       说明：此处的界面设计，完全按照“酷狗——设置界面”为参考
'       写代码日期：20140727
'
Public Class km_backImage_select

    Private Sub km_backImage_select_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Me.ShowInTaskbar = False '这个只能在窗口代码下调整，在这里会卡屏，或者第一次不会被打开。。。（注意）
        Me.Icon = ico

        Me.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        Me.PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        Me.PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage

        Me.PictureBox1.Load(Application.StartupPath & "\beijing\fen-p1.gif")
        Me.PictureBox2.Load(Application.StartupPath & "\beijing\ncm-p1.jpg")
        Me.PictureBox3.Load(Application.StartupPath & "\beijing\pp-p1.jpg")


        Me.Label3.Image = System.Drawing.Image.FromFile(Application.StartupPath & "\beijing\对号.png")
        Me.Label4.Image = System.Drawing.Image.FromFile(Application.StartupPath & "\beijing\对号.png")
        Me.Label5.Image = System.Drawing.Image.FromFile(Application.StartupPath & "\beijing\对号.png")

        Me.Label3.Parent = Me.PictureBox1
        Me.Label4.Parent = Me.PictureBox2
        Me.Label5.Parent = Me.PictureBox3

        Me.Label3.BackColor = Color.Transparent
        Me.Label4.BackColor = Color.Transparent
        Me.Label5.BackColor = Color.Transparent

        

        Me.Label2.Text = ""
        Me.Label3.Text = "        " & vbCrLf & "       " & vbCrLf & "     "
        Me.Label4.Text = "        " & vbCrLf & "       " & vbCrLf & "     "
        Me.Label5.Text = "        " & vbCrLf & "       " & vbCrLf & "     "
   
        Me.Label3.Left = 38
        Me.Label3.Top = 38
        Me.Label4.Left = 38
        Me.Label4.Top = 38
        Me.Label5.Left = 38
        Me.Label5.Top = 38
        

        label_hide()
        Me.Label2.Visible = False
    End Sub
    Private Sub Show_true(ByVal label As Integer)

        Me.Label2.Visible = True
        Me.Label3.Visible = False
        Me.Label4.Visible = False
        Me.Label5.Visible = False
        'Form1.PictureBox1.ImageLocation = ""
        ' Form1.PictureBox1.Load(Application.StartupPath + "\Skin\MainDialog.gif")
        Select Case label
            Case 0
                Me.Label3.Visible = True
                'Form1.BackColor = Color.White
                Form1.ListBox1.BackColor = Color.MistyRose
                Form1.TrackBar4.BackColor = Color.MistyRose
                Form1.PictureBox1.BackColor = Color.White
                Form1.PictureBox1.Load(Application.StartupPath & "\beijing\fen-p1.gif")
                Form1.PictureBox3.Load(Application.StartupPath & "\beijing\fen-fmPlayer.png")

            Case 1
                Me.Label4.Visible = True
                Form1.ListBox1.BackColor = Color.PeachPuff
                Form1.TrackBar4.BackColor = Color.PeachPuff
                Form1.PictureBox1.Load(Application.StartupPath & "\beijing\ncm-p1.jpg")
                Form1.PictureBox3.Load(Application.StartupPath & "\beijing\ncm-fmPlayer.png")

            Case 2
                Me.Label5.Visible = True
                Form1.ListBox1.BackColor = Color.NavajoWhite
                Form1.TrackBar4.BackColor = Color.NavajoWhite
                ' Form1.PictureBox1.Load(Application.StartupPath & "\beijing\pp-p1.jpg")
                Form1.PictureBox1.Load(Application.StartupPath & "\beijing\播放背景8副本.png")
                Form1.PictureBox3.Load(Application.StartupPath & "\beijing\pp-fmPlayer.png")



        End Select
        Form1.Refresh()
    End Sub
    Private Sub label_hide()
        Me.Label3.Visible = False
        Me.Label4.Visible = False
        Me.Label5.Visible = False
    End Sub
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        label_hide()
        Me.Label3.Visible = True
        Show_true(0)
    End Sub

    Private Sub PictureBox1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseHover
        Me.Label2.Text = "默认"
        Me.Label2.Left = Me.PictureBox1.Left + (Me.PictureBox1.Width - Me.Label2.Width) / 2
        Me.Label2.Top = Me.PictureBox1.Top + Me.PictureBox1.Height + 2
        Me.Label2.Visible = True
    End Sub

    Private Sub PictureBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave
        Me.Label2.Visible = False
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Show_true(1)
    End Sub

    Private Sub PictureBox2_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseHover
        Me.Label2.Text = "咖啡美女"
        Me.Label2.Left = Me.PictureBox2.Left + ((Me.PictureBox2.Width - Me.Label2.Width) / 2)
        Me.Label2.Top = Me.PictureBox2.Top + Me.PictureBox2.Height + 2
        Me.Label2.Visible = True
    End Sub

    Private Sub PictureBox2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseLeave
        Me.Label2.Visible = False
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Show_true(2)
    End Sub

 

    Private Sub PictureBox3_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseHover
        Me.Label2.Text = "甜静美女"
        Me.Label2.Left = Me.PictureBox3.Left + ((Me.PictureBox3.Width - Me.Label2.Width) / 2)
        Me.Label2.Top = Me.PictureBox3.Top + Me.PictureBox3.Height + 2
        Me.Label2.Visible = True
    End Sub

    Private Sub PictureBox3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseLeave
        Me.Label2.Visible = False
    End Sub
    
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Me.ColorDialog1.ShowDialog()
            If Me.ColorDialog1.Color <> Color.Red Then
                Form1.PictureBox1.ImageLocation = ""
                Form1.PictureBox3.ImageLocation = ""
                Form1.PictureBox1.BackColor = Me.ColorDialog1.Color
                Form1.PictureBox3.BackColor = Me.ColorDialog1.Color
                Form1.TrackBar4.BackColor = Me.ColorDialog1.Color
                'If Me.ColorDialog1.Color = Color.Black Then
                '    Form1.ListBox1.BackColor = Color.Silver
                'Else
                '    Form1.ListBox1.BackColor = Me.ColorDialog1.Color
                'End If
               

                Form1.Refresh()
                label_hide()
            Else
                MsgBox("请换个颜色")
            End If


        Catch ex As Exception
            'MsgBox("调色板" & ex.Message)
            debug_write("km_backImage_select.vb  换皮肤 行170 " & ex.Message.ToString)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call Form1.Label39_Click(Nothing, Nothing)
    End Sub
End Class