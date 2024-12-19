using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingAPIS.Models;
using TestingAPIS.Services;
using FluentAssertions;
using TestingAPIS;
using TestingAPIS.Models;
using TestingAPIS.Services;


namespace TestProject1.RepositoryTests
{
    public class JokeRepositoryTest
    {
        // Configure the required properties

        //private Mock<IJokeRepository> _jokeRepositoryMock;
        //private JokeService _jokeService;
        public JokeRepository _JokeRepository;

        [SetUp]
        public void Setup()
        {
            _JokeRepository = new JokeRepository();
            //_jokeRepositoryMock = new Mock<IJokeRepository>();
           // _jokeService = new JokeService(_jokeRepositoryMock.Object);

        }
        [Test]
        public void NewJokeWithId()
        {
            Joke testCase = new Joke() { IsFunny = false };
            var result = _JokeRepository.AddJoke(testCase);

            result.Id.Should().BeGreaterThan(0);
        }
        [Test]
        public void GetJokeByIdTest()
        {
            //Arrange
            var result = _JokeRepository.GetJokeById(1);
            //Act
            //Assert
            result.Id.Should().Be(1);
        }
    }
}
