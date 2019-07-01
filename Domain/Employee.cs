using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public int EmployeeNumber { get; set; }
        public string EmployeeRole { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [ForeignKey("ApplicationUser")]
        public string applicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
