﻿using TestingAPIS.Models;

namespace TestingAPIS.Services
{
    public class JokeService : IJokeService
    {
        private readonly JokeRepository _jokeRepository;
        public JokeService(JokeRepository jokeRepository)
        {
            _jokeRepository = jokeRepository;
        }
        public IEnumerable<Joke> GetAllJokes()
        {
            return _jokeRepository.FindAllJokes();
        }
    }
}
