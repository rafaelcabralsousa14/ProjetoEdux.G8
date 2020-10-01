using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoEduXG8.Domains;
using ProjetoEduXG8.Interfaces;
using ProjetoEduXG8.Repositories;
using ProjetoEduXG8.Utils;

namespace ProjetoEduXG8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DicaController : ControllerBase
    {
        private readonly iDica _dicaRepository;

        public DicaController()
        {
            _dicaRepository = new DicaRepository();
        }

        /// <summary>
        /// Lista as dicas existentes
        /// </summary>
        /// <returns>Lista de dicas</returns>
        [HttpGet]
        public List<Dica> Get()
        {
            try
            {
                return _dicaRepository.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Busca uma dica pelo id
        /// </summary>
        /// <param name="id">Id que será buscado</param>
        /// <returns>Dica com o Id buscado</returns>
        [HttpGet("{id}")]
        public Dica Get(Guid id)
        {
            try
            {
                return _dicaRepository.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Adiciona uma nova dica
        /// </summary>
        /// <param name="dica">Dica que será adicionada</param>
        [HttpPost]
        public void Post([FromForm] Dica dica)
        {
            try
            {
                if (dica.Imagem != null)
                {
                    var urlImagem = Upload.Local(dica.Imagem);

                    dica.UrlImagem = urlImagem;
                }

                _dicaRepository.Adicionar(dica);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Edita determinada dica
        /// </summary>
        /// <param name="id">Id novo da dica</param>
        /// <param name="dica">Dica que será editada</param>
        [HttpPut("{id}")]
        public void Put(Guid id, Dica dica)
        {
            try
            {
                dica.IdDica = id;
                _dicaRepository.Editar(dica);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Remove determinada dica
        /// </summary>
        /// <param name="id">Id da dica que será excluída</param>
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            try
            {
                _dicaRepository.Remover(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}