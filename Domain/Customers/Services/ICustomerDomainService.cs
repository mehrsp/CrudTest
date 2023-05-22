namespace Domain.Customers.Services;

public interface ICustomerDomainService
{
    bool ValidatePhoneNumber(string phoneNumber);
    bool ValidateBAccNumber(string number);
    bool ValidateEmail(string email);
    void ValidateCustomer(string fname,string lname,DateTime bd,string email,int id);
    bool ValidateDuplicateCustomer(List<Customer> customers, string fname, string lname, DateTime dbirth);
    bool ValidateCustomerEmailDuplication(List<Customer> customers, string email);
    List<Customer> MocList();
    Customer MocCustomer();


}