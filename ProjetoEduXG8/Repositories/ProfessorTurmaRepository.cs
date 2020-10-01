using ProjetoEduxG8.Interface;
using ProjetoEduXG8.Context;
using ProjetoEduXG8.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxG8.Repositories
{

    public class ProfessorTurmaRepository : iProfessorTurma
    {
        private readonly EduXContext _ctx;

        public ProfessorTurmaRepository()
        {
            _ctx = new EduXContext();
        }

        public void Adicionar(ProfessorTurma professorTurma)
        {
            try
            {
                _ctx.ProfessorTurmas.Add(professorTurma);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public ProfessorTurma BuscarPorId(Guid id)
        {
            try
            {
                ProfessorTurma professorTurma = _ctx.ProfessorTurmas.Find(id);

                return professorTurma;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(ProfessorTurma professorTurma)
        {
            try
            {
                ProfessorTurma professorTurmaTemp = BuscarPorId(professorTurma.IdProfessorTurma);

                if (professorTurmaTemp == null)
                    throw new Exception("Professor não encontrado");

                professorTurmaTemp.IdUsuario = professorTurma.IdUsuario;
                professorTurmaTemp.IdTurma = professorTurma.IdTurma;

                _ctx.ProfessorTurmas.Update(professorTurmaTemp);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ProfessorTurma> Listar()
        {
            try
            {
                List<ProfessorTurma> professorTurmas = _ctx.ProfessorTurmas.ToList();

                return professorTurmas;
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
                ProfessorTurma professorTurma = BuscarPorId(id);

                if (professorTurma == null)
                    throw new Exception("Professor não encontrado");

                _ctx.ProfessorTurmas.Remove(professorTurma);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }

}