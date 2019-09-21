using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiPrueba.Services;

namespace WebApiPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService userService;

        public UserController()
        {
            userService = new UserService();
        }

        // GET: api/User
        [HttpGet("GetAll")]
        public List<BOUser> Get()
        {
            return CoreFactory.Instance.GetAllUsers();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public BusinessResult Get(int id)
        {
            return CoreFactory.Instance.GetUserById(id);
        }

        // POST: api/User/Create
        [HttpPost("Create")]
        public BusinessResult Create([FromBody] BOUser objUser)
        {
            return CoreFactory.Instance.CreateUser(objUser);
        }

        // POST: api/User/Update
        [HttpPost("Update")]
        public BusinessResult Update([FromBody] BOUser objUser)
        {
            return CoreFactory.Instance.UpdateUser(objUser);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public BusinessResult Delete(int id)
        {
            return CoreFactory.Instance.DeleteUser(id);
        }
    }
}
