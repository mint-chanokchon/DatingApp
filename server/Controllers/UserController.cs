using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.Entities;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly DataContext _context;

    public UserController(DataContext context)
    {
            _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<AppUser>> GetUser()
    {
        return Ok(_context.Users.ToList());
    }

    [HttpGet("{id}")]
    public ActionResult<AppUser> GetUser(string id)
    {
        return Ok(_context.Users.Find(id));
    }
}
