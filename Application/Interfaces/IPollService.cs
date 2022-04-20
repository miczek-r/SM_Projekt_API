using Application.DTOs.Poll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPollService
    {
        Task<IEnumerable<PollLiteDTO>> GetAll();
        Task<PollBaseDTO> Get(int id);
        Task<PollLiteDTO> Update(PollCreateDTO pollCreateDTO);
        Task Delete(int id);
        Task<int> Create(PollCreateDTO pollCreateDTO);
        Task Activate(int id);
    }
}
