using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViaYou.Domain;
using ViaYou.Domain.Travels;
using ViaYou.Domain.Users;
using ViaYou.Infraestructure.Mapping;

namespace ViaYou.Web.Areas.Admin.Models
{
    public class TravelViewModel:IMapFrom<Travel>
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public decimal Grade { get; set; }

        public string CustomerId { get; set; }
        
        public string TravelerId { get; set; }

        public IEnumerable<SelectListItem> Users { get; set; }
      
        [Required]
        public int? CityOriginId { get; set; }          
     
        [Required]
        public int? CityDestinationId { get; set; }
        
        public IEnumerable<Package> Packages { get; set; }
                
        public IEnumerable<SelectListItem> CitiesList { get; internal set; }
       





    }
}