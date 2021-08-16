using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestAPI.Models
{
    public class PartNumbers
    {
        [Key]
        public int PKPartNumbers { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string PartNumber { get; set; }



        [Display(Name = "FKCustomer")]
        public virtual int FKCustomer { get; set; }

        [ForeignKey("FKCustomer")]
        public virtual Customers Customers { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Avaliable { get; set; }

    }
}
