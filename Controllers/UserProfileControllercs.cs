using GameReviews.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameReviews.Data;
[Route("api/[controller]")]
[ApiController]
public class UserProfileController : ControllerBase
{
    private readonly GameReviewContext _context;

    public UserProfileController(GameReviewContext context)
    {
        _context = context;
    }

    // GET: api/UserProfile
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserProfile>>> GetUserProfiles()
    {
        return await _context.UserProfiles.ToListAsync();
    }

    // GET: api/UserProfile/5
    [HttpGet("{id}")]
    public async Task<ActionResult<UserProfile>> GetUserProfile(int id)
    {
        var userProfile = await _context.UserProfiles.FindAsync(id);
        if (userProfile == null)
        {
            return NotFound();
        }
        return userProfile;
    }

    // POST: api/UserProfile
    [HttpPost]
    public async Task<ActionResult<UserProfile>> PostUserProfile(UserProfile userProfile)
    {
        _context.UserProfiles.Add(userProfile);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetUserProfile), new { id = userProfile.UserId }, userProfile);
    }

    // PUT: api/UserProfile/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(string id, User user)
    {
        if (id != user.Id)
        {
            return BadRequest();
        }
        _context.Entry(user).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Users.Any(e => e.Id == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return NoContent();
    }


    // DELETE: api/UserProfile/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserProfile(int id)
    {
        var userProfile = await _context.UserProfiles.FindAsync(id);
        if (userProfile == null)
        {
            return NotFound();
        }
        _context.UserProfiles.Remove(userProfile);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
