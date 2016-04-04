using System.ComponentModel.DataAnnotations;

namespace ViaYou.Domain.Travels
{
    public class ContainedIn
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
    }
}
