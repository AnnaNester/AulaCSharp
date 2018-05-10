using System;

namespace Aula1005_POO
{
    class Program
    {
        static void Main(string[] args)
        {
            Cliente cli = new Cliente();

            cli.Nome = "Link"; //set

            string nomeCliente = cli.Nome; //get

            cli.Cpf = "12345678909"; //set
            string cpfCliente = cli.Cpf; //get

            Console.WriteLine(cli.Nome);
            Console.WriteLine(cli.Cpf);

            Console.ReadKey();
        }
    }
}
