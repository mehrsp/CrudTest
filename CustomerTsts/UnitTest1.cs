using Domain.Customers;
using Domain.Customers.Services;

namespace CustomerTsts
{
    [TestClass]
    public class UnitTest1
    {
        private readonly ICustomerDomainService _customerDomainService;
        public UnitTest1(ICustomerDomainService customerDomainService)
        {
            _customerDomainService = customerDomainService;
        }
        [TestMethod]
        public void ValidatePhoneNumberReturnsTrue()
        {
            //Arrang
            string phonenumber = "(123) 456 - 7890";
            //Act
            bool result= _customerDomainService.ValidatePhoneNumber(phonenumber);
            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void ValidateEmailReturnsTrue()
        {
            //Arrang
            string email = "test@gmail.com";
            //Act
            bool result = _customerDomainService.ValidateEmail(email);
            //Assert
            Assert.IsTrue(result);

        }


        [TestMethod]
        public void ValidateBankAccNumberReturnsTrue()
        {
            //Arrang
            string BankAccNumber = "122105155";
            //Act
            bool result = _customerDomainService.ValidatePhoneNumber(BankAccNumber);
            //Assert
            Assert.IsTrue(result);

        }


        [TestMethod]
        public void DuplicateCustomerReturnsTrue()
        {
            //Arrang
          
            //Act
            bool result = _customerDomainService.ValidateDuplicateCustomer(_customerDomainService.MocList(),_customerDomainService.MocCustomer().Firstname, _customerDomainService.MocCustomer().Lastname, _customerDomainService.MocCustomer().DateOfBirth);
            
            //Assert
            Assert.IsTrue(result);

        }


        [TestMethod]
        public void DuplicateCustomerEmailReturnsTrue()
        {
            //Arrang

            //Act
            bool result = _customerDomainService.ValidateCustomerEmailDuplication(_customerDomainService.MocList(), _customerDomainService.MocCustomer().Email);

            //Assert
            Assert.IsTrue(result);

        }
    }
}