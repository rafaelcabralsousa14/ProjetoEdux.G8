using ProjetoEduXG8.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduXG8.Interfaces
{
    interface iCategoria
    {
        List<Categoria> Listar();
        Categoria BuscarPorId(Guid id);
        void Adicionar(Categoria categoria);
        void Remover(Guid id);
        void Editar(Categoria categoria);
    }
}