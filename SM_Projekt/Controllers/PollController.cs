﻿using Application.DTOs.Poll;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [HttpGet("MyPolls")]
        public async Task<ActionResult<IEnumerable<PollBaseDTO>>> GetMyPolls()
        {
            return Ok(await _pollService.GetMyPolls());
        }

        /*[HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<PollBaseDTO>>> Put(int id, PollCreateDTO poll)
        {
            return Ok(await _pollService.Update(poll,id));
        }*/

        [HttpPut("Activate/{id}")]
        public async Task<ActionResult> Activate(int pollId)
        {
            await _pollService.OpenPoll(pollId);
            return Ok();
        }

        [HttpPut("Invite/{id}")]
        public async Task<ActionResult> InviteToPoll(int pollId, PollInviteDTO pollInviteDTO)
        {
            await _pollService.InviteUsers(pollId, pollInviteDTO);
            return Ok();
        }

        [HttpPut("AddModerators/{id}")]
        public async Task<ActionResult> SetPollModerators(int pollId, PollInviteDTO pollInviteDTO)
        {
            await _pollService.SetPollModerators(pollId, pollInviteDTO);
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
            return CreatedAtAction(nameof(UserController.Get), new { id }, poll);
        }

    }

}
