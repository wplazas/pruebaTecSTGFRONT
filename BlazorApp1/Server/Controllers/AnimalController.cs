using BlazorApp1.Server.Interfaces;
using BlazorApp1.Shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimal _IAnimal;

        public AnimalController(IAnimal iAnimal)
        {
            _IAnimal = iAnimal;
        }

        [HttpGet]
        public async Task<List<Animal>> Get()
        {
            return await Task.FromResult(_IAnimal.GetAnimalDetails());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Int16 id)
        {
            Animal animal = _IAnimal.GetAnimalData(id);
            if (animal != null)
            {
                return Ok(animal);
            }
            return NotFound();
        }

        [HttpPost]
        public void Post(Animal animal)
        {
            _IAnimal.AddAnimal(animal);
        }
        [HttpPut]
        public void Put(Animal animal)
        {
            _IAnimal.UpdateAnimalDetails(animal);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Int16 id)
        {
            _IAnimal.DeleteAnimal(id);
            return Ok();
        }



    }
}
