
namespace TestingAPIS.Models
{
    public interface IJokeRepository
    {        
        IEnumerable<Joke> FindAllJokes();
    }
}