using ProjetoEduXG8.Context;
using ProjetoEduXG8.Domains;
using ProjetoEduXG8.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduXG8.Repository
{
    public class CurtidaRepository : iCurtida
    {
        private readonly EduXContext _ctx;

        public CurtidaRepository()
        {
            _ctx = new EduXContext();
        }

        public void Adicionar(Curtida curtida)
        {
            try
            {
                _ctx.Curtidas.Add(curtida);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Curtida BuscarPorId(Guid id)
        {
            try
            {
                Curtida curtida = _ctx.Curtidas.Find(id);

                return curtida;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Curtida> Listar()
        {
            try
            {
                List<Curtida> curtidas = _ctx.Curtidas.ToList();

                return curtidas;
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
                Curtida curtida = BuscarPorId(id);

                if (curtida == null)
                    throw new Exception("Curtida não encontrado");

                _ctx.Curtidas.Remove(curtida);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}