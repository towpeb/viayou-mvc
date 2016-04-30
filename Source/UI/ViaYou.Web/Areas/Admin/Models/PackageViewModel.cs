using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViaYou.Domain.Travels;

namespace ViaYou.Web.Areas.Admin.Models
{
    public class PackageViewModel
    {
        public int Id { get; set; }
        [Required]
        public int? CategoryId { get; set; }
        [Required]
        public int? ContainedInId { get; set; }
        [Required]
        public int? TravelId { get; set; }
        public IEnumerable<SelectListItem> AvailableCategories { get; internal set; }
        public IEnumerable<SelectListItem> AvailableContained { get; internal set; }
        public IEnumerable<SelectListItem> AvailableTravel { get; internal set; }

    }
}