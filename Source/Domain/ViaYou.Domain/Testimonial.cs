using System.ComponentModel.DataAnnotations;
using ViaYou.Domain.Users;

namespace ViaYou.Domain
{
    public class Testimonial
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public byte[] Picture { get; set; }
        public ApplicationUser User { get; set; }

        public void Update(string text, byte[] picture, ApplicationUser user)
        {
            Text = text;
            Picture = picture;
            User = user;
        }

        public string GetUser
        {
            get
            {
                if (User != null)
                    return User.MiddleName;
                else
                    return "";
            }
        }
    }
}
