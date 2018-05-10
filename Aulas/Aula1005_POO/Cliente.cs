using System;

namespace Aula1005_POO
{
    class Cliente : Pessoa
    {
        public DateTime DataNasc { get; set; }

        public Cliente()
        {

        }

        public Cliente(string nome) : base(nome)
        {

        }

        public Cliente (string nome, string cpf) : base(nome, cpf)
        {

        }
 
    }
}
