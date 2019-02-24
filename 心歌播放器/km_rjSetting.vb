
'酷猫播放器 热键设置（Setting的子窗口）
'       作者：srxboys
'       说明：此处的界面设计，完全按照“酷狗——设置界面”为参考
'       日期：20140722


Public Class km_rjSetting



    Dim i As Integer = 0
    Dim s1, s2 As Integer
    Dim s(4) As String



    Private Sub km_rjSetting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

        Me.TextBox1.TextAlign = HorizontalAlignment.Center
        Me.TextBox2.TextAlign = HorizontalAlignment.Center
        Me.TextBox3.TextAlign = HorizontalAlignment.Center
        Me.TextBox4.TextAlign = HorizontalAlignment.Center
        Me.TextBox5.TextAlign = HorizontalAlignment.Center

        Me.TextBox1.Text = "不可用"
        Me.TextBox2.Text = "不可用"
        Me.TextBox3.Text = "不可用"
        Me.TextBox4.Text = "不可用"
        Me.TextBox5.Text = "不可用"

    End Sub
  

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown

        If i = 0 And (e.KeyCode = 17 Or e.KeyCode = 18) Then
            Me.TextBox1.Text = ""

            Me.TextBox1.Text = "Ctrl +"


            i = 1
            s1 = 17
            s2 = 17

        ElseIf i = 1 And e.KeyCode <> 17 Then
            If e.KeyCode = 18 Then
                Me.TextBox1.Text += "Alt +"
                i = 2
            Else
                Me.TextBox1.Text += Chr(e.KeyCode)
                i = 5
            End If
           
            s2 = e.KeyCode
        ElseIf i = 2 And e.KeyCode <> s1 And e.KeyCode <> s2 Then

            Me.TextBox1.Text += Chr(e.KeyCode)
            i = 3
            s(0) = Chr(e.KeyCode)
        End If


    End Sub
    Private Sub TextBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyUp
        i = 0
    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        If i = 0 And (e.KeyCode = 17 Or e.KeyCode = 18) Then
            Me.TextBox2.Text = ""

            Me.TextBox2.Text = "Ctrl +"


            i = 1
            s1 = 17
            s2 = 17

        ElseIf i = 1 And e.KeyCode <> 17 Then
            If e.KeyCode = 18 Then
                Me.TextBox2.Text += "alt +"
                i = 2
            Else
                Me.TextBox2.Text += Chr(e.KeyCode)
                i = 5
            End If

            s2 = e.KeyCode
        ElseIf i = 2 And e.KeyCode <> s1 And e.KeyCode <> s2 Then

            Me.TextBox2.Text += Chr(e.KeyCode)
            i = 3
            s(1) = Chr(e.KeyCode)
        End If

    End Sub

    Private Sub TextBox2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyUp
        i = 0
    End Sub

    Private Sub TextBox3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyDown
        If i = 0 And (e.KeyCode = 17 Or e.KeyCode = 18) Then
            Me.TextBox3.Text = ""

            Me.TextBox3.Text = "Ctrl +"


            i = 1
            s1 = 17
            s2 = 17

        ElseIf i = 1 And e.KeyCode <> 17 Then
            If e.KeyCode = 18 Then
                Me.TextBox3.Text += "alt +"
                i = 2
            Else
                Me.TextBox3.Text += Chr(e.KeyCode)
                i = 5
            End If

            s2 = e.KeyCode
        ElseIf i = 2 And e.KeyCode <> s1 And e.KeyCode <> s2 Then

            Me.TextBox3.Text += Chr(e.KeyCode)
            i = 3
            s(2) = Chr(e.KeyCode)
        End If
    End Sub

    Private Sub TextBox3_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyUp
        i = 0
    End Sub

  

    Private Sub TextBox4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox4.KeyDown
        If i = 0 And (e.KeyCode = 17 Or e.KeyCode = 18) Then
            Me.TextBox4.Text = ""

            Me.TextBox4.Text = "Ctrl +"


            i = 1
            s1 = 17
            s2 = 17

        ElseIf i = 1 And e.KeyCode <> 17 Then
            If e.KeyCode = 18 Then
                Me.TextBox4.Text += "alt +"
                i = 2
            Else
                Me.TextBox4.Text += Chr(e.KeyCode)
                i = 5
            End If

            s2 = e.KeyCode
        ElseIf i = 2 And e.KeyCode <> s1 And e.KeyCode <> s2 Then

            Me.TextBox4.Text += Chr(e.KeyCode)
            i = 3
            s(3) = Chr(e.KeyCode)
        End If
    End Sub

    Private Sub TextBox4_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox4.KeyUp
        i = 0
    End Sub

    Private Sub TextBox5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox5.KeyDown
        If i = 0 And (e.KeyCode = 17 Or e.KeyCode = 18) Then
            Me.TextBox5.Text = ""

            Me.TextBox5.Text = "Ctrl +"


            i = 1
            s1 = 17
            s2 = 17

        ElseIf i = 1 And e.KeyCode <> 17 Then
            If e.KeyCode = 18 Then
                Me.TextBox5.Text += "alt +"
                i = 2
            Else
                Me.TextBox5.Text += Chr(e.KeyCode)
                i = 5
            End If

            s2 = e.KeyCode
        ElseIf i = 2 And e.KeyCode <> s1 And e.KeyCode <> s2 Then

            Me.TextBox5.Text += Chr(e.KeyCode)
            i = 3
            s(4) = Chr(e.KeyCode)
        End If
    End Sub

    Private Sub TextBox5_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox5.KeyUp
        i = 0
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call Setting.Label2_Click(Nothing, Nothing)
    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click
        System.Diagnostics.Process.Start(Application.StartupPath & "\常用快捷键.txt")
    End Sub

    Private Sub Label8_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label8.MouseDown
        Me.Label8.BackColor = Color.Blue
    End Sub

    Private Sub Label8_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label8.MouseHover
        Me.Label8.BackColor = Color.Red
    End Sub

    Private Sub Label8_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label8.MouseLeave
        Me.Label8.BackColor = Color.Transparent
    End Sub
End Class