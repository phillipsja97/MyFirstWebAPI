using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebAPI.Models;

namespace MyFirstWebAPI.Controllers
{
    [Route("api/animals")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        static List<Animal> _animals = new List<Animal>
            {
            new Animal {Id = 1, Name = "Steve", Type = "Elephant", Weight = 2000 },
            new Animal {Id = 2, Name = "George", Type = "Monkey", Weight = 87 },
            new Animal {Id = 3, Name = "Tony", Type = "Tiger", Weight = 1200 }
            };

        [HttpGet]
        public IActionResult GetAllAnimals()
        {
       
            return Ok(_animals);
        }
        [HttpGet("{id}")]
        public IActionResult GetSingleAnimal(int id)
        {
            var animalIWant = _animals.FirstOrDefault(a => a.Id == id);

            if (animalIWant == null)
            {
                return NotFound($"Animal with the Id of {id} was not found.");
            }
            else
            {
            return Ok(animalIWant);
            }
        }

        // This needs to be a POST to /api/animals
        [HttpPost]
        public IActionResult AddAnAnimal(Animal animalToAdd)
        {
            _animals.Add(animalToAdd);
            return Ok(_animals);
        }

        // PUT / api/animals/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateAnAnimal(int id, Animal animal)
        {
            var animalToUpdate = _animals.FirstOrDefault(a => a.Id == id);

            if (animalToUpdate == null)
            {
                return NotFound("Can't update because it doesn't exist");
            }
            else
            {
                animalToUpdate.Name = animal.Name;
                animalToUpdate.Weight = animal.Weight;
                animalToUpdate.Type = animal.Type;
                return Ok(animalToUpdate);
            }
        }
    }
}