using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HIOF.V2025.Arbeidskrav1.BookStore.Interfaces;

namespace HIOF.V2025.Arbeidskrav1.BookStore.Services
{
    public class CustomerManager : ICustomerService
    {
        private readonly List<Customer> _customers;

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
            // Copilot-prompt: "How can this be shortned, while still following the .NET guidelines?"
            // Copilot-result: Copilot formatted the if-statement with exception into a single line.
            if (customer == null) throw new ArgumentNullException(nameof(customer), "Customer cannot be null.");
            if (string.IsNullOrWhiteSpace(customer.FirstName)) throw new ArgumentException("First name cannot be empty.");
            if (string.IsNullOrWhiteSpace(customer.LastName)) throw new ArgumentException("Last name cannot be empty.");
            if (string.IsNullOrWhiteSpace(customer.Email)) throw new ArgumentException("Email cannot be empty.");
            if (_customers.Any(c => c.Email == customer.Email)) throw new ArgumentException("A customer with the same email already exists.");

            _customers.Add(customer);
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
                throw new ArgumentNullException(nameof(customer), "Customer cannot be null.");
            }
            else
            {
                _customers.Remove(customer);
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
        /// <returns>Return customer object</returns>
        public Customer GetCustomerByName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                Console.WriteLine("First name and last name cannot be null, empty, or whitespace.");
            }

            else
            {
                foreach (var customer in _customers)
                {
                    if (customer.FirstName == firstName && customer.LastName == lastName)
                    {
                        return customer;
                    }
                }
                Console.WriteLine($"Customer '{firstName} {lastName}' not found");
            }
            return null;
        }
        /// <summary>
        /// Gets a customer by first name.
        /// </summary>
        /// <param name="firstName">The first name of the customer</param>
        /// <returns>Returns customer object</returns>
        public Customer GetCustomerByFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                Console.WriteLine("First name cannot be null, empty, or whitespace.");
            }

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
        /// <returns>Returns customer object</returns>
        public Customer GetCustomerByLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                Console.WriteLine("Last name cannot be null, empty, or whitespace.");
            }

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
        /// <returns>Returns customer object</returns>
        public Customer GetCustomerByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Email cannot be null, empty, or whitespace.");
            }

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
        /// <returns></returns>
        public Customer GetCustomerByPhoneNumber(int phoneNumber)
        {
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
        /// <returns>A list of customers</returns>
        public List<Customer> GetAllCustomers()
        {
            return _customers;
        }
    }
}