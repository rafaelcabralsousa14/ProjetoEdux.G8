using ProjetoEduXG8.Context;
using ProjetoEduXG8.Domains;
using ProjetoEduXG8.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduXG8.Repositories
{
    public class InstituicaoRepository : iInstituicao
    {
        private readonly EduXContext _ctx;
        public InstituicaoRepository()
        {
            _ctx = new EduXContext();
        }

        public void Adicionar(Instituicao instituicao)
        {
            try
            {
                _ctx.Instituicoes.Add(instituicao);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        
        public Instituicao BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Instituicoes.FirstOrDefault(c => c.IdInstituicao == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public void Editar(Instituicao instituicao)
        {
            try
            {
                Instituicao instituicaTemp = BuscarPorId(instituicao.IdInstituicao);

                if (instituicaTemp == null)
                    throw new Exception("Instituição não encontrada");

                instituicaTemp.Nome = instituicao.Nome;
                instituicaTemp.Logradouro = instituicao.Logradouro;
                instituicaTemp.Numero = instituicao.Numero;
                instituicaTemp.Complemento = instituicao.Complemento;
                instituicaTemp.Bairro = instituicao.Bairro;
                instituicaTemp.Cidade = instituicao.Cidade;
                instituicaTemp.UF = instituicao.UF;
                instituicaTemp.CEP = instituicao.CEP;

                _ctx.Instituicoes.Update(instituicaTemp);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Instituicao> Listar()
        {
            try
            {
                return _ctx.Instituicoes.ToList();
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
                Instituicao instituicaTemp = BuscarPorId(id);

                if (instituicaTemp == null)
                    throw new Exception("Instituição não encontrada");

                _ctx.Instituicoes.Remove(instituicaTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}