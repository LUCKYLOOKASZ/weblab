namespace WebApplication3.Models.Services;

public interface IContactServices
{
    void Add(ContactModel model);
    void Update(ContactModel model);
    void Delete(int id);
    List<ContactModel> GetAll();
    ContactModel? GetById(int id);
}