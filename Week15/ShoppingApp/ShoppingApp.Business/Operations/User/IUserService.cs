using ShoppingApp.Business.Operations.User.Dtos;
using ShoppingApp.Business.Types;
using ShoppingApp.Business.Operations.User.Dtos;
using ShoppingApp.Business.Types;

namespace ShoppingApp.Business.Operations.User
{
    // lifetime must be specified
    public interface IUserService
    {
        Task<ServiceMessage> AddUser(AddUserDto user);

        ServiceMessage<UserInfoDto> LoginUser(LoginUserDto user);
    }
}