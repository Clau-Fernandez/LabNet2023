using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabNetPractica6_MVC.Models
{
    public class CategoryView
    {
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [DisplayName("Nombre de la categoría")]
        [RegularExpression(@"^[a-zA-Z]+(\s?[a-zA-Z]+)?(/[a-zA-Z]+(\s?[a-zA-Z]+)?)*$", ErrorMessage = "El nombre debe ser una cadena de caracteres alfabéticos. Puedes agregar barras diagonales para separar términos '/'")]
        [StringLength(25, ErrorMessage = "El nombre de categoría debe tener máximo 25 caracteres.")]
        public string CategoryName { get; set; }

        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "La descripción debe ser una cadena de caracteres alfabéticos")]
        [StringLength(100, ErrorMessage = "La descripción debe tener máximo 100 caracteres.")]
        [DisplayName("Descripción")]
        public string Description { get; set; }
    }
}