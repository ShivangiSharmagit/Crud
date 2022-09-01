using Crud.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Crud.Models
{
    public class Class3
    {
        [Key]
        public int EID { get; set; }
        [Required]
        public string COURSE { get; set; }
        [Required]
        public string BRANCH { get; set; }
        [Required]
        public int ? PERCENTAGEE { get; set; }
     
    }
}