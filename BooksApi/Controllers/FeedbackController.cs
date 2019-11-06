using ConFusionApi.Models;
using ConFusionApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ConFusionApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly FeedbackService _feedbackService;

        public FeedbackController(FeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet]
        public ActionResult<List<Feedback>> Get() =>
            _feedbackService.Get();

        [HttpGet("{id:length(24)}", Name = "GetFeedback")]
        public ActionResult<Feedback> Get(string id)
        {
            var feedback = _feedbackService.Get(id);

            if (feedback == null)
            {
                return NotFound();
            }

            return feedback;
        }

        [HttpPost]
        public ActionResult<Feedback> Create(Feedback feedback)
        {
            _feedbackService.Create(feedback);

            return CreatedAtRoute("GetFeedback", new { id = feedback.Id.ToString() }, feedback);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Feedback feedbackIn)
        {
            var feedback = _feedbackService.Get(id);

            if (feedback == null)
            {
                return NotFound();
            }

            _feedbackService.Update(id, feedbackIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var feedback = _feedbackService.Get(id);

            if (feedback == null)
            {
                return NotFound();
            }

            _feedbackService.Remove(feedback.Id);

            return NoContent();
        }
    }
}