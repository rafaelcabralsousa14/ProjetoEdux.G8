using ProjetoEduXG8.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduXG8.Interfaces
{
    interface iDica
    {
        List<Dica> Listar();
        Dica BuscarPorId(Guid id);
        void Adicionar(Dica dica);
        void Remover(Guid id);
        void Editar(Dica dica);
    }
}