using ApplicationContract.Customers.Commands;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts.Customers;

namespace Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : Controller
{
    private readonly ApplicationContract.Customers.ServiceContracts.ICustomerService _customerService;
    private readonly ServiceContracts.Customers.Contracts.ICustomerService _readcustomerService;
    public CustomerController(ApplicationContract.Customers.ServiceContracts.ICustomerService customerService, ServiceContracts.Customers.Contracts.ICustomerService readcustomerService)
    {
        _customerService = customerService;
        _readcustomerService = readcustomerService;
    }
    [HttpGet("~/GetcCustomers")]
    public List<CustomerViewModel> GetAll()
    {
        return  _readcustomerService.GetAll();
    }

    [HttpGet("~/GetCustomer")]
    public CustomerViewModel GetById(int id)
    {
        return   _readcustomerService.GetById(id);
    }
   
    [HttpPost("~/CreateCustomer")]
    public void CreateAsync(CreateCommand command)
    {
         _customerService.CreateAsync(command);
    }


    [HttpPost("~/UpdateCustomer")]
    public void UpdateAsync(UpdateCommand command)
    {
         _customerService.UpdateAsync(command);
    }

    [HttpPost("~/DeleteCustomer")]
    public void DeleteAsync(DeleteCommand command)
    {
         _customerService.DeleteAsync(command);
    }
}