using Application.DTO;
using Application.DTO.User;
using Application.DTOs.User;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SM_Projekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserBaseDTO>>> GetAll() {
            return Ok(await _userService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserBaseDTO>> Get(string id)
        {
            return Ok(await _userService.Get(id));
        }


        [HttpPost]
        public async Task<ActionResult> Register([FromBody] UserCreateDTO registerDTO)
        {
            string id = await _userService.Create(registerDTO);
            UserBaseDTO user = await _userService.Get(id);
            return CreatedAtAction(nameof(UserController.Get), new { id }, user);
        }

        [HttpPost("ConfirmMail")]
        public async Task<ActionResult> ConfirmMail([FromBody] EmailConfirmationDTO confirmationDTO)
        {
            await _userService.ConfirmEmail(confirmationDTO);
            return Ok();
        }
    }
}
