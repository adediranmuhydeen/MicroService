using User.Data;
using User.Model;

namespace User.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public AppUser AddUser(AppUser user)
        {
            var appUser = _context.Users.Add(user);
            _context.SaveChanges();
            return appUser.Entity;
        }

        public bool DeleteUser(int Id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == Id);
            if (user == null)
            {
                return false;
            }
            _context.Remove(user);
            _context.SaveChanges();
            return true;
        }

        public AppUser GetUserById(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public IEnumerable<AppUser> GetUserList()
        {
            return _context.Users.ToList();
        }

        public AppUser UpdateUser(AppUser product)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == product.Email);
            if (user == null)
            {
                return null;
            }
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }
    }
}
