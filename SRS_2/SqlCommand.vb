Friend Class SqlCommand
    Private sqlQuery As String
    Private connection As SqlConnection

    Public Sub New(sqlQuery As String, connection As SqlConnection)
        Me.sqlQuery = sqlQuery
        Me.connection = connection
    End Sub

    Friend Sub ExecuteNonQuery()
        Throw New NotImplementedException()
    End Sub

    Friend Function Parameters() As Object
        Throw New NotImplementedException()
    End Function

    Friend Function ExecuteScalar() As Boolean
        Throw New NotImplementedException()
    End Function
End Class
