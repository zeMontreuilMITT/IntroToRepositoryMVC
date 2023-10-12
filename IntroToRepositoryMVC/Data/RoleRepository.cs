using IntroToRepositoryMVC.Models;

namespace IntroToRepositoryMVC.Data
{
    public class RoleRepository : IRepository<Role>
    {
        private IntroToRepositoryMVCContext _context;
        public RoleRepository(IntroToRepositoryMVCContext context)
        {
            _context = context;
        }

        public Role Create(Role entity)
        {
            _context.Role.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Role entity)
        {
            _context.Role.Remove(entity);
            _context.SaveChanges();
        }

        public Role Get(int id)
        {
            Role role = _context.Role.Find(id);
            return role;
        }

        public ICollection<Role> GetAll()
        {
            return _context.Role.ToHashSet();
        }

        public Role Update(Role entity)
        {
            _context.Role.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
