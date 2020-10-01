using ProjetoEduXG8.Context;
using ProjetoEduXG8.Domains;
using ProjetoEduXG8.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduXG8.Repository
{
    public class PerfilRepository : iPerfil
    {
        private readonly EduXContext _ctx;

        public PerfilRepository()
        {
            _ctx = new EduXContext();
        }

        public void Adicionar(Perfil perfil)
        {
            try
            {
                _ctx.Perfils.Add(perfil);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Perfil BuscarPorId(Guid id)
        {
            try
            {
                Perfil perfil = _ctx.Perfils.Find(id);

                return perfil;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Perfil perfil)
        {
            try
            {
                Perfil perfilTemp = BuscarPorId(perfil.IdPerfil);

                if (perfilTemp == null)
                    throw new Exception("Perfil não encontrado");

                perfilTemp.Permissao = perfil.Permissao;
                _ctx.Perfils.Update(perfilTemp);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Perfil> Listar()
        {
            try
            {
                List<Perfil> perfils = _ctx.Perfils.ToList();

                return perfils;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remover(Guid id)
        {
            try
            {
                Perfil perfil = BuscarPorId(id);

                if (perfil == null)
                    throw new Exception("Perfil não encontrado");

                _ctx.Perfils.Remove(perfil);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}