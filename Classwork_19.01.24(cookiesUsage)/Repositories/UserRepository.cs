using Classwork_19._01._24_cookiesUsage_.Models;

namespace Classwork_19._01._24_cookiesUsage_.Repositories
{
    public class UserRepository
    {
        private readonly List<User> users;

        public UserRepository()
        {
            users = new List<User>()
            {
                new User{Id = 1, Name = "Emily Johnson", Email = "emily.johnson@example.com"},
                new User{Id = 1, Name = "Marcus Rodriguez", Email = "marcus.rodriguez@example.com"},
                new User{Id = 1, Name = "Olivia Campbell", Email = "olivia.campbell@example.com"},
                new User{Id = 1, Name = "Xavier Liu", Email = "xavier.liu@example.com"},
                new User{Id = 1, Name = "Ava Patel", Email = "xava.patel@example.com"},
            };
        }

        public List<User> GetAllUsers()
        {
            return users;
        }

        public User GetUserById(int id)
        {
            return users.FirstOrDefault(e => e.Id.Equals(id))!;
        }
    }
}
