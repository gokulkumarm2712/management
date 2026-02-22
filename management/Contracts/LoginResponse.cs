namespace management.Api.Contracts
{
    public class LoginResponse
    {
        public string Token { get; set; } = "";
        public DateTime ExpiresAt { get; set; }
    }
}