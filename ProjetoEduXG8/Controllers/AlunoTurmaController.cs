using Microsoft.AspNetCore.Mvc;
using ProjetoEduXG8.Domains;
using ProjetoEduxG8.Interface;
using ProjetoEduxG8.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ProjetoEduxG8.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AlunoTurmaController : ControllerBase
    {
        private readonly iAlunoTurma _alunoTurmaRepository;

        public AlunoTurmaController()
        {
            _alunoTurmaRepository = new AlunoTurmaRepository();
        }

        /// <summary>
        /// Lista os alunos adicionados
        /// </summary>
        /// <returns>Lista de alunos</returns>
        [HttpGet]
        public List<AlunoTurma> Get()
        {
            try
            {
                return _alunoTurmaRepository.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca aluno por seu Id
        /// </summary>
        /// <param name="id">Id do aluno buscado</param>
        /// <returns>Aluno com o Id buscado</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                AlunoTurma alunoTurma = _alunoTurmaRepository.BuscarPorId(id);
                
                if (alunoTurma == null)
                    return NotFound();

                return Ok(alunoTurma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Professor")]
        /// <summary>
        /// Adiciona um novo aluno
        /// </summary>
        /// <param name="alunoTurma">Aluno que será adicionada</param>
        [HttpPost]
        public IActionResult Post([FromForm] AlunoTurma alunoTurma)
        {
            try
            {
                _alunoTurmaRepository.Adicionar(alunoTurma);

                return Ok(alunoTurma);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Edita um aluno existente
        /// </summary>
        /// <param name="id">Id nova do aluno</param>
        /// <param name="alunoTurma">Aluno que será editado</param>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, AlunoTurma alunoTurma)
        {
            try
            {
                var AlunoTurma = _alunoTurmaRepository.BuscarPorId(id);

                if (AlunoTurma == null)
                    return NotFound();

                alunoTurma.IdAlunoTurma = id;
                _alunoTurmaRepository.Editar(alunoTurma);

                return Ok(alunoTurma);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Remove um aluno existente
        /// </summary>
        /// <param name="id">Id do aluno que será deletado</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _alunoTurmaRepository.Remover(id);
                return Ok(id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}