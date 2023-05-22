using Domain.Customers.Services;

namespace Domain.Customers;

public class Customer:AggregateRoot
{
    private readonly ICustomerDomainService _customerDomainService;
    
    public Customer()
    {
            
    }
    public Customer(string firstname,string lastname, DateTime dateofbirth,
        string phonenumber,string email,string bankacountnumber)
    {
        
       


       ChangeFirstName(firstname); 
       ChangeLastname(lastname);    
       ChangeDateOfBirth(dateofbirth);    
       ChangePhoneNumber(phonenumber);    
       ChangeEmail(email);    
       ChangeBankAccountNumber(bankacountnumber);
       AddEvent(new CustomerCreatedEvent(Id,firstname,lastname,
           dateofbirth,phonenumber,email,bankacountnumber));
    }


    public void ChangeFirstName(string firstname)
    {
        Firstname = firstname;
    }
    
    public void ChangeLastname(string lastname)
    {
        Lastname = lastname;
    }
    
    public void ChangeDateOfBirth(DateTime dateofbirth)
    {
        DateOfBirth = dateofbirth;
    }
    
    public void ChangePhoneNumber(string phonenumber)
    {
        PhoneNumber = phonenumber;
    }
    
    public void ChangeEmail(string email)
    {
      
        Email = email;
    }
    
    public void ChangeBankAccountNumber(string bankacountnumber)
    {
        BankAccountNumber = bankacountnumber;
    }

    public void Update(string firstname,string lastname, DateTime dateofbirth,string phonenumber,string email,string bankacountnumber, ICustomerDomainService customerDomainService, int id)
    {
        customerDomainService.ValidateCustomer(firstname,lastname,dateofbirth,email,id);
       

        
       ChangeFirstName(firstname); 
       ChangeLastname(lastname);    
       ChangeDateOfBirth(dateofbirth);    
       ChangePhoneNumber(phonenumber);    
       ChangeEmail(email);    
       ChangeBankAccountNumber(bankacountnumber);
       AddEvent(new CustomerUpdatedEvent(Id,firstname,lastname,
           dateofbirth,phonenumber,email,bankacountnumber));
    }

    public string Firstname { get; private set; }
    public string Lastname { get;private set; }
    public DateTime DateOfBirth { get;private set; }
    public string PhoneNumber { get;private set; }
    public string Email { get;private set; }
    public string BankAccountNumber { get;private set; }

    public void DeleteValidate(int id)
    {
        //business of delete
        AddEvent(new CustomerDeletedEvent(id));
    }
}