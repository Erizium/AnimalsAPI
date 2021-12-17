using AnimalsAPI.DTOs;
using AnimalsAPI.Entities;
using AnimalsAPI.Repos;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsAPI.Controllers
{
    [ApiController]
    [Route("animals")]
    public class AnimalController : Controller
    {
        private readonly IAnimalsRepo _repo;

        public AnimalController(IAnimalsRepo repo)
        {
            _repo = repo;
        }
        
        [HttpGet]
        [Route("")]
        public IActionResult GetAnimals()
        {
            var animals = _repo
                .GetAll()
                .Select(v => new AnimalDTO
                {
                    Id = v.Id,
                    Name = v.Name,
                    Type = v.Type,
                });
            return Ok(animals);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAnimalById(int id)
        {
            Animal animal = _repo.GetByID(id);
            if(animal == null)
            {
                return NotFound("Could not find Animal with id: " + id);
            }
            AnimalDTO animalDTO = new AnimalDTO
            {
                Id = animal.Id,
                Name = animal.Name,
                Type = animal.Type,
            };
            return Ok(animalDTO);
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateAnimal([FromBody]Animal animal)
        {
            Animal createdAnimal = _repo.CreateAnimal(animal);
            return CreatedAtAction(
                nameof(GetAnimalById),
                new { id = createdAnimal.Id },
                createdAnimal);
        }

        [HttpPut]
        [Route("")]
        public IActionResult Update([FromBody]Animal animal)
        {
            Animal updatedAnimal = _repo.UpdateAnimal(animal);
            return Ok(updatedAnimal);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            _repo.DeleteAnimal(id);
            return NoContent();
        }
        
     } 

}
