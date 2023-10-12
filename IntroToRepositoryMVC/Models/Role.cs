namespace IntroToRepositoryMVC.Models
{
    public class Role
    { 
        public Movie Movie { get; set; }
        public int MovieId {  get; set; }
        public Actor Actor { get; set; }
        public int ActorId { get; set; }
        public string RoleCredit {  get; set; }
    }
}
