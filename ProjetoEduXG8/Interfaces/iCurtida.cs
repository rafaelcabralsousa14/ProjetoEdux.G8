using ProjetoEduXG8.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduXG8.Interfaces
{
    interface iCurtida
    {
        List<Curtida> Listar();
        Curtida BuscarPorId(Guid id);
        void Adicionar(Curtida curtida);
        void Remover(Guid id);
    }
}