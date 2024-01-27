namespace GameReviews.Models
{
    public class UserProfile
    {
        public int Id { get; set; } // Cheie primară separată
        public int UserId { get; set; } // Cheie străină pentru User
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string ProfilePictureUrl { get; set; }

        public User User { get; set; }
    }


}
