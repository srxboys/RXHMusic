
'酷猫播放器 歌词路径设置（Setting的子窗口）
'       作者：srxboys
'       说明：此处的界面设计，完全按照“酷狗——设置界面”为参考
'       日期：20140722

Imports System.Data.OleDb
Public Class km_gcPathSetting
    Dim myds As New DataSet
    Dim timer1_index As Integer = 0
    Private Sub km_gcPathSetting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

        Me.Label2.Text = "设置成功"
        Me.Label2.Visible = False
        open_kmSetting()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.FolderBrowserDialog1.ShowDialog()
        Me.TextBox1.Text = Me.FolderBrowserDialog1.SelectedPath
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call Setting.Label2_Click(Nothing, Nothing)
    End Sub


    Private Sub open_kmSetting()
        Try
            myconn.Open()
            Dim myda1 As New OleDbDataAdapter("select lrcPath,id_diaoyong from kmSetting  where id_diaoyong=" & 1, myconn)
            myda1.Fill(myds, "kmSet1")
            myconn.Close()
            If myds.Tables("kmSet1").Rows.Count = 1 Then
                Me.TextBox1.Text = myds.Tables("kmSet1").Rows(0).Item("lrcPath").ToString
            End If
            myds.Clear()
        Catch ex As Exception
            'MsgBox("常规设置" & vbCrLf & ex.Message)
            debug_write("km_gcPathSetting.vb 歌词路径设置 行55" & ex.Message.ToString)
            myconn.Close()
            myds.Clear()
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            ' Setting_boolean = False
            Dim mysql As String
            Dim mycmd As New OleDbCommand
            myconn.Open()
            mysql = "update kmSetting set " & "lrcPath='" & Trim(Me.TextBox1.Text) & "' where id_diaoyong=" & 1
            mycmd.Connection = myconn
            mycmd.CommandText = mysql
            mycmd.ExecuteNonQuery()
            myconn.Close()
            myds.Clear()


            If Setting_boolean = False Then
                Me.Label2.Left = 303
                Me.Label2.Top = 275
                Me.Label2.ForeColor = Color.Red
                Me.Label2.Visible = True
                Me.Timer1.Enabled = True
            End If
        Catch ex As Exception
            'MsgBox("常规设置" & vbCrLf & ex.Message)
            debug_write("km_gcPathSetting.vb 歌词路径设置 行84" & ex.Message.ToString)
            myds.Clear()
            myconn.Close()
        End Try
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If timer1_index < 25 Then
            Me.Label2.Top -= 5
            timer1_index += 1
        Else
            timer1_index = 0
            Me.Label2.Visible = False
            Me.Timer1.Enabled = False
        End If
    End Sub
End Class