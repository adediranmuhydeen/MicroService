namespace WebUser.Model
{
    public class AppUser
    {
        public int Id { get; set; }
        private string fullName;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return fullName; } set { fullName = FirstName + ", " + LastName; } }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
