using System.Text.RegularExpressions;

namespace Domain.Customers.Services;


public class CustomerDomainService:ICustomerDomainService
{
  
    private readonly ICustomerRepository _customerRepository;

    public CustomerDomainService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public bool ValidatePhoneNumber(string number)
    {
        var isPhone = IsPhoneNbr(number);
        if (!isPhone)
        {
            return false;
        }
        else
            return true;
    }

    public bool ValidateBAccNumber(string number)
    {
        var isValid= IsValidBAC(number);
        if (!isValid)
        {
            return false;
        }
        else
            return true;
    }


    public bool ValidateEmail(string email)
    {
        var isValid = IsValidemail(email);
        if (!isValid)
        {
            return false;
        }
        else
            return true;
    }



    public  void ValidateCustomer(string fname, string lname ,DateTime dbirth,string email,int id=0)
    {
       

        var customers =   _customerRepository.GetAllCustomers();
        if(id>0)
         customers = _customerRepository.GetAllCustomersNotId(id);

        if (customers != null)
        {
            
            if (ValidateDuplicateCustomer(customers,  fname,  lname,  dbirth))
                throw new Exception("this customer is exist");
            if (ValidateCustomerEmailDuplication(customers,email))
                throw new Exception("this Email is exist");
            
        }


    }



    public bool ValidateDuplicateCustomer(List<Customer> customers, string fname, string lname, DateTime dbirth)
    {
        bool result = false;
        foreach (var c in customers)
        {
            if (c.Firstname == fname && c.Lastname == lname && c.DateOfBirth == dbirth)
            {
                result = true;
                break;
            }
            
        }
        return result;
       
        
    }

    public bool ValidateCustomerEmailDuplication(List<Customer> customers,string email)
    {
        bool result = false;
        foreach (var c in customers)
        {
            if (c.Email == email)
            {
                result = true;
                break;
            }

        }
        return result;



    }

    // Regular expression used to validate a phone number.
    private const string motif = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";

   // private const string bacc = @"((\\d{4})-){3}\\d{4}";
    private const string email = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

    private bool IsPhoneNbr(string number)
    {
        return Regex.IsMatch(number, motif);
    }

  
    private bool IsValidBAC(string input)
    {

        string[] splited = input.Split('-');
        return splited.All(a => a.Length == 4) && !splited.Any(a => a.Any(b => b < 48 || b > 57));
        //return Regex.IsMatch(input, bacc);
    }


    private bool IsValidemail(string input)
    {
        return Regex.IsMatch(input, email);
    }

    public  List<Customer> MocList()
    {
        var  sessions = new List<Customer>();
        sessions.Add(new Customer("A", "B", new DateTime(2016, 7, 2), "(123) 456-7890", "Test@gmail.com", "122105155", this));
        sessions.Add(new Customer("A1", "B1", new DateTime(2016, 7, 1), "123-456-7890", "Test1@gmail.com","892145655", this));
        
        return sessions;
    }


    public  Customer MocCustomer()
    {
        var session = new Customer("A1", "B1", new DateTime(2016, 7, 1), "123-456-7890", "Test1@gmail.com", "892145655", this);

        return session;
    }

  
}