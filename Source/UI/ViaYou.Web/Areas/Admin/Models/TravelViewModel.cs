using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ViaYou.Domain;
using ViaYou.Domain.Users;

namespace ViaYou.Web.Areas.Admin.Models
{
    public class TravelViewModel
    {
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
    }
}