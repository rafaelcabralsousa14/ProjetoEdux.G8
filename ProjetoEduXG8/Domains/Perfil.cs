﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduXG8.Domains
{
    public class Perfil
    {
        [Key]
        public Guid IdPerfil { get; set; }
        public string Permissao { get; set; }

        public Perfil()
        {
            IdPerfil = Guid.NewGuid();
        }
    }
}