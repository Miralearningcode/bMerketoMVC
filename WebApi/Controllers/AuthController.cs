using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Entities;
using WebApi.Models.Schemas;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;

        public AuthController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpSchema schema)
        {
            if(ModelState.IsValid)
            {
                var result = await _userManager.CreateAsync(schema, schema.Password);
                if (result.Succeeded)
                    return Created("", null!);
            }

            return BadRequest();
        }
    }
}
