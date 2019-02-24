

'酷猫播放器 常规设置（Setting的子窗口）
'       作者：srxboys
'       说明：此处的界面设计，完全按照“酷狗——设置界面”为参考
'       日期：20140722


Imports System.Data.OleDb

Public Class km_cgSetting


    Dim myds As New DataSet

    Dim autoPlay As Integer = 0  '自动播放
    Dim playHello As Integer = 0 '播放hello
    Dim tp As Integer = 0  '托盘
    Dim kjOpen As Integer = 0     '开机打开酷猫播放器

    Dim timer1_index As Integer = 0

    Private Sub km_cgSetting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

        Me.Label3.Text = "设置成功"
        Me.Label3.Visible = False


        open_kmSetting()

    End Sub

  

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call Setting.Label2_Click(Nothing, Nothing)
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If Me.CheckBox1.Checked = True Then
            autoPlay = 1
        Else
            autoPlay = 0
        End If

    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If Me.CheckBox2.Checked = True Then
            playHello = 1
        Else
            playHello = 0
        End If

    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If Me.RadioButton1.Checked = True Then
            tp = 1
        Else
            tp = 0
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If Me.RadioButton2.Checked = True Then
            tp = 0
        Else
            tp = 1
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If Me.CheckBox3.Checked = True Then
            kjOpen = 1
        Else
            kjOpen = 0
        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            ' Setting_boolean = False
            Dim mysql As String
            Dim mycmd As New OleDbCommand
            myconn.Open()
            mysql = "update kmSetting set " & "autoPlay=" & autoPlay & "," & "playHello=" & playHello & "," & "tp=" & tp & "," & "kjOpen=" & kjOpen & " where id_diaoyong=" & 1
            mycmd.Connection = myconn
            mycmd.CommandText = mysql
            mycmd.ExecuteNonQuery()
            myconn.Close()
            myds.Clear()
            Form1.tp = tp

            'me.Label3 .Location =303, 275
            If Setting_boolean = False Then
                Me.Label3.Left = 303
                Me.Label3.Top = 275
                Me.Label3.ForeColor = Color.Red
                Me.Label3.Visible = True
                Me.Timer1.Enabled = True
            End If
           
        Catch ex As Exception
            'MsgBox("常规设置" & vbCrLf & ex.Message)
            debug_write("km_cgSetting.vb 常规设置 行123" & ex.Message.ToString)
            myds.Clear()
            myconn.Close()
        End Try
      
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If timer1_index < 25 Then
            Me.Label3.Top -= 5
            timer1_index += 1
        Else
            timer1_index = 0
            Me.Label3.Visible = False
            Me.Timer1.Enabled = False
        End If
    End Sub

    '打开前先判断数据库
    Private Sub open_kmSetting()
        Try
            myconn.Open()
            Dim myda1 As New OleDbDataAdapter("select autoPlay,playHello,tp,kjOpen from kmSetting  where id_diaoyong=" & 1, myconn)
            myda1.Fill(myds, "kmSet")
            myconn.Close()
            If myds.Tables("kmSet").Rows.Count = 1 Then
                If myds.Tables("kmSet").Rows(0).Item("autoPlay") = 1 Then
                    Me.CheckBox1.Checked = True
                End If

                If myds.Tables("kmSet").Rows(0).Item("playHello") = 1 Then
                    Me.CheckBox2.Checked = True
                End If

                If myds.Tables("kmSet").Rows(0).Item("tp") = 1 Then
                    Me.RadioButton1.Checked = True
                Else
                    Me.RadioButton2.Checked = True
                End If

                If myds.Tables("kmSet").Rows(0).Item("kjOpen") = 1 Then
                    Me.CheckBox3.Checked = True
                End If

            End If
            myds.Clear()
        Catch ex As Exception
            'MsgBox("常规设置" & vbCrLf & ex.Message)
            debug_write("km_cgSetting.vb 常规设置 行171" & ex.Message.ToString)
            myconn.Close()
            myds.Clear()
        End Try
    End Sub

End Class