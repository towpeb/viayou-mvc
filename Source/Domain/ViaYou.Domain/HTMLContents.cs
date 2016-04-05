using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViaYou.Domain.Enums;

namespace ViaYou.Domain
{
    public class HTMLContents
    {
        public int ID { get; set; }
        [Required]
        public string text { get; set; }
        [Required]
        public Region region { get; set; }
        public int order { get; set; }
    }
}
