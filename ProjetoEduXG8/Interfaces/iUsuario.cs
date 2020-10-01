using ProjetoEduXG8.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduXG8.Interfaces
{
    interface iUsuario
    {
        List<Usuario> Listar();
        Usuario BuscarPorId(Guid id);
        void Adicionar(Usuario usuario);
        void Remover(Guid id);
        void Editar(Usuario usuario);
    }
}