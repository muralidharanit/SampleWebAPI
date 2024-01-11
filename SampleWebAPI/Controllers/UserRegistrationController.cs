using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using SampleWebAPI.Data;
using SampleWebAPI.Helper;

namespace SampleWebAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        private readonly ApiDBContext _dbContext;
        public UserRegistrationController(ApiDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {            
            var users = await(from user in  _dbContext.Users
                              select new 
                              {
                                  user.Id,
                                  user.Name,
                                  user.Mobile,
                                  user.EMail,
                                  user.Address                                  
                              }).ToListAsync();
            return Ok(users);
        }
        
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromForm]User user)
        {
            if(user != null)
            {
                if (user.AadhaarImage != null)
                {
                    user.AadhaarImagePath = await FileManager.UploadImageToCloudContainer(user.AadhaarImage);
                }

                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                
                return Ok(StatusCodes.Status201Created);
            }
            return BadRequest(StatusCodes.Status400BadRequest);
        }

        [HttpPut]
        public void UpdateUserProfile(int id, [FromBody] User user)
        {            
            Console.WriteLine("User modified : {0}, {1}", user, id);
        }

        [HttpDelete]
        public void DeleteUserProfile(int id)
        {
            Console.WriteLine("User deleted : {0}", id);
        }
    }
}
