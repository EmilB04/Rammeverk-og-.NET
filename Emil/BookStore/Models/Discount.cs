using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emil.BookStore.Models
{
    /// <summary>
    /// Represents a discount that can be applied to a book.
    /// </summary>
    public class Discount
    {
        /// <summary>
        /// Gets or sets the code of the discount.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the percentage of the discount.
        /// </summary>
        public int? Percentage { get; set; }

        /// <summary>
        /// Gets or sets the amount of the discount.
        /// </summary>
        public double? Amount { get; set; }

        /// <summary>
        /// Gets or sets the date the discount is valid from.
        /// </summary>
        public DateTime? ValidFrom { get; set; }

        /// <summary>
        /// Gets or sets the date the discount is valid to.
        /// </summary>
        public DateTime? ValidTo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the discount is in use.
        /// </summary>
        public bool DiscountInUse { get; set; }

        /// <summary>
        /// Constructor for Discount.
        /// </summary>
        /// <param name="code">The code of the discount.</param>
        /// <param name="percentage">The percentage of the discount.</param>
        /// <param name="validFrom">The date the discount is valid from.</param>
        /// <param name="validTo">The date the discount is valid to.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when percentage is less than 0 or greater than 100.</exception>
        /// <exception cref="ArgumentException">Thrown when validFrom is later than validTo.</exception>
        /// <exception cref="ArgumentNullException">Thrown when code is null or empty.</exception>
        public Discount(string code, int percentage, DateTime validFrom, DateTime validTo)
        {
            if (percentage < 0 || percentage > 100)
                throw new ArgumentOutOfRangeException(nameof(percentage), "Percentage must be between 0 and 100.");
            if (validFrom >= validTo)
                throw new ArgumentException("ValidFrom must be earlier than ValidTo.");
            if (string.IsNullOrEmpty(code))
                throw new ArgumentNullException(nameof(code), "Code cannot be null or empty.");

            Code = code;
            Percentage = percentage;
            Amount = null;
            ValidFrom = validFrom;
            ValidTo = validTo;
            DiscountInUse = false;
        }

        /// <summary>
        /// Constructor for Discount.
        /// </summary>
        /// <param name="code">The code of the discount.</param>
        /// <param name="amount">The amount of the discount.</param>
        /// <param name="validFrom">The date the discount is valid from.</param>
        /// <param name="validTo">The date the discount is valid to.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when amount is less than 0.</exception>
        /// <exception cref="ArgumentException">Thrown when validFrom is later than validTo.</exception>
        /// <exception cref="ArgumentNullException">Thrown when code is null or empty.</exception>
        public Discount(string code, double amount, DateTime validFrom, DateTime validTo)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be a positive number.");
            if (validFrom >= validTo)
                throw new ArgumentException("ValidFrom must be earlier than ValidTo.");
            if (string.IsNullOrEmpty(code))
                throw new ArgumentNullException(nameof(code), "Code cannot be null or empty.");

            Code = code;
            Percentage = null;
            Amount = amount;
            ValidFrom = validFrom;
            ValidTo = validTo;
            DiscountInUse = false;
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