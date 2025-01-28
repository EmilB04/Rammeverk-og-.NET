using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIOF.V2025.Arbeidskrav1.BookStore.Interfaces
{
    public interface IBookStoreManager : IBookService, ICustomerService, IOrderService
    {
        // Empty for now
    }
}