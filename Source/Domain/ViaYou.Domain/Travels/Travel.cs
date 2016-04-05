using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ViaYou.Domain.Users;

namespace ViaYou.Domain.Travels
{
    public class Travel
    {
        public Travel()
        {
            
        }
        public Travel(int id, DateTime date, decimal grade, City origin, City destination, ApplicationUser customer, ApplicationUser traveler, ICollection<Package> packages)
        {
            Id = id;
            Date = date;
            Grade = grade;
            Origin = origin;
            Destination = destination;
            Customer = customer;
            Traveler = traveler;
            Packages = packages;
        }
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public decimal Grade { get; set; }
        [Required]
        public City Origin { get; set; }
        [Required]
        public City Destination { get; set; }
        [Required]
        public ApplicationUser Customer { get; set; }
        [Required]
        public ApplicationUser Traveler { get; set; }
        public ICollection<Package> Packages { get; set; }
    }
}
