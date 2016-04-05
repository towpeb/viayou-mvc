using System.ComponentModel.DataAnnotations;
using ViaYou.Domain.Travels;

namespace ViaYou.Domain
{
    public class Package
    {
        public Package()
        {
            
        }
        public Package(int id, Category category, ContainedIn containedIn, Travel travel)
        {
            Id = id;
            Category = category;
            ContainedIn = containedIn;
            Travel = travel;
        }
        public int Id { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        public ContainedIn ContainedIn { get; set; }
        [Required]
        public Travel Travel { get; set; }
    }
}
