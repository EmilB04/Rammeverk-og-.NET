using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emil.BookStore.Models;

namespace Emil.BookStore.Interfaces
{
    /// <summary>
    /// Interface for the DiscountManager class.
    /// Contains methods for adding, removing, printing, getting and applying discounts.
    /// </summary>
    /// <remarks>
    /// This interface is used to implement the DiscountManager class.
    /// </remarks>
    /// <seealso cref="DiscountManager"/>
    /// <seealso cref="Discount"/>
    public interface IDiscountService
    {
        // Discount CRUD
        public void AddDiscountToInventory(Discount discount);
        public void RemoveDiscountFromInventory(Discount discount);
        public void AddDiscountToBook(Discount discount, Book book);
        public void RemoveDiscountFromBook(Discount discount, Book book);
        public void PrintAllDiscounts();
        Discount GetDiscountByCode(string code);
        Discount GetDiscountByPercentage(int percentage);
        Discount GetDiscountByAmount(double amount);
        List<Discount> GetAllDiscounts();

    }
}