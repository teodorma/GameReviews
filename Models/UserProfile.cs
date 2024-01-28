namespace GameReviews.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string UserId { get; set; } 
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string ProfilePictureUrl { get; set; }

        public User User { get; set; }
    }

}
