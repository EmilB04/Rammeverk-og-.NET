using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HIOF.V2025.Arbeidskrav2.BookStore.Interfaces;
using HIOF.V2025.Arbeidskrav2.BookStore.Models;

namespace HIOF.V2025.Arbeidskrav2.BookStore.Services
{
    public class DiscountManager : IDiscountService
    {
        private List<Discount> discounts = new List<Discount>();

        public void AddDiscountToInventory(Discount discount)
        {
            if (discount == null)
                throw new ArgumentNullException(nameof(discount), "Discount cannot be null. Enter a valid discount.");
            if (discount.Amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(discount.Amount), "Amount cannot be zero or negative. Enter a positive amount.");
            if (discount.Percentage <= 0)
                throw new ArgumentOutOfRangeException(nameof(discount.Percentage), "Percentage cannot be zero or negative. Enter a positive percentage.");
            if (discount.Percentage > 100)
                throw new ArgumentOutOfRangeException(nameof(discount.Percentage), "Percentage cannot be higher than 100. Enter a valid percentage.");
            if (discount.ValidFrom == null)
                throw new ArgumentNullException(nameof(discount.ValidFrom), "Valid from date cannot be null. Enter a valid date.");
            if (discount.ValidTo == null)
                throw new ArgumentNullException(nameof(discount.ValidTo), "Valid to date cannot be null. Enter a valid date.");
            if (discount.ValidFrom > discount.ValidTo)
                throw new ArgumentException("Valid from date cannot be later than valid to date. Enter a valid date range.");
            Console.WriteLine("Discount successfully added.");
            discounts.Add(discount);
        }
        public void RemoveDiscountFromInventory(Discount discount)
        {
            if (discount == null)
                throw new ArgumentNullException(nameof(discount), "Discount cannot be null. Enter a valid discount.");
            if (!discounts.Contains(discount))
                throw new ArgumentException("Discount does not exist. Enter a valid discount.");
            Console.WriteLine("Discount successfully removed.");
            discounts.Remove(discount);
        }
        public void PrintAllDiscounts()
        {
            if (discounts.Count == 0)
                Console.WriteLine("No discounts available.");
            else
            {
                foreach (var discount in discounts)
                {
                    Console.WriteLine(discount.ToString());
                }
            }
        }
        public Discount GetDiscountByCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentException("Code cannot be empty. Enter a valid code.");
            if (discounts.Count == 0)
                throw new InvalidOperationException("No discounts available.");
            if (discounts.Find(d => d.Code == code) == null)
                throw new ArgumentException("Discount does not exist.");
            return discounts.Find(d => d.Code == code);
        }
        public Discount GetDiscountByPercentage(int percentage)
        {
            if (percentage <= 0)
                throw new ArgumentOutOfRangeException(nameof(percentage), "Percentage cannot be zero or negative. Enter a positive percentage.");
            if (percentage > 100)
                throw new ArgumentOutOfRangeException(nameof(percentage), "Percentage cannot be higher than 100. Enter a valid percentage.");
            if (discounts == null)
                throw new ArgumentNullException(nameof(discounts), "Discounts cannot be null. Enter a valid discount.");
            if (discounts.Count == 0)
                throw new InvalidOperationException("No discounts available.");
            if (discounts.Find(d => d.Percentage == percentage) == null)
                throw new ArgumentException("Discount does not exist.");
            return discounts.Find(d => d.Percentage == percentage);
        }
        public Discount GetDiscountByAmount(double amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount cannot be zero or negative. Enter a positive amount.");
            if (discounts == null)
                throw new ArgumentNullException(nameof(discounts), "Discounts cannot be null. Enter a valid discount.");
            if (discounts.Count == 0)
                throw new InvalidOperationException("No discounts available.");
            if (discounts.Find(d => d.Amount == amount) == null)
                throw new ArgumentException("Discount does not exist.");
            return discounts.Find(d => d.Amount == amount);
        }
        public List<Discount> GetAllDiscounts()
        {
            if (discounts.Count == 0)
                throw new InvalidOperationException("No discounts available.");
            if (discounts == null)
                throw new ArgumentNullException(nameof(discounts), "No discounts available.");
            return discounts;
        }
        public void AddDiscountToBook(Discount discount, Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book), "Book cannot be null. Enter a valid book.");
            if (discount == null)
                throw new ArgumentNullException(nameof(discount), "Discount cannot be null. Enter a valid discount.");

            if (discount.Amount.HasValue)
            {
                book.Price -= (double)discount.Amount;
            }
            else if (discount.Percentage.HasValue)
            {
                book.Price -= book.Price * (discount.Percentage.Value / 100.0);
            }
            else
            {
                throw new InvalidOperationException("Discount must have either an amount or a percentage.");
            }

            book.IsDiscounted = true;
            Console.WriteLine($"Discount applied to book: {book.Title}");
        }
        public void RemoveDiscountFromBook(Discount discount, Book book)
        {
            if (discount == null)
                throw new ArgumentNullException(nameof(discount), "Discount cannot be null. Enter a valid discount.");
            if (book == null)
                throw new ArgumentNullException(nameof(book), "Book cannot be null. Enter a valid book.");

            if (discount.Amount.HasValue)
            {
                book.Price += (double)discount.Amount;
            }
            else if (discount.Percentage.HasValue)
            {
                book.Price /= (1 - discount.Percentage.Value / 100.0);
            }
            else
            {
                throw new InvalidOperationException("Discount must have either an amount or a percentage.");
            }

            book.IsDiscounted = false;
            Console.WriteLine($"Discount removed from book: {book.Title}");
        }
    }
}