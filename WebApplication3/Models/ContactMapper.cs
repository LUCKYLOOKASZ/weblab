namespace WebApplication3.Models;

public class ContactMapper {

    public static ContactEntity? ToEntity(ContactModel model) {
        return new ContactEntity {
            Name = model.FirstName,
            Surname = model.LastName,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            BirthDate = model.BirthDate,
            Category = model.Category,
            Created = DateTime.Now
        };
    }
    
    public static ContactModel ToModel(ContactEntity entity) {
        return new ContactModel {
            Id = entity.Id,
            FirstName = entity.Name,
            LastName = entity.Surname,
            Email = entity.Email,
            PhoneNumber = entity.PhoneNumber,
            BirthDate = entity.BirthDate,
            Category = entity.Category
        };
    }
}