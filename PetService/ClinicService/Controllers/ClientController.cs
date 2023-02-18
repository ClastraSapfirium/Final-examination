using ClinicService.Models;
using ClinicService.Models.Requests;
using ClinicService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IClientRepository _clientRepository;


        public ClientController(IClientRepository clientRepository) {
            _clientRepository = clientRepository;
        }


        [HttpPost("create")]
        public ActionResult<int> Create([FromBody]  CreateClientRequest createClientRequest)
        {
            Client client = new Client();
            client.SurName = createClientRequest.SurName;
            client.FirstName = createClientRequest.FirstName;
            client.Patronymic = createClientRequest.Patronymic;
            client.Document = createClientRequest.Document; 
            client.Birthday = createClientRequest.Birthday;
            return Ok(_clientRepository.Create(client));
        }

        [HttpPut("update")]
        public ActionResult<int> Update([FromBody]  UpdateClientRequest updateClientRequest)
        {
            Client client = new Client();
            client.ClientId = updateClientRequest.ClientId;
            client.SurName = updateClientRequest.SurName;
            client.FirstName = updateClientRequest.FirstName;
            client.Patronymic = updateClientRequest.Patronymic;
            client.Document = updateClientRequest.Document;
            client.Birthday = updateClientRequest.Birthday;
            return Ok(_clientRepository.Update(client));
        }


        [HttpDelete("delete")]
        public ActionResult<int> Delete(int id)
        {
            return Ok(_clientRepository.Delete(id));
        }

        [HttpGet("get-all")]
        public ActionResult<List<Client>> GetAll()
        {
            return Ok(_clientRepository.GetAll());
        }

        [HttpGet("get-by-id")]
        public ActionResult<Client> GetById(int id)
        {
            return Ok(_clientRepository.GetById(id));
        }

    }
}
