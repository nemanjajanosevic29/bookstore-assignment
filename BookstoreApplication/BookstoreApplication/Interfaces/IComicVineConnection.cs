namespace BookstoreApplication.Interfaces
{
    public interface IComicVineConnection
    {
        Task<string> Get(string url);
    }
}