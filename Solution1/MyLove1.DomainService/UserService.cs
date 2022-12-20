using MyLove1.Domain;
using MyLove1.Domain.Repositories;
using MyLove1.DomainService.Abstractions;
using MyLove1.Dto;

namespace MyLove1.DomainService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService (IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public CommandResponse CreateUsers(CreateUserDto createUserDto)
        {
            try
            {
                var users = new List<User>();
                for (int i = 1; i <= createUserDto.NumberUser; i++)
                {
                    users.Add(new User
                    {
                        Name = createUserDto.Name + "-" + i.ToString(),
                        LastName = createUserDto.Name + "-" + i.ToString()
                    });
                }
                _userRepository.AddRange(users);
                return new CommandResponse { Successful = true };
            }
            catch
            {
                throw new BadRequestException("ساخت کاربر با خطا مواجه شد");
            }
        }
    }
}
