namespace Bookeasy.Application.Common.Models
{
    public class AuthenticationRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string IpAddress { get; set; }
    }
}
