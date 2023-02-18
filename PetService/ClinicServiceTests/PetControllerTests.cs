using ClinicService.Controllers;
using ClinicService.Models;
using ClinicService.Models.Requests;
using ClinicService.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServiceTests
{
    public class PetControllerTests
    {

        private PetController _petController;
        private Mock<IPetRepository> _mocPetRepository;

        public PetControllerTests()
        {
            _mocPetRepository = new Mock<IPetRepository>();
            _petController = new PetController(_mocPetRepository.Object);
        }


        [Fact]
        public void CreatePetTest()
        {
            // МЕТОД ТЕСТИРОВАНИЯ СОСТОИТ ИЗ УСЛОВНЫХ 3 ЧАСТЕЙ

            // [1] Подготовка данных для тестирования
            CreatePetRequest createPetRequest = new CreatePetRequest();
            createPetRequest.Name = "Персик";
            createPetRequest.Birthday = DateTime.Now.AddYears(-15);
            createPetRequest.ClientId = 1;


            // [2] Исполнение тестируемого метода
            ActionResult<int> operationResult = _petController.Create(createPetRequest);

            // [3] Подготовка эталонного результата (expected), проверка результата
            int expectedOperationValue = 1;

            // Assert 
            Assert.IsType<OkObjectResult>(operationResult.Result);
            Assert.Equal<int>(expectedOperationValue, (int)((OkObjectResult)operationResult.Result).Value);

         }


        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(-20)]
        [InlineData(6)]
        public void DeletePetTest(int petId)
        {

            // [2] Исполнение тестируемого метода
            ActionResult<int> operationResult = _petController.Delete(petId);


            // [3] Подготовка эталонного результата (expected), проверка результата
            int expectedOperationValue = 1;
            Assert.IsType<OkObjectResult>(operationResult.Result);
            Assert.Equal<int>(expectedOperationValue, (int)((OkObjectResult)operationResult.Result).Value);

        }

        public void GetAllTest()
        {

            // [2] Исполнение тестируемого метода
            ActionResult<List<Pet>> operationResult = _petController.GetAll();


            // [3] Подготовка эталонного результата (expected), проверка результата
            List<Pet> expectedOperationValue = null;
            Assert.IsType<OkObjectResult>(operationResult.Result);
            Assert.Equal<List<Pet>>(expectedOperationValue, (List<Pet>)((OkObjectResult)operationResult.Result).Value);

        }

        public void GetByIdTest(int Id)
        {

            // [2] Исполнение тестируемого метода
            ActionResult<Pet> operationResult = _petController.GetById(Id);


            // [3] Подготовка эталонного результата (expected), проверка результата
            int expectedOperationValue = 1;
            Assert.IsType<OkObjectResult>(operationResult.Result);
            Assert.Equal<int>(expectedOperationValue, (int)((OkObjectResult)operationResult.Result).Value);

        }


    }
}
