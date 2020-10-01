using ProjetoEduXG8.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxG8.Interface
{
    interface iAlunoTurma
    {
        List<AlunoTurma> Listar();
        AlunoTurma BuscarPorId(Guid id);
        void Adicionar(AlunoTurma alunoTurma);
        void Remover(Guid id);
        void Editar(AlunoTurma alunoTurma);
    }
}