using ProjetoEduxG8.Interface;
using ProjetoEduXG8.Context;
using ProjetoEduXG8.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxG8.Repositories
{

    public class AlunoTurmaRepository : iAlunoTurma
    {
        private readonly EduXContext _ctx;

        public AlunoTurmaRepository()
        {
            _ctx = new EduXContext();
        }

        public void Adicionar(AlunoTurma alunoTurma)
        {
            try
            {
                _ctx.AlunosTurmas.Add(alunoTurma);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public AlunoTurma BuscarPorId(Guid id)
        {
            try
            {
                AlunoTurma alunosTurmas = _ctx.AlunosTurmas.Find(id);

                return alunosTurmas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(AlunoTurma alunoTurma)
        {
            try
            {
                AlunoTurma alunoTurmaTemp = BuscarPorId(alunoTurma.IdAlunoTurma);

                if (alunoTurmaTemp == null)
                    throw new Exception("Aluno não encontrado");

                alunoTurmaTemp.IdUsuario = alunoTurma.IdUsuario;
                alunoTurmaTemp.IdTurma = alunoTurma.IdTurma;

                _ctx.AlunosTurmas.Update(alunoTurmaTemp);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<AlunoTurma> Listar()
        {
            try
            {
                List<AlunoTurma> alunosTurmas = _ctx.AlunosTurmas.ToList();

                return alunosTurmas;
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
                AlunoTurma alunoTurma = BuscarPorId(id);

                if (alunoTurma == null)
                    throw new Exception("Aluno não encontrado");

                _ctx.AlunosTurmas.Remove(alunoTurma);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}