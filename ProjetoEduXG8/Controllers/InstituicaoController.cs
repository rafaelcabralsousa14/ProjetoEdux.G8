using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoEduXG8.Domains;
using ProjetoEduXG8.Interfaces;
using ProjetoEduXG8.Repositories;

namespace ProjetoEduXG8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstituicaoController : ControllerBase
    {
        private readonly iInstituicao _instRepository;

        public InstituicaoController()
        {
            _instRepository = new InstituicaoRepository();
        }

        /// <summary>
        /// Lista as instituições adicionadas
        /// </summary>
        /// <returns>Lista de instituições</returns>
        [HttpGet]
        public List<Instituicao> Get()
        {
            try
            {
                return _instRepository.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca instituicao por seu Id
        /// </summary>
        /// <param name="id">Id da instituicao buscado</param>
        /// <returns>Instituição com o Id buscado</returns>
        [HttpGet("{id}")]
        public Instituicao Get(Guid id)
        {
            try
            {
                return _instRepository.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Adiciona uma nova instituição
        /// </summary>
        /// <param name="instituicao">Instituição que será adicionada</param>
        [HttpPost]
        public void Post(Instituicao instituicao)
        {
            try
            {
                _instRepository.Adicionar(instituicao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edita uma instituição existente
        /// </summary>
        /// <param name="id">Id nova da intituição</param>
        /// <param name="instituicao">Instituição que será editada</param>
        [HttpPut("{id}")]
        public void Put(Guid id, Instituicao instituicao)
        {
            try
            {
                instituicao.IdInstituicao = id;
                _instRepository.Editar(instituicao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove instituição existente
        /// </summary>
        /// <param name="id">Id da instituição que será deletada</param>
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            try
            {
                _instRepository.Remover(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
