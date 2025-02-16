using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emil.BookStore.Models;

namespace Emil.BookStore.Interfaces
{
    /// <summary>
    /// Interface for managing discounts in the inventory and books.
    /// </summary>
    public interface IDiscountService
    {
        /// <summary>
        /// Adds a discount to the inventory.
        /// </summary>
        /// <param name="discount">The discount to add.</param>
        void AddDiscountToInventory(Discount discount);

        /// <summary>
        /// Removes a discount from the inventory.
        /// </summary>
        /// <param name="discount">The discount to remove.</param>
        void RemoveDiscountFromInventory(Discount discount);

        /// <summary>
        /// Adds a discount to a specific book.
        /// </summary>
        /// <param name="discount">The discount to add.</param>
        /// <param name="book">The book to which the discount will be added.</param>
        void AddDiscountToBook(Discount discount, Book book);

        /// <summary>
        /// Removes a discount from a specific book.
        /// </summary>
        /// <param name="discount">The discount to remove.</param>
        /// <param name="book">The book from which the discount will be removed.</param>
        void RemoveDiscountFromBook(Discount discount, Book book);

        /// <summary>
        /// Prints all available discounts.
        /// </summary>
        void PrintAllDiscounts();

        /// <summary>
        /// Retrieves a discount by its code.
        /// </summary>
        /// <param name="code">The code of the discount.</param>
        /// <returns>The discount with the specified code.</returns>
        Discount GetDiscountByCode(string code);

        /// <summary>
        /// Retrieves a discount by its percentage.
        /// </summary>
        /// <param name="percentage">The percentage of the discount.</param>
        /// <returns>The discount with the specified percentage.</returns>
        Discount GetDiscountByPercentage(int percentage);

        /// <summary>
        /// Retrieves a discount by its amount.
        /// </summary>
        /// <param name="amount">The amount of the discount.</param>
        /// <returns>The discount with the specified amount.</returns>
        Discount GetDiscountByAmount(double amount);

        /// <summary>
        /// Retrieves all available discounts.
        /// </summary>
        /// <returns>A list of all discounts.</returns>
        List<Discount> GetAllDiscounts();
    }
}