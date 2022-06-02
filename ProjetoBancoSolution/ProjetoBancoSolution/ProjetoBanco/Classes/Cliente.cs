using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBanco.Classes
{
    public class Cliente
    {
        private Cliente() { }
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Telefone { get; private set; }
        public string Endereço { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string IDConta { get; private set; }

        public static Cliente CreateCliente(string nome, string cpf, string endereço, string telefone, DateTime datanascimento) =>
        
        new Cliente { Nome = nome, CPF = cpf, Telefone = telefone, Endereço = endereço, DataNascimento = datanascimento };
        
    }
}
