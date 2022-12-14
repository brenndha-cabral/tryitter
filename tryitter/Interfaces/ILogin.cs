namespace tryitter.Interfaces
{
    public interface ILogin
    {
        Task<string> TokenGenerate(string email, string password);
    }
}
