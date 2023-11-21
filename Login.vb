Imports MySql.Data.MySqlClient
Public Class Login
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim db As New Class1()
        Dim adapter As New MySqlDataAdapter()
        Dim table As New DataTable()
        Dim command As New MySqlCommand("SELECT * FROM `db_store` WHERE `Username` = admin AND `Password' = admin@12", db.getconnection)


        command.Parameters.Add("admin", MySqlDbType.VarChar).Value = TextBox1.Text
        command.Parameters.Add("admin@12", MySqlDbType.VarChar).Value = TextBox2.Text

        Dim Username As String
        Dim Password As String
        Username = TextBox1.Text
        Password = TextBox2.Text
        If (Username.Equals("admin") And Password.Equals("admin@12")) Then
            Label3.Visible = False
            Inventory.Show()
        Else
            Label3.Visible = True
            TextBox2.Clear()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Cancelbtn.Click
        Dim response As Integer
        response = MessageBox.Show("Are you sure to cancel the application?", "Cancel application",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If response = vbYes Then
            Application.ExitThread()
        End If
    End Sub

    Private Class Class1
        Public Sub New()
        End Sub

        Public Property getconnection As MySqlConnection
    End Class
End Class