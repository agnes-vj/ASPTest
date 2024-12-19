
namespace TestingAPIS.Models
{
    public interface IJokeRepository
    {        
        IEnumerable<Joke> FindAllJokes();
        Joke AddJoke(Joke joke);
        Joke GetJokeById(int id);
    }
}