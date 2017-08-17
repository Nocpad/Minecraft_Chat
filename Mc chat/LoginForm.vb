Public Class LoginForm

    Private hideForm As Boolean
    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If My.Settings.rememberMe = True Then
            CheckBox1.CheckState = CheckState.Checked
            hideForm = True
        End If

        If My.Settings.User <> Nothing Then usernameProperty = My.Settings.User
        TextBox1.Text = My.Settings.User

        If My.Settings.pass <> Nothing Then PassProperty = My.Settings.pass
        TextBox2.Text = My.Settings.pass


    End Sub

    Public Property usernameProperty As String
    Public Property PassProperty() As String


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text <> Nothing And TextBox2.Text <> Nothing Then
            PassProperty = TextBox2.Text
            usernameProperty = TextBox1.Text

            If CheckBox1.Checked Then
                My.Settings.User = TextBox1.Text
                My.Settings.pass = TextBox2.Text
            End If

            Me.Hide()
            Form1.Show()

            My.Settings.Save()
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            My.Settings.rememberMe = True
        Else
            My.Settings.rememberMe = False
        End If
    End Sub

    Private Sub LoginForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If hideForm = True Then
            Form1.Show()
            Me.Hide()
        End If

    End Sub
End Class