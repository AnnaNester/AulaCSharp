using Controllers.Base;
using Modelos;
using System.Collections.Generic;
using System;
using Controllers.DAL;
using System.Linq;

namespace Controllers
{
    class AtividadesController : IBaseController<Atividade>
    {
        private Contexto contexto = new Contexto();

        private static int ultimoID = 0;

        public void Adicionar(Atividade entity)
        {
            contexto.Atividades.Add(entity);
            contexto.SaveChanges();
        }

        public IList<Atividade> ListarTodos()
        {
            return contexto.Atividades.ToList();
        }

        public IList<Atividade> ListarPorNome(string nome)
        {
            //var atividadesComNome = from a in contexto.Atividades
            //            where a.Nome == nome
            //            select a;

            //return atividadesComNome.ToList();

            //LAMBDA
            return contexto.Atividades.Where(a => a.Nome.ToLower() == nome.ToLower()).ToList();
        }

        public Atividade BuscarPorID(int id)
        {
            return contexto.Atividades.Find();
        }

        public void Atualizar(Atividade entity)
        {
            contexto.Entry(entity).State = System.Data.Entity.EntityState.Modified;

            contexto.SaveChanges();
        }

        public void Excluir(int id)
        {
            Atividade a = BuscarPorID(id);
            if (a != null)
            {
                //forma 1
                contexto.Atividades.Remove(a);

                //forma 2
                //contexto.Entry(a).State = System.Data.Entity.EntityState.Deleted;

                contexto.SaveChanges();
            }
        }
    }
}
