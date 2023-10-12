using IntroToRepositoryMVC.Data;
using IntroToRepositoryMVC.Models.ViewModels;

namespace IntroToRepositoryMVC.Models.BusinessLogicLayer
{
    public class MovieBusinessLogic
    {
        private IRepository<Movie> _movieRepository;
        private IRepository<Actor> _actorRepository;
        public MovieBusinessLogic(IRepository<Movie> movieRepository, IRepository<Actor> actorRepository)
        {
            _movieRepository = movieRepository;
            _actorRepository = actorRepository;
        }

        public Movie GetMovie(int id)
        {
            try
            {
                return _movieRepository.Get(id);
            }
            catch
            {
                throw new InvalidOperationException();
            }
        }

        public CreateRoleVM InitializeCreateRoleVM()
        {
            // unit test: make sure it has a count of selectListItems equal to the number of actors and movies in the database
            CreateRoleVM newVm = new CreateRoleVM(_actorRepository.GetAll(), 
                _movieRepository.GetAll());
            return newVm;
        }
    }
}
