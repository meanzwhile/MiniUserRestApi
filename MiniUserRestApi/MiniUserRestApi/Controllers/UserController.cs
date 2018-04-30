using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniUserRestApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiniUserRestApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;
        
        public UserController(UserContext context)
        {
            _context = context;
            //if (_context.Users.Count() == 0)
            //{
            //    _context.Users.Add(new User { UserName = "Name1" });
            //    _context.SaveChanges();
            //}
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<User> GetAllUser()
        {
            return _context.Users.ToList();
        }

        //GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            User user = _context.Users.SingleOrDefault(x => x.Id == id);
            if (user != null)
            {
                return new ObjectResult(user);
            }
            return new NotFoundResult();
        }

        // POST api/<controller>
        [HttpPost]
        public void RegisterUser([FromBody]User user)
        {
            if (user.UserEmail != null && user.UserName != null)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
        }
     
        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public bool DeleteUser(int id)
        {
            User UserToRemove = _context.Users.SingleOrDefault(x => x.Id == id);
            if (UserToRemove != null)
            {
                _context.Users.Remove(UserToRemove);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
