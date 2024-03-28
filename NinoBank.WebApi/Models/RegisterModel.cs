namespace NinoBank.WebApi.Models
{
    public class RegisterModel
    {
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Password { get; set; }
        public decimal Balance { get; set; } 
    }
}
