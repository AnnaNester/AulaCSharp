using Aula1705_Camadas.Controllers;
using Aula1705_Camadas.Models;
using System;

namespace Aula1705_Camadas.Views
{
    class AtividadeView
    {
        private AtividadesController atividadeController;

        enum OpcoesMenu
        {
            CriarAtividade = 1,
            ListarAtividades = 2,
            BuscarAtividade = 3,
            EditarAtividade = 4,
            ExcluirAtividade = 5,
            BuscarAtividadeNome = 6,
            ListarAtividadeAtivos = 7,
            Sair = 9
        }

        public void ExibirMenu()
        {
            OpcoesMenu opcao = OpcoesMenu.Sair;
            do
            {
                Console.Clear();
                Console.WriteLine("=========================================");
                Console.WriteLine("= Escolha uma opção:                    =");
                Console.WriteLine("= 1 - Criar uma Atividade               =");
                Console.WriteLine("= 2 - Listar Atividades                 =");
                Console.WriteLine("= 3 - Buscar Atividade                  =");
                Console.WriteLine("= 4 - Editar Atividade                  =");
                Console.WriteLine("= 5 - Excluir Atividade                 =");
                Console.WriteLine("= 6 - Buscar Atividade por Nome         =");
                Console.WriteLine("= 7 - Listar Atividade (Ativos/Inativos)=");
                Console.WriteLine("= 9 - Sair                              =");
                Console.WriteLine("=========================================");

                opcao = (OpcoesMenu) int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case OpcoesMenu.CriarAtividade:
                        CriarAtividade();
                        break;
                    case OpcoesMenu.ListarAtividades:
                        ListarAtividades();
                        break;
                    case OpcoesMenu.BuscarAtividade:
                        BuscarAtividade();
                        break;
                    case OpcoesMenu.EditarAtividade:
                        EditarAtividade();
                        break;
                    case OpcoesMenu.ExcluirAtividade:
                        ExcluirAtividade();
                        break;
                    case OpcoesMenu.BuscarAtividadeNome:
                        BuscarAtividadeNome();
                        break;
                    case OpcoesMenu.ListarAtividadeAtivos:
                        ListarAtividadesAtivos();
                        break;
                    case OpcoesMenu.Sair:
                        break;
                    default:
                        Console.WriteLine("OPÇÃO INVÁLIDA! Digite qualquer tecla para continuar");
                        Console.ReadKey();
                        break;

                }
            }
            while (opcao !=OpcoesMenu.Sair);
        }

        public void CriarAtividade()
        {
            Atividade atividade = ObterDadosAtividade();

            atividadeController = new AtividadesController();
            atividadeController.Salvar(atividade);
        }

        private static Atividade ObterDadosAtividade()
        {
            Atividade atividade = new Atividade();
            Console.Write("Digite o nome da atividade: ");
            atividade.Nome = Console.ReadLine();

            Console.WriteLine("Ativo? (s/n): ");
            atividade.Ativo = Console.ReadLine() == "s"? true: false;
            return atividade;
        }

        private static void ExibirDetalhesAtividade(Atividade atividade)
        {
            Console.WriteLine("----");
            Console.WriteLine("ID: " + atividade.AtividadeID);
            Console.WriteLine("Nome: " + atividade.Nome);
            Console.WriteLine("Ativo: " + atividade.Ativo);
            Console.WriteLine("----");
        }

        public void ListarAtividades()
        {
            atividadeController = new AtividadesController();
            Console.WriteLine("Listando atividade cadastradas");
            foreach (Atividade atividade in atividadeController.Listar())
            {
                ExibirDetalhesAtividade(atividade);
            }
            Console.WriteLine("Fim da lista");
            Console.ReadKey();
        }

        public void ListarAtividadesAtivos()
        {
            atividadeController = new AtividadesController();
            Console.WriteLine("Deseja buscar atividades ativas? (s/n): ");
            string busca = Console.ReadLine();
            if (busca == "s" ? true : false)
            {
                Console.WriteLine("Listando atividade ativas");
                foreach (Atividade atividade in atividadeController.Listar())
                {
                    if (atividade.Ativo == true)
                        ExibirDetalhesAtividade(atividade);
                }
                Console.WriteLine("Fim da lista");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Listando atividade inativas");
                foreach (Atividade atividade in atividadeController.Listar())
                {
                    if (atividade.Ativo == false)
                        ExibirDetalhesAtividade(atividade);
                }
                Console.WriteLine("Fim da lista");
                Console.ReadKey();
            }
        }

        public void BuscarAtividade()
        {
            atividadeController = new AtividadesController();
            Console.Write("Digite o id da atividade: ");
            int id = int.Parse(Console.ReadLine());

            Atividade atividade = atividadeController.BuscarPorID(id);

            if (atividade != null)
            {
                ExibirDetalhesAtividade(atividade);
            }
            else
            {
                Console.WriteLine("Atividade não encontrada");
            }
            Console.ReadKey();
        }

        public void BuscarAtividadeNome()
        {
            atividadeController = new AtividadesController();
            Console.Write("Digite o nome da atividade: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Exibindo lista de atividades por nome");
            foreach (Atividade a in atividadeController.BuscarPorNome(nome))
            {
                ExibirDetalhesAtividade(a);
            }
            Console.WriteLine("Fim da lista de atividades por nome");
            Console.ReadKey();
        }

        public void EditarAtividade()
        {
            ListarAtividades();
            Console.WriteLine("Digite o id da atividade a ser editada: ");
            int id = int.Parse(Console.ReadLine());

            Atividade atividadeAtualizada = ObterDadosAtividade();
            atividadeController = new AtividadesController();
            atividadeController.Editar(id, atividadeAtualizada);
        }

        public void ExcluirAtividade()
        {
            ListarAtividades();
            Console.Write("Digite o id da atividade que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            atividadeController = new AtividadesController();
            atividadeController.Excluir(id);
        }
    }
} 