using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bank_MVC_Web_App.Models.Dto;

namespace Bank_MVC_Web_App.Models
{
    public class DataManager
    {
        private BankEntities _db;

        public DataManager()
        {
            _db = new BankEntities();
        }

        public int AddNewCustomer(NewCustomerDto model)
        {
            var newCustomer = new Customer();
            newCustomer.FirstName = model.FirstName;
            newCustomer.LastName = model.LastName;
            newCustomer.MiddleName = model.MiddleName;
            newCustomer.ContractNumber = model.ContractNumber;

            _db.Customers.Add(newCustomer);
            _db.SaveChanges();

            var newAccount = new Account();
            newAccount.CustomerId = newCustomer.CustomerId;
            newAccount.AccountNumber = model.AccountNumber;
            newAccount.Balance = 0;

            _db.Accounts.Add(newAccount);
            _db.SaveChanges();

            return newCustomer.CustomerId;
        }

        public CustomerDto GetCustomerDto(int customerId)
        {
            CustomerDto customerDto = new CustomerDto();
            Customer customer = _db.Customers.FirstOrDefault(c => c.CustomerId == customerId);

            customerDto = CreateCustomerDto(customer);

            return customerDto;
        }

        public CustomersDto GetCustomerByContractNumber(int countractNumber)
        {
            Customer customer = _db.Customers.FirstOrDefault(c => c.ContractNumber == countractNumber);


            return CreateCustomersDto(customer);
        }

        public CustomersDto GetCustomersByLastName(string lastName)
        {
            IQueryable<Customer> customers = _db.Customers.Where(c => c.LastName == lastName);

            return CreateCustomersDto(customers);
        }

        private CustomerDto CreateCustomerDto(Customer customer)
        {
            CustomerDto customerDto = new CustomerDto();

            List<string> accountList = new List<string>();

            foreach (Account account in customer.Accounts)
            {
                accountList.Add(account.AccountNumber);
            }

            customerDto.CustomerId = customer.CustomerId;
            customerDto.FirstName = customer.FirstName;
            customerDto.MiddleName = customer.MiddleName;
            customerDto.LastName = customer.LastName;
            customerDto.ContractNumber = customer.ContractNumber;
            customerDto.AccountNumberList = accountList;

            return customerDto;
        }

        private CustomersDto CreateCustomersDto(IEnumerable<Customer> customers)
        {
            CustomersDto customersDto = new CustomersDto();
            
            List<CustomerDto> customerDtoList = new List<CustomerDto>();

            foreach (Customer customer in customers)
            {
                customerDtoList.Add(CreateCustomerDto(customer));
            }

            customersDto.CustomerDtoList = customerDtoList;
            return customersDto;
        }

        private CustomersDto CreateCustomersDto(Customer customer)
        {
            List<CustomerDto> customerDtoList = new List<CustomerDto>();

            customerDtoList.Add(CreateCustomerDto(customer));

            CustomersDto customersDto = new CustomersDto();
            customersDto.CustomerDtoList = customerDtoList;
            return customersDto;
        }
    }
}