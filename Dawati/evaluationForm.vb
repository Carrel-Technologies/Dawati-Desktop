﻿Public Class evaluationForm

    Public rowCount As Integer = 0
    Public exam_id As Integer
    Public hours As String
    Public minutes As String
    Public numQuestions As Integer
    Public examName As String
    Public subject As String
    'Public mainObject As New mainForm 'mainForm Object

    Public Sub initialize()

    End Sub
    Public Sub showExamDetails()
        Dim selectedExam As String = evaluationsListBox.SelectedItem
        Dim dbConnect As New databaseConnection
        dbConnect.sqlLiteConnection("Evaluations.db")
        Dim strSql As String = "select exam_id, exam_name, hours, minutes,description,num_of_questions, subject from exams where exam_name = '" & selectedExam & "';"
        dbConnect.selectSqlite(strSql)

        While dbConnect.reader.Read
            exam_id = dbConnect.reader("exam_id")
            hours = dbConnect.reader("hours")
            numQuestions = dbConnect.reader("num_of_questions")
            minutes = dbConnect.reader("minutes")
            examName = dbConnect.reader("exam_name")

            examNameLabel.Text = examName
            subjectLabel.Text = dbConnect.reader("subject")
            descriptionLabel.Text = dbConnect.reader("description")
            noOfQuestionsLabel.Text = numQuestions
            hoursLabel.Text = hours
            hoursNameLabel.Visible = True
            minutesLabel.Text = minutes
            MinutesNameLabel.Visible = True
        End While
        questions.getter(exam_id, examName, numQuestions)
    End Sub
    Public Sub databaseReader(ByVal subject As String)

        Dim dbConnect As New databaseConnection
        dbConnect.sqlLiteConnection("Evaluations.db")
        'select questions which are not open ended
        Dim selectsql As String = "select exam_name,hours,minutes from exams where subject='" & subject & "' "
        'Dim selectsql As String = "Select exam_name,hours,minutes from exams where subject='English'"
        dbConnect.selectSqlite(selectsql)
        While dbConnect.reader.Read
            evaluationsListBox.Items.Add(dbConnect.reader("exam_name"))
        End While
        dbConnect.closeSqlite()



    End Sub


    'Public Sub trueOrFalseQuestions()
    '    'initialize components
    '    Dim varTest = New System.Windows.Forms.Label()

    'End Sub

    ''single select questions
    'Private Sub singleSelectQuestion()

    'End Sub

    ''multiple select questions
    'Private Sub multipleSelectQuestion()

    'End Sub
    ''open ended questions
    'Public Sub openEndedQuestion()

    'End Sub



    Private Sub evaluationsListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles evaluationsListBox.SelectedIndexChanged
        showExamDetails()
    End Sub

    Private Sub startMetroTile_Click(sender As Object, e As EventArgs) Handles startMetroTile.Click
        questions.initialize(exam_id, examName, numQuestions)

        questions.Show()
        Close()
    End Sub
#Region "menu strips"
    Private Sub AttemptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AttemptToolStripMenuItem.Click
        Close()
        mainForm.ebooksMetroPanel.Visible = False
        mainForm.aboutPanel.Visible = False
        mainForm.videosMetroPanel.Visible = False
        mainForm.profilePanel.Visible = False
        mainForm.evaluationMetroPanel.Visible = True
    End Sub

    Private Sub mathsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mathsToolStripMenuItem.Click
        Close()
        Dim subject As String = "Mathematics"
        Dim learningMaterial As String = "videos"
        selectStudyLevel.initialize(subject, learningMaterial)
        selectStudyLevel.Show()
    End Sub

    Private Sub englishToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles englishToolStripMenuItem.Click
        Close()
        Dim subject As String = "english"
        Dim learningMaterial As String = "videos"
        selectStudyLevel.initialize(subject, learningMaterial)
        selectStudyLevel.Show()
    End Sub

    Private Sub biologyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles biologyToolStripMenuItem.Click
        Close()
        Dim subject As String = "biology"
        Dim learningMaterial As String = "videos"
        selectStudyLevel.initialize(subject, learningMaterial)
        selectStudyLevel.Show()
    End Sub

    Private Sub physicsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles physicsToolStripMenuItem.Click

        Close()
        Dim subject As String = "physics"
        Dim learningMaterial As String = "videos"
        selectStudyLevel.initialize(subject, learningMaterial)
        selectStudyLevel.Show()
    End Sub

    Private Sub chemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles chemToolStripMenuItem.Click
        Close()
        Dim subject As String = "chemistry"
        Dim learningMaterial As String = "videos"
        selectStudyLevel.initialize(subject, learningMaterial)
        selectStudyLevel.Show()
    End Sub

    Private Sub ebooksMathsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ebooksMathsToolStripMenuItem.Click

        Close()
        Dim subject As String = "Mathematics"
        Dim learningMaterial As String = "eBook"
        selectStudyLevel.initialize(subject, learningMaterial)
        selectStudyLevel.Show()
    End Sub

    Private Sub ebookEngToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ebookEngToolStripMenuItem.Click
        Close()
        Dim subject As String = "english"
        Dim learningMaterial As String = "eBook"
        selectStudyLevel.initialize(subject, learningMaterial)
        selectStudyLevel.Show()
    End Sub

    Private Sub EbookBioToolStripMenuIte_Click(sender As Object, e As EventArgs) Handles EbookBioToolStripMenuIte.Click
        Close()
        Dim subject As String = "biology"
        Dim learningMaterial As String = "eBook"
        selectStudyLevel.initialize(subject, learningMaterial)
        selectStudyLevel.Show()
    End Sub

    Private Sub EbookPhyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EbookPhyToolStripMenuItem.Click
        Close()
        Dim subject As String = "physics"
        Dim learningMaterial As String = "eBook"
        selectStudyLevel.initialize(subject, learningMaterial)
        selectStudyLevel.Show()
    End Sub

    Private Sub EbookChemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EbookChemToolStripMenuItem.Click
        Close()
        Dim subject As String = "chemistry"
        Dim learningMaterial As String = "eBook"
        selectStudyLevel.initialize(subject, learningMaterial)
        selectStudyLevel.Show()
    End Sub
#End Region

End Class