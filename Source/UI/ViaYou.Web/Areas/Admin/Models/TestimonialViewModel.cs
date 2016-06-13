using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViaYou.Domain;
using ViaYou.Domain.Users;
using ViaYou.Infraestructure.Mapping;

namespace ViaYou.Web.Areas.Admin.Models
{
    public class TestimonialViewModel : IMapFrom<Testimonial>
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public byte[] Picture { get; set; }
        public ApplicationUser User { get; set; }
        public IEnumerable<SelectListItem> AvailableUsers { get; internal set; }
    }
}