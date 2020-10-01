using ProjetoEduXG8.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxG8.Interface
{
    interface iTurma
    {
        List<Turma> Listar();
        Turma BuscarPorId(Guid id);
        void Adicionar(Turma turma);
        void Remover(Guid id);
        void Editar(Turma turma);
    }
}