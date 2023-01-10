﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Domain.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "Varchar(20)")]
        public string NombreUsuario { get; set; }
        [Required]
        [Column(TypeName = "Varchar(50)")]
        public string Password{ get; set;}
    }
}
