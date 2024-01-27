namespace GameReviews.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Platform { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public int PublisherId { get; set; }
        public string Developer { get; set; }
        public double AverageRating { get; set; }

        public Publisher Publisher { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
