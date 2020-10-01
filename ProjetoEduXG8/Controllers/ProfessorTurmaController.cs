﻿using Microsoft.AspNetCore.Mvc;
using ProjetoEduXG8.Domains;
using ProjetoEduxG8.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoEduxG8.Interface;

namespace ProjetoEduxG8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorTurmaController : ControllerBase
    {
        private readonly iProfessorTurma _professorTurmaRepository;

        public ProfessorTurmaController()
        {
            _professorTurmaRepository = new ProfessorTurmaRepository();
        }

        /// <summary>
        /// Lista os professores adicionados
        /// </summary>
        /// <returns>Lista de professores</returns>
        [HttpGet]
        public List<ProfessorTurma> Get()
        {
            try
            {
                return _professorTurmaRepository.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca professor por seu Id
        /// </summary>
        /// <param name="id">Id do professor buscado</param>
        /// <returns>Professor com o Id buscado</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {

                ProfessorTurma professorTurma = _professorTurmaRepository.BuscarPorId(id);


                if (professorTurma == null)
                    return NotFound();

                return Ok(professorTurma);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Adiciona um novo professor
        /// </summary>
        /// <param name="professorTurma">Professor que será adicionado</param>
        [HttpPost]
        public IActionResult Post([FromForm] ProfessorTurma professorTurma)
        {
            try
            {

                _professorTurmaRepository.Adicionar(professorTurma);

                return Ok(professorTurma);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Edita um professor existente
        /// </summary>
        /// <param name="id">Id nova do professor</param>
        /// <param name="professorTurma">Professor que será editado</param>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, ProfessorTurma professorTurma)
        {
            try
            {
                var ProfessorTurma = _professorTurmaRepository.BuscarPorId(id);

                if (ProfessorTurma == null)
                    return NotFound();

                professorTurma.IdProfessorTurma = id;
                _professorTurmaRepository.Editar(professorTurma);

                return Ok(professorTurma);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Remove um professor existente
        /// </summary>
        /// <param name="id">Id do professor que será deletado</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _professorTurmaRepository.Remover(id);
                return Ok(id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }

}
