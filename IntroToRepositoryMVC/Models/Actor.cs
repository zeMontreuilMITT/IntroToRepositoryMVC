namespace IntroToRepositoryMVC.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public HashSet<Role> Roles { get; set; } = new HashSet<Role>();
    }
}
