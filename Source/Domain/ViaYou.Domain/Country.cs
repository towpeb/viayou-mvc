using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ViaYou.Domain
{
    public class Country
    {
        public Country()
        {
            
        }

        public Country(string name, string code, ICollection<City> cities = null)
        {
            Name = name;
            Code = code;
            Cities = cities;
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
