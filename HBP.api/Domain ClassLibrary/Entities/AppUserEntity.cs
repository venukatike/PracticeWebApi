namespace HBP.api.Domain_ClassLibrary.Entities
{
    public class AppUserEntity
    {
        public long UserId { get; set; }

        public string Username { get; set; } = null!;

        public string? Email { get; set; }

        public string? DisplayName { get; set; }

        public string? PasswordHash { get; set; }

        public bool IsActive { get; set; }
    }
}
