using management.Api.Domain;

namespace management.Api.Infrastructure
{
    public static class InMemoryUserStore
    {
        public static List<AppUser> Users = new()
        {
            new AppUser { Username = "admin", Password = "admin123", Role = "Admin" },
            new AppUser { Username = "user", Password = "user123", Role = "User" }
        };
    }
}