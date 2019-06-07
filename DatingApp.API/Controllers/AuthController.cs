using Microsoft.AspNetCore.Mvc;
using DatingApp.API.Data;
using System.Threading.Tasks;
using DatingApp.API.Models;
using DatingApp.API.Dtos;

namespace DatingApp.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly IAuthRepository _repo;


    public AuthController(IAuthRepository repo)
    {
      this._repo = repo;
    }

    [HttpPost]
    public async Task<ActionResult> Register(UserForRegister userForRegister)
    {
        //validate request

        userForRegister.Username = userForRegister.Username.ToLower();

        if(await _repo.UserExists(userForRegister.Username))
            return BadRequest("Username already taken!");

        var userToCreate = new User
        {
            Username = userForRegister.Username
        };

        var createdUser = await _repo.Register(user:userToCreate, password:userForRegister.Password);

        return StatusCode(201);
    }


  }
}