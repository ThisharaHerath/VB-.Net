Imports MySql.Data.MySqlClient
Public Class Inventory
    Dim Connection As New MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=db_store")

    Private Sub Inventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim connection As New MySqlConnection("datasource=localhost;port=3306;username=root;password=")
        Dim Table As New DataTable()
        Dim adapter As New MySqlDataAdapter("SELECT * FROM db_store.store", connection)

        adapter.Fill(Table)
        DataGridView1.DataSource = Table
    End Sub

    Private Sub Addbtn_Click(sender As Object, e As EventArgs) Handles Addbtn.Click
        Dim command As New MySqlCommand("INSERT INTO `store` (`fruitid`, `fruitname`, `price`, `totalquantity`, `availablequantity`) VALUES (@fid,@name,@pri,@tqu,@aqu)", Connection)

        command.Parameters.Add("@fid", MySqlDbType.Int16).Value = TextBox1.Text
        command.Parameters.Add("@name", MySqlDbType.VarChar).Value = ComboBox1.Text
        command.Parameters.Add("@pri", MySqlDbType.Int64).Value = TextBox2.Text
        command.Parameters.Add("@tqu", MySqlDbType.Int64).Value = TextBox3.Text
        command.Parameters.Add("@aqu", MySqlDbType.Int64).Value = TextBox4.Text

        Connection.Open()

        If command.ExecuteNonQuery() = 1 Then
            MessageBox.Show("saved successfully")
        Else
            MessageBox.Show("Error")
        End If

        Connection.Close()
    End Sub

    Private Sub Updatebtn_Click(sender As Object, e As EventArgs) Handles Updatebtn.Click
        Dim command As New MySqlCommand("UPDATE `store` SET `fruitname`=@name, `price`=@price, `totalquantity`=@tqu, `availablequantity`=@aqu WHERE `fruitid`=@fid", Connection)

        command.Parameters.Add("@fid", MySqlDbType.Int16).Value = TextBox1.Text
        command.Parameters.Add("@name", MySqlDbType.VarChar).Value = ComboBox1.Text
        command.Parameters.Add("@price", MySqlDbType.Int64).Value = TextBox2.Text
        command.Parameters.Add("@tqu", MySqlDbType.Int64).Value = TextBox3.Text
        command.Parameters.Add("@aqu", MySqlDbType.Int64).Value = TextBox4.Text

        Connection.Open()

        If command.ExecuteNonQuery() = 1 Then
            MessageBox.Show("Update successfully")
        Else
            MessageBox.Show("Update not success")
        End If

        Connection.Close()
    End Sub

    Private Sub Deletebtn_Click(sender As Object, e As EventArgs) Handles Deletebtn.Click
        Dim command As New MySqlCommand("DELETE FROM `store` WHERE `fruitid`=@fid", Connection)

        command.Parameters.Add("@fid", MySqlDbType.Int16).Value = TextBox1.Text
        command.Parameters.Add("@name", MySqlDbType.VarChar).Value = ComboBox1.Text
        command.Parameters.Add("@price", MySqlDbType.Int64).Value = TextBox2.Text
        command.Parameters.Add("@tqu", MySqlDbType.Int64).Value = TextBox3.Text
        command.Parameters.Add("@aqu", MySqlDbType.Int64).Value = TextBox4.Text

        Connection.Open()

        If command.ExecuteNonQuery() = 1 Then
            MessageBox.Show("Delete successfully")
        Else
            MessageBox.Show("Not Deleted")
        End If

        Connection.Close()
    End Sub

    Private Sub Nextbtn_Click(sender As Object, e As EventArgs) Handles nextbtn.Click
        Store.Show()
    End Sub
End Class