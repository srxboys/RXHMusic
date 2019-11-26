'
'
' 错误打印 模块
'
'
' 日期： 2019-11-24
'
' 老项目了，就改改数据库，就不会再又优化了
'
'


Imports System.IO

Module Module_error

    Public Sub ReportError(ByVal ex As Exception)
        Dim message As String = "can'n break this -->>>>"
        If ex IsNot Nothing Then
            message = ex.Message.ToString()
        End If

        Dim CallStack As System.Diagnostics.StackTrace = New System.Diagnostics.StackTrace(1, True)
        debug_write("Error file=" & CallStack.GetFrame(0).GetFileName() & "  line=" & CallStack.GetFrame(0).GetFileLineNumber &
                    " column=" & CallStack.GetFrame(0).GetFileColumnNumber & vbCrLf & " message=" & message)
    End Sub

    Public Sub debug_write(ByVal txt As String)
        Dim IsDebug As Boolean = System.Diagnostics.Debugger.IsAttached
        If IsDebug = True Then
            '不是 Debug模式，不要打印日志
            Exit Sub
        End If

        Dim fs As FileStream = Nothing
        Dim s As StreamWriter = Nothing

        Try

            fs = New FileStream(Application.StartupPath & "\debug.txt", FileMode.Append, FileAccess.Write)

            s = New StreamWriter(fs)
            s.AutoFlush = False
            ' s.NewLine
            s.Write(" " & Chr(13) & Chr(10) & Chr(13) & Chr(10) & txt & "。 日期：" & Now())
            s = Nothing
            fs = Nothing
            s.Close()
            fs.Close()
        Catch ex As Exception
            s = Nothing
            fs = Nothing

            s.Close()
            fs.Close()
            MsgBox("debug 没有写入" & ex.Message)
        End Try
    End Sub

End Module
