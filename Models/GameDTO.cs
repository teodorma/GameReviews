namespace GameReviews.Models
{
    public class GameDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Platform { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Developer { get; set; }
        public double AverageRating { get; set; }
        public string CategoryName { get; set; }
        public string PublisherName { get; set; }
    }
}