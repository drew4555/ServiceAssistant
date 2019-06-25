using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public string Vin { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
