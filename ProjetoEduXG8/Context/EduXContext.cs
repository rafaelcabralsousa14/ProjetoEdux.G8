using Microsoft.EntityFrameworkCore;
using ProjetoEduXG8.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduXG8.Context
{
    public class EduXContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<AlunoTurma> AlunosTurmas { get; set; }
        public DbSet<ProfessorTurma> ProfessorTurmas { get; set; }
        public DbSet<Instituicao> Instituicoes { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<ObjetivoAluno> ObjetivosAlunos { get; set; }
        public DbSet<Dica> Dicas { get; set; }
        public DbSet<Perfil> Perfils { get; set; }
        public DbSet<Objetivo> Objetivos { get; set; }
        public DbSet<Curtida> Curtidas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"data Source=DESKTOP-LJ2FRJ8\SQLEXPRESS;Initial Catalog=ProjetoEdux;User ID=sa;Password=sa132");

            base.OnConfiguring(optionsBuilder);
        }

    }
}