using ApplicationContract.Customers.Commands;
using ApplicationContract.Customers.ServiceContracts;
using Domain.Customers;
using Domain.Customers.Services;
using Infra;
using Microsoft.EntityFrameworkCore;

namespace Application.Customers;

public class CreateCommandHandler:ICustomerService
{
    
    private readonly ICustomerRepository _customerRepository;
    private readonly ICustomerDomainService _customerDomainService;
    public CreateCommandHandler(DataContext context, ICustomerDomainService customerDomainService,ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
        _customerDomainService = customerDomainService;
    }
    public void CreateAsync(CreateCommand command)
    {
        var customer = new Customer(command.FirstName, command.LastName, command.DateOfBirth, command.PhoneNumber,
            command.Email, command.BankAccountNumber,_customerDomainService);
         _customerRepository.CreateAsync(customer);
    
    }

    public void UpdateAsync(UpdateCommand command)
    {
        var customer =  _customerRepository.GetById(command.Id);
        _customerRepository.UpdateAsync(customer,command, _customerDomainService);

      
    }
    
    public void DeleteAsync(DeleteCommand command)
    {

        var customer =  _customerRepository.GetById(command.Id);

         customer.DeleteValidate(command.Id);
         _customerRepository.DeleteAsync(customer);
      
       
    }
}