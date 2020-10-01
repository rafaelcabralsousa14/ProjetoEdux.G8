using ProjetoEduXG8.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduXG8.Interfaces
{
    interface iCurso
    {
        List<Curso> Listar();
        Curso BuscarPorId(Guid id);
        void Adicionar(Curso curso);
        void Remover(Guid id);
        void Editar(Curso curso);
    }
}