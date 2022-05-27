using System;
using ProjetoBanco.Classes;

namespace ProjetoBanco
{
    class Program
    {
        static void Main(string[] args)
        {
            string nome;
            string cpf;
            string endereço;
            string telefone;
            string datanascimento;

            Console.WriteLine("Nome: ");
            nome = Console.ReadLine();

            Console.WriteLine("CPF: ");
            cpf = Console.ReadLine();

            Console.WriteLine("Endereço: ");
            endereço = Console.ReadLine();

            Console.WriteLine("Telefone: ");
            telefone = Console.ReadLine();

            Console.WriteLine("Data de nascimento (dd/mm/yyy): ");
            datanascimento = Console.ReadLine();

            DateTime DateObject = DateTime.ParseExact(datanascimento, "dd/MM/yyyy", null);
            var cliente = Cliente.CreateCliente(nome, cpf, endereço, telefone, DateObject);

            Console.WriteLine($"\nBem vindo ao nosso sistema de investimentos, {cliente.Nome}!");

            DateTime localDate = DateTime.Now;
            try
            {

                Conta contaCorrente = new Corrente(cliente, localDate, 0);
                Console.WriteLine("Segundo sua data de nascimento: " + cliente.DataNascimento.Day + "/" + cliente.DataNascimento.Month + "/" + cliente.DataNascimento.Year + ", você tem " + contaCorrente.Idade + " anos");
                Console.WriteLine($"Seu saldo atual é de: R$ {contaCorrente.Saldo}");
                Console.WriteLine("Informe um valor de depósito:");
                decimal deposito = decimal.Parse(Console.ReadLine());
                contaCorrente.Depositar(deposito);
                Console.WriteLine(contaCorrente.MensagemTransacoes);

                Console.WriteLine($"Sua conta corrente possui: R$ { contaCorrente.Saldo}");
                Console.WriteLine("Informe o valor que deseja sacar:");
                decimal saque = decimal.Parse(Console.ReadLine());
                contaCorrente.Sacar(saque);
                Console.WriteLine(contaCorrente.MensagemTransacoes);
                Console.WriteLine($"Novo Saldo: R$ {contaCorrente.Saldo}");

                Conta contaInvestimento = new Investimento(cliente, localDate, contaCorrente.Saldo);
                Console.WriteLine("Informe o valor que deseja investir:");
                decimal investir = decimal.Parse(Console.ReadLine());
                contaInvestimento.Depositar(investir);
                Console.WriteLine(contaInvestimento.MensagemTransacoes);
                contaCorrente.Investir(investir);

                Console.WriteLine($"Novo Saldo Conta Corrente: R$ {contaCorrente.Saldo}");
                Console.WriteLine($"Novo Saldo Conta de Investimentos: R$ {contaInvestimento.Saldo}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

        }
    }
}
