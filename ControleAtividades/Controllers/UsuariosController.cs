using Controllers.Base;
using Modelos;
using System.Collections.Generic;
using System;
using Controllers.DAL;
using System.Linq;

namespace Controllers
{
    class UsuariosController : IBaseController<Usuario>
    {
        private List<Usuario> listaUsuarios { get; set; }

        private Contexto contexto = new Contexto();

        public void Adicionar(Usuario entity)
        {
            contexto.Usuarios.Add(entity);
            contexto.SaveChanges();
        }

        public IList<Usuario> ListarTodos()
        {
            return listaUsuarios;
        }

        public IList<Usuario> ListarPorNome(string nome)
        {
            return contexto.Usuarios.Where(a => a.Nome.ToLower() == nome.ToLower()).ToList();
        }

        public Usuario BuscarPorID(int id)
        {
            return contexto.Usuarios.Find();
        }

        public void Atualizar(Usuario entity)
        {
            contexto.Entry(entity).State = System.Data.Entity.EntityState.Modified;

            contexto.SaveChanges();
        }

        public void Excluir(int id)
        {
            Usuario a = BuscarPorID(id);

            if (a != null)
            {
                contexto.Usuarios.Remove(a);

                contexto.SaveChanges();
            }
        }
    }
}
