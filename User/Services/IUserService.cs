using WebUser.Model;

namespace WebUser.Services
{
    public interface IUserService
    {
        public IEnumerable<AppUser> GetUserList();
        public AppUser GetUserById(int id);
        public AppUser AddUser(AppUser product);
        public AppUser UpdateUser(AppUser product);
        public bool DeleteUser(int Id);
    }
}
