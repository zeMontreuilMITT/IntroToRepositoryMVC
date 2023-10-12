using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace IntroToRepositoryMVC.Models.ViewModels
{
    public class CreateRoleVM
    {
        public HashSet<SelectListItem> Actors { get; set; } = new HashSet<SelectListItem>();
        public HashSet<SelectListItem> Movies { get; set; } = new HashSet<SelectListItem>();

        [Required]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }

        public CreateRoleVM(ICollection<Actor> actors, ICollection<Movie> movies)
        {

            foreach(Actor a in actors)
            {
                Actors.Add(new SelectListItem(a.Name, a.Id.ToString()));
            }

            foreach(Movie m in movies)
            {
                Movies.Add(new SelectListItem(m.Title, m.Id.ToString()));
            }
        }

    }
}
