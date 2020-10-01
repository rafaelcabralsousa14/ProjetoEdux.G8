using ProjetoEduXG8.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduXG8.Interfaces
{
    public interface iPerfil
    {
        List<Perfil> Listar();
        Perfil BuscarPorId(Guid id);
        void Adicionar(Perfil perfil);
        void Remover(Guid id);
        void Editar(Perfil perfil);
        
    }
}