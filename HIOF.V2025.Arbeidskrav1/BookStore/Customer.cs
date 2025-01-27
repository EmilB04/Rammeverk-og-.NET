using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIOF.V2025.Arbeidskrav1.BookStore
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }

        public Customer(string firstName, string lastName, string email, int phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentNullException(nameof(firstName), "First name cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException(nameof(lastName), "Last name cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException(nameof(email), "Email cannot be null or empty.");
            }
            if (phoneNumber <= 0)
            {
                throw new ArgumentException("Phone number must be greater than zero.", nameof(phoneNumber));
            }
            




            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            PhoneNumber = phoneNumber;
        }
        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}, Email: {Email}, Phone number: {PhoneNumber}";
        }
    }
}