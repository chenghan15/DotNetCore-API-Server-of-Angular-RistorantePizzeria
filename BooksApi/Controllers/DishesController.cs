using ConFusionApi.Models;
using ConFusionApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ConFusionApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly DishService _dishService;

        public DishesController(DishService dishService)
        {
            _dishService = dishService;
        }

        [HttpGet]
        public ActionResult<List<Dish>> Get() =>
            _dishService.Get();

        [HttpGet("{id:length(24)}")]
        public ActionResult<Dish> Get(string id)
        {
            var dish = _dishService.Get(id);

            if (dish == null)
            {
                return NotFound();
            }

            return dish;
        }

        [HttpGet("{id}")]
        public ActionResult<Dish> GetById(string id)
        {
            var dish = _dishService.GetById(id);

            if (dish == null)
            {
                return NotFound();
            }

            return dish;
        }

        [HttpGet("[action]")]
        // Featured? test1 = 1 & test2 = 3
        public ActionResult<List<Dish>> Featured(string test1, string test2)
        {
            return _dishService.Get(true);

            //if (dish == null)
            //{
            //    return NotFound();
            //}

            //return dish;
        }

        [HttpPost]
        public ActionResult<Dish> Create(Dish dish)
        {
            _dishService.Create(dish);

            return CreatedAtRoute("GetDish", new { id = dish.Id.ToString() }, dish);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Dish dishIn)
        {
            var dish = _dishService.Get(id);

            if (dish == null)
            {
                return NotFound();
            }

            _dishService.Update(id, dishIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var dish = _dishService.Get(id);

            if (dish == null)
            {
                return NotFound();
            }

            _dishService.Remove(dish.Id);

            return NoContent();
        }
    }
}