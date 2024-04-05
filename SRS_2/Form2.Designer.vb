<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        buttonAddOrder = New Button()
        comboBoxClients = New ComboBox()
        buttonCalculateTotal = New Button()
        dataGridViewOrderItems = New DataGridView()
        TextBoxNumProduct = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        DataGridViewMenu = New DataGridView()
        Label4 = New Label()
        Label5 = New Label()
        TextBoxTotalPrice = New TextBox()
        ButtonDel = New Button()
        CType(dataGridViewOrderItems, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridViewMenu, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' buttonAddOrder
        ' 
        buttonAddOrder.Location = New Point(12, 566)
        buttonAddOrder.Name = "buttonAddOrder"
        buttonAddOrder.Size = New Size(121, 32)
        buttonAddOrder.TabIndex = 4
        buttonAddOrder.Text = "добавить продукт"
        buttonAddOrder.UseVisualStyleBackColor = True
        ' 
        ' comboBoxClients
        ' 
        comboBoxClients.FormattingEnabled = True
        comboBoxClients.Location = New Point(134, 13)
        comboBoxClients.Name = "comboBoxClients"
        comboBoxClients.Size = New Size(121, 23)
        comboBoxClients.TabIndex = 5
        ' 
        ' buttonCalculateTotal
        ' 
        buttonCalculateTotal.Location = New Point(515, 4)
        buttonCalculateTotal.Name = "buttonCalculateTotal"
        buttonCalculateTotal.Size = New Size(121, 32)
        buttonCalculateTotal.TabIndex = 7
        buttonCalculateTotal.Text = "Совершить заказ"
        buttonCalculateTotal.UseVisualStyleBackColor = True
        ' 
        ' dataGridViewOrderItems
        ' 
        dataGridViewOrderItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dataGridViewOrderItems.Location = New Point(515, 79)
        dataGridViewOrderItems.Name = "dataGridViewOrderItems"
        dataGridViewOrderItems.Size = New Size(341, 467)
        dataGridViewOrderItems.TabIndex = 8
        ' 
        ' TextBoxNumProduct
        ' 
        TextBoxNumProduct.Location = New Point(149, 572)
        TextBoxNumProduct.Name = "TextBoxNumProduct"
        TextBoxNumProduct.Size = New Size(38, 23)
        TextBoxNumProduct.TabIndex = 9
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 15)
        Label1.Name = "Label1"
        Label1.Size = New Size(116, 15)
        Label1.TabIndex = 10
        Label1.Text = "выбор пользоваеля"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(204))
        Label2.Location = New Point(610, 39)
        Label2.Name = "Label2"
        Label2.Size = New Size(123, 37)
        Label2.TabIndex = 11
        Label2.Text = "Корзина"
        ' 
        ' DataGridViewMenu
        ' 
        DataGridViewMenu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewMenu.Location = New Point(12, 79)
        DataGridViewMenu.Name = "DataGridViewMenu"
        DataGridViewMenu.Size = New Size(430, 467)
        DataGridViewMenu.TabIndex = 13
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(204))
        Label4.Location = New Point(193, 580)
        Label4.Name = "Label4"
        Label4.Size = New Size(26, 15)
        Label4.TabIndex = 14
        Label4.Text = "шт."
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(204))
        Label5.Location = New Point(167, 39)
        Label5.Name = "Label5"
        Label5.Size = New Size(88, 37)
        Label5.TabIndex = 15
        Label5.Text = "меню"
        ' 
        ' TextBoxTotalPrice
        ' 
        TextBoxTotalPrice.Location = New Point(651, 10)
        TextBoxTotalPrice.Name = "TextBoxTotalPrice"
        TextBoxTotalPrice.Size = New Size(154, 23)
        TextBoxTotalPrice.TabIndex = 16
        ' 
        ' ButtonDel
        ' 
        ButtonDel.Location = New Point(526, 572)
        ButtonDel.Name = "ButtonDel"
        ButtonDel.Size = New Size(121, 32)
        ButtonDel.TabIndex = 18
        ButtonDel.Text = "удалить продукт"
        ButtonDel.UseVisualStyleBackColor = True
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(872, 643)
        Controls.Add(ButtonDel)
        Controls.Add(TextBoxTotalPrice)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(DataGridViewMenu)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(TextBoxNumProduct)
        Controls.Add(dataGridViewOrderItems)
        Controls.Add(buttonCalculateTotal)
        Controls.Add(comboBoxClients)
        Controls.Add(buttonAddOrder)
        Name = "Form2"
        Text = "Form2"
        CType(dataGridViewOrderItems, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridViewMenu, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents buttonAddOrder As Button
    Friend WithEvents comboBoxClients As ComboBox
    Friend WithEvents buttonCalculateTotal As Button
    Friend WithEvents dataGridViewOrderItems As DataGridView
    Friend WithEvents TextBoxNumProduct As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents DataGridViewMenu As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBoxTotalPrice As TextBox
    Friend WithEvents ButtonDel As Button
End Class
