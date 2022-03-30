using Application.DTO;
using Application.Interfaces;
using Core.Entities;
using Core.Repositories;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Application.Exceptions;

namespace Application.Services
{
    public class AuthenticationServiceImp : AuthenticationService
    {
        private readonly UserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthenticationServiceImp(UserRepository userRepository, UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<LoginResponseDTO> Login(LoginDTO model)
        {
            User user = await _userRepository.GetByLambdaAsync(user => user.UserName == model.Username);
            if (user == null)
            {
                throw new ObjectNotFoundException("User with this combination of username and password does not exist");
            }
            SignInResult loginResult;
            loginResult = await _signInManager.PasswordSignInAsync(user, model.Password, false, true);
            if (loginResult.Succeeded)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);

                return new LoginResponseDTO(token);
            }
            throw new ObjectNotFoundException("User with this combination of username and password does not exist");
        }

        public Task<TokenInfoDTO> RefreshToken(string refreshToken)
        {
            throw new NotImplementedException();
        }

        private TokenInfoDTO GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                //issuer: _configuration["JWT:ValidIssuer"],
                //audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return new TokenInfoDTO { Token = token.EncodedPayload, TokenValidUntil = token.ValidTo };
        }


    }
}
