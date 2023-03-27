using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabNetPractica7.WEB.API.Models
{
    public class ShipperModel
    {
        public int ShipperID { get; set; }
        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(24)]
        public string Phone { get; set; }
    }
}