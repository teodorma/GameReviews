using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameReviews.Data;
using GameReviews.Services.Publishers;
using GameReviews.Models.Publishers;

[Route("api/[controller]")]
[ApiController]
public class PublisherController : ControllerBase
{
    private readonly IPublisherService _publishersService;

    public PublisherController(IPublisherService context)
    {
        _publishersService = context;
    }

    [HttpGet]
    public async Task<IEnumerable<PublisherDTO>> Getpublishers()
    {
        return await _publishersService.GetPublisher();
    }

    [HttpGet("{id}")]
    public async Task<PublisherDTO> GetPublisher(int id)
    {
        return await _publishersService.GetPublisher(id);

    }

    [HttpPost]
    public async Task<ActionResult> CreatePublisher(PublisherDTO Publisher)
    {
        await _publishersService.CreatePublisher(Publisher);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutPublisher(int id, PublisherDTO Publisher)
    {
        await _publishersService.PutPublisher(id, Publisher);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeletePublisher(PublisherDTO nume)
    {
        await _publishersService.DeletePublisher(nume);
        return Ok();
    }
}
