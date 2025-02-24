using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emil.BookStore.Interfaces
{
    /// <summary>
    /// Interface for payment processing.
    ///  This interface defines methods for taking payments, refunding payments, and checking payment status.
    /// </summary>
    public interface IPaymentProcessor
    {
        /// <summary>
        /// Take payment amount for order.
        /// </summary>
        /// <param name="amount">The amount to be paid </param>
        void TakePaymentAmount(double amount);

        /// <summary>
        /// Refund payment amount for order.
        /// </summary>
        /// <param name="amount">The amount to be refunded</param>
        void RefundPaymentAmount(double amount);

        /// <summary>
        /// Check if payment was successful.
        /// </summary>
        /// <returns>True if payment was successful, otherwise false.</returns>
        bool IsPaymentSuccessful();

        /// <summary>
        /// Check if refund was successful.
        /// </summary>
        /// <returns>True if refund was successful, otherwise false.</returns>
        bool IsRefundSuccessful();
        
        /// <summary>
        /// Choose payment method from available options in PaymentType enum.
        /// </summary>
        /// <returns>PaymentType</returns>
        PaymentType ChoosePaymentMethod();
        
        /// <summary>
        /// Handle payment process. If payment is successful, set IsPaymentSucessfull to true, else false.
        /// </summary>
        /// <param name="amount">The amount to be paid</param>
        /// <param name="paymentType">The type of payment</param>
        /// <param name="order">The order which the payment involves</param>
        /// <param name="customer">The customer who made the payment</param>
        void HandlePaymentProcess(double amount, PaymentType paymentType, Order order, Customer customer);

        /// <summary>
        /// Handle refund process. If refund is successful, set IsRefundSucessfull to true, else false.
        /// </summary>
        /// <param name="amount">The amount to be refunded</param>
        /// <param name="paymentType">The type of payment</param>
        /// <param name="order">The order which the payment involves</param>
        /// <param name="customer">The customer to be refunded</param>
        void HandleRefundProcess(double amount, PaymentType paymentType, Order order, Customer customer);


        /// <summary>
        /// Enum for payment types.
        /// </summary>
        public enum PaymentType
        {
            CreditCard,
            DebitCard,
            Vipps,
            BankTransfer
        }

    }
}