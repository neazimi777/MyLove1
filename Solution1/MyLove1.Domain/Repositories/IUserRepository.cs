namespace MyLove1.Domain.Repositories
{
    public interface IUserRepository
    {
        public Task<User> AddAsync(User user);
        public void AddRange(List<User> users);
    }
}
