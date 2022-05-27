using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBanco.Classes
{
    public abstract class Conta
    {

        private decimal _saldo; // O _ é aprenas para indicar q é privado, NÃO POSSUI EFEITO NENHUM
        public string Numero { get; private set; }
        public string MensagemTransacoes { get; set; }
        public Cliente Cliente { get; private set; }
        public int Idade { get; private set; }
        public decimal Saldo
        {
            get { return _saldo; }
            protected set
            {
                if (value >= 0)
                    _saldo = value;
                else
                    _saldo = 0;
            }
        }

        public Conta(Cliente cliente, DateTime numero, decimal saldo)
        {

            DateTime n = numero; // To avoid a race condition around midnight
            int age = n.Year - cliente.DataNascimento.Year;

            if (n.Month < cliente.DataNascimento.Month || (n.Month == cliente.DataNascimento.Month && n.Day < cliente.DataNascimento.Day))
                age--;

            // if ((numero.Year - cliente.DataNascimento.Year) < 18)
            if (age < 18)
            {

                throw new Exception("\nUsuário menor de 18 anos!Não foi possível criar uma conta!");
            }
            if (cliente.CPF.Length < 5)
            {
                throw new Exception("\nNúmero da conta inválido! CPF com menos de 5 dígitos!");
            }

            Numero = cliente.CPF; Saldo = saldo; Cliente = cliente; Idade = age;

        }
        public abstract bool Sacar(decimal valorSaque);

        public abstract bool Depositar(decimal valorDeposito);

        public abstract bool Investir(decimal valorInvestir);
    }
}
