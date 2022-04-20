using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<LoginResponseDTO> Login(LoginDTO model);
        Task<TokenInfoDTO> RefreshToken(string refreshToken);
    }
}
