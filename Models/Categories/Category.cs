namespace GameReviews.Models.Categories
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Game> Games { get; set; }
    }

}
