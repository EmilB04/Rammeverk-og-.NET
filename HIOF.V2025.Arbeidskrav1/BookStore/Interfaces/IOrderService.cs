using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIOF.V2025.Arbeidskrav1.BookStore.Interfaces
{
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