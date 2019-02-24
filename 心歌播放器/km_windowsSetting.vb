
'酷猫播放器 窗口歌词设置（Setting的子窗口）
'       作者：srxboys
'       说明：此处的界面设计，完全按照“酷狗——设置界面”为参考
'       日期：20140722
'

Public Class km_windowsSetting

    

    Private Sub km_windowsSetting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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



        '字体
        Me.ComboBox1.DropDownHeight = 100
        Me.ComboBox1.Text = 1
        Me.ComboBox1.Items.Add(1)
        Me.ComboBox1.Items.Add(2)
        Me.ComboBox1.Items.Add(3)

        '字号
        Me.ComboBox2.Text = 9
        Me.ComboBox2.DropDownHeight = 100   '给下拉框限制高度，不然整个界面会被覆盖的
        For i As Integer = 1 To 48
            Me.ComboBox2.Items.Add(i)
        Next

        '字型
        'Me.ComboBox3.DropDownHeight = 100
        Me.ComboBox3.Text = "常规"
        Me.ComboBox3.Items.Add("常规")
        Me.ComboBox3.Items.Add("粗体")
        Me.ComboBox3.Items.Add("斜体")
        'Me.ComboBox3.Items.Add("下划线")
        Me.ComboBox3.Items.Add("粗体、斜体")

        '未播放颜色
        Me.Label7.BackColor = Color.Blue
        Me.Label7.Text = "               "

        '播放颜色
        Me.Label8.BackColor = Color.Red
        Me.Label8.Text = "               "

      
    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        Me.ComboBox1.DroppedDown = True
    End Sub

    Private Sub ComboBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox1.KeyUp
        Me.ComboBox1.Text = 1
    End Sub

    Private Sub ComboBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ComboBox1.MouseDown
        Me.ComboBox1.DroppedDown = True
    End Sub
    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox2.KeyPress
        Me.ComboBox2.DroppedDown = True
    End Sub

    Private Sub ComboBox2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox2.KeyUp
        Me.ComboBox2.Text = 9
    End Sub

    Private Sub ComboBox2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ComboBox2.MouseDown
        Me.ComboBox2.DroppedDown = True
    End Sub
    Private Sub ComboBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox3.KeyPress
        Me.ComboBox3.DroppedDown = True
    End Sub

    Private Sub ComboBox3_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox3.KeyUp
        Me.ComboBox3.Text = "常规"
    End Sub

    Private Sub ComboBox3_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ComboBox3.MouseDown
        Me.ComboBox3.DroppedDown = True
    End Sub

  

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        '恢复默认值

        Me.ComboBox1.Text = "1"
        Me.ComboBox2.Text = 9
        Me.ComboBox3.Text = "常规"
        Me.Label7.BackColor = Color.Blue
        Me.Label8.BackColor = Color.Red
       
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        Me.ColorDialog1.ShowDialog()
        Me.Label7.BackColor = Me.ColorDialog1.Color
        ' MsgBox(Me.ColorDialog1.Color.ToString)
    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click
        Me.ColorDialog1.ShowDialog()
        Me.Label8.BackColor = Me.ColorDialog1.Color
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call Setting.Label2_Click(Nothing, Nothing)
    End Sub
End Class