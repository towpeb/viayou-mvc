using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ViaYou.Domain;
using ViaYou.Infraestructure.Mapping;

namespace ViaYou.Web.Areas.Admin.Models
{
    public class KeyWordViewModel: IMapFrom<KeyWord>
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Keywords { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        [MaxLength(200)]
        public string FacebookMsg { get; set; }
        public byte[] FacebookImg { get; set; }
        [MaxLength(200)]
        public string TwitterMsg { get; set; }
        public byte[] TwitterImg { get; set; }
        public bool Active { get; set; }
    }
}