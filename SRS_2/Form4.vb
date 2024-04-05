Imports MySql.Data.MySqlClient

Public Class Form4
    Dim connectionString As String = "Server=192.168.43.50;User id=adil;password=Adil55555;database=test_db"

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadOrdersWithStatusTrue()
        LoadOrdersWithStatusFalse()
    End Sub

    Private Sub LoadOrdersWithStatusTrue()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim sqlQuery As String = "SELECT * FROM orders WHERE status = true"
                Dim cmd As New MySqlCommand(sqlQuery, connection)
                Dim da As New MySqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)
                DataGridView1.DataSource = dt
            End Using
        Catch ex As Exception
            MessageBox.Show($"Ошибка при загрузке заказов со статусом true: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadOrdersWithStatusFalse()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim sqlQuery As String = "SELECT * FROM orders WHERE status = false"
                Dim cmd As New MySqlCommand(sqlQuery, connection)
                Dim da As New MySqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)
                DataGridView2.DataSource = dt
            End Using
        Catch ex As Exception
            MessageBox.Show($"Ошибка при загрузке заказов со статусом false: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class
