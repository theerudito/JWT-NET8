namespace JWT_Models.Entities
{
    public class Auth
    {
        public int IdAuth { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}