namespace TrnAPI_01.Models
{
    public class CreateUserViewModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int EmailId { get; set; }
    }
}