Namespace ByteBank
    Public Class Cliente

        Public Sub New(Name As String, Cpf As String)
            Name = Name
            Cpf = Cpf
            m_NumeroCliente += 1
        End Sub

        Private Shared m_NumeroCliente As Integer
        Public Shared ReadOnly Property NumeroClientes As Integer
            Get
                Return m_NumeroCliente
            End Get
        End Property

        Public Property Name As String
        Public Property Cpf As Long
        Public Property Profissao As String
        Public Property City As String

    End Class
End Namespace


