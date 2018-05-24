using Aula1705_Camadas.Controllers;
using Aula1705_Camadas.Models;
using System;
using System.Collections.Generic;

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

        public AtividadeView()
        {
            atividadeController = new AtividadesController();
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
            Console.WriteLine ("Pesquisando por Ativos/Inativos");
            Console.WriteLine("Deseja pesquisar itens ativos(a) ou inativos (i)? (a/i): ");
            bool resposta = Console.ReadLine() == "a" ? true : false;

            List<Atividade> lista = atividadeController.BuscarAtivoInativo(resposta);

            if (lista.Count > 0)
            {
                foreach (Atividade a in lista)
                {
                    ExibirDetalhesAtividade(a);
                }
            }
            else
                Console.WriteLine("Lista vazia");

            Console.WriteLine("Fim da lista de Atividades Ativo/Inativo");
            Console.ReadKey();

        }

        public void BuscarAtividade()
        {
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
            Console.Write("Digite o nome da atividade: ");
            string atividade = Console.ReadLine();
            List<Atividade> lista = atividadeController.BuscarPorNome(atividade);

            if (lista.Count > 0)
            {
                foreach (Atividade a in lista)
                {
                    ExibirDetalhesAtividade(a);
                }
            }
        }

        public void EditarAtividade()
        {
            ListarAtividades();
            Console.WriteLine("Digite o id da atividade a ser editada: ");
            int id = int.Parse(Console.ReadLine());

            Atividade atividadeAtualizada = ObterDadosAtividade();
            atividadeController.Editar(id, atividadeAtualizada);
        }

        public void ExcluirAtividade()
        {
            ListarAtividades();
            Console.Write("Digite o id da atividade que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            atividadeController.Excluir(id);
        }
    }
} 