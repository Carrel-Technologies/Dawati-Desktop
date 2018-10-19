﻿Imports System.Net
Imports System.Threading
Imports System.IO
Imports System.Net.WebClient.dowloadFile
Imports MySql.Data.MySqlClient
Imports System.Data.SQLite
Public Class loading

    'dbConnect is an object of database connection

    'global variables
    Private sqliteCommand As SQLiteCommand
    Public result As DialogResult ' stores dialog result from checkConnection method
    Public count As Integer = 0 ' has 0 if no occurence of the file in database, else >0
    'Private Shared newFields(60000) As Integer  '


    'checks internet connectivity
    Public Sub checkConnection()
        Dim connection As Boolean

        'send web request
        Try
            Using client = New WebClient()
                Using stream = client.OpenRead("http://www.google.com")
                    If client.IsBusy Then 'times out
                        connection = False
                    End If

                    connection = True
                End Using
            End Using
        Catch
            connection = False
        End Try

        If connection = True Then
            mainForm.updateContentMetroTile.Visible = True
            mainForm.internetConnectionLabel.Visible = True
        End If


    End Sub

    Public Sub updateContent()
        syncEvaluations()
        updateUsers()

        writeMaterialDetails()



        counter()
    End Sub

    'connect to remote sever and write details about the learning materials
    Public Sub writeMaterialDetails()
        ' stores data from remote database
        Dim file_name, file_type, target, study_level As String
        Dim file_id, num_slides, multimedia_series, multimedia_type As Integer
        Dim count As Integer = 0
        Dim dbConnect = New databaseConnection 'object
        dbConnect.dbConnection()
        'get data from remote server
        Dim strSql As String = "Select * FROM multimedia_content ORDER BY file_id ASC"
        dbConnect.selectMySql(strSql)

        Try
            While dbConnect.MySqlReader.Read
                file_id = dbConnect.MySqlReader("file_id")
                file_name = dbConnect.MySqlReader("file_name")
                file_type = dbConnect.MySqlReader("file_type")
                target = dbConnect.MySqlReader("target")
                'num_slides = dbConnect.MySqlReader("num_slides")
                multimedia_series = dbConnect.MySqlReader("multimedia_series")
                multimedia_type = dbConnect.MySqlReader("multimedia_type")
                study_level = dbConnect.MySqlReader("study_level")

                'check for existing content in local database
                dbConnect.sqlLiteConnection("multimedia.db")
                Try
                    'sql string
                    Dim selectStrSql = "select file_id from multimedia_content where file_id ='" & file_id & "'"
                    dbConnect.selectSqlite(selectStrSql) 'call method selectSqlite and pass sql string as parameter

                    If dbConnect.reader.HasRows Then
                        'do nothing
                    Else
                        'add counter
                        count = count + 1
                        'record doesn't exist
                        Dim insertstrSql As String = "Insert into multimedia_content (file_id,file_name,file_type,target,num_slides,multimedia_series,
                    multimedia_type,study_level ) VALUES( '" & file_id & "','" & file_name & "','" & file_type & "','" & target & "','" & num_slides & "',
                    '" & multimedia_series & "','" & multimedia_type & "','" & study_level & "') "
                        'download said video

                        dbConnect.insertSqlite(insertstrSql)


                        If multimedia_type = 1 Then
                            '  downloadVideos(file_name, multimedia_series)
                        Else
                            'downloadEbooks(file_id, file_name)
                        End If

                        dbConnect.closeSqlite()

                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            End While
        Catch ex As Exception
            Dim result As DialogResult
            result = MessageBox.Show("Server Refused to connect, Try again later.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information)
            If result = DialogResult.Retry Then
                writeMaterialDetails()
            ElseIf result = DialogResult.Cancel Then

            End If
        End Try


        dbConnect.closeDbConnection() 'close connection


    End Sub

    'downloads videos 

    Private Sub downloadVideos(ByVal filename As String, ByVal multimediaSeries As String)

        If multimediaSeries = "3" Then
            'Mathematics
            My.Computer.Network.DownloadFile("https://www.dawati.co.ke/uploads/multimedia/content/video/Mathematics/" & filename & "",
                                             "assets\videos\decrypted\" & filename & "")

        ElseIf multimediaSeries = "2" Then
            'Chemistry
            My.Computer.Network.DownloadFile("https://www.dawati.co.ke/uploads/multimedia/content/Chemistry/" & filename & "",
                                             "assets\videos\decrypted\" & filename & "")

        ElseIf multimediaSeries = "1" Then
            'English
            My.Computer.Network.DownloadFile("https://www.dawati.co.ke/uploads/multimedia/content/video/English/" & filename & "",
                                             "assets\videos\decrypted\" & filename & "")
        ElseIf multimediaSeries = "12" Then
            'Physics
            My.Computer.Network.DownloadFile("https://www.dawati.co.ke/uploads/multimedia/content/video/Physics/" & filename & "",
                                             "assets\videos\decrypted\" & filename & "")
            'Biology
        ElseIf multimediaSeries = "5" Then

            My.Computer.Network.DownloadFile("https://www.dawati.co.ke/uploads/multimedia/content/video/Biology/" & filename & "",
                                             "assets\videos\decrypted\" & filename & "")
        End If
    End Sub
    Public Sub downloadEbooks(ByVal fileId As Integer, ByVal fileName As String)
        Dim s As String = "https://www.dawati.co.ke/uploads/multimedia/content/slides/" & fileId & "/" & fileName & ".pdf"
        My.Computer.Network.DownloadFile(s,
                                            "assets\ebooks\decrypted\" & fileName & "")
    End Sub

    'sends analytics to remote server
    Private Sub sendAnalytics()

    End Sub
    ' syncs new evaluation from the internet
    Private Sub syncEvaluations()
        Dim dbconnect As New databaseConnection
        dbconnect.dbConnection()
        'select statements from remote
        Dim examsStrSql As String = "select * from exams;"
        Dim questionsStrSql As String = "select * from questions;"
        Dim questionAnswersSql As String = "select * from question_answers;"
        Dim questionTypeSql As String = "select * from question_type"

        'read and write to variables
        '--------------
        'exams
        '--------------
        dbconnect.selectMySql(examsStrSql)
        'read while write into sqlite database
        'dbconnect.sqlLiteConnection("Evaluations.db")
        While dbconnect.MySqlReader.Read

            Dim examId As Integer = dbconnect.MySqlReader("exam_id")
            Dim examName As String = dbconnect.MySqlReader("exam_name")
            Dim subject As String = dbconnect.MySqlReader("subject")
            ' Dim studyLevel As String = dbconnect.MySqlReader("")
            Dim description As String = dbconnect.MySqlReader("description")
            Dim numOfQuestions As Integer = dbconnect.MySqlReader("num_of_questions")
            Dim hours As Integer = dbconnect.MySqlReader("hours")
            Dim minutes As Integer = dbconnect.MySqlReader("minutes")
            Dim dateCreated As String = dbconnect.MySqlReader("date_created")

            'check if record exists
            'sqlite connection done manually
            Dim dbLocation As String = "evaluations.db"
            Dim sqliteConnectionString As String = "Data Source=" & dbLocation & "; version=3;"
            Dim SQLiteConnection = New SQLiteConnection(sqliteConnectionString)
            SQLiteConnection.Open()
            'reading from database

            Dim existsStrSql As String = "select exam_id from exams where exam_id ='" & examId & "'"
            Dim sqliteCommand As New SQLiteCommand(existsStrSql, SQLiteConnection)
            Dim reader As SQLiteDataReader
            reader = sqliteCommand.ExecuteReader()
            'Try
            '  
            'Catch ex As Exception
            '    MessageBox.Show(ex.Message)
            'End Try



            If reader.HasRows Then
                'do nothing
                'update
            Else
                'Dim insertExamsSql As String = "insert into exams(exam_id, exam_name,subject,description,num_of_questions,hours,minutes)values
                '('" & examId & "','" & examName & "','" & subject & "','" & description & "','" & numOfQuestions & "','" & hours & "','" & minutes & "');"

                Dim insertExamsSql As String = "insert into exams(exam_id, exam_name,subject,description,num_of_questions,hours,minutes)values
                (?,?,?,?,?,?,?);"


                sqliteCommand = New SQLiteCommand(insertExamsSql, SQLiteConnection)

                'sqliteCommand.Connection.Open()
                '  Using transaction = sqliteCommand.Connection.BeginTransaction()
                sqliteCommand.Parameters.AddWithValue("@exam_id", examId)
                sqliteCommand.Parameters.AddWithValue("@exam_name", examName)
                sqliteCommand.Parameters.AddWithValue("@subject", subject)
                sqliteCommand.Parameters.AddWithValue("@dscription", description)
                sqliteCommand.Parameters.AddWithValue("@numQuestions", numOfQuestions)
                sqliteCommand.Parameters.AddWithValue("@hours", hours)
                sqliteCommand.Parameters.AddWithValue("@minutes", minutes)

                sqliteCommand.ExecuteNonQuery()
                count = count + 1
                SQLiteConnection.Close()
            End If


        End While
        'dbconnect.closeSqlite()
        dbconnect.MySqlReader.Dispose()

        '---------
        'end exams
        '---------

        'questions
        '----------
        dbconnect.selectMySql(questionsStrSql)
        'read while write into sqlite database
        While dbconnect.MySqlReader.Read

            Dim questionId As Integer = dbconnect.MySqlReader("question_id")
            Dim question As String = dbconnect.MySqlReader("question")
            Dim type As String = dbconnect.MySqlReader("type")
            ' Dim studyLevel As String = dbconnect.MySqlReader("")
            Dim score As String = dbconnect.MySqlReader("score")
            ' Dim date_updated As String = dbconnect.MySqlReader("date_updated").ToString
            Dim examId As Integer = dbconnect.MySqlReader("exam_id")
            Dim attachment As String = dbconnect.MySqlReader("attachment")
            'Dim numOfAnswers As String = dbconnect.MySqlReader("num_answers")

            'check if file exists
            'sqlite connection done manually
            Dim dbLocation As String = "evaluations.db"
            Dim sqliteConnectionString As String = "Data Source=" & dbLocation & "; version=3;"
            Dim SQLiteConnection = New SQLiteConnection(sqliteConnectionString)
            SQLiteConnection.Open()
            'reading from database
            Dim existsStrSql As String = "select question_id from questions where question_id ='" & questionId & "'"
            Dim sqliteCommand As New SQLiteCommand(existsStrSql, SQLiteConnection)
            Dim reader As SQLiteDataReader

            Try
                reader = sqliteCommand.ExecuteReader()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try


            If reader.HasRows Then
                    'do nothing
                    'update
                Else
                    Dim insertQuestionsSql As String = "insert into questions(question_id, question,type,score,exam_id,attachment)values
                    (?,?,?,?,?,?);"

                    sqliteCommand = New SQLiteCommand(insertQuestionsSql, SQLiteConnection)

                    'sqliteCommand.Connection.Open()

                    sqliteCommand.Parameters.AddWithValue("@questionId", questionId)
                    sqliteCommand.Parameters.AddWithValue("@question", question)
                    sqliteCommand.Parameters.AddWithValue("@type", type)
                    sqliteCommand.Parameters.AddWithValue("@score", score)
                    sqliteCommand.Parameters.AddWithValue("@exaam_id", examId)
                    sqliteCommand.Parameters.AddWithValue("@atachment", attachment)

                'Try
                sqliteCommand.ExecuteNonQuery()
                '  Catch ex As Exception
                ' MessageBox.Show(ex.Message)
                ' End Try

                count = count + 1
                    SQLiteConnection.Close()
                End If


        End While

        dbconnect.MySqlReader.Dispose()
        'end questions
        '-------------

        'question answers
        '---------------
        dbconnect.selectMySql(questionAnswersSql)
        'read while write into sqlite database
        While dbconnect.MySqlReader.Read

            Dim choiceId As Integer = dbconnect.MySqlReader("choice_id")
            Dim choice As String = dbconnect.MySqlReader("choice")
            Dim status As String = dbconnect.MySqlReader("status")
            Dim questionId As String = dbconnect.MySqlReader("question_id")

            dbconnect.sqlLiteConnection("Evaluations.db")
            'check if file exists
            'sqlite connection done manually
            Dim dbLocation As String = "evaluations.db"
            Dim sqliteConnectionString As String = "Data Source=" & dbLocation & "; version=3;"
            Dim SQLiteConnection = New SQLiteConnection(sqliteConnectionString)
            SQLiteConnection.Open()
            'reading from database
            Dim existsStrSql As String = "select choice_id from question_answers where choice_id ='" & choiceId & "'"

            Dim sqliteCommand As New SQLiteCommand(existsStrSql, SQLiteConnection)
            Dim reader As SQLiteDataReader

            Try
                reader = sqliteCommand.ExecuteReader()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try


            If reader.HasRows Then
                'do nothing
                'update
            Else
                Dim insertQuestionAnswersSql As String = "insert into question_answers(choice_id, choice,status,question_id)values
                (?,?,?,?);"
                sqliteCommand = New SQLiteCommand(insertQuestionAnswersSql, SQLiteConnection)

                'sqliteCommand.Connection.Open()

                sqliteCommand.Parameters.AddWithValue("@choiceId", choiceId)
                sqliteCommand.Parameters.AddWithValue("@choice", choice)
                sqliteCommand.Parameters.AddWithValue("@status", status)
                sqliteCommand.Parameters.AddWithValue("@questionId", questionId)


                Try
                    sqliteCommand.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

                count = count + 1
                SQLiteConnection.Close()
            End If


        End While

        dbconnect.MySqlReader.Dispose()

        'question type
        '--------------
        dbconnect.selectMySql(questionTypeSql)
        'read while write into sqlite database
        While dbconnect.MySqlReader.Read
            Dim Id As Integer = dbconnect.MySqlReader("id")
            Dim name As String = dbconnect.MySqlReader("name")



            'check if file exists
            dbconnect.sqlLiteConnection("Evaluations.db")
            Dim existsStrSql As String = "select id from question_type where id ='" & Id & "'"
            dbconnect.selectSqlite(existsStrSql)


            If dbconnect.reader.HasRows Then
                'do nothing
            Else
                Try
                    Dim insertQuestionTypeSql As String = "insert into question_type(id, name)values
                ('" & Id & "','" & name & "');"


                    dbconnect.insertSqlite(insertQuestionTypeSql)

                    count = count + 1
                    dbconnect.reader.Close()
                Catch
                End Try
            End If


        End While
        dbconnect.closeSqlite()
        dbconnect.MySqlReader.Dispose()
        'end questiontypes
        '-----------------


    End Sub
    'getter to get sqlitecommand
    Public Sub getSqliteCommand(ByVal sqliteCommand As SQLiteCommand)
        Me.sqliteCommand = sqliteCommand ' give global variable the value of local variable
    End Sub
    Private Sub updateUsers()
        Dim dbConnect As New databaseConnection
        dbConnect.dbConnection()
        Dim strSql As String = "Select * from users "
        dbConnect.selectMySql(strSql)

        While dbConnect.MySqlReader.Read


            Dim userId As Integer = dbConnect.MySqlReader("user_id")
            Dim fname As String = dbConnect.MySqlReader("fname")
            Dim lname As String = dbConnect.MySqlReader("lname")
            Dim email As String = dbConnect.MySqlReader("email")
            Dim hash As String = dbConnect.MySqlReader("hash")
            'Dim username As String = dbConnect.MySqlReader("username")
            Dim password As String = dbConnect.MySqlReader("password")
            Dim gender As String = dbConnect.MySqlReader("gender")
            Dim user_type As Integer = dbConnect.MySqlReader("user_type")
            Dim date_joined As String = dbConnect.MySqlReader("date_joined")
            Dim user_status As String = dbConnect.MySqlReader("user_status")
            Dim prof_img As String = "avatar.jpg"
            Dim about_me As String = dbConnect.MySqlReader("about_me")
            Dim online_status As Integer = dbConnect.MySqlReader("online_status")
            'Dim last_seen As String = dbConnect.MySqlReader("last_seen")


            'sqlite connection done manually
            Dim dbLocation As String = "dawatico_dawati.db"
            Dim sqliteConnectionString As String = "Data Source=" & dbLocation & "; version=3;"
            Dim SQLiteConnection = New SQLiteConnection(sqliteConnectionString)
            SQLiteConnection.Open()

            Dim liteSql As String = "select * from users where user_id='" & userId & "' "
            'reading from database
            Dim sqliteCommand As New SQLiteCommand(liteSql, SQLiteConnection)
            Dim reader As SQLiteDataReader

            Try
                reader = sqliteCommand.ExecuteReader()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            'Dim sqliteConn = New SQLiteConnection("Data Source=dawatico_dawati.db; version=3;")

            If reader.HasRows Then 'update existing user
                'write update statement here
            Else 'insert new record
                'Dim insertLiteSql = "Insert into users(user_id,fname,lname,email,
                ' hash,password,gender,user_type,date_joined,user_status,prof_img,about_me,online_status)VALUES ('" & userId & "','" & fname & "',
                '    '" & lname & "','" & email & "','" & hash & "','" & password & "','" & gender & "','" & user_type & "',
                '    '" & date_joined & "','" & user_status & "','" & prof_img & "','" & about_me & "','" & online_status & "');"
                Dim insertLiteSql = "Insert into users(user_id,fname,lname,email,hash,password,gender,user_type,date_joined,user_status,prof_img,about_me,online_status)VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?)"

                'parameters

                sqliteCommand = New SQLiteCommand(insertLiteSql, SQLiteConnection)



                'sqliteCommand.Connection.Open()
                '  Using transaction = sqliteCommand.Connection.BeginTransaction()
                sqliteCommand.Parameters.AddWithValue("@user_id", userId)
                sqliteCommand.Parameters.AddWithValue("@fname", fname)
                sqliteCommand.Parameters.AddWithValue("@lname", lname)
                sqliteCommand.Parameters.AddWithValue("@email", email)
                sqliteCommand.Parameters.AddWithValue("@hash", hash)
                sqliteCommand.Parameters.AddWithValue("@password", password)
                sqliteCommand.Parameters.AddWithValue("@gender", gender)
                sqliteCommand.Parameters.AddWithValue("@usertype", user_type)
                sqliteCommand.Parameters.AddWithValue("@datejoined", date_joined)
                sqliteCommand.Parameters.AddWithValue("@userstatus", user_status)
                sqliteCommand.Parameters.AddWithValue("@profimage", prof_img)
                sqliteCommand.Parameters.AddWithValue("@aboutMe", about_me)
                sqliteCommand.Parameters.AddWithValue("@onlinestatus", online_status)

                'Call insert
                'dbConnect.insertWithParams(insertLiteSql, "dawatico_dawati")
                Try
                    sqliteCommand.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

                '    'commit
                '  transaction.Commit()

                'call close
                SQLiteConnection.Close()
                ' End Using
            End If
        End While

        dbConnect.closeDbConnection()


        count = count + 1

    End Sub
    Private Sub counter()
        If count = 0 Then
            MessageBox.Show("Your videos,ebooks And evaluations are up To Date", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ElseIf count > 0 Then
            'ukora
            ' MessageBox.Show("" & count - 6", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub


End Class
