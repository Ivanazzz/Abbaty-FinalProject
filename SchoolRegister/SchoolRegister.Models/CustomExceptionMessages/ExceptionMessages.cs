namespace SchoolRegister.Models.CustomExceptionMessages
{
    public static class ExceptionMessages
    {
        // User
        public const string InvalidUser = "Невалиден потребител";
        public const string AlreadyExistingUser = "Потребител с този имейл вече същестува";
        public const string NonExistentUser = "Няма потребител с този имейл";
        public const string InvalidUserPassword = "Невалидна парола";

        // School
        public const string NonExistentSchool = "Няма училище с това име";
    }
}
