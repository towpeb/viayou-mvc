using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViaYou.Domain.Enums;

namespace ViaYou.Domain
{
    public class HTMLContent
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public Region Region { get; set; }
        public int Order { get; set; }
    }
}
