Imports MySql.Data.MySqlClient
Imports System.Windows.Forms.VisualStyles

Public Class Form3
    Dim connectionString As String = "Server=192.168.43.50;User id=adil;password=Adil55555;database=test_db"

    Private Sub buttonAddClient_Click(sender As Object, e As EventArgs) Handles buttonAddClient.Click
        Dim name As String = textBoxName.Text.Trim()
        Dim city As String = textBoxCit.Text.Trim()
        Dim state As String = TextBoxState.Text.Trim()
        Dim postalCode As String = textBoxPostalCod.Text.Trim()
        Dim address As String = textBoxAddress.Text.Trim()

        If String.IsNullOrEmpty(name) OrElse String.IsNullOrEmpty(city) OrElse String.IsNullOrEmpty(state) OrElse String.IsNullOrEmpty(postalCode) OrElse String.IsNullOrEmpty(address) Then
            MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If IsNameExists(name) Then
            MessageBox.Show("Клиент с таким именем уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        AddClientToDatabase(name, city, state, postalCode, address)
    End Sub

    Private Function IsNameExists(name As String) As Boolean
        Dim connection As New MySqlConnection(connectionString)
        connection.Open()
        Dim sqlQuery As String = "SELECT COUNT(*) FROM client WHERE name = @name"
        Dim cmd As New MySqlCommand(sqlQuery, connection)
        cmd.Parameters.AddWithValue("@name", name)
        Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
        connection.Close()
        Return count > 0
    End Function

    Private Sub AddClientToDatabase(name As String, city As String, state As String, postalCode As String, address As String)
        Dim connection As New MySqlConnection(connectionString)
        connection.Open()
        Dim sqlQuery As String = "INSERT INTO client (name, city, state, postal_code, address) VALUES (@name, @city, @state, @postalCode, @address)"
        Dim cmd As New MySqlCommand(sqlQuery, connection)
        cmd.Parameters.AddWithValue("@name", name)
        cmd.Parameters.AddWithValue("@city", city)
        cmd.Parameters.AddWithValue("@state", state)
        cmd.Parameters.AddWithValue("@postalCode", postalCode)
        cmd.Parameters.AddWithValue("@address", address)
        cmd.ExecuteNonQuery()
        connection.Close()
        MessageBox.Show("Клиент успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ClearTextBoxes()
    End Sub

    Private Sub ClearTextBoxes()
        textBoxName.Clear()
        textBoxCit.Clear()
        TextBoxState.Clear()
        textBoxPostalCod.Clear()
        textBoxAddress.Clear()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class
