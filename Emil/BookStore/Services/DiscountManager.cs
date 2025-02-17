using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emil.BookStore.Interfaces;
using Emil.BookStore.Models;

namespace Emil.BookStore.Services
{
    /// <summary>
    /// Represents a discount manager that can add, remove, print, get and apply discounts.
    /// </summary>
    /// <remarks>
    /// This class is used to manage discounts in the book store.
    /// </remarks>
    /// <seealso cref="IDiscountService"/>
    /// <seealso cref="Discount"/>
    public class DiscountManager : IDiscountService
    {
        private List<Discount> discounts = new List<Discount>();

        /// <summary>
        /// Adds a discount to the inventory.
        /// </summary>
        /// <param name="discount">The discount to be added.</param>
        /// <exception cref="ArgumentNullException">Thrown when the discount is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when amount or percentage is zero or negative, or when percentage is higher than 100.</exception>
        /// <exception cref="ArgumentException">Thrown when valid from date is later than valid to date, or when discount already exists.</exception>
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
            if (discount.ValidFrom == null || discount.ValidTo == null)
                throw new ArgumentNullException(nameof(discount.ValidFrom), "Valid from date cannot be null. Enter a valid date.");
            if (discount.ValidFrom > discount.ValidTo)
                throw new ArgumentException("Valid from date cannot be later than valid to date. Enter a valid date range.");
            if (discounts.Contains(discount))
                throw new ArgumentException("Discount already exists. Enter a unique discount.");
            Console.WriteLine("Discount successfully added.");
            discounts.Add(discount);
        }

        /// <summary>
        /// Removes a discount from the inventory.
        /// </summary>
        /// <param name="discount">The discount to be removed.</param>
        /// <exception cref="ArgumentNullException">Thrown when the discount is null.</exception>
        /// <exception cref="ArgumentException">Thrown when discount does not exist.</exception>
        /// <exception cref="InvalidOperationException">Thrown when no discounts are available.</exception>
        public void RemoveDiscountFromInventory(Discount discount)
        {
            if (discount == null)
                throw new ArgumentNullException(nameof(discount), "Discount cannot be null. Enter a valid discount.");
            if (!discounts.Contains(discount))
                throw new ArgumentException("Discount does not exist. Enter a valid discount.");
            if (discounts.Count == 0)
                throw new InvalidOperationException("No discounts available.");
            if (discount.DiscountInUse)
                throw new InvalidOperationException("Discount is in use. Cannot remove discount.");
            discounts.Remove(discount);
            Console.WriteLine("Discount successfully removed.");
        }

        /// <summary>
        /// Prints all discounts in the inventory.
        /// </summary>
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

        /// <summary>
        /// Gets a discount by its code.
        /// </summary>
        /// <param name="code">The code of the discount to get.</param>
        /// <returns>The discount with the specified code.</returns>
        /// <exception cref="ArgumentException">Thrown when code is null, empty, or whitespace.</exception>
        /// <exception cref="InvalidOperationException">Thrown when no discounts are available.</exception>
        /// <exception cref="ArgumentException">Thrown when discount does not exist.</exception>
        public Discount? GetDiscountByCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentException("Code cannot be empty. Enter a valid code.");
            if (discounts.Count == 0)
                throw new InvalidOperationException("No discounts available.");
            if (discounts.Find(d => d.Code == code) == null)
                throw new ArgumentException("Discount does not exist.");
            return discounts.Find(d => d.Code == code);
        }

        /// <summary>
        /// Gets a discount by its percentage.
        /// </summary>
        /// <param name="percentage">The percentage of the discount to get.</param>
        /// <returns>The discount with the specified percentage.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when percentage is zero or negative, or when percentage is higher than 100.</exception>
        /// <exception cref="ArgumentNullException">Thrown when discounts is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when no discounts are available.</exception>
        /// <exception cref="ArgumentException">Thrown when discount does not exist.</exception>
        public Discount? GetDiscountByPercentage(int percentage)
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

        /// <summary>
        /// Gets a discount by its amount.
        /// </summary>
        /// <param name="amount">The amount of the discount to get.</param>
        /// <returns>The discount with the specified amount.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when amount is zero or negative.</exception>
        /// <exception cref="ArgumentNullException">Thrown when discounts is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when no discounts are available.</exception>
        /// <exception cref="ArgumentException">Thrown when discount does not exist.</exception>
        public Discount? GetDiscountByAmount(double amount)
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

        /// <summary>
        /// Gets all discounts in the inventory.
        /// </summary>
        /// <returns>A list of all discounts in the inventory.</returns>
        /// <exception cref="InvalidOperationException">Thrown when no discounts are available.</exception>
        /// <exception cref="ArgumentNullException">Thrown when discounts is null.</exception>
        public List<Discount>? GetAllDiscounts()
        {
            if (discounts.Count == 0)
                throw new InvalidOperationException("No discounts available.");
            if (discounts == null)
                throw new ArgumentNullException(nameof(discounts), "No discounts available.");
            return discounts;
        }

        /// <summary>
        /// Adds a discount to a book.
        /// </summary>
        /// <param name="discount">The discount to be added.</param>
        /// <param name="book">The book to add the discount to.</param>
        /// <exception cref="ArgumentNullException">Thrown when discount or book is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when discount has neither an amount nor a percentage.</exception>
        /// <exception cref="ArgumentException">Thrown when book already has a discount applied.</exception>
        public void AddDiscountToBook(Discount discount, Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book), "Book cannot be null. Enter a valid book.");
            if (discount == null)
                throw new ArgumentNullException(nameof(discount), "Discount cannot be null. Enter a valid discount.");
            if (book.IsDiscounted)
                throw new ArgumentException("Book already has a discount applied.");

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
            discount.DiscountInUse = true;
            Console.WriteLine($"Discount applied to book: {book.Title}");
        }

        /// <summary>
        /// Removes a discount from a book.
        /// </summary>
        /// <param name="discount">The discount to be removed.</param>
        /// <param name="book">The book to remove the discount from.</param>
        /// <exception cref="ArgumentNullException">Thrown when discount or book is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when discount has neither an amount nor a percentage.</exception>
        /// <exception cref="ArgumentException">Thrown when discount is not applied to the book.</exception>
        /// <exception cref="ArgumentException">Thrown when book does not have a discount applied.</exception>
        public void RemoveDiscountFromBook(Discount discount, Book book)
        {
            if (discount == null)
                throw new ArgumentNullException(nameof(discount), "Discount cannot be null. Enter a valid discount.");
            if (book == null)
                throw new ArgumentNullException(nameof(book), "Book cannot be null. Enter a valid book.");
            if (!book.IsDiscounted)
                throw new ArgumentException($"The book {book.Title} does not have a discount applied.");
            if (!discount.DiscountInUse)
                throw new ArgumentException("Discount is not applied to this book.");

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
            discount.DiscountInUse = false;
            Console.WriteLine($"Discount removed from book: {book.Title}");
        }
    }
}