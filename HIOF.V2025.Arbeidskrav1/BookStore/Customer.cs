using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIOF.V2025.Arbeidskrav1.BookStore
{
    public class Customer
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private double _phoneNumber;

        public Customer(string firstName, string lastName, string email, double phoneNumber)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _phoneNumber = phoneNumber;
        }

        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }

        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public double PhoneNumber
        {
            get => _phoneNumber;
            set => _phoneNumber = value;
        }
    }
}