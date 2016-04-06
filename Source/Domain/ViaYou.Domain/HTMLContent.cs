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
        public int ID { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public Region Region { get; set; }
        public int Order { get; set; }
    }
}
