using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GeneralService.Model;
using GeneralService.Model.Response;
using GeneralService.Model.Mapper;

namespace GeneralService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet("UsersInfo")]
        [Produces(typeof(UsersResponse))]
        public IActionResult All()
        //public IEnumerable<UsersResponse> All()
        {
            List<Users> users = new List<Users>()
            {
                new Users()
                {
                    Id = 1,
                    UserName = "Test",
                    Email = "test@gmail.com"
                },
                new Users()
                {
                    Id = 2,
                    UserName = "Test2",
                    Email = "test2@gmail.com"
                },
                new Users()
                {
                    Id = 3,
                    UserName = "Test3",
                    Email = "test3@gmail.com"
                }
            };

            if (users != null && users.Count > 0)
            {
                List<UsersResponse> usersResponses = new List<UsersResponse>();

                foreach (var user in users)
                {
                    usersResponses.Add(UsersMapper.toUsersResponse(user));
                }

                return Ok(usersResponses);

            }

            return NotFound("No users in database or cannot reach to data");
        }

        [HttpPost("ProfilePicture/{UserName}")]
        public async Task<IActionResult> UploadProfilePic(IFormFile photo, [FromRoute]string UserName)
        {
            if (photo != null && photo.Length > 0)
            {

                var Path = "C:\\Users\\artit\\OneDrive\\รูปภาพ\\Profile Picture\\" + UserName + System.IO.Path.GetExtension(photo.FileName);

                using (var stream = new FileStream(Path, FileMode.CreateNew))
                {
                    await photo.CopyToAsync(stream);
                    
                    stream.Dispose();
                }

                return Ok("Success");
            }

            return BadRequest("Cannot upload, Please try again later");
        }
    }
}
