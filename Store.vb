Imports MySql.Data.MySqlClient
Public Class Store
    Dim Connection As New MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=db_store")
    Private Sub Store_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim connection As New MySqlConnection("datasource=localhost;port=3306;username=root;password=")
        Dim Table As New DataTable()
        Dim adapter As New MySqlDataAdapter("SELECT * FROM db_store.store", connection)

        adapter.Fill(Table)
        DataGridView1.DataSource = Table
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Calculatebtn_Click(sender As Object, e As EventArgs) Handles Calculatebtn.Click
        Dim A, B, C As Double
        A = TextBox2.Text
        B = TextBox3.Text
        TextBox4.Text = (A - B)
        C = TextBox4.Text
    End Sub

    Private Sub Clearbtn_Click(sender As Object, e As EventArgs) Handles Clearbtn.Click
        TextBox1.Text = ""
        ComboBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Updatebtn_Click(sender As Object, e As EventArgs) Handles Updatebtn.Click
        Dim command As New MySqlCommand("UPDATE `store` SET `soldquantity`=@squ WHERE `fruitid`=@fid", Connection)

        command.Parameters.Add("@fid", MySqlDbType.Int16).Value = TextBox1.Text
        command.Parameters.Add("@name", MySqlDbType.VarChar).Value = ComboBox1.Text
        command.Parameters.Add("@tqu", MySqlDbType.Int64).Value = TextBox2.Text
        command.Parameters.Add("@aqu", MySqlDbType.Int64).Value = TextBox3.Text
        command.Parameters.Add("@squ", MySqlDbType.Int64).Value = TextBox4.Text

        Connection.Open()

        If command.ExecuteNonQuery() = 1 Then
            MessageBox.Show("saved successfully")
        Else
            MessageBox.Show("Error")
        End If

        Connection.Close()
    End Sub

    Private Sub Exitbtn_Click(sender As Object, e As EventArgs) Handles Exitbtn.Click
        Dim response As Integer
        response = MessageBox.Show("Are you sure to exit the application?", "Cancel application",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If response = vbYes Then
            Application.ExitThread()
        End If
    End Sub
End Class