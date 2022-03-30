using Application.DTO;
using Application.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface AuthenticationService : Service
    {
        Task<LoginResponseDTO> Login(LoginDTO model);
        Task<TokenInfoDTO> RefreshToken(string refreshToken);
    }
}
