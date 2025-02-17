using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emil.BookStore.Interfaces;

namespace Emil.BookStore.Services
{
    public class CustomerManager : ICustomerService
    {
        private List<Customer> _customers;

        /// <summary>
        /// Constructor for CustomerManager.
        /// </summary>
        public CustomerManager()
        {
            _customers = new List<Customer>();
        }

        /// <summary>
        /// Adds a customer to the store.
        /// </summary>
        /// <param name="customer">The customer to be added.</param>
        /// <exception cref="ArgumentNullException">Thrown when the customer is null.</exception>
        /// <exception cref="ArgumentException">Thrown when first name, last name, or email is null, empty, or whitespace, or if a customer with the same email already exists.</exception>
        public void AddCustomer(Customer customer)
        {
            if (customer == null) 
                throw new ArgumentNullException(nameof(customer), "Customer cannot be null. Enter a valid customer.");
            if (string.IsNullOrWhiteSpace(customer.FirstName)) 
                throw new ArgumentException("First name cannot be empty. Enter a valid first name.");
            if (string.IsNullOrWhiteSpace(customer.LastName)) 
                throw new ArgumentException("Last name cannot be empty. Enter a valid last name.");
            if (string.IsNullOrWhiteSpace(customer.Email)) 
                throw new ArgumentException("Email cannot be empty. Enter a valid email.");
            if (_customers.Any(c => c.Email == customer.Email)) 
                throw new ArgumentException("A customer with the same email already exists. Enter a unique email.");

            _customers.Add(customer);
            Console.WriteLine("Customer added successfully.");
        }

        /// <summary>
        /// Removes a customer from the store.
        /// Throws ArgumentNullException if customer is null.
        /// </summary>
        /// <param name="customer">The customer to be removed.</param>
        /// <exception cref="ArgumentNullException">Thrown when the customer is null.</exception>
        public void RemoveCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer), "Customer was not found. Enter a valid customer.");
            }
            else
            {
                _customers.Remove(customer);
                Console.WriteLine("Customer removed successfully.");
            }
        }

        /// <summary>
        /// Prints all customers in the store.
        /// Prints "No customers in the store." if there are no customers in the store.
        /// </summary>
        public void PrintAllCustomers()
        {
            if (_customers.Count == 0)
            {
                Console.WriteLine("No customers in the store.");
            }
            else
            {
                foreach (var customer in _customers)
                {
                    Console.WriteLine(customer);
                }
            }
        }
        /// <summary>
        /// Gets a customer by first name and last name.
        /// </summary>
        /// <param name="firstName">The first name of the customer</param>
        /// <param name="lastName">The last name of the customer</param>
        /// <returns>The customer with the specified first name and last name, if found.</returns>
        /// <exception cref="ArgumentException">Thrown when the first name or last name is null, empty, or whitespace.</exception>
        /// <exception cref="ArgumentException">Thrown when the customer with the specified first name and last name is not found.</exception>
        public Customer? GetCustomerByName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name cannot be null, empty, or whitespace. Please enter a valid first name.", nameof(firstName));
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name cannot be null, empty, or whitespace. Please enter a valid last name.", nameof(lastName));
            else
            {
                foreach (var customer in _customers)
                {
                    if (customer.FirstName == firstName && customer.LastName == lastName)
                    {
                        return customer;
                    }
                }
                Console.WriteLine($"Customer with name '{firstName} {lastName}' was not found");
                return null;
            }
        }
        /// <summary>
        /// Gets a customer by first name.
        /// </summary>
        /// <param name="firstName">The first name of the customer</param>
        /// <returns>The customer with the specified first name, if found.</returns>
        /// <exception cref="ArgumentException">Thrown when the first name is null, empty, or whitespace.</exception>
        public Customer? GetCustomerByFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException(nameof(firstName), "First name cannot be null, empty, or whitespace." + "Please enter a valid first name.");

            else
            {
                foreach (var customer in _customers)
                {
                    if (customer.FirstName == firstName)
                    {
                        return customer;
                    }
                }
                Console.WriteLine($"Customer with firstname '{firstName}' was not found");
            }
            return null;
        }

        /// <summary>
        /// Gets a customer by last name.
        /// </summary>
        /// <param name="lastName">The last name of the customer</param>
        /// <returns>The customer with the specified last name, if found.</returns>
        /// <exception cref="ArgumentException">Thrown when the last name is null, empty, or whitespace.</exception>
        public Customer? GetCustomerByLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException(nameof(lastName), "Last name cannot be null, empty, or whitespace." + "Please enter a valid last name.");

            else
            {
                foreach (var customer in _customers)
                {
                    if (customer.LastName == lastName)
                    {
                        return customer;
                    }
                }
                Console.WriteLine($"Customer with last name '{lastName}' was not found");
            }
            return null;
        }

        /// <summary>
        /// Gets a customer by email.
        /// </summary>
        /// <param name="email">The email of the customer</param>
        /// <returns>The customer with the specified email, if found.</returns>
        /// <exception cref="ArgumentException">Thrown when the email is null, empty, or whitespace.</exception>
        public Customer? GetCustomerByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException(nameof(email), "Email cannot be null, empty, or whitespace." + "Please enter a valid email.");

            else
            {
                foreach (var customer in _customers)
                {
                    if (customer.Email == email)
                    {
                        return customer;
                    }
                }
                Console.WriteLine($"Customer with email '{email}' was not found");
            }
            return null;
        }

        /// <summary>
        /// Gets a customer by phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone numer of the customer</param>
        /// <returns>The customer with the specified phone number, if found.</returns>
        /// <exception cref="ArgumentException">Thrown when the phone number is zer.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the phone number is negative.</exception>
        public Customer? GetCustomerByPhoneNumber(int phoneNumber)
        {
            if (phoneNumber == 0)
                throw new ArgumentException("Phone number cannot be zero.", nameof(phoneNumber));
            if (phoneNumber < 0)
                throw new ArgumentOutOfRangeException("Phone number cannot be negative.", nameof(phoneNumber));
            foreach (var customer in _customers)
            {
                if (customer.PhoneNumber == phoneNumber)
                {
                    return customer;
                }
            }
            Console.WriteLine($"Customer with phone number '{phoneNumber}' was not found");
            return null;
        }

        /// <summary>
        /// Gets all customers in the store.
        /// </summary>
        /// <returns>A list of customers</returns
        public List<Customer> GetAllCustomers()
        {
            if (_customers.Count == 0)
            {
                Console.WriteLine("No customers in the store.");
            }
            return _customers;
        }
    }
}