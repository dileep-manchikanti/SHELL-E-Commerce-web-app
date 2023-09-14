using Bootcamp_Project.EF_Core;
using Bootcamp_Project.EF_Core.UserDetails;
using Bootcamp_Project.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Globalization;
using System.Net;
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

        public IActionResult GetUserAddresses(int user_id)
        {
            try
            {
                _logger.LogInformation("inside user service start");
                var user_addresses = _context.User_Addresses.Where(e => e.userid == user_id);
                if (user_addresses == null)
                {
                    return NotFound(new { errorCode = StatusCodes.Status404NotFound, errorMessage = "User not found" });
                }
                Console.WriteLine(user_addresses);
                _logger.LogInformation("inside user service start after if");

                List<int> addressIds = new List<int>();
                foreach (var address in user_addresses)
                {
                    addressIds.Add(address.addressid);
                }
                var resp = _context.Addresses.Where(e => addressIds.Contains(e.Id));

                List<UserAddressesResponse> addresses = new List<UserAddressesResponse>();
                foreach (var address in resp)
                {
                    addresses.Add(new UserAddressesResponse()
                {
                        addressLine1 = address.addressLine1,
                        addressLine2 = address.addressLine2,
                        city = address.city,
                        state = address.state,
                        postalCode = address.postalCode,
                        landmark = address.landmark
                    });
                }
                return Ok(addresses);
            }
            catch (Exception ex)
            {
                return BadRequest(new { errorCode = StatusCodes.Status500InternalServerError, errorMessage = ex.Message });
            }
        }

        public IActionResult AddAddress([FromBody] AddressRequest address)
        {
            try
            {
                Address newAddress = new Address()
                {
                    addressLine1 = address.addressLine1,
                    addressLine2 = address.addressLine2,
                    city = address.city,
                    state = address.state,
                    postalCode = address.postalCode,
                    landmark = address.landmark
                };
                _context.Addresses.Add(newAddress);

                User_Address newUserAddress = new User_Address() {
                    user = _context.Users.Where(e => e.Id == address.userId).FirstOrDefault(),
                    address = newAddress,
                    isDefault = address.isDefault
                };
                if(address.isDefault)
                {
                    var existingAddress = _context.User_Addresses.Where(e => e.userid==address.userId &&  e.isDefault == true).FirstOrDefault();
                    if(existingAddress != null) {
                        existingAddress.isDefault = false;
                    }
                }
                _context.User_Addresses.Add(newUserAddress);
                _context.SaveChanges();
                return Ok(address);
            }
            catch (Exception ex)
            {
                return BadRequest(new { errorCode = StatusCodes.Status500InternalServerError, errorMessage = ex.Message });
            }
        }


        public IActionResult UpdateAddress([FromBody] AddressRequest data,int address_id)
        {
            try
            {
                var user = _context.Users.Where(e => e.Id == data.userId).FirstOrDefault();
                if (user == null)
                {
                    return NotFound(new { errorCode = StatusCodes.Status404NotFound, errorMessage = "User not found" });
                }
                var userAddress = _context.User_Addresses.Where(e => e.userid == data.userId && e.addressid == address_id).FirstOrDefault();
                if (userAddress == null)
                {
                    return NotFound(new { errorCode = StatusCodes.Status404NotFound, errorMessage = "Address with given user id not found" });
                }
                var address = _context.Addresses.Where(e => e.Id == address_id).FirstOrDefault();
                if(address == null)
                {
                    return NotFound(new { errorCode = StatusCodes.Status404NotFound, errorMessage = "Address not found" });
                }
                address.addressLine1 = data.addressLine1;
                address.addressLine2 = data.addressLine2;
                address.postalCode = data.postalCode;
                address.landmark = data.landmark;
                address.city = data.city;
                address.state = data.state;

                userAddress.isDefault = data.isDefault;
                if (data.isDefault)
                {
                    var existingAddress = _context.User_Addresses.Where(e => e.userid == data.userId && e.isDefault == true).FirstOrDefault();
                    if (existingAddress != null)
                    {
                        existingAddress.isDefault = false;
                    }
                }

                _context.SaveChanges();
                return Ok(address);

            }
            catch (Exception ex)
            {
                return BadRequest(new { errorCode = StatusCodes.Status500InternalServerError, errorMessage = ex.Message });
            }
        }

    }
}
