using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBanco.Classes
{
    
    public class Investimento : Conta
    {
        public Investimento(Cliente cliente, DateTime numero, decimal saldo)
            : base(cliente, numero, saldo)
        { }

        public override bool Depositar(decimal valorDeposito)
        {
            if (Saldo <= 0m)
            {
                MensagemTransacoes = $"O saldo é insuficiente para Investir. Sua conta está com o valor atual de {Saldo}";
                return false;
            }

            if (Saldo < valorDeposito)
            {
                MensagemTransacoes = $"Valor solicitado para o investimento é {valorDeposito} e o Saldo é {Saldo}";
                Saldo = 0;
                return false;
            }


            Saldo = valorDeposito * 1.5m; //.m necessário pra contar como decimal
            MensagemTransacoes = $"Deposito realizado com sucesso! Seu Investimento irá render R${Saldo}";

            return true;
        }

        public override bool Investir(decimal valorInvestir)
        {
            throw new NotImplementedException();
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

            Saldo -= valorSaque + 0.1m;
            return true;
        }
    }
}
    

