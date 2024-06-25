Imports _2___OrientecaoObjetos.ByteBank

Public Class ContaCorrente

    Public Sub New(m_Saldo As Double)
        Saldo = m_Saldo
    End Sub

#Region "PROPRIEDADE"
    Private m_Extrato As String = ""
    Public Property Extrato As String
        Get
            Return m_Extrato
        End Get
        Set(value As String)
            m_Extrato = value
        End Set
    End Property

    Private m_Conta As Integer
    Public Property Conta As Integer
        Get
            Return m_Conta
        End Get
        Set(value As Integer)
            m_Conta = value
        End Set
    End Property

    Private m_Agencia As Integer
    Public Property Agencia As Integer
        Get
            Return m_Agencia
        End Get
        Set(value As Integer)
            m_Agencia = value
        End Set
    End Property

    Private m_Titular As ByteBank.Cliente
    Public Property Titular As ByteBank.Cliente
        Get
            Return m_Titular
        End Get
        Set(value As ByteBank.Cliente)
            m_Titular = value
        End Set
    End Property

    Private m_Saldo As Double = 100
    Public Property Saldo As Double
        Get
            Return m_Saldo
        End Get
        Set(value As Double)
            If value < 0 Then
                m_Saldo = 0
            Else
                m_Saldo = value
            End If
        End Set
    End Property
#End Region

#Region "METODOS"
    Public Function Sacar(ValorSaque As Double) As Boolean

        If Saldo < ValorSaque Then
            Return False
        Else
            Saldo -= ValorSaque
            Return True
        End If

    End Function

    Public Function Transferir(ValorTrasferir As Double, ByRef ContaTransferir As ContaCorrente) As Boolean

        If Saldo < ValorTrasferir Then
            Return False
        Else
            Saldo -= ValorTrasferir
            ContaTransferir.Depositar(ValorTrasferir)
            Return True
        End If

    End Function

    Public Function Depositar(ValorDeposito)
        If ValorDeposito > 0 Then
            Saldo += ValorDeposito
        End If
        Return Saldo
    End Function
#End Region
End Class


