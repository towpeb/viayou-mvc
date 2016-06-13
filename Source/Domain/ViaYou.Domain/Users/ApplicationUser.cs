using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ViaYou.Domain.Travels;

namespace ViaYou.Domain.Users
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public ICollection<Travel> Travels { get; set; }

        public void Update(string _firstName,string _lastName,string _middleName,string _userName,string _phoneNumber,string _email)
        {
           this.FirstName = _firstName;
           this.LastName = _lastName;
           this.MiddleName = _middleName;
           this.UserName = _userName;
           this.PhoneNumber = _phoneNumber;
           this.Email = _email;
        }

    }
}
