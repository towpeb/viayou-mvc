using System;
using System.ComponentModel.DataAnnotations;

namespace ViaYou.Domain.Travels
{
    public class Travel
    {
        public int Id { get; set; }
        [Required]
        public int OriginCode { get; set; }
        [Required]
        public int DestinationCode { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public int Calification { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        public ContainedIn ContainedIn { get; set; }
    }
}
