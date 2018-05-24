using Controllers.Base;
using Modelos;
using System.Collections.Generic;
using System;

namespace Controllers
{
    class AtividadesController : IBaseController<Atividade>
    {
        private List<Atividade> listaAtividades { get; set; }

        private static int ultimoID = 0;

        public void Adicionar(Atividade atividade)
        {
            atividade.AtividadeID = ++ultimoID;
            listaAtividades.Add(atividade);
        }

        public IList<Atividade> ListarTodos()
        {
            return listaAtividades;
        }

        public IList<Atividade> ListarPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public Atividade BuscarPorID(int id)
        {
            foreach (Atividade a in listaAtividades)
            {
                if (a.AtividadeID == id)
                {
                    return a;
                }
            }
            return null;
        }

        public void Atualizar(Atividade atividade)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}
