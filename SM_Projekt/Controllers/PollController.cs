﻿using Application.DTOs.Poll;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SM_Projekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollController : ControllerBase
    {
        private readonly IPollService _pollService;

        public PollController(IPollService pollService)
        {
            _pollService = pollService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PollBaseDTO>>> GetAll()
        {
            return Ok(await _pollService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<PollBaseDTO>>> Get(int id)
        {
            return Ok(await _pollService.Get(id));
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<PollBaseDTO>>> Put(PollCreateDTO poll)
        {
            return Ok(await _pollService.Update(poll));
        }

        [HttpPut("activate/{id}")]
        public async Task<ActionResult> Activate(int id)
        {
            await _pollService.Activate(id);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _pollService.Delete(id);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PollCreateDTO pollCreateDTO)
        {
            int id = await _pollService.Create(pollCreateDTO);
            PollBaseDTO poll = await _pollService.Get(id);
            return CreatedAtAction(nameof(UserController.Get), new { id = id }, poll);
        }

    }

}
