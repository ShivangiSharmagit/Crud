using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Crud.Models
{
    public class Class1
    {
        public int ID { get; set; }
        [Required]
        
        public string NAME { get; set; }
        [Required]
        public string GENDER { get; set; }
        [Required]
        public string DEPARTMENT { get; set; }
        [Required]
        public decimal ? SALARY { get; set; }
        [Required]
        public string ADDRESS { get; set; }
    }
}