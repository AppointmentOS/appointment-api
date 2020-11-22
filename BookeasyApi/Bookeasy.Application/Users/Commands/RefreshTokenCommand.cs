namespace Bookeasy.Application.Users.Commands
{
    public class RefreshTokenCommand
    {
        public string RefreshToken { get; set; }
        public string UserId { get; set; }
        public string IpAddress { get; set; }
    }
}
