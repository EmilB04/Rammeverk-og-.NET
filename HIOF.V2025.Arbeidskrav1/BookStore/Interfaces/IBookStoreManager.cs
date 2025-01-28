using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIOF.V2025.Arbeidskrav1.BookStore.Interfaces
{
    public interface IBookStoreManager : IBookService, ICustomerService, IOrderService
    {
        // Print all
        void PrintAllBooks();
        public void PrintAllCustomers();
        public void PrintAllOrders();

        

    }
}