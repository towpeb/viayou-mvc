using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ViaYou.Domain
{
    public class Question
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
