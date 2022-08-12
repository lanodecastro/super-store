namespace SuperStore.Domain.Account
{
    public interface IUserRepository
    {
        User Get(int userId);

    }
}
