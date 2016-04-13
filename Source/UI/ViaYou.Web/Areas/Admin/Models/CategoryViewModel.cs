using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ViaYou.Domain.Travels;
using ViaYou.Infraestructure.Mapping;

namespace ViaYou.Web.Areas.Admin.Models
{
    public class CategoryViewModel: IMapFrom<Category>
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}