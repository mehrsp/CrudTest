using Domain.Customers.Services;

namespace Domain.Customers;

public class Customer:AggregateRoot
{
    private readonly ICustomerDomainService _customerDomainService;
    
    public Customer()
    {
            
    }
    public Customer(string firstname,string lastname, DateTime dateofbirth,
        string phonenumber,string email,string bankacountnumber,ICustomerDomainService customerDomainService)
    {
        _customerDomainService = customerDomainService;
        _customerDomainService.ValidateCustomer(firstname,lastname,dateofbirth,email,0);
       


        ChangeFirstName(firstname); 
       ChangeLastname(lastname);    
       ChangeDateOfBirth(dateofbirth);    
       ChangePhoneNumber(phonenumber,customerDomainService);    
       ChangeEmail(email, customerDomainService);    
       ChangeBankAccountNumber(bankacountnumber, customerDomainService);
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
    
    public void ChangePhoneNumber(string phonenumber, ICustomerDomainService customerDomainService)
    {
        if(!customerDomainService.ValidatePhoneNumber(phonenumber))
            throw new Exception("Phone Number is not Correct");
        PhoneNumber = phonenumber;
    }
    
    public void ChangeEmail(string email, ICustomerDomainService customerDomainService)
    {
        if (!customerDomainService.ValidateEmail(email))
            throw new Exception("Email is not Valid");
        Email = email;
    }
    
    public void ChangeBankAccountNumber(string bankacountnumber, ICustomerDomainService customerDomainService)
    {
        if (!customerDomainService.ValidateBAccNumber(bankacountnumber))
            throw new Exception("Bank account number is not Valid");
        BankAccountNumber = bankacountnumber;
    }

    public void Update(string firstname,string lastname, DateTime dateofbirth,string phonenumber,string email,string bankacountnumber, ICustomerDomainService customerDomainService, int id)
    {
        customerDomainService.ValidateCustomer(firstname,lastname,dateofbirth,email,id);
       

        
       ChangeFirstName(firstname); 
       ChangeLastname(lastname);    
       ChangeDateOfBirth(dateofbirth);    
       ChangePhoneNumber(phonenumber,customerDomainService);    
       ChangeEmail(email, customerDomainService);    
       ChangeBankAccountNumber(bankacountnumber, customerDomainService);
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