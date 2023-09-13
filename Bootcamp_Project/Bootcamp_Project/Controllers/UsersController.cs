using Bootcamp_Project.EF_Core;
using Bootcamp_Project.Models.Users;
using Bootcamp_Project.Service;
using Microsoft.AspNetCore.Mvc;


namespace Bootcamp_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService userService;
        public UsersController(EF_DataContext context)
        {
            userService = new UserService(context);
        }

        // GET: api/<UsersController>
        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            
            try
            {
                IEnumerable<UserModel> data = userService.GetUsers();
                if(!data.Any())
                {
                    return NotFound(new {errorCode=StatusCodes.Status404NotFound,errorMessage="No users found in the database"});
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new {errorCode=StatusCodes.Status500InternalServerError,errorMessage= ex.Message });
            }

        }

        [HttpGet("GetUser/{id}")]
        public IActionResult GetUser(int id)
        {
            try
            {
                UserModel user = userService.GetUser(id);
                if(user == null)
                {
                    return NotFound(new { errorCode = StatusCodes.Status404NotFound, errorMessage = $"No user with id = {id} found in the database." });
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { errorCode = StatusCodes.Status500InternalServerError,errorMessage = ex.Message } );
            }
        }
    }
}
