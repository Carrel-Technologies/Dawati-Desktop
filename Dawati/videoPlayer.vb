﻿Public Class videoPlayer
    ' Private videoPath As String
    Private multimediaSeries As String
    Private studylevel As String
    'Public Sub initialize(ByVal url As String)
    Private videoViews As Integer
    Public Sub getVideoViews(ByVal views As Integer)
        videoViews = views
        If videoViews = 1 Then
            viewsLabel.Text = "View"
        Else
            viewsLabel.Text = "Views"
        End If
    End Sub
    Public Sub initialize(ByVal url As String)
        ViewsCounter.Text = videoViews


        videoLabel.Text = url.Substring(24)
        AxWindowsMediaPlayer.URL = url
        '   videoPath = url
        If AxWindowsMediaPlayer.playState = WMPLib.WMPPlayState.wmppsPlaying Then
            AxWindowsMediaPlayer.Height = 400
            AxWindowsMediaPlayer.Width = 891
            AxWindowsMediaPlayer.Size = New Size(550, 891)

        End If

        AxWindowsMediaPlayer.windowlessVideo = False
        playListListBox.Items.Clear()
        fillOtherListBox()
    End Sub


    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles exitMetroButton.Click
        AxWindowsMediaPlayer.close()
        mainForm.encrypt()
        classRoom.Close()
        Close()
        dawatiParent.Show()
        mainForm.MdiParent = dawatiParent
        mainForm.WindowState = FormWindowState.Maximized
        mainForm.Show()
    End Sub

    Private Sub playMetroButton_Click(sender As Object, e As EventArgs) Handles playMetroButton.Click
        classRoom.getSelectedVideo(playListListBox)

    End Sub

    Private Sub playListListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles playListListBox.DoubleClick
        classRoom.getSelectedVideo(playListListBox)
    End Sub
    Public Sub getters(ByVal multimediaSeries As Integer, ByVal studylevel As String)
        Me.multimediaSeries = multimediaSeries
        Me.studylevel = studylevel
    End Sub
    Public Sub fillOtherListBox()
        Dim dbConnect As New databaseConnection
        dbConnect.sqlLiteConnection("multimedia.db")
        Dim strSql As String = "Select file_name from multimedia_content where multimedia_series ='" & multimediaSeries & "' and file_type='video' and study_level='" & studylevel & "'"
        dbConnect.selectSqlite(strSql)

        While dbConnect.reader.Read

            playListListBox.Items.Add(dbConnect.reader("file_name"))
        End While
        dbConnect.closeSqlite()
    End Sub
End Class