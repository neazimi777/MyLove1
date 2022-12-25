using MyLove1.Domain;
using MyLove1.Domain.Repositories;

namespace MyLove1.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MyLove1DBContext _myLove1DBContext;
        public UserRepository(MyLove1DBContext myLove1DBContext)
        {
            _myLove1DBContext=myLove1DBContext;
        }
        //public async Task<User> AddAsync(User user)
        //{
        //   return  await _myLove1DBContext.User
        //        .AddAsync(user);
        //}

        public void AddRange(List<User> users)
        {
            _myLove1DBContext.User.AddRange(users);
        }
    }
}
