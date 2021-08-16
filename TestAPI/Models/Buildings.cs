using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestAPI.Models
{
    public class Buildings
    {
         
        [Key]
        public int PKBuilding { get; set; }

        [Required]
        [Column(TypeName ="varchar(50)")]
        public string Building { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Avaliable { get; set; }

        public ICollection<Customers> Customers { get; set; }

        
    }
}
