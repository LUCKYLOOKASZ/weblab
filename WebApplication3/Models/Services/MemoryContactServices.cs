namespace WebApplication3.Models.Services;

public class MemoryContactServices: IContactServices
{
    private Dictionary<int, ContactModel> _contacts = new()
    {
        {
            1,
            new ContactModel()
            {
                Id = 1,
                FirstName = "Krzysztof",
                Category = Category.Business,
                LastName = "Ryszard",
                Email = "krzys@gmail.com",
                PhoneNumber = "222 333 444",
                BirthDate = new DateOnly(2003,10,10)
            }
        },
        {
            2,
            new ContactModel()
            {
                Id = 2,
                FirstName = "Michal",
                Category = Category.Business,
                LastName = "Mati",
                Email = "matmich@gmail.com",
                PhoneNumber = "333 333 444",
                BirthDate = new DateOnly(2003,11,10)
            }
        }
        ,
        {
            3,
            new ContactModel()
            {
                Id = 3,
                FirstName = "Domi",
                LastName = "Korba",
                Category = Category.Friend,
                Email = "domkor@gmail.com",
                PhoneNumber = "444 333 444",
                BirthDate = new DateOnly(2003,4,15)
            }
        }
    };
    
    private int currentId = 3;
    
    public void Add(ContactModel model)
    {
        model.Id = ++currentId;
        _contacts.Add(model.Id, model);
    }

    public void Update(ContactModel model)
    {
        if (_contacts.ContainsKey(model.Id))
        {
            _contacts[model.Id] = model;
        }
    }

    public void Delete(int id)
    {
        _contacts.Remove(id);
    }

    public List<ContactModel> GetAll()
    {
        return _contacts.Values.ToList();
    }

    public ContactModel? GetById(int id)
    {
        return _contacts[id];
    }
}