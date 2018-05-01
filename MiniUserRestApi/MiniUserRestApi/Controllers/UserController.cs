using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MiniUserRestApi.Models;


namespace MiniUserRestApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;

        private const string apiKey = "SuperSecretKey1234";
        
        public UserController(UserContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult GetAllUser()
        {
            if (Request.Headers["x-api-key"] != apiKey)
            {
                return new StatusCodeResult(403);
            }

            return new ObjectResult(_context.Users.ToList());
        }

        //GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            if (Request.Headers["x-api-key"] != apiKey)
            {
                return new StatusCodeResult(403);
            }

            User user = _context.Users.SingleOrDefault(x => x.Id == id);
            if (user != null)
            {
                return new ObjectResult(user);
            }
            return new NotFoundResult();
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult RegisterUser([FromBody]User user)
        {
            if (Request.Headers["x-api-key"] != apiKey)
            {
                return new StatusCodeResult(403);
            }

            if (user?.UserName != null && user?.UserEmail != null)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return new OkObjectResult(200);
            }
            return new StatusCodeResult(418);
        }
     
        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (Request.Headers["x-api-key"] != apiKey)
            {
                return new StatusCodeResult(403);
            }

            User UserToRemove = _context.Users.SingleOrDefault(x => x.Id == id);
            if (UserToRemove != null)
            {
                _context.Users.Remove(UserToRemove);
                _context.SaveChanges();
                return new OkObjectResult(200);
            }
            return new StatusCodeResult(404);
        }
    }
}
