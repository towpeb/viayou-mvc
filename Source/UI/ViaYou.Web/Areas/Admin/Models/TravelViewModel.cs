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

        public int? CustomerId { get; set; }
        [Required]
        public int? TravelerId { get; set; }
      

        public int? CityOriginId { get; set; }          
     

        public int? CityDestinationId { get; set; }
        
        public IEnumerable<Package> Packages { get; set; }
                
        public IEnumerable<SelectListItem> CitiesListOrig { get; internal set; }
        public IEnumerable<SelectListItem> CitiesListDest { get; internal set; }





    }
}