Imports System.IO
Imports System.Net
Imports System.Text
Public Class FTP_Settings
    Private Sub FTP_Settings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button2.Select()
        If My.Settings.FTPLink = "" Or TextBox1.Text = "Example: http://yourhost.com/chat.txt" Then
            TextBox1.ForeColor = Color.Silver
            TextBox1.Text = "Example: http://yourhost.com/chat.txt"
        Else
            TextBox1.Text = My.Settings.FTPLink
        End If
        TextBox2.Text = My.Settings.FTPUser
        TextBox3.Text = My.Settings.FTPPass
        CheckBox1.Checked = False
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TextBox3.PasswordChar = ""
        Else
            TextBox3.PasswordChar = "*"
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Check if your FTP is correct or no
        Try
            Dim request As FtpWebRequest = DirectCast(FtpWebRequest.Create(TextBox1.Text), FtpWebRequest)
            request.KeepAlive = False
            request.Credentials = New NetworkCredential(TextBox2.Text, TextBox3.Text)
            request.Method = WebRequestMethods.Ftp.GetFileSize
            Dim response As WebResponse = request.GetResponse
            Using stream As Stream = response.GetResponseStream
                Using readStream As New StreamReader(stream)
                    MsgBox("FTP is correct", MsgBoxStyle.Information, "INFO:")
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox1.Text = "Example: http://yourhost.com/chat.txt" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MsgBox("Please, fill in the empty boxes.", MsgBoxStyle.Critical, "Error:")
        Else
            My.Settings.FTPLink = TextBox1.Text
            My.Settings.FTPUser = TextBox2.Text
            My.Settings.FTPPass = TextBox3.Text
            MsgBox("FTP was saved successfully", MsgBoxStyle.Information, "INFO:")
            Me.Close()
        End If
    End Sub

    Private Sub TextBox1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox1.MouseClick
        If TextBox1.Text = "Example: http://yourhost.com/chat.txt" Then
            TextBox1.Clear()
            TextBox1.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class