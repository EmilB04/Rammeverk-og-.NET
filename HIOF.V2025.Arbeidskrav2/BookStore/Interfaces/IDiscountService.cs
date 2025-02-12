using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HIOF.V2025.Arbeidskrav2.BookStore.Models;

namespace HIOF.V2025.Arbeidskrav2.BookStore.Interfaces
{
    /// <summary>
    /// Interface for the DiscountManager class.
    /// Contains methods for adding, removing, printing and getting discounts.
    /// </summary>
    /// <remarks>
    /// This interface is used to implement the DiscountManager class.
    /// </remarks>
    /// <seealso cref="DiscountManager"/>
    /// <seealso cref="Discount"/>
    public interface IDiscountService
    {
        // Discount CRUD
        public void AddDiscount(Discount discount);
        public void RemoveDiscount(Discount discount);
        public void PrintAllDiscounts();
        Discount GetDiscountByCode(string code);
        Discount GetDiscountByPercentage(int percentage);
        Discount GetDiscountByAmount(double amount);
        List<Discount> GetAllDiscounts();

    }
}