using Domain.Base;

namespace Domain
{
    public class User : Entity<long>
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLoginDate { get; set; }


        private User()
        {

        }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
            CreatedAt = DateTime.Now;
            LastLoginDate = null;
        }
    }
}