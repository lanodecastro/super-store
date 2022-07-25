namespace SuperStore.Domain.Model
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public User(int id, string name, string userName, string email)
        {
            Id = id;
            Name = name;
            UserName = userName;
            Email = email;
        }

    }
}
