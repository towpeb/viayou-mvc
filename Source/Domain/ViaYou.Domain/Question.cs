using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ViaYou.Domain
{
    public class Question
    {
        public Question()
        {

        }

        public Question(string text, ICollection<Answer> answers)
        {
            Text = text;
            Answers = answers;
        }
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public ICollection<Answer> Answers { get; set; }

        public void Update(string text, ICollection<Answer> answers)
        {
            Text = text;
            Answers = answers;
        }
    }
}
