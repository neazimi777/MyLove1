using MyLove1.Dto;

namespace MyLove1.DomainService.Abstractions
{
    public  interface IUserService
    {
        public CommandResponse CreateUsers(CreateUserDto createUserDto);
        
    }
}
