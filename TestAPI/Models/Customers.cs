using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestAPI.Models
{
    public class Customers
    {
        [Key]
        public int PKCustomers { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Customer { get; set; }
        [Required]
        [Column(TypeName = "varchar(5)")]
        public string Prefix { get; set; }


        [Display(Name = "FKBuilding")]
        public virtual int FKBuilding { get; set; }

        [ForeignKey("FKBuilding")]
        public virtual Buildings Buildings { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Avaliable { get; set; }

        
        
    }
}
