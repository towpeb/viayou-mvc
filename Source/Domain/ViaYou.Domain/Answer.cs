﻿namespace ViaYou.Domain
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
        public string Text { get; set; }
        public Question Question { get; set; }
        public void Update(string text, Question customer)
        {
            this.Text = text;
            this.Question = customer;
        }
    }
}
