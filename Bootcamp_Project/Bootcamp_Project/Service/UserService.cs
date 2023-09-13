using Bootcamp_Project.EF_Core;
using Bootcamp_Project.EF_Core.UserDetails;
using Bootcamp_Project.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Globalization;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Bootcamp_Project.Service
{
    public class UserService:ControllerBase
    {
        private readonly ILogger _logger;
        private readonly EF_DataContext _context;
        private static string salt = "shell-sell";
        public UserService(EF_DataContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }


        public IActionResult GetUsers()
        {
            try
            {
                List<UserResponse> users = new List<UserResponse>();
                var response = _context.Users.ToList();
                response.ForEach(row => users.Add(new UserResponse()
                {
                    Email = row.Email,
                    phoneNumber = row.phoneNumber,
                    fullName = row.fullName,
                }));
                _logger.LogInformation("Users fetched successfully");
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while fetching users. Error : {ex.Message}");
                return BadRequest(new { errorCode = StatusCodes.Status500InternalServerError, errorMessage = ex.Message });
            }
        }

        public IActionResult GetUser(int id)
        {
            try
            {
                var response = _context.Users.Find(id);
                if (response == null)
                {
                    _logger.LogInformation($"User with id {id} not found");
                    return NotFound(new {errorCode=StatusCodes.Status404NotFound,errorMessage=$"User with id = {id} not found"});
                }
                UserResponse user = new UserResponse()
                {
                    phoneNumber = response.phoneNumber,
                    Email = response.Email,
                    fullName = response.fullName
                };
                _logger.LogInformation($"User with id {id} fetched successfully");
                return Ok(user);
            }
            catch(Exception ex) 
            {
                _logger.LogError($"Error while fetching user. Error : {ex.Message}");
                return BadRequest(new { errorCode = StatusCodes.Status500InternalServerError, errorMessage = ex.Message });
            }
        }

        public IActionResult RegisterUser(RegisterRequest newUser)
        {

            try
            {
                var fullName = newUser.firstName + " "+ newUser.lastName;
                string format = "dd-MM-yyyy";
                DateTime dob = DateTime.SpecifyKind(DateTime.ParseExact(newUser.dateOfBirth, format, CultureInfo.InvariantCulture), DateTimeKind.Utc);

                string hashedPassword = BCryptNet.HashPassword(newUser.password,salt);
                string hashedEmail = BCryptNet.HashPassword(newUser.Email, salt);
                string hashedPhoneNumber = BCryptNet.HashPassword(newUser.phoneNumber, salt);
                User user = new User()
                {
                    Email = hashedEmail,
                    phoneNumber = hashedPhoneNumber,
                    firstName = newUser.firstName,
                    lastName = newUser.lastName,
                    fullName = fullName,
                    dateOfBirth = dob,
                    Password = hashedPassword
                };

                _context.Add(user);
                _context.SaveChanges();
                return Ok(newUser);
            }
            catch (Exception ex)
            {
                return BadRequest(new { errorCode = StatusCodes.Status500InternalServerError, errorMessage = ex.Message });
            }
        }

        public IActionResult LoginUser(LoginRequest data)
        {
            try
            {
                var hashedEmail = BCryptNet.HashPassword(data.email,salt);
                var user = _context.Users.FirstOrDefault(e => e.Email == hashedEmail);
                
                if (user == null)
                {
                    return NotFound(new { errorCode = StatusCodes.Status404NotFound, errorMessage = "Invalid credentials" });
                }
                bool isPasswordMatch = BCryptNet.Verify(data.password, user.Password);
                if (isPasswordMatch)
                {
                    return Ok("Login Successfull");
                }
                return BadRequest(new {errorCode=400,errorMessage="Invalid credentials" });
            }
            catch(Exception ex)
            {
                return BadRequest(new { errorCode = StatusCodes.Status500InternalServerError, errorMessage = ex.Message });
            }
        }
    }
}
