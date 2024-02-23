namespace SchoolRegister.Models.CustomExceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message)
            : base(message)
        {

        }
    }
}
