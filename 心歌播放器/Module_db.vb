'
'
' 数据库操作 模块
'
'
' 日期： 2019-11-24
'
' 老项目了，就改改数据库，就不会再又优化了
'
'
' SQLite 二进制添加到vs中： https://blog.csdn.net/ght886/article/details/83791418
'
' SQLite 代码连接数据库： https://blog.csdn.net/cheug/article/details/7878166
'
'
Imports System.IO
Imports System.Data.SQLite

Module Module_db

    '数据库 SQLite
    Public ReadOnly db_name As String = Application.StartupPath & "\kmplay.db"
    Public ReadOnly myconn As SQLiteConnection = New SQLiteConnection（"Data Source=" & db_name & ";Pooling=true;FailIfMissing=false"）

    '备份数据库
    Public ReadOnly backup_db_name As String = Application.StartupPath & "\数据库备份\kmplay.db"

    '判断数据库 文件是否存在
    Private Function SQLiteDBEnable() As Boolean
        Dim exists As Boolean = True
        If System.IO.File.Exists(db_name) = False Then
            SQLiteConnection.CreateFile(db_name)
            exists = False
            debug_write("SQLiteDBEnable not db")
        End If

        If exists = False Then
            If SQLiteCreateDB() = False Then
                ' 创建表 失败
                debug_write("SQLiteDBEnable error 创建表")
                Return False
            End If
        End If
        debug_write("SQLiteDBEnable success")
        Return True
    End Function

    '创建数据库表
    Private Function SQLiteCreateDB() As Boolean
        '参数具体的意思，和 kmplay.mdb, 设计视图一样的，没有改动

        ' 歌曲列表
        Dim mListTableSql As String = "CREATE TABLE mList (Id INTEGER PRIMARY KEY,Music_name VARCHAR(500) default(''),Music_path  VARCHAR(500) default(''),
                                        Music_playTime VARCHAR(100) default(''),Music_playCi INT default 0,Music_auther VARCHAR(100) default(''),Music_zj VARCHAR(100) default(''),
                                        Music_M decimal(1000,2) default 0,Music_type VARCHAR(100) default(''),create_date VARCHAR(100) default(''))"

        ' 播放器设置
        Dim kmSettingSql As String = "CREATE TABLE kmSetting (ID INTEGER PRIMARY KEY,
                                        autoPlay INT default 1,playHello INT default 1,tp INT default 0,kjOpen INT default 1,lrcPath VARCHAR(1000) default('F:\d'),font_name VARCHAR(50) default(''),size INT default 0,
                                        fontType VARCHAR(50) default(''),font_color VARCHAR(50) default(''),tmd decimal(10,2) default 1.2,
                                        c_font VARCHAR(50) default(''),c_size VARCHAR(50) default(''),c_fontType VARCHAR(50) default(''),c_color VARCHAR(50) default(''),c_font_play_color VARCHAR(100) default(''),
                                        play_pause VARCHAR(50) default(''),pre_play VARCHAR(50) default(''),next_play VARCHAR(50) default(''),mute VARCHAR(50) default(''),
                                        play_pause_moRen VARCHAR(50) default(''),pre_play_moRen VARCHAR(50) default(''),next_play_moRenpre_play_moRen VARCHAR(50) default(''),mute_moRen VARCHAR(50) default(''),
                                        lrcPath_moren VARCHAR(1000) default(''),font_moren VARCHAR(50) default(''),
                                        size_moren VARCHAR(50) default(''),fontType_moren VARCHAR(50) default(''),color_moren VARCHAR(50) default(''),
                                        Font_play_color_moren VARCHAR(50) default(''),tmd_moren  VARCHAR(50) default(''),
                                        c_font_moren VARCHAR(50) default(''),c_size_moren VARCHAR(50) default(''),c_fontType_moren VARCHAR(50) default(''),
                                        c_color_moren VARCHAR(50) default(''),c_font_play_color_moren VARCHAR(50) default(''),
                                        sound_mute INT default 0,sound_int INT default 50,playSetting INT default 3,id_diaoyong INT default 1)"
        '
        Dim km_backcolorSql As String = "CREATE TABLE km_backcolor (ID INTEGER PRIMARY KEY,colorPath1 VARCHAR(1000) default(''),colorPath2 VARCHAR(1000) default(''),colorPath3 VARCHAR(1000) default(''))"

        If DBExecuteNonQueryAndNonInsert(mListTableSql) = False Then
            Return False '创建表失败
        End If
        If DBExecuteNonQueryAndNonInsert(kmSettingSql) = False Then
            Return False '创建表失败
        End If
        If DBExecuteNonQueryAndNonInsert(km_backcolorSql) = False Then
            Return False '创建表失败
        End If
        Return True
    End Function

    ' 关闭数据库
    Public Sub DBClose()
        If myconn.State = ConnectionState.Open Then
            myconn.Close（）
        End If
    End Sub

    'sql 方法: 1. create Table。 2.update。 3.delete。
    Public Function DBExecuteNonQueryAndNonInsert(ByVal commandText As String) As Boolean
        SQLiteDBEnable()
        Try
            If myconn.State <> ConnectionState.Open Then
                myconn.Open()
            End If
            Dim cmd As New SQLiteCommand
            cmd.Connection = myconn
            cmd.CommandText = commandText
            'cmd.CommandTimeout = 10
            Dim result As Integer = cmd.ExecuteNonQuery()
            '这里 create ==0 成功，， update > 0成功，delete 可能>0 也有可能==0， 截取sql字符串判断吧
            'If result = 0 Then  
            '    debug_write("error sql=" & commandText)
            '    DBClose()
            '    Return False
            'End If

        Catch ex As Exception
            DBClose()
            ReportError(ex)
            Return False
        End Try

        DBClose()
        Return True
    End Function

    Public Function DBSelect(ByVal commandText As String) As SQLiteDataAdapter
        SQLiteDBEnable()
        Dim sa As New SQLiteDataAdapter(commandText, myconn)
        Return sa
    End Function

    Public Function DBTableMlistInsert(ByVal Music_name As String,
                                     ByVal Music_path As String,
                                     ByVal Music_playTime As String,
                                     ByVal Music_auther As String,
                                     ByVal Music_zj As String,
                                     ByVal Music_M As Double,
                                     ByVal Music_type As String
                                     ) As Boolean
        SQLiteDBEnable()


        Try
            If myconn.State <> ConnectionState.Open Then
                myconn.Open()
            End If
            Dim cmd As New SQLiteCommand
            cmd = myconn.CreateCommand()
            cmd.CommandText = "insert into mlist(Music_name,Music_path,Music_playTime,Music_auther,Music_zj,Music_M,Music_type,create_date) values(
                                         @Music_name,@Music_path,@Music_playTime,@Music_auther,@Music_zj,@Music_M,@Music_type,@create_date)"

            cmd.Parameters.Add("@Music_name", Data.DbType.String).Value = DBNotNullValue(Music_name)
            cmd.Parameters.Add("@Music_path", Data.DbType.String).Value = DBNotNullValue(Music_path)
            cmd.Parameters.Add("@Music_playTime", Data.DbType.String).Value = DBNotNullValue(Music_playTime)
            cmd.Parameters.Add("@Music_auther", Data.DbType.String).Value = DBNotNullValue(Music_auther)
            cmd.Parameters.Add("@Music_zj", Data.DbType.String).Value = DBNotNullValue(Music_zj)
            cmd.Parameters.Add("@Music_M", Data.DbType.Double).Value = Music_M
            cmd.Parameters.Add("@Music_type", Data.DbType.String).Value = DBNotNullValue(Music_type)

            Dim datestr As String = ""
            datestr = Format(Now(), "yyyy/MM/dd H:mm:ss ffff")
            cmd.Parameters.Add("@create_date", Data.DbType.String).Value = datestr

            Dim result As Integer = cmd.ExecuteNonQuery()
            If result <> 0 Then
                DBClose()
                Return False
            End If
        Catch ex As Exception
            DBClose()
            ReportError(ex)
            Return False
        End Try


        DBClose()
        Return True
    End Function

    Public Function DBNotNullValue(ByVal value As String) As String
        If value Is Nothing Then
            value = ""
        End If
        Return value
    End Function

End Module
