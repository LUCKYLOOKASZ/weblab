namespace WebApplication3.Models;

public class OrganizationEntity
{
    public int Id { get; set; }
    public String Name { get; set; }
    public String Nip { get; set; }
    public String REGON { get; set; }
    public Address Address { get; set; }                // osadzanie klasy
    public ISet<ContactEntity> Contact { get; set; }    //właściwość nawigacyjna
}

public class Address
{
    public string City { get; set; }
    public string Street { get; set; }
    
}