using ViaYou.Domain.Enums;

namespace ViaYou.Domain
{
    public class Advice
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Customer Customer { get; set; }
    }
}
