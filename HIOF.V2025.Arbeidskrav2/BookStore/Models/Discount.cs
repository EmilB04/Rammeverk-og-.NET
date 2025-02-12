using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIOF.V2025.Arbeidskrav2.BookStore.Models
{
    public class Discount
    {
        public virtual string? Code { get; set; }
        public virtual int? Percentage { get; set; }
        public virtual double? Amount { get; set; }
        public virtual DateTime? ValidFrom { get; set; }
        public virtual DateTime? ValidTo { get; set; }

        public Discount(string code, int percentage, double amount, DateTime validFrom, DateTime validTo)
        {
            Code = code;
            Percentage = percentage;
            Amount = amount;
            ValidFrom = validFrom;
            ValidTo = validTo;
        }
        public Discount(string code, int percentage, DateTime validFrom, DateTime validTo)
        {
            Code = code;
            Percentage = percentage;
            Amount = null;
            ValidFrom = validFrom;
            ValidTo = validTo;
        }
        public Discount(string code, double amount, DateTime validFrom, DateTime validTo)
        {
            Code = code;
            Percentage = null;
            Amount = amount;
            ValidFrom = validFrom;
            ValidTo = validTo;
        }

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