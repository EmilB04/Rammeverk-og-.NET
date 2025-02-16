using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emil.BookStore.Interfaces
{
    /// <summary>
    /// Interface for customer service operations.
    /// </summary>
    /// <remarks>
    /// This interface is used to implement the CustomerManger class
    /// </remarks>
    /// <seealso cref="CustomerManager"/>
    /// <seealso cref="Customer"/>
    public interface ICustomerService
    {
        /// <summary>
        /// Adds a new customer.
        /// </summary>
        /// <param name="customer">The customer to add.</param>
        void AddCustomer(Customer customer);

        /// <summary>
        /// Removes an existing customer.
        /// </summary>
        /// <param name="customer">The customer to remove.</param>
        void RemoveCustomer(Customer customer);

        /// <summary>
        /// Prints all customers.
        /// </summary>
        void PrintAllCustomers();

        /// <summary>
        /// Gets a customer by their email.
        /// </summary>
        /// <param name="email">The email of the customer.</param>
        /// <returns>The customer with the specified email.</returns>
        Customer GetCustomerByEmail(string email);

        /// <summary>
        /// Gets a customer by their phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number of the customer.</param>
        /// <returns>The customer with the specified phone number.</returns>
        Customer GetCustomerByPhoneNumber(int phoneNumber);

        /// <summary>
        /// Gets a customer by their first and last name.
        /// </summary>
        /// <param name="firstName">The first name of the customer.</param>
        /// <param name="lastName">The last name of the customer.</param>
        /// <returns>The customer with the specified first and last name.</returns>
        Customer GetCustomerByName(string firstName, string lastName);

        /// <summary>
        /// Gets a customer by their first name.
        /// </summary>
        /// <param name="firstName">The first name of the customer.</param>
        /// <returns>The customer with the specified first name.</returns>
        Customer GetCustomerByFirstName(string firstName);

        /// <summary>
        /// Gets a customer by their last name.
        /// </summary>
        /// <param name="lastName">The last name of the customer.</param>
        /// <returns>The customer with the specified last name.</returns>
        Customer GetCustomerByLastName(string lastName);

        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns>A list of all customers.</returns>
        List<Customer> GetAllCustomers();
    }
}