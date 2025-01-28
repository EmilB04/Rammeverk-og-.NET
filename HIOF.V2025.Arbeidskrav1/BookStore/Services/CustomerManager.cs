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


        public CustomerManager()
        {
            _customers = new List<Customer>();
        }

        public void AddCustomer(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.FirstName))
            {
                throw new ArgumentException("First name cannot be null, empty, or whitespace.", nameof(customer.FirstName));
            }

            else
            {
                _customers.Add(customer);
            }
        }
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
        public Customer GetCustomerByName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                Console.WriteLine("First name and last name cannot be null, empty, or whitespace.");
                CheckIfUserWantsToExit();
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
        public Customer GetCustomerByFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                Console.WriteLine("First name cannot be null, empty, or whitespace.");
                CheckIfUserWantsToExit();
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
        public Customer GetCustomerByLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                Console.WriteLine("Last name cannot be null, empty, or whitespace.");
                CheckIfUserWantsToExit();
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
        public Customer GetCustomerByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Email cannot be null, empty, or whitespace.");
                CheckIfUserWantsToExit();
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

        public List<Customer> GetAllCustomers()
        {
            return _customers;
        }
        public void CheckIfUserWantsToExit()
        {
            Console.WriteLine("Do you want to exit the program? (yes/no)");
            string input = Console.ReadLine() ?? string.Empty;
            if (input == "yes" || input == "y")
            {
                Environment.Exit(0);
            }
            else if (input == "no" || input == "n")
            {
                return;
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
                CheckIfUserWantsToExit();
            }
        }
    }
}