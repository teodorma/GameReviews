using GameReviews.Data;
using GameReviews.Models.Publishers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameReviews.Repositories.Publishers
{
    public interface IPublisherRepository
    {
        Task CreatePublisher(Publisher c);
        Task DeletePublisher(Publisher pub);
        Task<Publisher> findbyname(string name);
        Task PutPublisher(int id, Publisher Publisher);
        Task<IEnumerable<Publisher>> GetPublisher();
        Task<Publisher> findbyid(int id);
    }
}