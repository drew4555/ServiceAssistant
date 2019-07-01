using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace serviceAssistants.Models
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        public List<string> Roles { get; set; }
        public Client client { get; set; }
    }
}
