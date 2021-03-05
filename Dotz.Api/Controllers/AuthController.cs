using AutoMapper;
using Dotz.Api.Resources.Auth;
using Dotz.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dotz.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(
            IAuthService authService,
            IMapper mapper
        )
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UsuarioTokenResource>> Login([FromBody] LoginResource loginResource)
        {
            var usuarioToken = await _authService.Login(loginResource.Email, loginResource.Senha);
            if (usuarioToken == null)
            {
                return Unauthorized("Usuário ou senha inválidos");
            }

            var usuarioTokenResource = _mapper.Map<UsuarioTokenResource>(usuarioToken);
            return Ok(usuarioTokenResource);
        }
    }
}
