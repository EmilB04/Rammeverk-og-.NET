using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emil.BookStore.Interfaces
{
    /// <summary>
    /// Interface for CustomerService.
    /// Contains methods for adding, removing, and printing customers, as well as getting customers by different properties.
    /// </summary>
    public interface ICustomerService
    {
        // Customer CRUD
        public void AddCustomer(Customer customer);
        public void RemoveCustomer(Customer customer);
        public void PrintAllCustomers();
        Customer GetCustomerByEmail(string email);
        Customer GetCustomerByPhoneNumber(int phoneNumber);
        Customer GetCustomerByName(string firstName, string lastName);
        Customer GetCustomerByFirstName(string firstName);
        Customer GetCustomerByLastName(string lastName);
        List<Customer> GetAllCustomers();
    }
}