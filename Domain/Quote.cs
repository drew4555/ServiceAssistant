using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Quote
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Tech")]
        public int TechId { get; set; }
        //public Tech Tech { get; set; }
        //[NotMapped]
        //public Service[] Service { get; set; }
        public DateTime DateTime { get; set; }
        public double RepairCost { get; set; }

    }
}
