using GeneralService.Model;
using GeneralService.Model.Response;

namespace GeneralService.Model.Mapper
{
    public static class UsersMapper
    {
        public static UsersResponse toUsersResponse(Users user)
        {
            UsersResponse response = new UsersResponse()
            {
                UserName = user.UserName,
                Email = user.Email
            };

            return response;
        }
    }
}
