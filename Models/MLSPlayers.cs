using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1_CésarSilva_1184519_JonnathanLanuza_1082219.Models
{
    public class MLSplayers
    {
        public string Club { get; set; }
        public string Name { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Position { get; set; }
        public int? Salary { get; set; }
    }
}
