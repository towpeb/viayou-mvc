using System.ComponentModel.DataAnnotations;
using ViaYou.Domain.Travels;

namespace ViaYou.Domain
{
    public class Package
    {
        public Package()
        {

        }
        public Package(int id, Category category, Container containedIn, Travel travel)
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
        public Container ContainedIn { get; set; }
        [Required]
        public Travel Travel { get; set; }
        public string GetCategory
        {
            get
            {
                if (Category != null)
                    return Category.Name;
                else
                    return "";
            }
        }
        public string GetConatiner
        {
            get
            {
                if (ContainedIn != null)
                    return ContainedIn.Name;
                else
                    return "";
            }
        }

        public int GetTravel
        {
            get
            {
                if (Travel != null)
                    return Travel.Id;
                else
                    return 0;
            }
        }

        public void Update(Category category, Container containedIn, Travel travel)
        {
            Category = category;
            ContainedIn = containedIn;
            Travel = travel;
        }
    }
}
