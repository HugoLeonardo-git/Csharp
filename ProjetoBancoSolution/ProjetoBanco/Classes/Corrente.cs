using System;

namespace ProjetoBanco.Classes
{
    public class Corrente : Conta
    {
        public Corrente(Cliente cliente, DateTime numero, decimal saldo)
            : base(cliente, numero, saldo)
        { }

        public override bool Depositar(decimal valorDeposito)
        {
            if (valorDeposito <= 0)
            {
                MensagemTransacoes = $"O valor do depósito é inválido!";
                return false;
            }

            Saldo += valorDeposito;
            MensagemTransacoes = "Deposito realizado com sucesso!";

            return true;
        }

        public override bool Sacar(decimal valorSaque)
        {
            if (Saldo <= 0m)
            {
                MensagemTransacoes = $"O saldo é insuficiente para saque. Sua conta está com o valor atual de {Saldo}";
                return false;
            }

            if (Saldo < valorSaque)
            {
                MensagemTransacoes = $"Valor solicitado para o saque é {valorSaque} e o Saldo é {Saldo}";
                return false;
            }

            Saldo -= valorSaque;
            MensagemTransacoes = "Saque realizado com sucesso!";
            return true;
        }

        public override bool Investir(decimal valorInvestir)
        {
            if (Saldo <= 0m)
            {
                return false;
            }

            if (Saldo < valorInvestir)
            {
                return false;
            }

            Saldo -= valorInvestir;
            return true;
        }
    }
}