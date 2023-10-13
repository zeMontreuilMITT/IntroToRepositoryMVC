using IntroToRepositoryMVC.Data;
using IntroToRepositoryMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IntroToRepositoryMVC.Models.BusinessLogicLayer
{
    public class MovieBusinessLogic
    {
        private readonly IRepository<Movie> _movieRepository;
        private readonly IRepository<Actor> _actorRepository;
        private readonly IRepository<Role> _roleRepository;
        public MovieBusinessLogic(IRepository<Movie> movieRepository, IRepository<Actor> actorRepository, IRepository<Role> roleRepository)
        {
            _movieRepository = movieRepository;
            _actorRepository = actorRepository;
            _roleRepository = roleRepository;
        }

        public Movie GetMovie(int id)
        {
            Movie foundMovie = _movieRepository.Get(id);

            if (foundMovie == null)
            {
                throw new InvalidOperationException("Movie not found");
            } else
            {
                return foundMovie;
            }

        }
        public Actor GetActor(int id)
        {
            Actor foundActor = _actorRepository.Get(id);

            if(foundActor == null)
            {
                throw new InvalidOperationException("Actor not found");
            } else
            {
                return foundActor;
            }
        }
        public Movie CreateMovie(Movie movie)
        {
            _movieRepository.Create(movie);
            return movie;
        }
        public Movie AddMovie(Movie movie)
        {
            try
            {
                _movieRepository.Create(movie);
                return movie;
            } catch(Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        public CreateRoleVM InitializeCreateRoleVM()
        {
            // unit test: make sure it has a count of selectListItems equal to the number of actors and movies in the database
            CreateRoleVM newVm = new CreateRoleVM(_actorRepository.GetAll(), 
                _movieRepository.GetAll());
            return newVm;
        }
        public Role AddToRole(Movie movie, Actor actor, string credit)
        {
            Role newRole = new Role { MovieId = movie.Id, ActorId = actor.Id, RoleCredit = credit };
            _roleRepository.Create(newRole);
            return newRole;
        }
    }
}
