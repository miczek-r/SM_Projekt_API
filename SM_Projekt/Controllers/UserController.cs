using Application.DTO;
using Application.DTO.User;
using Application.DTOs.User;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SM_Projekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserBaseDTO>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<UserBaseDTO>>> GetAll() {
            return Ok(await _userService.GetAll());
        }

        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(UserBaseDTO))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserBaseDTO>> Get(string id)
        {
            return Ok(await _userService.Get(id));
        }


        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Register([FromBody] UserCreateDTO registerDTO)
        {
            string id = await _userService.Create(registerDTO);
            UserBaseDTO user = await _userService.Get(id);
            return CreatedAtAction(nameof(UserController.Register), new { id }, user);
        }

        [HttpPost("ConfirmMail")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> ConfirmMail([FromBody] EmailConfirmationDTO confirmationDTO)
        {
            await _userService.ConfirmEmail(confirmationDTO);
            return NoContent();
        }
    }
}
