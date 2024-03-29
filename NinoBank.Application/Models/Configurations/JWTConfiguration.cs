namespace NinoBank.Application.Models.Configurations
{
    public class JWTConfiguration
    {
        public required string Secret { get; set; }
        public int ExpirationInMinutes { get; set; }
        public required string ValidAudience { get; set; }
        public required string ValidIssuer { get; set; }
    }
}
