using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIOF.V2025.Arbeidskrav2.BookStore.Models
{
    /// <summary>
    /// Represents a discount that can be applied to a book.
    /// </summary>
    public class Discount
    {
        public virtual string? Code { get; set; }
        public virtual int? Percentage { get; set; }
        public virtual double? Amount { get; set; }
        public virtual DateTime? ValidFrom { get; set; }
        public virtual DateTime? ValidTo { get; set; }

        /// <summary>
        /// Constructor for Discount.
        /// </summary>
        /// <param name="code">The code of the discount.</param>
        /// <param name="percentage">The percentage of the discount.</param>
        /// <param name="amount">The amount of the discount.</param>
        /// <param name="validFrom">The date the discount is valid from.</param>
        /// <param name="validTo">The date the discount is valid to.</param>
        public Discount(string code, int percentage, double amount, DateTime validFrom, DateTime validTo)
        {
            Code = code;
            Percentage = percentage;
            Amount = amount;
            ValidFrom = validFrom;
            ValidTo = validTo;
        }

        /// <summary>
        /// Constructor for Discount.
        /// </summary>
        /// <param name="code">The code of the discount.</param>
        /// <param name="percentage">The percentage of the discount.</param>
        /// <param name="validFrom">The date the discount is valid from.</param>
        /// <param name="validTo">The date the discount is valid to.</param>
        public Discount(string code, int percentage, DateTime validFrom, DateTime validTo)
        {
            Code = code;
            Percentage = percentage;
            Amount = null;
            ValidFrom = validFrom;
            ValidTo = validTo;
        }

        /// <summary>
        /// Constructor for Discount.
        /// </summary>
        /// <param name="code">The code of the discount.</param>
        /// <param name="amount">The amount of the discount.</param>
        /// <param name="validFrom">The date the discount is valid from.</param>
        /// <param name="validTo">The date the discount is valid to.</param>
        public Discount(string code, double amount, DateTime validFrom, DateTime validTo)
        {
            Code = code;
            Percentage = null;
            Amount = amount;
            ValidFrom = validFrom;
            ValidTo = validTo;
        }

        /// <summary>
        /// Constructor for Discount.
        /// </summary>
        /// <returns>A string that represents the current discount.</returns>
        public override string ToString()
        {
            if (Percentage.HasValue)
            {
            return $"Code: {Code}, Percentage: {Percentage}%, Valid from: {ValidFrom}, Valid to: {ValidTo}";
            }
            else if (Amount.HasValue)
            {
            return $"Code: {Code}, Amount: {Amount:C}, Valid from: {ValidFrom}, Valid to: {ValidTo}";
            }
            else
            {
            return $"Code: {Code}, Percentage: {Percentage}%, Amount: {Amount:C}, Valid from: {ValidFrom}, Valid to: {ValidTo}";
            }
        }
    }
}