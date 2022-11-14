namespace Domain.Customers.Services;

public class CustomerCreatedEvent
{
    public CustomerCreatedEvent(int id,string firstname, string lastname,
        DateTime dateOfBirth, string phoneNumber, string email, string bankAccountNumber)
    {
        Firstname = firstname;
        Lastname = lastname;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        BankAccountNumber = bankAccountNumber;
        Id = id;
    }
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string BankAccountNumber { get; set; }
}