using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIOF.V2025.Arbeidskrav1.BookStore.Interfaces
{
    public interface IOrderService
    {
        // Order CRUD
        public void NewOrder(Order order);
        public void RemoveOrder(Order order);
        public void UpdateOrder(Order order);
        Order GetOrderByOrderId(int orderId);
        List<Order> GetOrdersByCustomer(Customer customer);
    }
}