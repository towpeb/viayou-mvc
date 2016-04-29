using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ViaYou.Domain.Enums;
using ViaYou.Domain;
using ViaYou.Infraestructure.Mapping;

namespace ViaYou.Web.Areas.Admin.Models
{
    public class HTMLContentViewModel : IMapFrom<HTMLContent>
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public Region Region { get; set; }
        public int Order { get; set; }
    }
}