using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        public string PartName { get; set; }
        public double PartCost { get; set; }
        public double LaborRate { get; set; }
        public double TotalCost { get; set; }
        public bool IsApproved { get; set; }
        [ForeignKey("Quote")]
        public int QuoteNumber { get; set; }
        public Quote Quote { get; set; }

        
    }
}
