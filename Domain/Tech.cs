using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Tech
    {
        [Key]
        public int id { get; set; }
        public string FirstName { get; set; }
        public int TechId { get; set; }
        [ForeignKey("ApplicationUser")]
        public string applicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
