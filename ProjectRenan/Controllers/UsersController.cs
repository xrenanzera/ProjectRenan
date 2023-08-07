using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectRenan.Application.Interfaces;
using ProjectRenan.Application.ViewModels;
using ProjectRenan.Auth.Services;
using System.Security.Claims;

namespace ProjectRenan.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
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
        [HttpPost, AllowAnonymous]
        public ActionResult Post(UserViewModel model)
        {
            return Ok(this.userService.Post(model));
        }
        [HttpGet("{id}")]
        public ActionResult GetById(string id)
        {
            return Ok(this.userService.GetById(id));
        }
        [HttpPut]
        public ActionResult Put(UserViewModel model)
        {
            return Ok(this.userService.Put(model));
        }
        [HttpDelete]
        public ActionResult Delete()
        {
            string userId = TokenService.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier);
            return Ok(this.userService.Delete(userId));
        }

        [HttpPost("authenticate"), AllowAnonymous]
        public ActionResult Authenticate(UserAuthenticateRequestViewModel model)
        {
            return Ok(this.userService.Authenticate(model));
        }
    }
}
