using ViaYou.Domain.Enums;

namespace ViaYou.Domain
{
    public class Advice
    {
        public Advice()
        {
                
        }
        public Advice(string text, Customer customer)
        {
            Text = text;
            Customer = customer;
        }
        public int Id { get; set; }
        public string Text { get; set; }
        public Customer Customer { get; set; }

        public void Update(string text, Customer customer)
        {
            this.Text = text;
            this.Customer = customer;
        }
    }
}
