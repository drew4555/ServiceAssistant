using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace serviceAssistants.Models
{
    public class QuoteViewModel
    {
        public Quote Quote { get; set; }
        public Service[] Services { get; set; }
    }
}
