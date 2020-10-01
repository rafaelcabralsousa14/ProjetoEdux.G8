using ProjetoEduXG8.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxG8.Interface
{
    interface iProfessorTurma
    {
        List<ProfessorTurma> Listar();
        ProfessorTurma BuscarPorId(Guid id);
        void Adicionar(ProfessorTurma professorTurma);
        void Remover(Guid id);
        void Editar(ProfessorTurma professorTurma);
    }
}