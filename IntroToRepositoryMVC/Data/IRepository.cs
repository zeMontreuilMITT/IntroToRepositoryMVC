using IntroToRepositoryMVC.Models;

namespace IntroToRepositoryMVC.Data
{
    public interface IRepository<T> where T : class
    {
        public T Get(int id);
        public ICollection<T> GetAll();
        public T Create(T entity);
        public T Update(T entity);
        public void Delete(T entity);
    }
    public class MovieRepository: IRepository<Movie>
    {
        private IntroToRepositoryMVCContext _context;
        public MovieRepository(IntroToRepositoryMVCContext context)
        {
            _context = context;
        }

        public Movie Create(Movie entity)
        {
            _context.Movie.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Movie entity)
        {
            _context.Movie.Remove(entity);
            _context.SaveChanges();
        }

        public Movie Get(int id)
        {
            return _context.Movie.Find(id);
        }

        public ICollection<Movie> GetAll()
        {
            return _context.Movie.ToList();
        }

        public Movie Update(Movie entity)
        {
            _context.Movie.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
