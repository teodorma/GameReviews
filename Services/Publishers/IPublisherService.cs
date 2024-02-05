using GameReviews.Models.Publishers;
using Microsoft.AspNetCore.Mvc;

namespace GameReviews.Services.Publishers
{
    public interface IPublisherService
    {
        Task CreatePublisher(PublisherDTO c);
        Task DeletePublisher(PublisherDTO cat);
        Task<Publisher> findbyname(string name);
        Task PutPublisher(int id, PublisherDTO Publisher);
        Task<IEnumerable<PublisherDTO>> GetPublisher();
        Task<PublisherDTO> GetPublisher(int id);
    }
}
