using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingAPIS.Controllers;
using TestingAPIS.Services;
using FluentAssertions;
using TestingAPIS;
using TestingAPIS.Models;

namespace TestProject1.ControllerTests
{
    internal class JokeControllerTest
    {
        // Configure the required properties

        private Mock<IJokeService> _IJokeServiceMock;
        private JokesController _JokesController;

        [SetUp]
        public void Setup()
        {
            _IJokeServiceMock = new Mock<IJokeService>();
            _JokesController = new JokesController(_IJokeServiceMock.Object);
        }

        [Test]
        public void Index_GetAllJokes()
        {
            List<Joke> listOfJokes = new List<Joke>();
            listOfJokes.Add(new Joke() { Id = 1, IsFunny = false, Category = "animal", PunchLine = "A fsh", SetupLine = "What do you call a fish with no eyes?" });
            listOfJokes.Add(new Joke() { Id = 2, IsFunny = false, Category = "programming", PunchLine = "So they could C#", SetupLine = "Why did the developer go to the opticians?" });
            listOfJokes.Add(new Joke() { Id = 3, IsFunny = false, Category = "pirate", PunchLine = "Cuz they ARRRRR!", SetupLine = "Why are pirates called pirates?" });

            _IJokeServiceMock.Setup(repo => repo.GetAllJokes()).Returns(listOfJokes);

            // ACT

            //var expectedResult = _JokesController.Index();
            //var result = new JokesController(new JokeService(new JokeRepository())).Index();
            var result = _JokesController.Index();

            // ASSERT
            //result.Should().BeEquivalentTo(expectedResult);
            result.Should().BeEquivalentTo(listOfJokes);
            _IJokeServiceMock.Verify(service => service.GetAllJokes(), Times.Once);
        }

        [Test]
        public void PostJokeTest()
        {

        }
    }
}
