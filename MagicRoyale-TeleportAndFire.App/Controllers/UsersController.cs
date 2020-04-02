using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagicRoyale_TeleportAndFire.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        MagicRoyaleDbContext db;
        public UsersController(MagicRoyaleDbContext context)
        {
            db = context;
            if (!db.Users.Any())
            {
                db.Users.Add(new User { Name = "Tom", Age = 20 });
                db.Users.Add(new App.User {Name = "Agile", Age = 25);
                db.SaveChanges();
            }
        }
        // GET: api/Users
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Users
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
