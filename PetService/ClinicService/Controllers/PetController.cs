using ClinicService.Models.Requests;
using ClinicService.Models;
using ClinicService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private IPetRepository _PetRepository;


        public PetController(IPetRepository PetRepository)
        {
            _PetRepository = PetRepository;
        }


        [HttpPost("create")]
        public ActionResult<int> Create([FromBody] CreatePetRequest createPetRequest)
        {
            Pet pet = new Pet();
            pet.PetId = createPetRequest.PetId;
            pet.ClientId = createPetRequest.ClientId;
            pet.Name = createPetRequest.Name;
            pet.Birthday = createPetRequest.Birthday;
            return Ok(_PetRepository.Create(pet));
        }

        [HttpPut("update")]
        public ActionResult<int> Update([FromBody] UpdatePetRequest updatePetRequest)
        {
            Pet pet = new Pet();
            pet.PetId = updatePetRequest.PetId;
            pet.ClientId = updatePetRequest.ClientId;
            pet.Name = updatePetRequest.Name;
            pet.Birthday = updatePetRequest.Birthday;
            return Ok(_PetRepository.Update(pet));
        }


        [HttpDelete("delete")]
        public ActionResult<int> Delete(int id)
        {
            return Ok(_PetRepository.Delete(id));
        }

        [HttpGet("get-all")]
        public ActionResult<List<Pet>> GetAll()
        {
            return Ok(_PetRepository.GetAll());
        }

        [HttpGet("get-by-id")]
        public ActionResult<Pet> GetById(int id)
        {
            return Ok(_PetRepository.GetById(id));
        }

    }
}
