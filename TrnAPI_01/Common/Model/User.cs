namespace Common.Model
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public int EmailId { get; set; }
    }
}
