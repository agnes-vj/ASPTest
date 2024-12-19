
namespace TestingAPIS.Services
{
    public interface IJokeService
    {
        IEnumerable<Joke> GetAllJokes();
    }
}