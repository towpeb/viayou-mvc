using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ViaYou.Domain
{
    public class Question
    {
        public int Id { get; set; }
        [Required]
        public string Identifier { get; set; }
        [Required]
        public string Text { get; set; }
        public ICollection<Answer> Answers { get; set; }

        public Question()
        {

        }

        public Question(string identifier, string text, ICollection<Answer> answers)
        {
            Identifier = identifier;
            Text = text;
            Answers = answers;
        }

        public void Update(string identifier, string text)
        {
            Identifier = identifier;
            Text = text;
        }

        public void AddAnswer(Answer answer)
        {
            if (Answers == null)
                Answers = new List<Answer>();

            Answers.Add(answer);
        }

        public void DropAnswer(Answer answer)
        {
            Answers.Remove(Answers.First(a => a.Id == answer.Id));
        }
    }
}
