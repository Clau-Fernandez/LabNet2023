﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LabNetPractica7.WEB.API.Models
{
    public class CategoryModel
    {
        public int CategoryID { get; set; }
 
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [DisplayName("Nombre de la categoría")]
        [RegularExpression(@"^[a-zA-Z\s]+(/[a-zA-Z\s]+)*$", ErrorMessage = "El nombre debe ser una cadena de caracteres alfabéticos. Puedes agregar barras diagonales para separar términos '/'")]
        [StringLength(25, ErrorMessage = "El nombre de categoría debe tener máximo 25 caracteres.")]
        public string CategoryName { get; set; }

        [RegularExpression(@"^[a-zA-Z,\s]+$", ErrorMessage = "Sólo caracteres alfabéticos")]
        [StringLength(80, ErrorMessage = "La descripción debe tener máximo 100 caracteres.")]
        [DisplayName("Descripción")]
        public string Description { get; set; }
    }
}