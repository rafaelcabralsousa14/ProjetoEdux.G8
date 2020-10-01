using ProjetoEduXG8.Context;
using ProjetoEduXG8.Domains;
using ProjetoEduXG8.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduXG8.Repositories
{
    public class CursoRepository : iCurso
    {
        private readonly EduXContext _ctx;
        public CursoRepository()
        {
            _ctx = new EduXContext();
        }
        
        public void Adicionar(Curso curso)
        {
            try
            {
                _ctx.Cursos.Add(curso);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Curso BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Cursos.FirstOrDefault(c => c.IdCurso == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Curso curso)
        {
            try
            {
                Curso cursoTemp = BuscarPorId(curso.IdCurso);

                if (cursoTemp == null)
                    throw new Exception("Curso não encontrado");

                cursoTemp.Titulo = curso.Titulo;


                _ctx.Cursos.Update(cursoTemp);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Curso> Listar()
        {
            try
            {
                return _ctx.Cursos.ToList();
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
                Curso cursoTemp = BuscarPorId(id);

                if (cursoTemp == null)
                    throw new Exception("Curso não encontrado");

                _ctx.Cursos.Remove(cursoTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}