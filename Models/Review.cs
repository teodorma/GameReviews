namespace GameReviews.Models
{
    public class Review
    {
        public int Id { get; set; } // Cheie primară
        public string UserId { get; set; }
        public int GameId { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public DateTime DatePosted { get; set; }

        public Game Game { get; set; }
        public User User { get; set; }
    }
}
