
using System;
using System.Collections.Generic;


namespace HIOF.V2025.Arbeidskrav1.BookStore
{
    public class Order
    {
        public int OrderId { get; set; }
        public List<Book> Books { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }

        public Order(int orderId, List<Book> books, Customer customer, DateTime orderDate, double totalPrice)
        {
            OrderId = orderId;
            Books = books;
            Customer = customer;
            OrderDate = orderDate;
            TotalPrice = totalPrice;
        }
        public override string ToString()
        {
            return $"Order ID: {OrderId}, Customer: {Customer.FirstName} {Customer.LastName}, Order Date: {OrderDate}, Total Price: {TotalPrice:C}";
        }
    }

}
