using Application.DTO;
using Application.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserBaseDTO>> GetAll();
        Task<UserBaseDTO> Get(string id);
        Task<string> Create(UserCreateDTO userPostDTO);

    }
}
