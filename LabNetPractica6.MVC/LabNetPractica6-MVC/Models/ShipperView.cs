using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabNetPractica6_MVC.Models
{
    public class ShipperView
    {
        public int ShipperID { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [DisplayName("Nombre de la compañía")]
        [StringLength(40)]
        public string CompanyName { get; set; }

        [StringLength(24)]
        [DisplayName("Número de teléfono")]
        public string Phone { get; set; }
    }
}
