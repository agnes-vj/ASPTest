using System.Text.Json;

namespace TestingAPIS.Models
{
    public class JokeRepository : IJokeRepository
    {
        public IEnumerable<Joke> FindAllJokes()
        {
            var jsonJokes = File.ReadAllText("Resources\\Jokes.json");
            var jokes = JsonSerializer.Deserialize<List<Joke>>(jsonJokes);
            return jokes;
        }
        public Joke AddJoke(Joke newJoke)
        {
            var jsonJokes = File.ReadAllText("Resources\\Jokes.json");
            List<Joke> jokes = JsonSerializer.Deserialize<List<Joke>>(jsonJokes);
            int newId = jokes.OrderByDescending(joke => joke.Id).FirstOrDefault().Id + 1;
            newJoke.Id = newId;
            jokes.Add(newJoke);
            File.WriteAllText("Resources\\Jokes.json", JsonSerializer.Serialize<List<Joke>>(jokes));
            return newJoke;
        }

        public Joke GetJokeById(int id)
        {
            var jsonJokes = File.ReadAllText("Resources\\Jokes.json");
            List<Joke> jokes = JsonSerializer.Deserialize<List<Joke>>(jsonJokes);

            var result = jokes.FirstOrDefault(j => j.Id == id);


            return result;
        }
    }
}
