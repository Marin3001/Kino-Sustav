namespace Cinema_API.Exceptions
{
    public class UserErrorException : Exception
    {
        public UserErrorException(string? message) : base(message)
        {
        }
    }
}