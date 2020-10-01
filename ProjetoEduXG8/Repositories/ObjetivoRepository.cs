using ProjetoEduXG8.Context;
using ProjetoEduXG8.Domains;
using ProjetoEduXG8.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduXG8.Repository
{
    public class ObjetivoRepository : iObjetivo
    {
        private readonly EduXContext _ctx;

        public ObjetivoRepository()
        {
            _ctx = new EduXContext();
        }

        public void Adicionar(Objetivo objetivo)
        {
            try
            {
                _ctx.Objetivos.Add(objetivo);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Objetivo BuscarPorId(Guid id)
        {
            try
            {
                Objetivo objetivo = _ctx.Objetivos.Find(id);

                return objetivo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Objetivo objetivo)
        {
            try
            {
                Objetivo objetivoTemp = BuscarPorId(objetivo.IdObjetivo);

                if (objetivoTemp == null)
                    throw new Exception("Objetivo não encontrado");

                objetivoTemp.Descricao = objetivo.Descricao;
                _ctx.Objetivos.Update(objetivoTemp);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Objetivo> Listar()
        {
            try
            {
                List<Objetivo> objetivos = _ctx.Objetivos.ToList();

                return objetivos;
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
                Objetivo objetivo = BuscarPorId(id);

                if (objetivo == null)
                    throw new Exception("Objetivo não encontrado");

                _ctx.Objetivos.Remove(objetivo);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}