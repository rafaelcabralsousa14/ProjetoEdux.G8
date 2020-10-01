using ProjetoEduXG8.Context;
using ProjetoEduXG8.Domains;
using ProjetoEduXG8.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduXAPI.Repositories
{
    public class UsuarioRepository : iUsuario
    {
        private readonly EduXContext _ctx;
        public UsuarioRepository()
        {
            _ctx = new EduXContext();
        }
        
        public void Adicionar(Usuario usuario)
        {
            try
            {
                _ctx.Usuarios.Add(usuario);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Usuarios.FirstOrDefault(c => c.IdUsuario == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Usuario usuario)
        {
            try
            {
                Usuario usuarioTemp = BuscarPorId(usuario.IdUsuario);

                if (usuarioTemp == null)
                    throw new Exception("Usuário não encontrado");

                usuarioTemp.Nome = usuario.Nome;
                usuarioTemp.Senha = usuario.Senha;
                usuarioTemp.Email = usuario.Email;
                usuarioTemp.DataCadastro = usuario.DataCadastro;
                usuarioTemp.DataUltimoAcesso = usuario.DataUltimoAcesso;

                _ctx.Usuarios.Update(usuarioTemp);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Usuario> Listar()
        {
            try
            {
                return _ctx.Usuarios.ToList();
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
                Usuario usuarioTemp = BuscarPorId(id);

                if (usuarioTemp == null)
                    throw new Exception("Usuário não encontrado");

                _ctx.Usuarios.Remove(usuarioTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}