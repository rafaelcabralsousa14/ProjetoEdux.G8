using ProjetoEduXG8.Context;
using ProjetoEduXG8.Domains;
using ProjetoEduXG8.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduXAPI.Repositories
{
    public class CategoriaRepository : iCategoria
    {
        private readonly EduXContext _ctx;
        public CategoriaRepository()
        {
            _ctx = new EduXContext();
        }

        public void Adicionar(Categoria categoria)
        {
            try
            {
                _ctx.Categorias.Add(categoria);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        
        public Categoria BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Categorias.FirstOrDefault(c => c.IdCategoria == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Categoria categoria)
        {
            try
            {
                Categoria categoriaTemp = BuscarPorId(categoria.IdCategoria);

                if (categoriaTemp == null)
                    throw new Exception("Categoria não encontrada");

                categoriaTemp.Tipo = categoria.Tipo;

                _ctx.Categorias.Update(categoriaTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Categoria> Listar()
        {
            try
            {
                return _ctx.Categorias.ToList();
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
                Categoria categoriaTemp = BuscarPorId(id);

                if (categoriaTemp == null)
                    throw new Exception("Categoria não encontrada");

                _ctx.Categorias.Remove(categoriaTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}