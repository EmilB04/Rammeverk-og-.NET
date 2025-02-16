using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Good to go! 🚀
namespace Emil.BookStore
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }

        /// <summary>
        /// Constructor for Customer.
        /// </summary>
        /// <param name="firstName">The first name of the customer.</param>
        /// <param name="lastName">The last name of the customer.</param>
        /// <param name="email">The email of the customer.</param>
        /// <param name="phoneNumber">The phone number of the customer.</param>
        /// <exception cref="ArgumentNullException">Thrown when first name, last name, or email is null or empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when phone number is less than or equal to zero or not 8 digits long.</exception>
        public Customer(string firstName, string lastName, string email, int phoneNumber)
        {
            // Copilot-prompt: "How can this be shortned, while still following the .NET guidelines?"
            if (string.IsNullOrWhiteSpace(firstName)) 
                throw new ArgumentNullException(nameof(firstName), "First name cannot be null or empty. Please enter a valid first name.");
            if (string.IsNullOrWhiteSpace(lastName)) 
                throw new ArgumentNullException(nameof(lastName), "Last name cannot be null or empty. Please enter a valid last name.");
            if (string.IsNullOrWhiteSpace(email)) 
                throw new ArgumentNullException(nameof(email), "Email cannot be null or empty. Please enter a valid email.");
            if (phoneNumber <= 0) 
                throw new ArgumentOutOfRangeException(nameof(phoneNumber), "Phone number must be greater than zero. Please enter a valid phone number.");
            if (phoneNumber.ToString().Length != 8) 
                throw new ArgumentOutOfRangeException(nameof(phoneNumber), "Phone number must be 8 digits. Please enter a valid phone number.");

            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// Returns a string that represents the current customer.
        /// </summary>
        /// <returns>A string that represents the current customer.</returns>
        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}, Email: {Email}, Phone number: {PhoneNumber}";
        }
    }
}