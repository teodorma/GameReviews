namespace GameReviews.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string WebsiteUrl { get; set; }
        public DateTime FoundedDate { get; set; }
        public string Headquarters { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
