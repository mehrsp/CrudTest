using ApplicationContract.Customers.Commands;

namespace Domain.Customers.Services;

public interface ICustomerRepository
{
    
    void CreateAsync(Customer command);

    void UpdateAsync(Customer customer, UpdateCommand command, ICustomerDomainService _customerDomainService);
    Customer GetById(int id);
    void DeleteAsync(Customer command);
    List<Customer> GetAllCustomers();
    List<Customer> GetAllCustomersNotId(int id);
}