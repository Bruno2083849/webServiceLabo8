using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Labo8api.Data;
using Labo8api.Models;

namespace Labo8api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly AnimalService AnimalService;

        public AnimalsController(AnimalService animalService)
        {
            AnimalService = animalService;
        }

        // GET: api/Animals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAnimal()
        {
            return Ok(await AnimalService.GetAll());
        }

        // GET: api/Animals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> GetAnimal(int id)
        {
            Animal? animal = await AnimalService.Get(id);
            return animal == null ? NotFound() : animal;
        }

        // PUT: api/Animals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimal(int id, Animal animal)
        {
            if (id != animal.Id)
            {
                return BadRequest();
            }

           Animal? updatedAnimal = await AnimalService.Put(id, animal);

           if(updatedAnimal == null)
           {
               return StatusCode(StatusCodes.Status500InternalServerError,
                   new { Message = "L'animal a été supprimé ou modifié. Veuillez réessayer." });
           }

            return NoContent();
        }

        // POST: api/Animals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Animal>> PostAnimal(Animal animal)
        {
            Animal? newAnimal = await AnimalService.Post(animal);
          if (newAnimal == null)
          {
              return Problem("Entity set 'Labo8apiContext.Animal'  is null.");
          }
            return CreatedAtAction("GetAnimal", new { id = newAnimal.Id }, newAnimal);
        }

        // DELETE: api/Animals/5
        [HttpPost]
        [Route("/api/destroy/{id}")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            await AnimalService.Delete(id);
            return NoContent();
        }

        [HttpDelete]
        [Route("/api/destroy")]
        public async Task<IActionResult> DeleteAllANimal(int id)
        {
            await AnimalService.DeleteAll();
            return NoContent();
        }
    }
}
