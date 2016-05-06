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
        public Travel(DateTime date, decimal grade, City origin, City destination, ApplicationUser customer, ApplicationUser traveler, ICollection<Package> packages)
        {            
            Date = date;
            Grade = grade;
            CityOrigin = origin;
            CityDestination = destination;
            Customer = customer;
            Traveler = traveler;
            Packages = packages;
        }
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public decimal Grade { get; set; }

        public int? CustomerId { get; set; }
        [Required]
        public ApplicationUser Customer { get; set; }

        public int? TravelerId { get; set; }
        public ApplicationUser Traveler { get; set; }

        public int CityOriginId { get; set; }
        [Required]
        public City CityOrigin { get; set; }

        public int? CityDestinationId { get; set; }
        public City CityDestination { get; set; }

        public ICollection<Package> Packages { get; set; }

        public void Update(DateTime time, decimal grade/*, ApplicationUser customer, ApplicationUser traveler, City cityOrigin, City cityDestinatation*/)
        {
            this.Date = time;
            this.Grade = grade;
            //this.Customer = customer;
            //this.Traveler = traveler;
            //this.CityOrigin = cityOrigin;
            //this.CityDestination = cityDestinatation;
        }
    }
}
