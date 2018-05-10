namespace Aula1005_POO
{
    class Pessoa
    {
        //Atributo
        private string nome;

        //Propriedade
        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public string Cpf { get; set; }

        //Construtor
        public Pessoa() //Construtor vazio
        {

        }

        public Pessoa(string nome)
        {
            Nome = nome;
        }

        public Pessoa(string nome, string cpf)
        {
            Nome = nome;
            Cpf = cpf;
        }
    }
}
