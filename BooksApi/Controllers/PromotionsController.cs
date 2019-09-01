using BooksApi.Models;
using BooksApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BooksApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PromotionsController : ControllerBase
    {
        private readonly PromotionService _promotionService;

        public PromotionsController(PromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        [HttpGet]
        public ActionResult<List<Promotion>> Get() =>
            _promotionService.Get();

        [HttpGet("{id:length(24)}", Name = "GetPromotion")]
        public ActionResult<Promotion> Get(string id)
        {
            var promotion = _promotionService.Get(id);

            if (promotion == null)
            {
                return NotFound();
            }

            return promotion;
        }

        [HttpGet("[action]")]
        // Featured? test1 = 1 & test2 = 3
        public ActionResult<List<Promotion>> Featured(string test1, string test2)
        {
            return _promotionService.Get(true);

            //if (promotion == null)
            //{
            //    return NotFound();
            //}

            //return promotion;
        }

        [HttpPost]
        public ActionResult<Promotion> Create(Promotion promotion)
        {
            _promotionService.Create(promotion);

            return CreatedAtRoute("GetPromotion", new { id = promotion.Id.ToString() }, promotion);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Promotion promotionIn)
        {
            var promotion = _promotionService.Get(id);

            if (promotion == null)
            {
                return NotFound();
            }

            _promotionService.Update(id, promotionIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var promotion = _promotionService.Get(id);

            if (promotion == null)
            {
                return NotFound();
            }

            _promotionService.Remove(promotion.Id);

            return NoContent();
        }
    }
}
