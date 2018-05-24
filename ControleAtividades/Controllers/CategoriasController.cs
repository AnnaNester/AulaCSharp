using Controllers.Base;
using Modelos;
using System.Collections.Generic;
using System;

namespace Controllers
{
    public class CategoriasController : IBaseController<Categoria>
    {
        private List<Categoria> listaCategorias { get; set; }

        private static int ultimoID = 0;

        public void Adicionar(Categoria categoria)
        {
            categoria.CategoriaID = ++ultimoID;
            listaCategorias.Add(categoria);
        }

        public void Atualizar(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Categoria BuscarPorID(int id)
        {
            foreach (Categoria a in listaCategorias)
            {
                if (a.CategoriaID == id)
                {
                    return a;
                }
            }
            return null;
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Categoria> ListarPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public IList<Categoria> ListarTodos()
        {
            return listaCategorias;
        }
    }
}
