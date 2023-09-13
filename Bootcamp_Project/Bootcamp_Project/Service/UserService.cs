using Bootcamp_Project.EF_Core;
using Bootcamp_Project.Models.Users;

namespace Bootcamp_Project.Service
{
    public class UserService
    {
        private readonly EF_DataContext _context;

        public UserService(EF_DataContext context)
        {
            _context = context;
        }

        public List<UserModel> GetUsers()
        {
            List<UserModel> users = new List<UserModel>();
            var response = _context.Users.ToList();
            response.ForEach(row => users.Add(new UserModel()
            {
                Id = row.Id,
                Email = row.Email,
                phoneNumber = row.phoneNumber,
                Password = row.Password,
                status = row.status
            }));
            return users;
        }

        public UserModel GetUser(int id)
        {
            var response = _context.Users.Find(id);
            if (response == null)
            {
                return null;
            }
            UserModel user = new UserModel()
            {
                Id = id,
                phoneNumber = response.phoneNumber,
                Email = response.Email,
                Password = response.Password,
                status = response.status
            };
            return user;
        }
    }
}
