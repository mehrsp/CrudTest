namespace ServiceContracts.Customers.Contracts;

public interface ICustomerService
{
    List<CustomerViewModel> GetAll();
    CustomerViewModel? GetById(int id);
}