using System.ComponentModel.DataAnnotations;

namespace ViaYou.Domain
{
    public class City
    {
        public City()
        {
            
        }
        public City(string name, string code, Country country)
        {
            Name = name;
            Code = code;
            Country = country;
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public Country Country { get; set; }
    }
}
