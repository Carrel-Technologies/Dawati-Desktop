﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class signInForm
    Inherits System.Windows.Forms.Form



    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(signInForm))
        Me.titleMetroLabel = New MetroFramework.Controls.MetroLabel()
        Me.emailMetroTextBox = New MetroFramework.Controls.MetroTextBox()
        Me.passwordMetroTextBox = New MetroFramework.Controls.MetroTextBox()
        Me.signInMetroButton = New MetroFramework.Controls.MetroButton()
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel2 = New MetroFramework.Controls.MetroLabel()
        Me.closeMetroButton = New MetroFramework.Controls.MetroButton()
        Me.logoPanel = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'titleMetroLabel
        '
        Me.titleMetroLabel.AutoSize = True
        Me.titleMetroLabel.FontSize = MetroFramework.MetroLabelSize.Tall
        Me.titleMetroLabel.Location = New System.Drawing.Point(469, 27)
        Me.titleMetroLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.titleMetroLabel.Name = "titleMetroLabel"
        Me.titleMetroLabel.Size = New System.Drawing.Size(73, 25)
        Me.titleMetroLabel.TabIndex = 0
        Me.titleMetroLabel.Text = "SIGN IN"
        '
        'emailMetroTextBox
        '
        '
        '
        '
        Me.emailMetroTextBox.CustomButton.Image = Nothing
        Me.emailMetroTextBox.CustomButton.Location = New System.Drawing.Point(182, 2)
        Me.emailMetroTextBox.CustomButton.Margin = New System.Windows.Forms.Padding(4)
        Me.emailMetroTextBox.CustomButton.Name = ""
        Me.emailMetroTextBox.CustomButton.Size = New System.Drawing.Size(23, 23)
        Me.emailMetroTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.emailMetroTextBox.CustomButton.TabIndex = 1
        Me.emailMetroTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.emailMetroTextBox.CustomButton.UseSelectable = True
        Me.emailMetroTextBox.CustomButton.Visible = False
        Me.emailMetroTextBox.Lines = New String(-1) {}
        Me.emailMetroTextBox.Location = New System.Drawing.Point(625, 102)
        Me.emailMetroTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.emailMetroTextBox.MaxLength = 32767
        Me.emailMetroTextBox.Name = "emailMetroTextBox"
        Me.emailMetroTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.emailMetroTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.emailMetroTextBox.SelectedText = ""
        Me.emailMetroTextBox.SelectionLength = 0
        Me.emailMetroTextBox.SelectionStart = 0
        Me.emailMetroTextBox.ShortcutsEnabled = True
        Me.emailMetroTextBox.Size = New System.Drawing.Size(208, 28)
        Me.emailMetroTextBox.TabIndex = 1
        Me.emailMetroTextBox.UseSelectable = True
        Me.emailMetroTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.emailMetroTextBox.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'passwordMetroTextBox
        '
        '
        '
        '
        Me.passwordMetroTextBox.CustomButton.Image = Nothing
        Me.passwordMetroTextBox.CustomButton.Location = New System.Drawing.Point(182, 2)
        Me.passwordMetroTextBox.CustomButton.Margin = New System.Windows.Forms.Padding(4)
        Me.passwordMetroTextBox.CustomButton.Name = ""
        Me.passwordMetroTextBox.CustomButton.Size = New System.Drawing.Size(23, 23)
        Me.passwordMetroTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.passwordMetroTextBox.CustomButton.TabIndex = 1
        Me.passwordMetroTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.passwordMetroTextBox.CustomButton.UseSelectable = True
        Me.passwordMetroTextBox.CustomButton.Visible = False
        Me.passwordMetroTextBox.Lines = New String(-1) {}
        Me.passwordMetroTextBox.Location = New System.Drawing.Point(625, 164)
        Me.passwordMetroTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.passwordMetroTextBox.MaxLength = 32767
        Me.passwordMetroTextBox.Name = "passwordMetroTextBox"
        Me.passwordMetroTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.passwordMetroTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.passwordMetroTextBox.SelectedText = ""
        Me.passwordMetroTextBox.SelectionLength = 0
        Me.passwordMetroTextBox.SelectionStart = 0
        Me.passwordMetroTextBox.ShortcutsEnabled = True
        Me.passwordMetroTextBox.Size = New System.Drawing.Size(208, 28)
        Me.passwordMetroTextBox.TabIndex = 2
        Me.passwordMetroTextBox.UseSelectable = True
        Me.passwordMetroTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.passwordMetroTextBox.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'signInMetroButton
        '
        Me.signInMetroButton.BackColor = System.Drawing.Color.Navy
        Me.signInMetroButton.Location = New System.Drawing.Point(688, 258)
        Me.signInMetroButton.Margin = New System.Windows.Forms.Padding(4)
        Me.signInMetroButton.Name = "signInMetroButton"
        Me.signInMetroButton.Size = New System.Drawing.Size(145, 46)
        Me.signInMetroButton.TabIndex = 4
        Me.signInMetroButton.Text = "Sign In"
        Me.signInMetroButton.UseSelectable = True
        Me.signInMetroButton.UseStyleColors = True
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.Location = New System.Drawing.Point(469, 107)
        Me.MetroLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(42, 20)
        Me.MetroLabel1.TabIndex = 4
        Me.MetroLabel1.Text = "Email"
        '
        'MetroLabel2
        '
        Me.MetroLabel2.AutoSize = True
        Me.MetroLabel2.Location = New System.Drawing.Point(469, 169)
        Me.MetroLabel2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.MetroLabel2.Name = "MetroLabel2"
        Me.MetroLabel2.Size = New System.Drawing.Size(66, 20)
        Me.MetroLabel2.TabIndex = 5
        Me.MetroLabel2.Text = "Password"
        '
        'closeMetroButton
        '
        Me.closeMetroButton.Location = New System.Drawing.Point(452, 258)
        Me.closeMetroButton.Margin = New System.Windows.Forms.Padding(4)
        Me.closeMetroButton.Name = "closeMetroButton"
        Me.closeMetroButton.Size = New System.Drawing.Size(113, 44)
        Me.closeMetroButton.TabIndex = 3
        Me.closeMetroButton.Text = "Close"
        Me.closeMetroButton.UseSelectable = True
        '
        'logoPanel
        '
        Me.logoPanel.BackgroundImage = CType(resources.GetObject("logoPanel.BackgroundImage"), System.Drawing.Image)
        Me.logoPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.logoPanel.Location = New System.Drawing.Point(0, -1)
        Me.logoPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.logoPanel.Name = "logoPanel"
        Me.logoPanel.Size = New System.Drawing.Size(395, 389)
        Me.logoPanel.TabIndex = 6
        '
        'signInForm
        '
        Me.AcceptButton = Me.signInMetroButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(897, 386)
        Me.ControlBox = False
        Me.Controls.Add(Me.closeMetroButton)
        Me.Controls.Add(Me.logoPanel)
        Me.Controls.Add(Me.MetroLabel2)
        Me.Controls.Add(Me.MetroLabel1)
        Me.Controls.Add(Me.signInMetroButton)
        Me.Controls.Add(Me.passwordMetroTextBox)
        Me.Controls.Add(Me.emailMetroTextBox)
        Me.Controls.Add(Me.titleMetroLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "signInForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents titleMetroLabel As MetroFramework.Controls.MetroLabel
    Friend WithEvents emailMetroTextBox As MetroFramework.Controls.MetroTextBox
    Friend WithEvents passwordMetroTextBox As MetroFramework.Controls.MetroTextBox
    Friend WithEvents signInMetroButton As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroLabel1 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel2 As MetroFramework.Controls.MetroLabel
    Friend WithEvents closeMetroButton As MetroFramework.Controls.MetroButton
    Friend WithEvents logoPanel As Panel
End Class
