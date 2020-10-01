using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoEduXAPI.Repositories;
using ProjetoEduXAPI.Utils;
using ProjetoEduXG8.Domains;
using ProjetoEduXG8.Interfaces;
using ProjetoEduXG8.Repositories;
using ProjetoEduXG8.Utils;

namespace ProjetoEduXAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly iUsuario _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista os usuários adicionados
        /// </summary>
        /// <returns>Lista de usuários</returns>
        [HttpGet]
        public List<Usuario> Get()
        {
            try
            {
                return _usuarioRepository.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Busca usuario por seu Id
        /// </summary>
        /// <param name="id">Id do usuário buscado</param>
        /// <returns>Usuário com o Id buscado</returns>
        [HttpGet("{id}")]
        public Usuario Get(Guid id)
        {
            try
            {
                return _usuarioRepository.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Adiciona um novo usuário
        /// </summary>
        /// <param name="usuario">Usuário que será adicionado</param>
        [HttpPost]
        public void Post(Usuario usuario)
        {
            try
            {
                usuario.Senha = Crypto.Criptografar(usuario.Senha, usuario.Email.Substring(0, 4));
                _usuarioRepository.Adicionar(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edita um usuário existente
        /// </summary>
        /// <param name="id">Id nova do usuário</param>
        /// <param name="usuario">Usuário que será editado</param>
        [HttpPut("{id}")]
        public void Put(Guid id, Usuario usuario)
        {
            try
            {
                usuario.Senha = Crypto.Criptografar(usuario.Senha, usuario.Email.Substring(0, 4));
                usuario.IdUsuario = id;
                _usuarioRepository.Editar(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Remove um usuário existente
        /// </summary>
        /// <param name="id">Id do usuário que será deletado</param>
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            try
            {
                _usuarioRepository.Remover(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}