namespace SportBookApi.Model.DTO
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public List<Review> Reviews { get; set; } = new();
    }
}
