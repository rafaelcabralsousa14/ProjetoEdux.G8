using ProjetoEduXG8.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduXG8.Interfaces
{
    interface iInstituicao
    {
        List<Instituicao> Listar();
        Instituicao BuscarPorId(Guid id);
        void Adicionar(Instituicao instituicao);
        void Remover(Guid id);
        void Editar(Instituicao instituicao);
    }
}
