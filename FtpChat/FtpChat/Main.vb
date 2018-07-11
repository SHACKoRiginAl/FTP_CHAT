Imports System.IO
Imports System.Net
Imports System.Text

Public Class Main
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Text = My.Settings.UserName
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim name As String
        name = My.Settings.UserName
        Try
            Dim client As New Net.WebClient
            client.Credentials = New Net.NetworkCredential(My.Settings.FTPUser, My.Settings.FTPPass)
            client.UploadString(My.Settings.FTPLink, RichTextBox1.Text & "" & name & ": " & TextBox1.Text & vbNewLine)
            TextBox1.Clear()
        Catch ex As Exception
            MsgBox("Your FTP server is not correct.", MsgBoxStyle.Critical, "Error!")
        End Try
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            Dim client As New Net.WebClient
            client.Credentials = New Net.NetworkCredential(My.Settings.FTPUser, My.Settings.FTPPass)
            RichTextBox1.Text = client.DownloadString(My.Settings.FTPLink)
            If RichTextBox1.Text = RichTextBox1.Text Then

            Else : RichTextBox1.Text = RichTextBox1.Text
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub UserNameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserNameToolStripMenuItem.Click
        UserName.ShowDialog()
    End Sub

    Private Sub FTPConfigToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FTPConfigToolStripMenuItem.Click
        FTP_Settings.ShowDialog()
    End Sub
End Class
