﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    class RepairHistory
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public double Cost { get; set; }
        public int RepairOrder { get; set; }
        [NotMapped]
        public Service[] Services { get; set; }
        [ForeignKey("Tech")]
        public int TechId { get; set; }
        public Tech Tech { get; set; }
        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
