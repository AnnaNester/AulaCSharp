using Controllers.Base;
using Modelos;
using System.Collections.Generic;
using System;

namespace Controllers
{
    class UsuariosController : IBaseController<Usuario>
    {
        private List<Usuario> listaUsuarios { get; set; }

        private static int ultimoID = 0;

        public void Adicionar(Usuario usuario)
        {
            usuario.UsuarioID = ++ultimoID;
            listaUsuarios.Add(usuario);
        }

        public IList<Usuario> ListarTodos()
        {
            return listaUsuarios;
        }

        public IList<Usuario> ListarPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorID(int id)
        {
            foreach (Usuario a in listaUsuarios)
            {
                if (a.UsuarioID == id)
                {
                    return a;
                }
            }
            return null;
        }

        public void Atualizar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}
