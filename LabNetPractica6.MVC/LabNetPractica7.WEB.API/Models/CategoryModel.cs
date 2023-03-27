using System;
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
        [Required]

        [StringLength(25)]
        public string CategoryName { get; set; }
        [Required]
        [StringLength(80)]
        public string Description { get; set; }
    }
}