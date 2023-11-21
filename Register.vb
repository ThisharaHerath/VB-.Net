Imports MySql.Data.MySqlClient
Public Class Register
    Dim Connection As New MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=db_store")

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Cancelbtn_Click(sender As Object, e As EventArgs) Handles Cancelbtn.Click
        Dim response As Integer
        response = MessageBox.Show("Are you sure to cancel the application?", "Cancel application",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If response = vbYes Then
            Application.ExitThread()
        End If
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub Savebtn_Click(sender As Object, e As EventArgs) Handles Savebtn.Click
        Dim command As New MySqlCommand("INSERT INTO `register` (`userid`, `name`, `address`, `mobilenumber`) VALUES (@uid,@name,@add,@mob)", Connection)

        command.Parameters.Add("@uid", MySqlDbType.Int16).Value = TextBox1.Text
        command.Parameters.Add("@name", MySqlDbType.VarChar).Value = TextBox2.Text
        command.Parameters.Add("@add", MySqlDbType.VarChar).Value = TextBox3.Text
        command.Parameters.Add("@mob", MySqlDbType.VarChar).Value = TextBox4.Text

        Connection.Open()

        If command.ExecuteNonQuery() = 1 Then
            MessageBox.Show("saved successfully")
        Else
            MessageBox.Show("Error")
        End If

        Connection.Close()
    End Sub

    Private Sub Registerbtn_Click(sender As Object, e As EventArgs) Handles Registerbtn.Click
        Inventory.Show()
        Me.Hide()
    End Sub
End Class