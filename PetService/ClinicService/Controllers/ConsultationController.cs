using ClinicService.Models.Requests;
using ClinicService.Models;
using ClinicService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultationController : ControllerBase
    {
        private IConsultationRepository _consultationRepository;


        public ConsultationController(IConsultationRepository consultationRepository)
        {
            _consultationRepository = consultationRepository;
        }


        [HttpPost("create")]
        public ActionResult<int> Create([FromBody] CreateConsultationRequest createConsultationRequest)
        {
            Consultation consultation = new Consultation();
            consultation.ConsultationId = createConsultationRequest.ConsultationId;
            consultation.ClientId = createConsultationRequest.ClientId;
            consultation.PetId = createConsultationRequest.PetId;
            consultation.ConsultationDate = createConsultationRequest.ConsultationDate;
            consultation.Description = createConsultationRequest.Description;
            return Ok(_consultationRepository.Create(consultation));
        }

        [HttpPut("update")]
        public ActionResult<int> Update([FromBody] UpdateCosnsultationRequest updateConsultationRequest)
        {
            Consultation consultation = new Consultation();
            consultation.ConsultationId = updateConsultationRequest.ConsultationId;
            consultation.ClientId = updateConsultationRequest.ClientId;
            consultation.PetId = updateConsultationRequest.PetId;
            consultation.ConsultationDate = updateConsultationRequest.ConsultationDate;
            consultation.Description = updateConsultationRequest.Description;
            return Ok(_consultationRepository.Create(consultation));
        }


        [HttpDelete("delete")]
        public ActionResult<int> Delete(int id)
        {
            return Ok(_consultationRepository.Delete(id));
        }

        [HttpGet("get-all")]
        public ActionResult<List<Consultation>> GetAll()
        {
            return Ok(_consultationRepository.GetAll());
        }

        [HttpGet("get-by-id")]
        public ActionResult<Consultation> GetById(int id)
        {
            return Ok(_consultationRepository.GetById(id));
        }
    }
}
