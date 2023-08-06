using Microsoft.AspNetCore.Mvc;
using ProjectRenan.Application.Interfaces;

namespace ProjectRenan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpGet]
        public ActionResult Get()
        {       
            return Ok(this.userService.Get());
        }
    }
}
