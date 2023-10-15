using Iconic.Service.DTOs.Users;
using Iconic.Service.Interfaces.Users;
using Microsoft.AspNetCore.Mvc;

namespace Iconic.Api.Controllers
{
    [ApiController,Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService userService;

        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public object Login(UserForLoginDTO dto)
            => userService.LoginAsync(dto.Login,dto.Password);
    }
}
