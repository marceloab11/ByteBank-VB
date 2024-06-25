Imports _2___OrientecaoObjetos.ByteBank

Public Class Form1
    Dim ContaGabriela As New ContaCorrente("300")
    Dim ContaBruno As New ContaCorrente("700")
    Dim gabriela As New Cliente("Gabriela", "219738397333")
    Dim bruno As New Cliente("Bruno", "21973839734")
    Public Sub New()

        ' Esta chamada é requerida pelo designer.
        InitializeComponent()
        Lbl_numero_clientes.Text = Cliente.NumeroClientes

        ' Adicione qualquer inicialização após a chamada InitializeComponent().

        ' Inicialização dos Textos da gabriela

        Me.Text = "Primeira classe - Formulario 02"
        Grp_gabriela.Text = "Gabriela"
        Lbl_titulo.Text = "Primeira classe 02"
        Lbl_saldo_gabriela.Text = "Saldo atual"
        Lbl_valor_gabriela.Text = "Valor Deposito/saque"
        Btn_sacar_gabriela.Text = "Sacar"
        Lbl_novoSaldo_gabriela.Text = "Novo saldo"
        Lbl_resultado_gabriela.Text = "Resultado"
        Btn_depositar_gabriela.Text = "Depositar"
        Lbl_extrato_gabriela.Text = "Extrato"
        Txt_saldo_gabriela.ReadOnly = True
        Txt_novoSaldo_gabriela.ReadOnly = True
        Txt_resultado_gabriela.ReadOnly = True
        Txt_extrato_gabriela.ReadOnly = True
        Btn_transferir_gabriela.Text = "Transferir"
        Lbl_name_trocar_gabriela.Text = "Name a ser trocado"
        Btn_name_trocar_gabriela.Text = "..."

        ' Inicialização dados gabriela
        gabriela.Profissao = "Desenvolvedora de software"
        gabriela.City = "Rio de Janeiro"

        ContaGabriela.Titular = gabriela
        ContaGabriela.Agencia = "1611"
        ContaGabriela.Conta = "1116"
        Lbl_bem_vindo_gabriela.Text = "Bem vindo " + ContaGabriela.Titular.Name + " Agência " + ContaGabriela.Agencia.ToString + " Conta " + ContaGabriela.Conta.ToString
        Txt_saldo_gabriela.Text = ContaGabriela.Saldo.ToString

        ' Inicialização dos Textos do Bruno
        Me.Text = "Primeira classe - Formulario 022"
        Grp_bruno.Text = "Bruno"
        Lbl_titulo.Text = "Primeiraa classe 02"
        Lbl_saldo_bruno.Text = "Saldo atual"
        Lbl_valor_bruno.Text = "Valor Deposito/saque"
        Btn_sacar_bruno.Text = "Sacar"
        Lbl_novoSaldo_bruno.Text = "Novo saldo"
        Lbl_resultado_bruno.Text = "Resultado"
        Btn_depositar_bruno.Text = "Depositar"
        Lbl_extrato_bruno.Text = "Extrato"
        Txt_saldo_bruno.ReadOnly = True
        Txt_novoSaldo_bruno.ReadOnly = True
        Txt_resultado_bruno.ReadOnly = True
        Txt_extrato_bruno.ReadOnly = True
        Btn_transferir_bruno.Text = "Transferir"
        Lbl_name_troca_bruno.Text = "Name a ser trocado"
        Btn_name_troca_bruno.Text = "..."

        ' Inicialização dados bruno
        bruno.Profissao = "Suporte TI"
        bruno.City = "Magé"

        ContaBruno.Titular = bruno
        ContaBruno.Agencia = "1611"
        ContaBruno.Conta = "1116"
        Lbl_bem_vindo_Bruno.Text = "Bem vindo " + ContaBruno.Titular.Name + " Agência " + ContaBruno.Agencia.ToString + " Conta " + ContaBruno.Conta.ToString
        Txt_saldo_bruno.Text = ContaBruno.Saldo.ToString
    End Sub

    Private Sub Btn_sacar_gabriela_Click(sender As Object, e As EventArgs) Handles Btn_sacar_gabriela.Click
        Txt_novoSaldo_gabriela.Text = ""
        Txt_resultado_gabriela.Text = ""

        Dim ValorSacar As Double = Val(Txt_valor_gabriela.Text)

        Dim RetornoSacar As Boolean = ContaGabriela.Sacar(ValorSacar)

        If RetornoSacar = False Then
            Txt_resultado_gabriela.ForeColor = Color.Red
            Txt_resultado_gabriela.Text = "Saldo insuficiente"
        Else
            Txt_novoSaldo_gabriela.Text = ContaGabriela.Saldo.ToString
            Txt_resultado_gabriela.ForeColor = Color.Green
            Txt_resultado_gabriela.Text = "Saque efetuado com sucesso"
            Txt_saldo_gabriela.Text = Txt_novoSaldo_gabriela.Text
            ContaGabriela.Extrato += Now.ToString + " Saque efetuado no valor de " + ValorSacar.ToString + " saldo atual " + ContaGabriela.Saldo.ToString + vbCrLf
            Txt_extrato_gabriela.Text = ContaGabriela.Extrato
        End If
    End Sub

    Private Sub Btn_depositar_gabriela_Click(sender As Object, e As EventArgs) Handles Btn_depositar_gabriela.Click
        Txt_novoSaldo_gabriela.Text = ""
        Txt_resultado_gabriela.Text = ""
        Dim valorDeposito As Double = Txt_valor_gabriela.Text

        Dim RetornoDeposito As Double = ContaGabriela.Depositar(valorDeposito)
        Txt_novoSaldo_gabriela.Text = RetornoDeposito.ToString
        Txt_resultado_gabriela.ForeColor = Color.Green
        Txt_resultado_gabriela.Text = "Deposito efetuado com sucesso"
        Txt_saldo_gabriela.Text = Txt_novoSaldo_gabriela.Text
        ContaGabriela.Extrato += Now.ToString + " Deposito efetuado no valor de " + valorDeposito.ToString + " saldo atual " + ContaGabriela.Saldo.ToString + vbCrLf
        Txt_extrato_gabriela.Text = ContaGabriela.Extrato
    End Sub

    Private Sub Btn_transferir_gabriela_Click(sender As Object, e As EventArgs) Handles Btn_transferir_gabriela.Click
        Txt_novoSaldo_gabriela.Text = ""
        Txt_resultado_gabriela.Text = ""

        Dim ValorTransferir As Double = Val(Txt_valor_gabriela.Text)

        Dim RetornoTransferir As Boolean = ContaGabriela.Transferir(ValorTransferir, ContaBruno)

        If RetornoTransferir = False Then
            Txt_resultado_gabriela.ForeColor = Color.Red
            Txt_resultado_gabriela.Text = "Saldo insuficiente"
        Else
            Txt_novoSaldo_gabriela.Text = ContaGabriela.Saldo.ToString
            Txt_novoSaldo_bruno.Text = ContaBruno.Saldo.ToString
            Txt_resultado_gabriela.ForeColor = Color.Green
            Txt_resultado_gabriela.Text = "Transferencia efetuado com sucesso"
            Txt_saldo_bruno.Text = Txt_novoSaldo_bruno.Text
            Txt_saldo_gabriela.Text = Txt_novoSaldo_gabriela.Text
            ContaGabriela.Extrato += Now.ToString + " Transferência efetuado no valor de " + ValorTransferir.ToString + " saldo atual " + ContaGabriela.Saldo.ToString + vbCrLf
            Txt_extrato_gabriela.Text = ContaGabriela.eXTRATO

            ContaBruno.eXTRATO += Now.ToString + " Transferência recebida no valor de " + ValorTransferir.ToString + " saldo atual " + ContaBruno.Saldo.ToString + vbCrLf
            Txt_extrato_bruno.Text = ContaBruno.Extrato
        End If
    End Sub

    Private Sub Btn_sacar_bruno_Click(sender As Object, e As EventArgs) Handles Btn_sacar_bruno.Click
        Txt_novoSaldo_bruno.Text = ""
        Txt_resultado_bruno.Text = ""

        Dim ValorSacar As Double = Val(Txt_valor_bruno.Text)

        Dim RetornoSacar As Boolean = ContaBruno.Sacar(ValorSacar)

        If RetornoSacar = False Then
            Txt_resultado_bruno.ForeColor = Color.Red
            Txt_resultado_bruno.Text = "Saldo insuficiente"
        Else
            Txt_novoSaldo_bruno.Text = ContaBruno.Saldo.ToString
            Txt_resultado_bruno.ForeColor = Color.Green
            Txt_resultado_bruno.Text = "Saque efetuado com sucesso"
            Txt_saldo_bruno.Text = Txt_novoSaldo_bruno.Text
            ContaBruno.Extrato += Now.ToString + " Saque efetuado no valor de " + ValorSacar.ToString + " saldo atual " + ContaBruno.Saldo.ToString + vbCrLf
            Txt_extrato_bruno.Text = ContaBruno.Extrato
        End If
    End Sub

    Private Sub Btn_depositar_bruno_Click(sender As Object, e As EventArgs) Handles Btn_depositar_bruno.Click
        Txt_novoSaldo_bruno.Text = ""
        Txt_resultado_bruno.Text = ""
        Dim valorDeposito As Double = Txt_valor_bruno.Text

        Dim RetornoDeposito As Double = ContaBruno.Depositar(valorDeposito)
        Txt_novoSaldo_bruno.Text = RetornoDeposito.ToString
        Txt_resultado_bruno.ForeColor = Color.Green
        Txt_resultado_bruno.Text = "Deposito efetuado com sucesso"
        Txt_saldo_bruno.Text = Txt_novoSaldo_bruno.Text
        ContaBruno.Extrato += Now.ToString + " Deposito efetuado no valor de " + valorDeposito.ToString + " saldo atual " + ContaBruno.Saldo.ToString + vbCrLf
        Txt_extrato_bruno.Text = ContaBruno.Extrato
    End Sub

    Private Sub Btn_transferir_bruno_Click(sender As Object, e As EventArgs) Handles Btn_transferir_bruno.Click
        Txt_novoSaldo_bruno.Text = ""
        Txt_resultado_bruno.Text = ""

        Dim ValorTransferir As Double = Val(Txt_valor_bruno.Text)

        Dim RetornoTransferir As Boolean = ContaBruno.Transferir(ValorTransferir, ContaGabriela)

        If RetornoTransferir = False Then
            Txt_resultado_bruno.ForeColor = Color.Red
            Txt_resultado_bruno.Text = "Saldo insuficiente"
        Else
            Txt_novoSaldo_gabriela.Text = ContaGabriela.Saldo.ToString
            Txt_novoSaldo_bruno.Text = ContaBruno.Saldo.ToString
            Txt_resultado_bruno.ForeColor = Color.Green
            Txt_resultado_bruno.Text = "Transferencia efetuado com sucesso"
            Txt_saldo_bruno.Text = Txt_novoSaldo_bruno.Text
            Txt_saldo_gabriela.Text = Txt_novoSaldo_gabriela.Text
            ContaBruno.Extrato += Now.ToString + " Transferência efetuado no valor de " + ValorTransferir.ToString + " saldo atual " + ContaBruno.Saldo.ToString + vbCrLf
            Txt_extrato_bruno.Text = ContaBruno.Extrato

            ContaGabriela.Extrato += Now.ToString + " Transferência recebida no valor de " + ValorTransferir.ToString + " saldo atual " + ContaGabriela.Saldo.ToString + vbCrLf
            Txt_extrato_gabriela.Text = ContaGabriela.Extrato
        End If

    End Sub

    Private Sub Btn_name_trocar_Click(sender As Object, e As EventArgs) Handles Btn_name_trocar_gabriela.Click

        Dim nameTroca As String = Txt_name_trocar_gabriela.Text
        gabriela.Name = nameTroca
        Lbl_bem_vindo_gabriela.Text = "Bem vindo " + ContaGabriela.Titular.Name + " Agência " + ContaGabriela.Agencia.ToString + " Conta " + ContaGabriela.Conta.ToString
    End Sub

    Private Sub Btn_name_troca_bruno_Click(sender As Object, e As EventArgs) Handles Btn_name_troca_bruno.Click

        Dim nameTroca As String = Txt_name_troca_bruno.Text
        bruno.Name = nameTroca
        Lbl_bem_vindo_Bruno.Text = "Bem vindo " + ContaBruno.Titular.Name + " Agência " + ContaBruno.Agencia.ToString + " Conta " + ContaBruno.Conta.ToString

    End Sub
End Class
