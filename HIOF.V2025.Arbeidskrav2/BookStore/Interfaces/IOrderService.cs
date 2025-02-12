using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIOF.V2025.Arbeidskrav2.BookStore.Interfaces
{
    /// <summary>
    /// Interface for OrderService.
    /// Contains methods for creating new orders, removing orders, printing all orders, and getting orders by order ID and customer name.
    /// </summary>
    public interface IOrderService
    {
        // Order CRUD
        public void NewOrder(string firstName, string lastName, string titleOrIsbn, int quantity);
        public void RemoveOrder(Order order);
        public void PrintAllOrders();
        Order GetOrderByOrderId(int orderId);
        List<Order> GetOrdersByCustomerName(Customer customer);
    }
}