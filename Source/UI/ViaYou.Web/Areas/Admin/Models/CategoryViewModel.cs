using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ViaYou.Web.Areas.Admin.Models
{
    public class CategoryViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}