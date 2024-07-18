using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Sigma.Controllers;
using Sigma.Model;
using Sigma.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma.Tests.Controllers
{
    public class CandidatesControllerTest
    {
        private readonly Mock<ICandidateService> _candidateService;
        public CandidatesControllerTest()
        {
            _candidateService = new Mock<ICandidateService>();
        }


        [Fact]
        public async  Task CandidatesController_AddEditCandidate_ValidResult()

        {
            var candiDate = new Candidate()
            {
                FirstName = "Hari",
                LastName = "Sharma",
                PhoneNumber = "9856618003",
                Email = "bishal21@gmail.com",
                CallTime = "3:00 Pm",
                LinkedInUrl = "https://www.linkedin.com/np/harisharma/",
                GitHubUrl = "https://github.com/harisharma89",
                Comment = "He is unique problem solver "

            };

            string expectedResult = "Created Successfully";
            _candidateService.Setup(x => x.AddOrEditCandidateAsync(It.IsAny<Candidate>())).ReturnsAsync("Updated");

            CandidatesController candidatesController = new CandidatesController(_candidateService.Object);

            var candiDateResult = await  candidatesController.AddEditCandidate(candiDate);

            // Assert
            var objectResult = Assert.IsType<OkObjectResult>(candiDateResult);

            Console.WriteLine(objectResult);
            if (objectResult.Value.ToString().Contains("Updated"))
            {
                expectedResult = "Updated Successfully";

            }
           

            Assert.Equal(expectedResult, objectResult.Value);
        }
    }
}
