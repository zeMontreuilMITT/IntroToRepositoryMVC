using IntroToRepositoryMVC.Models;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace IntroToRepositoryMVC.Data
{
    public class ActorRepository: IRepository<Actor>
    {
        private IntroToRepositoryMVCContext _context;
        public ActorRepository(IntroToRepositoryMVCContext context)
        {
            _context = context;
        }

        public Actor Create(Actor entity)
        {
            _context.Actor.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Actor entity)
        {
            _context.Actor.Remove(entity);
            _context.SaveChanges();
        }
        public Actor Get(int id)
        {
            Actor actor = _context.Actor.Find(id);
            return actor;
        }

        public ICollection<Actor> GetAll()
        {
            return _context.Actor.ToHashSet();
        }

        public Actor Update(Actor entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }



    }
}
