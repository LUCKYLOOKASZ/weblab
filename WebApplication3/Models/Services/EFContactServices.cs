using WebApplication3.Models.Services;

namespace WebApplication3.Models.services;

public class EfContantService : IContactServices {
    
    private readonly AppDbContext _context;

    public EfContantService(AppDbContext context) {
        _context = context;
    }

    public void Add(ContactModel model) {
        _context.Type.Add(ContactMapper.ToEntity(model));
        _context.SaveChanges();
    }

    public void Update(ContactModel model) {
        _context.Type.Update(ContactMapper.ToEntity(model));
        _context.SaveChanges();
    }

    public void Delete(int id) {
        _context.Type.Remove(_context.Type.Find(id));
        _context.SaveChanges();
    }

    public List<ContactModel> GetAll() {
        return _context.Type.Select(ContactMapper.ToModel!).ToList();
    }

    public ContactModel? GetById(int id) {
        throw new NotImplementedException();
    }
}