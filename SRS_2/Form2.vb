Imports MySql.Data.MySqlClient
Imports Mysqlx.Crud

Public Class Form2
    Dim connString As String = "Server=192.168.43.50;User id=adil;password=Adil55555;database=test_db"
    Dim connection As New MySqlConnection(connString)

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProductMenu()
        LoadClients()

    End Sub

    Private Sub LoadClients()
        Dim sqlQuery As String = "SELECT client_id, name FROM client"
        Dim cmd As New MySqlCommand(sqlQuery, connection)
        Dim da As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable()

        da.Fill(dt)

        comboBoxClients.DataSource = dt
        comboBoxClients.DisplayMember = "name"
        comboBoxClients.ValueMember = "client_id"
    End Sub



    Private Sub buttonAddOrder_Click(sender As Object, e As EventArgs) Handles buttonAddOrder.Click
        Dim selectedClientId As Integer = Convert.ToInt32(comboBoxClients.SelectedValue)

        ' Проверка наличия незавершенного заказа для выбранного клиента
        Dim orderId As Integer = GetPendingOrderForClient(selectedClientId)

        ' Если нет незавершенного заказа, создаем новый
        If orderId = -1 Then
            connection.Open()

            Dim sqlQuery As String = "INSERT INTO orders (client_id, status, num_product) VALUES (@clientId, @status, @num_product)"
            Dim cmd As New MySqlCommand(sqlQuery, connection)
            cmd.Parameters.AddWithValue("@clientId", selectedClientId)
            cmd.Parameters.AddWithValue("@status", False) ' Установка статуса заказа как незавершенного
            cmd.Parameters.AddWithValue("@num_product", 0) ' Установка начального значения для num_product
            cmd.ExecuteNonQuery()

            ' Получаем идентификатор последнего вставленного заказа
            orderId = Convert.ToInt32(cmd.LastInsertedId)

            connection.Close()
        End If

        ' Добавление продуктов в заказ
        ' Добавление продуктов в заказ
        For Each row As DataGridViewRow In DataGridViewMenu.SelectedRows
            Dim productId As Integer = Convert.ToInt32(row.Cells("product_id").Value)
            Dim productName As String = row.Cells("name").Value.ToString()

            ' Получаем количество товара, которое хочет заказать клиент
            Dim requestedQuantity As Integer

            ' Проверка на пустое значение или ноль
            If String.IsNullOrEmpty(TextBoxNumProduct.Text) OrElse TextBoxNumProduct.Text.Trim() = "0" Then
                MessageBox.Show("Пожалуйста, введите корректное количество товара.")
                Exit Sub
            End If

            ' Преобразование текста в целое число
            If Not Integer.TryParse(TextBoxNumProduct.Text, requestedQuantity) Then
                MessageBox.Show("Пожалуйста, введите корректное количество товара.")
                Exit Sub
            End If

            ' Проверяем наличие товара на складе
            Dim availableQuantity As Integer = CheckProductAvailability(productId)

            If availableQuantity < requestedQuantity Then
                MessageBox.Show($"Недостаточное количество товара {productName}! В наличии только {availableQuantity} шт.")
                Exit Sub ' Прерываем выполнение метода, так как товара недостаточно
            End If

            ' Уменьшаем количество товара на складе
            UpdateProductQuantity(productId, availableQuantity - requestedQuantity)
            LoadProductMenu()

            ' Добавляем продукт в заказ
            AddProductToOrder(orderId, productId, requestedQuantity)
        Next


        MessageBox.Show("Заказ добавлен успешно!")

        IncrementNumProductForOrder(orderId)
        GetNumProductForOrder(orderId)
        ' После добавления заказа обновляем отображение предметов заказа
        LoadOrderItems(orderId)

    End Sub

    Private Sub IncrementNumProductForOrder(orderId As Integer)
        connection.Open()

        Dim sqlQuery As String = "UPDATE orders SET num_product = num_product + 1 WHERE order_id = @orderId"
        Dim cmd As New MySqlCommand(sqlQuery, connection)
        cmd.Parameters.AddWithValue("@orderId", orderId)
        cmd.ExecuteNonQuery()

        connection.Close()
    End Sub

    Private Function GetNumProductForOrder(orderId As Integer) As Integer
        Dim numProduct As Integer = -1

        connection.Open()

        Dim sqlQuery As String = "SELECT num_product FROM orders WHERE order_id = @orderId"
        Dim cmd As New MySqlCommand(sqlQuery, connection)
        cmd.Parameters.AddWithValue("@orderId", orderId)

        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        If reader.Read() Then
            numProduct = Convert.ToInt32(reader("num_product"))
        End If

        connection.Close()

        Return numProduct
    End Function




    Private Function GetQuantity(productName As String) As Integer
        ' Здесь можно реализовать логику получения количества товара из интерфейса
        ' Например, через текстовые поля или другие элементы управления
        ' В данном примере просто возвращаем 1
        Return 1
    End Function

    Private Sub buttonCalculateTotal_Click(sender As Object, e As EventArgs) Handles buttonCalculateTotal.Click
        Dim selectedClientId As Integer = Convert.ToInt32(comboBoxClients.SelectedValue)

        ' Проверка наличия незавершенного заказа для выбранного клиента
        Dim orderId As Integer = GetPendingOrderForClient(selectedClientId)

        If orderId <> -1 Then
            ' Если есть незавершенный заказ, обновляем его статус на "завершенный" (status = TRUE)
            UpdateOrderStatus(orderId, True)

            ' Вычисляем общую сумму заказа
            Dim total As Decimal = CalculateTotalOrderPrice(orderId)

            ' Выводим общую сумму заказа в TextBoxTotalPrice
            TextBoxTotalPrice.Text = total.ToString("C")

            MessageBox.Show("Заказ успешно совершен!")

            UpdateTotalPrice(orderId, total)
            dataGridViewOrderItems.DataSource = Nothing

        Else
            MessageBox.Show("Для выбранного клиента нет незавершенных заказов.")
        End If
    End Sub

    Private Sub UpdateTotalPrice(orderId As Integer, newTotalPrice As Decimal)
        Try
            Using connection As New MySqlConnection(connString)
                connection.Open()
                Dim sqlQuery As String = "UPDATE orders SET total_price = @newTotalPrice WHERE order_id = @orderId"
                Dim cmd As New MySqlCommand(sqlQuery, connection)
                cmd.Parameters.AddWithValue("@newTotalPrice", newTotalPrice)
                cmd.Parameters.AddWithValue("@orderId", orderId)
                cmd.ExecuteNonQuery()
            End Using
            MessageBox.Show("Значение total_price успешно обновлено.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Ошибка при обновлении total_price: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub textBoxQuantity_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub



    Private Sub LoadOrderItems(orderId As Integer)
        connection.Open()

        Dim sqlQuery As String = "SELECT p.product_id AS ProductID, p.name AS Product, op.quantity AS Quantity FROM order_product op JOIN product p ON op.product_id = p.product_id WHERE op.order_id = @orderId"
        Dim cmd As New MySqlCommand(sqlQuery, connection)
        cmd.Parameters.AddWithValue("@orderId", orderId)

        Dim da As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable()
        da.Fill(dt)

        dataGridViewOrderItems.DataSource = dt

        connection.Close()
    End Sub


    Private Function GetPendingOrderForClient(clientId As Integer) As Integer
        Dim orderId As Integer = -1

        connection.Open()

        Dim sqlQuery As String = "SELECT order_id FROM orders WHERE client_id = @clientId AND status = FALSE"
        Dim cmd As New MySqlCommand(sqlQuery, connection)
        cmd.Parameters.AddWithValue("@clientId", clientId)

        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        If reader.Read() Then
            orderId = Convert.ToInt32(reader("order_id"))
        End If

        connection.Close()

        Return orderId
    End Function

    Private Function CheckProductAvailability(productId As Integer) As Integer
        Dim availableQuantity As Integer = 0

        connection.Open()

        Dim sqlQuery As String = "SELECT quantity FROM product WHERE product_id = @productId"
        Dim cmd As New MySqlCommand(sqlQuery, connection)
        cmd.Parameters.AddWithValue("@productId", productId)

        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        If reader.Read() Then
            availableQuantity = Convert.ToInt32(reader("quantity"))
        End If

        connection.Close()

        Return availableQuantity
    End Function

    Private Sub UpdateProductQuantity(productId As Integer, newQuantity As Integer)
        connection.Open()

        Dim sqlQuery As String = "UPDATE product SET quantity = @newQuantity WHERE product_id = @productId"
        Dim cmd As New MySqlCommand(sqlQuery, connection)
        cmd.Parameters.AddWithValue("@newQuantity", newQuantity)
        cmd.Parameters.AddWithValue("@productId", productId)

        cmd.ExecuteNonQuery()

        connection.Close()
    End Sub

    Private Sub AddProductToOrder(orderId As Integer, productId As Integer, quantity As Integer)
        connection.Open()

        ' Проверяем, существует ли уже запись для данного заказа и продукта
        Dim sqlCheckQuery As String = "SELECT * FROM order_product WHERE order_id = @orderId AND product_id = @productId"
        Dim cmdCheck As New MySqlCommand(sqlCheckQuery, connection)
        cmdCheck.Parameters.AddWithValue("@orderId", orderId)
        cmdCheck.Parameters.AddWithValue("@productId", productId)

        Dim existingRecord As Object = cmdCheck.ExecuteScalar()

        If existingRecord IsNot Nothing Then
            ' Если запись уже существует, обновляем значение quantity
            Dim sqlUpdateQuery As String = "UPDATE order_product SET quantity = quantity + @quantity WHERE order_id = @orderId AND product_id = @productId"
            Dim cmdUpdate As New MySqlCommand(sqlUpdateQuery, connection)
            cmdUpdate.Parameters.AddWithValue("@orderId", orderId)
            cmdUpdate.Parameters.AddWithValue("@productId", productId)
            cmdUpdate.Parameters.AddWithValue("@quantity", quantity)

            cmdUpdate.ExecuteNonQuery()
        Else
            ' Если запись не существует, вставляем новую запись
            Dim sqlInsertQuery As String = "INSERT INTO order_product (order_id, product_id, quantity) VALUES (@orderId, @productId, @quantity)"
            Dim cmdInsert As New MySqlCommand(sqlInsertQuery, connection)
            cmdInsert.Parameters.AddWithValue("@orderId", orderId)
            cmdInsert.Parameters.AddWithValue("@productId", productId)
            cmdInsert.Parameters.AddWithValue("@quantity", quantity)

            cmdInsert.ExecuteNonQuery()
        End If

        connection.Close()
    End Sub


    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub LoadProductMenu()
        Try
            connection.Open()

            Dim sqlQuery As String = "SELECT * FROM product"
            Dim cmd As New MySqlCommand(sqlQuery, connection)
            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()

            da.Fill(dt)

            DataGridViewMenu.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Ошибка при загрузке данных из таблицы product: " & ex.Message)
        Finally
            connection.Close()
        End Try
    End Sub

    Private Sub comboBoxClients_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboBoxClients.SelectedIndexChanged
        If comboBoxClients.SelectedItem IsNot Nothing Then
            Dim selectedClientId As Integer
            If Integer.TryParse(comboBoxClients.SelectedValue.ToString(), selectedClientId) Then
                Dim pendingOrderId As Integer = GetPendingOrderForClient(selectedClientId)

                If pendingOrderId <> -1 Then
                    MessageBox.Show("Найден незавершенный заказ с номером: " & pendingOrderId.ToString())
                    LoadOrderItems(pendingOrderId)
                Else
                    MessageBox.Show("Для выбранного клиента нет незавершенных заказов.")
                End If
            End If
        Else
            MessageBox.Show("Не выбран клиент.")
        End If
    End Sub

    Private Sub UpdateOrderStatus(orderId As Integer, status As Boolean)
        connection.Open()

        Dim sqlQuery As String = "UPDATE orders SET status = @status WHERE order_id = @orderId"
        Dim cmd As New MySqlCommand(sqlQuery, connection)
        cmd.Parameters.AddWithValue("@status", status)
        cmd.Parameters.AddWithValue("@orderId", orderId)

        cmd.ExecuteNonQuery()

        connection.Close()
    End Sub

    Private Function CalculateTotalOrderPrice(orderId As Integer) As Decimal
        Dim total As Decimal = 0

        connection.Open()

        Dim sqlQuery As String = "SELECT p.price * op.quantity AS total_price FROM order_product op INNER JOIN product p ON op.product_id = p.product_id WHERE op.order_id = @orderId"
        Dim cmd As New MySqlCommand(sqlQuery, connection)
        cmd.Parameters.AddWithValue("@orderId", orderId)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        While reader.Read()
            total += Convert.ToDecimal(reader("total_price"))
        End While

        connection.Close()

        Return total
    End Function




    Private Sub ButtonDel_Click(sender As Object, e As EventArgs) Handles ButtonDel.Click
        ' Проверка наличия незавершенного заказа для выбранного клиента
        Dim selectedClientId As Integer = Convert.ToInt32(comboBoxClients.SelectedValue)
        Dim pendingOrderId As Integer = GetPendingOrderForClient(selectedClientId)

        If pendingOrderId <> -1 Then
            ' Получение выбранного продукта для удаления
            Dim selectedProductId As Integer = GetSelectedProductIdFromOrderItems()

            If selectedProductId <> -1 Then
                ' Удаление выбранного продукта из заказа
                DeleteProductFromOrder(pendingOrderId, selectedProductId)
                MessageBox.Show("Продукт успешно удален из заказа.")
                LoadProductMenu()
            Else
                MessageBox.Show("Выберите продукт для удаления.")
            End If
        Else
            MessageBox.Show("Для выбранного клиента нет незавершенных заказов.")
        End If
    End Sub

    Private Function GetSelectedProductIdFromOrderItems() As Integer
        If dataGridViewOrderItems.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = dataGridViewOrderItems.SelectedRows(0)
            Dim productId As Integer
            If Integer.TryParse(selectedRow.Cells("ProductID").Value.ToString(), productId) Then
                MessageBox.Show(productId)
                Return productId
            End If
        End If
        Return -1
    End Function



    Private Sub DeleteProductFromOrder(orderId As Integer, productId As Integer)
        connection.Open()

        ' Получаем количество товара, которое нужно вернуть на склад
        Dim returnedQuantity As Integer = GetReturnedQuantity(orderId, productId)

        ' Уменьшаем num_product в таблице orders
        Dim sqlUpdateOrder As String = "UPDATE orders SET num_product = num_product - 1 WHERE order_id = @orderId"
        Dim cmdUpdateOrder As New MySqlCommand(sqlUpdateOrder, connection)
        cmdUpdateOrder.Parameters.AddWithValue("@orderId", orderId)
        cmdUpdateOrder.ExecuteNonQuery()

        ' Увеличиваем количество товара на складе в таблице product
        Dim sqlUpdateProduct As String = "UPDATE product SET quantity = quantity + @returnedQuantity WHERE product_id = @productId"
        Dim cmdUpdateProduct As New MySqlCommand(sqlUpdateProduct, connection)
        cmdUpdateProduct.Parameters.AddWithValue("@returnedQuantity", returnedQuantity)
        cmdUpdateProduct.Parameters.AddWithValue("@productId", productId)
        cmdUpdateProduct.ExecuteNonQuery()

        ' Удаляем товар из таблицы order_product
        Dim sqlDeleteOrderProduct As String = "DELETE FROM order_product WHERE order_id = @orderId AND product_id = @productId"
        Dim cmdDeleteOrderProduct As New MySqlCommand(sqlDeleteOrderProduct, connection)
        cmdDeleteOrderProduct.Parameters.AddWithValue("@orderId", orderId)
        cmdDeleteOrderProduct.Parameters.AddWithValue("@productId", productId)
        cmdDeleteOrderProduct.ExecuteNonQuery()

        connection.Close()

        LoadOrderItems(orderId)
        IncrementNumProductForOrder(orderId)

    End Sub

    Private Function GetReturnedQuantity(orderId As Integer, productId As Integer) As Integer
        Dim returnedQuantity As Integer = 0

        Dim sqlQuery As String = "SELECT quantity FROM order_product WHERE order_id = @orderId AND product_id = @productId"
        Dim cmd As New MySqlCommand(sqlQuery, connection)
        cmd.Parameters.AddWithValue("@orderId", orderId)
        cmd.Parameters.AddWithValue("@productId", productId)

        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        If reader.Read() Then
            returnedQuantity = Convert.ToInt32(reader("quantity"))
        End If

        reader.Close()

        Return returnedQuantity
    End Function


    Private Function GetSelectedProductIdFromDataGridViewMenu() As Integer
        If DataGridViewMenu.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = DataGridViewMenu.SelectedRows(0)
            Dim productId As Integer
            If Integer.TryParse(selectedRow.Cells("ProductID").Value.ToString(), productId) Then
                Return productId
            End If
        End If
        Return -1
    End Function

    Private Sub DataGridViewMenu_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewMenu.CellContentClick

    End Sub
End Class
