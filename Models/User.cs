using GameReviews.Models;
using Microsoft.AspNetCore.Identity;
namespace GameReviews.Models
{
    public class User : IdentityUser
    {
        public string Role { get; set; }

        public UserProfile UserProfile { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }

}
