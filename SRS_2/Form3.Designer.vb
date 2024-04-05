<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        textBoxName = New TextBox()
        buttonAddClient = New Button()
        textBoxAddress = New TextBox()
        textBoxPostalCod = New TextBox()
        TextBoxState = New TextBox()
        textBoxCit = New TextBox()
        Label1 = New Label()
        textBoxCity = New Label()
        Label3 = New Label()
        textBoxPostalCode = New Label()
        Label5 = New Label()
        Label2 = New Label()
        SuspendLayout()
        ' 
        ' textBoxName
        ' 
        textBoxName.Location = New Point(153, 52)
        textBoxName.Name = "textBoxName"
        textBoxName.Size = New Size(100, 23)
        textBoxName.TabIndex = 0
        ' 
        ' buttonAddClient
        ' 
        buttonAddClient.Location = New Point(178, 289)
        buttonAddClient.Name = "buttonAddClient"
        buttonAddClient.Size = New Size(75, 23)
        buttonAddClient.TabIndex = 1
        buttonAddClient.Text = "Добавить клиента"
        buttonAddClient.UseVisualStyleBackColor = True
        ' 
        ' textBoxAddress
        ' 
        textBoxAddress.Location = New Point(153, 205)
        textBoxAddress.Name = "textBoxAddress"
        textBoxAddress.Size = New Size(100, 23)
        textBoxAddress.TabIndex = 3
        ' 
        ' textBoxPostalCod
        ' 
        textBoxPostalCod.Location = New Point(153, 160)
        textBoxPostalCod.Name = "textBoxPostalCod"
        textBoxPostalCod.Size = New Size(100, 23)
        textBoxPostalCod.TabIndex = 4
        ' 
        ' TextBoxState
        ' 
        TextBoxState.Location = New Point(153, 119)
        TextBoxState.Name = "TextBoxState"
        TextBoxState.Size = New Size(100, 23)
        TextBoxState.TabIndex = 5
        ' 
        ' textBoxCit
        ' 
        textBoxCit.Location = New Point(153, 81)
        textBoxCit.Name = "textBoxCit"
        textBoxCit.Size = New Size(100, 23)
        textBoxCit.TabIndex = 6
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(48, 60)
        Label1.Name = "Label1"
        Label1.Size = New Size(37, 15)
        Label1.TabIndex = 7
        Label1.Text = "name"
        ' 
        ' textBoxCity
        ' 
        textBoxCity.AutoSize = True
        textBoxCity.Location = New Point(48, 89)
        textBoxCity.Name = "textBoxCity"
        textBoxCity.Size = New Size(26, 15)
        textBoxCity.TabIndex = 8
        textBoxCity.Text = "city"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(48, 127)
        Label3.Name = "Label3"
        Label3.Size = New Size(32, 15)
        Label3.TabIndex = 9
        Label3.Text = "state"
        ' 
        ' textBoxPostalCode
        ' 
        textBoxPostalCode.AutoSize = True
        textBoxPostalCode.Location = New Point(48, 168)
        textBoxPostalCode.Name = "textBoxPostalCode"
        textBoxPostalCode.Size = New Size(67, 15)
        textBoxPostalCode.TabIndex = 10
        textBoxPostalCode.Text = "PostalCode"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(48, 213)
        Label5.Name = "Label5"
        Label5.Size = New Size(47, 15)
        Label5.TabIndex = 11
        Label5.Text = "address"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(204))
        Label2.Location = New Point(35, 9)
        Label2.Name = "Label2"
        Label2.Size = New Size(243, 30)
        Label2.TabIndex = 12
        Label2.Text = "Добавить пользователя"
        ' 
        ' Form3
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(290, 334)
        Controls.Add(Label2)
        Controls.Add(Label5)
        Controls.Add(textBoxPostalCode)
        Controls.Add(Label3)
        Controls.Add(textBoxCity)
        Controls.Add(Label1)
        Controls.Add(textBoxCit)
        Controls.Add(TextBoxState)
        Controls.Add(textBoxPostalCod)
        Controls.Add(textBoxAddress)
        Controls.Add(buttonAddClient)
        Controls.Add(textBoxName)
        Name = "Form3"
        Text = "Form3"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents textBoxName As TextBox
    Friend WithEvents buttonAddClient As Button
    Friend WithEvents textBoxAddress As TextBox
    Friend WithEvents textBoxPostalCod As TextBox
    Friend WithEvents TextBoxState As TextBox
    Friend WithEvents textBoxCit As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents textBoxCity As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents textBoxPostalCode As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
End Class
