using ApplicationContract.Customers.Commands;

namespace ApplicationContract.Customers.ServiceContracts;

public interface ICustomerService
{
    void CreateAsync(CreateCommand command);
    void UpdateAsync(UpdateCommand command);
    void DeleteAsync(DeleteCommand command);
}