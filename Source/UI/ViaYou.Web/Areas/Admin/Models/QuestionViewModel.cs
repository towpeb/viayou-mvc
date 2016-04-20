using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ViaYou.Domain;
using ViaYou.Infraestructure.Mapping;

namespace ViaYou.Web.Areas.Admin.Models
{
    public class QuestionViewModel : IMapFrom<Question>
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}