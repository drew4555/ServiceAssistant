using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Domain
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        [ForeignKey("ApplicationUser")]
        public string applicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
