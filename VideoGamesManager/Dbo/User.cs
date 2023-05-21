using Microsoft.AspNetCore.Identity;

namespace VideoGamesManager.Dbo
{
    public class User : IObjectWithId
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; } = "Test";
        public bool RememberMe { get; set; } = false;

        public virtual string NormalizedUserName { get; set; } = string.Empty;

        public virtual string NormalizedEmail { get; set; } = string.Empty;

        public virtual bool EmailConfirmed { get; set; } = false;

        public virtual string PasswordHash { get; set; } = string.Empty;

        public virtual string SecurityStamp { get; set; } = Guid.NewGuid().ToString();

        public virtual string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

        public virtual bool PhoneNumberConfirmed { get; set; } = false;
        public virtual bool TwoFactorEnabled { get; set; } = false;
        public virtual DateTimeOffset LockoutEnd { get; set; } = new DateTimeOffset(2000, 1, 1, 0, 0, 0, TimeSpan.Zero);

        public virtual bool LockoutEnabled { get; set; } = false;

        public virtual int AccessFailedCount { get; set; } = 0;
    }
}
