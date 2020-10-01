using ProjetoEduXG8.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduXG8.Interfaces
{
    interface iObjetivoAluno
    {
        List<ObjetivoAluno> Listar();
        ObjetivoAluno BuscarPorId(Guid id);
        void Adicionar(ObjetivoAluno objetivoAluno);
        void Remover(Guid id);
        void Editar(ObjetivoAluno objetivoAluno);
    }
}