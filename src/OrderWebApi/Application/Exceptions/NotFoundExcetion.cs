namespace OrderWebApi.Application.Exceptions
{
    public class NotFoundExcetion : Exception
    {
        public NotFoundExcetion():base()
        {
        }

        public NotFoundExcetion(string message) : base(message)
        {
        }

        public NotFoundExcetion(string message, Exception innerException) : base(message, innerException)
        {
        }

        public NotFoundExcetion(string name, object key) : base($"Entity {name}({key}) was not found.)")
        {
        }
    }
}
