using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ViaYou.Domain
{
    public class Answer
    {
        public Answer()
        {

        }
        public Answer(string text, Question question)
        {
            Text = text;
            Question = question;
        }
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public Question Question { get; set; }
        public void Update(string text, Question question)
        {
            Text = text;
            if (question != null)
                Question = question;
        }
        public string GetQuestion
        {
            get
            {
                if (Question != null)
                    return Question.Identifier;
                else
                    return "";
            }
        }

        public IEnumerable<string> Terms()
        {
            yield return Text;
            yield return Question?.Identifier ?? "";
        }
    }
}
