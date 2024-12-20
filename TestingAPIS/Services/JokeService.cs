﻿using TestingAPIS.Models;

namespace TestingAPIS.Services
{
    public class JokeService : IJokeService
    {
        private readonly IJokeRepository _jokeRepository;
        public JokeService(IJokeRepository jokeRepository)
        {
            _jokeRepository = jokeRepository;
        }
        public IEnumerable<Joke> GetAllJokes()
        {
            return _jokeRepository.FindAllJokes();
        }
        public Joke AddJoke(Joke joke)
        {
            return _jokeRepository.AddJoke(joke);
        }
        public Joke GetJokeById(int id)
        {
            return _jokeRepository.GetJokeById(id);
        }
    }
}
