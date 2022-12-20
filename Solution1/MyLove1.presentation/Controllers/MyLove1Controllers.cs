using CPM.Dimension.Presentation.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using MyLove1.DomainService.Abstractions;
using MyLove1.Dto;

namespace MyLove1.presentation.Controllers
{
    public class MyLove1Controllers : ApiControllerBase
    {
        private readonly IUserService _userService;
        public MyLove1Controllers(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost()]
        public IActionResult Post([FromBody] CreateUserDto createUserDto)
        {
            var response = _userService.CreateUsers(createUserDto);

            return Ok(response);
        }
    }
}
