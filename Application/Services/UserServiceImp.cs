using Application.DTO;
using Application.DTO.User;
using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Core.Entities;
using Core.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserServiceImp : UserService
    {
        private readonly IMapper _mapper;
        private readonly UserRepository _userRepository;
        private readonly UserManager<User> _userManager;

        public UserServiceImp(IMapper mapper, UserRepository userRepository, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public async Task<IEnumerable<UserBaseDTO>> GetAll()
        {
            IEnumerable<User> users = await _userManager.Users.ToListAsync() ?? new List<User>();
           return _mapper.Map<List<UserBaseDTO>>(users);
        }

        public async Task<UserBaseDTO> Get(string id)
        {
            User user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                throw new ObjectNotFoundException("User does not exists");
            }
            UserBaseDTO userDTO = _mapper.Map<UserBaseDTO>(user);

            return userDTO;
        }

        public async Task<string> Create(UserCreateDTO userCreateDTO)
        {
            var userExists = await _userManager.FindByNameAsync(userCreateDTO.Username);
            if (userExists != null)
            {
                throw new ObjectAlreadyExistsException("User with this username already exists");
            }

            User user = new()
            {
                Email = userCreateDTO.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = userCreateDTO.Username
            };
            var result = await _userManager.CreateAsync(user, userCreateDTO.Password);
            if (!result.Succeeded)
            {
                string errors = "";
                foreach (var error in result.Errors)
                {
                    errors += error.Description;
                }
                throw new ObjectValidationException(errors);
            }
            return user.Id;

        }
    }
}
