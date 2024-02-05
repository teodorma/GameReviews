using GameReviews.Data;
using GameReviews.Models.Publishers;
using GameReviews.Repositories.Publishers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace GameReviews.Repositories.Publishers
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly GameReviewContext context;
        public PublisherRepository(GameReviewContext context)
        {
            this.context = context;
        }
        public async Task CreatePublisher(Publisher c)
        {
            await context.Publishers.AddAsync(c);
            await context.SaveChangesAsync();
        }
        public async Task DeletePublisher(Publisher pub)
        {
            context.Publishers.Remove(pub);
            await context.SaveChangesAsync();
        }
        public async Task<Publisher> findbyname(string nume)
        {
            var Publisher = await context.Publishers.Where(pub => pub.Name.Contains(nume)).FirstOrDefaultAsync();
            if (Publisher == null) { throw new Exception("nu exista"); }
            return Publisher;
        }
        public async Task<IEnumerable<Publisher>> GetPublisher()
        {
            return await context.Publishers.ToListAsync();
        }
        public async Task<Publisher> findbyid(int id)
        {
            var Publisher = await context.Publishers.FirstOrDefaultAsync(pub => pub.Id == id);
            if (Publisher == null) { throw new Exception("nu exista"); }
            return Publisher;
        }

        public async Task PutPublisher(int id, Publisher Publisher)
        {
            context.Publishers.Update(Publisher);
            await context.SaveChangesAsync();
        }
    }
}
