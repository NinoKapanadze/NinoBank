namespace NinoBank.Application.Models
{
    public class RegisterUserDTO
    {
        public required Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public decimal Balance { get; set; }
    }
}
