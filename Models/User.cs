namespace GameReviews.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }

        // Navigational properties
        public UserProfile UserProfile { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }

}
