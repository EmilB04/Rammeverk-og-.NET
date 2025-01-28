using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIOF.V2025.Arbeidskrav1.BookStore.Interfaces
{
    public interface ICustomerService
    {
        // Customer CRUD
        public void AddCustomer(Customer customer);
        public void RemoveCustomer(Customer customer);
        public void UpdateCustomer(Customer customer);
        Customer GetCustomerByEmail(string email);
        Customer GetCustomerByPhoneNumber(int phoneNumber);
        Customer GetCustomerByName(string firstName, string lastName);
        Customer GetCustomerByFirstName(string firstName);
        Customer GetCustomerByLastName(string lastName);
        List<Customer> GetAllCustomers();
    }
}