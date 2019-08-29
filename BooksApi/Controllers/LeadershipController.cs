using BooksApi.Models;
using BooksApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BooksApi.Controllers
{
    [Route("leadership/[controller]")]
    [ApiController]
    public class LeadershipController : ControllerBase
    {
        private readonly LeadershipService _leadershipService;

        public LeadershipController(LeadershipService leadershipService)
        {
            _leadershipService = leadershipService;
        }

        [HttpGet]
        public ActionResult<List<Leadership>> Get() =>
            _leadershipService.Get();

        [HttpGet("{id:length(24)}", Name = "GetLeadership")]
        public ActionResult<Leadership> Get(string id)
        {
            var leadership = _leadershipService.Get(id);

            if (leadership == null)
            {
                return NotFound();
            }

            return leadership;
        }

        [HttpPost]
        public ActionResult<Leadership> Create(Leadership leadership)
        {
            _leadershipService.Create(leadership);

            return CreatedAtRoute("GetLeadership", new { id = leadership.Id.ToString() }, leadership);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Leadership leadershipIn)
        {
            var leadership = _leadershipService.Get(id);

            if (leadership == null)
            {
                return NotFound();
            }

            _leadershipService.Update(id, leadershipIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var leadership = _leadershipService.Get(id);

            if (leadership == null)
            {
                return NotFound();
            }

            _leadershipService.Remove(leadership.Id);

            return NoContent();
        }
    }
}