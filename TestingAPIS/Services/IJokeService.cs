
namespace TestingAPIS.Services
{
    public interface IJokeService
    {
        IEnumerable<Joke> GetAllJokes();
        Joke AddJoke(Joke joke);

        Joke GetJokeById(int id);
    }
}