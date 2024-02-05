using GameReviews.Models.Publishers;
using GameReviews.Repositories.Publishers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;

namespace GameReviews.Services.Publishers
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository repository;
        public PublisherService(IPublisherRepository repository)
        {
            this.repository = repository;
        }
        public async Task CreatePublisher(PublisherDTO Publisher)
        {
            var publisher = new Publisher() { Name = Publisher.Name, Description = Publisher.Description, Headquarters = Publisher.Headquarters, FoundedDate = Publisher.FoundedDate, WebsiteUrl = Publisher.WebsiteUrl };
            await repository.CreatePublisher(publisher);
        }
        public async Task DeletePublisher(PublisherDTO pub)
        {
            var deSters = await repository.findbyname(pub.Name);
            if (deSters == null)
            {
                throw new Exception("nu exista");
            }
            await repository.DeletePublisher(deSters);
        }
        public async Task<Publisher> findbyname(string name)
        {
            return await repository.findbyname(name);
        }
        public async Task<IEnumerable<PublisherDTO>> GetPublisher()
        {
            var rez = new List<PublisherDTO>();
            var Publisher = await repository.GetPublisher();
            foreach (var item in Publisher)
            {
                rez.Add(new PublisherDTO() { Description = item.Description, Name = item.Name });
            }

            return rez;
        }
        public async Task PutPublisher(int id, PublisherDTO Publisher)
        {
            var publisher = await repository.findbyid(id);
            publisher.Name = Publisher.Name;
            publisher.Description = Publisher.Description;
            await repository.PutPublisher(id, publisher);
        }
        public async Task<PublisherDTO> GetPublisher(int id)
        {

            var c = await repository.findbyid(id);
            return new PublisherDTO() { Name = c.Name, Description = c.Description };
        }
    }
}
