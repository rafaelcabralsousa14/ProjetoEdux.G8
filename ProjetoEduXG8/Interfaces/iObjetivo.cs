using ProjetoEduXG8.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduXG8.Interfaces
{
    interface iObjetivo
    {
        List<Objetivo> Listar();
        Objetivo BuscarPorId(Guid id);
        void Adicionar(Objetivo objetivo);
        void Remover(Guid id);
        void Editar(Objetivo objetivo);
        
    }
}