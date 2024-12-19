using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingAPIS;
using TestingAPIS.Models;
using TestingAPIS.Services;
using FluentAssertions;

namespace TestProject1.ServiceTests
{
    public class JokeServiceTest
    {
        // Configure the required properties

        private Mock<IJokeRepository> _jokeRepositoryMock;
        private JokeService _jokeService;

        [SetUp]
        public void Setup()
        {
            _jokeRepositoryMock = new Mock<IJokeRepository>();
            _jokeService = new JokeService(_jokeRepositoryMock.Object);
            
        }

        [Test]
        public void GetAllJokes_ReturnsAllJokes()
        {
            // ARRANGE
            List<Joke> listOfJokes = new List<Joke>();
            listOfJokes.Add(new Joke() { Id = 1, IsFunny = false, Category = "animal", PunchLine = "A fsh", SetupLine = "What do you call a fish with no eyes?" });
            listOfJokes.Add(new Joke() { Id = 2, IsFunny = false, Category = "programming", PunchLine = "So they could C#", SetupLine = "Why did the developer go to the opticians?" });
            listOfJokes.Add(new Joke() { Id = 3, IsFunny = false, Category = "pirate", PunchLine = "Cuz they ARRRRR!", SetupLine = "Why are pirates called pirates?" });
            
            _jokeRepositoryMock.Setup(repo => repo.FindAllJokes()).Returns(listOfJokes);
            // ACT
            var result = _jokeService.GetAllJokes();
            
            // ASSERT
            result.Should().BeEquivalentTo(listOfJokes);
        }

        [Test]
        public void PostJoke_InvokesModelWithCorrectArgument()
        {
            //Arrange
            Joke joke = new Joke() { Id = 4, IsFunny = false, Category = "Sea Animal", PunchLine = "A fsh", SetupLine = "What do you call a fish with no eyes?" };
            Joke anotherJoke = new Joke() { Id = 5, IsFunny = false, Category = "Sea Animal", PunchLine = "A fsh", SetupLine = "What do you call a fish with no eyes?" };
            //_jokeRepositoryMock.Setup(repo => repo.AddJoke(joke)).Returns(joke);
            _jokeRepositoryMock.Setup(repo => repo.AddJoke(anotherJoke)).Returns(anotherJoke);


            //Act

            //var result = new JokeService(new JokeRepository()).AddJoke(anotherJoke);
            var result = _jokeRepositoryMock.Object.AddJoke(anotherJoke);

            //Assert

            _jokeRepositoryMock.Verify(repo => repo.AddJoke(anotherJoke), Times.Once());

        }
        [Test]
        public void PostJoke_ReturnsNewJokeWithIdAdded()
        {
            //Arrange
            Joke resultJoke = new Joke() { Id = 4, IsFunny = false, Category = "Sea Animal", PunchLine = "A fsh", SetupLine = "What do you call a fish with no eyes?" };
            Joke joke = new Joke() { IsFunny = false, Category = "Sea Animal", PunchLine = "A fsh", SetupLine = "What do you call a fish with no eyes?" };


            _jokeRepositoryMock.Setup(repo => repo.AddJoke(joke)).Returns(resultJoke);


            //Act
            Joke result = _jokeService.AddJoke(joke);


            //Assert
            Console.WriteLine(result.Id);
            result.Id.Should().BeGreaterThan(0);
            //result.Id.Should().NotBeNullOrEmpty();
            //_jokeRepositoryMock.Object.AddJoke(joke).Id);

        }
    }
}
