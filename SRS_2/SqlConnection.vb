Friend Class SqlConnection
    Private connectionString As String
    Private connection As System.Data.SqlClient.SqlConnection

    Public Sub New(connectionString As String)
        Me.connectionString = connectionString
        Me.connection = New System.Data.SqlClient.SqlConnection(connectionString)
    End Sub

    Friend Sub Open()
        If connection.State <> ConnectionState.Open Then
            connection.Open()
        End If
    End Sub

    Friend Sub Close()
        If connection.State <> ConnectionState.Closed Then
            connection.Close()
        End If
    End Sub
End Class
