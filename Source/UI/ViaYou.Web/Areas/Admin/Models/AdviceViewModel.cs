using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ViaYou.Domain;
using ViaYou.Domain.Enums;
using ViaYou.Infraestructure.Mapping;

namespace ViaYou.Web.Areas.Admin.Models
{
    public class AdviceViewModel: IMapFrom<Advice>
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public Customer Customer { get; set; }
    }
}