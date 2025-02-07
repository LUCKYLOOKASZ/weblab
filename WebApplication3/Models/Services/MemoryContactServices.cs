﻿namespace WebApplication3.Models.Services;

public class MemoryContactService : IContactServices {

    private static Dictionary<int, ContactModel> _contacts = new() {
        {
            1,
            new ContactModel {
                Id = 1, FirstName = "Jan", LastName = "Kowalski", Email = "", PhoneNumber = "123 456 789",
                BirthDate = new DateOnly(1990, 1, 1)
            }
        }, {
            2,
            new ContactModel {
                Id = 2, FirstName = "Anna", LastName = "Nowak", Email = "", PhoneNumber = "987 654 321",
                BirthDate = new DateOnly(1995, 5, 5)
            }
        }, {
            3,
            new ContactModel {
                Id = 3, FirstName = "Piotr", LastName = "Wiśniewski", Email = "", PhoneNumber = "456 789 123",
                BirthDate = new DateOnly(2000, 10, 10)
            }
        }
    };
    
    public void Add(ContactModel contactModel) {
        int newId = _contacts.Keys.Max() + 1;
        contactModel.Id = newId;
    }

    public void Update(ContactModel contactModel) {
        if (_contacts.ContainsKey(contactModel.Id)) {
            _contacts[contactModel.Id] = contactModel;
        }
    }

    public void Delete(int id) {
        _contacts.Remove(id);
    }

    public List<ContactModel> GetAll() {
        return _contacts.Values.ToList();
    }

    public ContactModel? GetById(int id) {
        return _contacts.ContainsKey(id) ? _contacts[id] : null;
    }

    public List<OrganizationEntity> getOrganizations()
    {
        throw new NotImplementedException();
    }
}