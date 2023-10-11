using IntroToRepositoryMVC.Data;

namespace IntroToRepositoryMVC.Models.BusinessLogicLayer
{
    public class MovieBusinessLogic
    {
        private IRepository<Movie> _movieRepository;
        public MovieBusinessLogic(IRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
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
    }
}
