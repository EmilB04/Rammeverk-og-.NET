using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HIOF.V2025.Arbeidskrav1.BookStore.Interfaces;

namespace HIOF.V2025.Arbeidskrav1.BookStore.Services
{
    public class OrderManager : IOrderService
    {
        readonly List<Order> _orders;
        private int orderId = 1;

        public OrderManager(List<Order> orders)
        {
            _orders = orders;
        }

        public void PurchaseBook()
        {
            string firstName;
            string lastName;
            string title = string.Empty;
            string isbn = string.Empty;
            int quantity;

            while (true)
            {
                Console.WriteLine("Provide the following information to create an order:");
                while (true) // fName
                {
                    Console.Write("Customer first name: ");
                    firstName = Console.ReadLine() ?? string.Empty;
                    if (string.IsNullOrWhiteSpace(firstName))
                    {
                        Console.WriteLine("First name cannot be null, empty, or whitespace.");
                        CheckIfUserWantsToExit();
                    }
                    else if (FindCustomerByFirstName(firstName) == null)
                    {
                        // Error handled by FindCustomerByFirstName
                    }
                    else
                    {
                        break;
                    }
                }
                while (true) // lName
                {
                    Console.Write("Customer last name: ");
                    lastName = Console.ReadLine() ?? string.Empty;
                    if (string.IsNullOrWhiteSpace(lastName))
                    {
                        Console.WriteLine("Last name cannot be null, empty, or whitespace.");
                        CheckIfUserWantsToExit();
                    }
                    else if (FindCustomerByLastName(lastName) == null)
                    {
                        // Error handled by FindCustomerByLastName
                    }
                    else
                    {
                        break;
                    }
                }
                while (true) // title or ISBN
                {
                    Console.WriteLine("Book title or ISBN: ");
                    Console.WriteLine("1. Title \n2. ISBN");
                    string input = Console.ReadLine() ?? string.Empty;

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Input cannot be null, empty, or whitespace.");
                        CheckIfUserWantsToExit();
                    }
                    if (input == "1")
                    {
                        Console.Write("Book title: ");
                        title = Console.ReadLine() ?? string.Empty;
                        FindBookByTitle(title);
                        break;
                    }
                    else if (input == "2")
                    {
                        Console.Write("Book ISBN: ");
                        isbn = Console.ReadLine() ?? string.Empty;
                        FindBookByIsbn(isbn);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please try again.");
                        continue;
                    }
                }
                while (true) // quantity
                {
                    Console.Write("Quantity: ");
                    if (!int.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
                    {
                        Console.WriteLine("Quantity must be a valid number greater than 0.");
                        CheckIfUserWantsToExit();
                    }
                    else if (FindBookByTitle(title).Quantity < quantity)
                    {
                        Console.WriteLine("Not enough books in stock.");
                    }
                    else
                    {
                        break;
                    }
                }

                Customer customer = FindCustomerByName(firstName, lastName);
                Book book = FindBookByTitle(title);
                Order order = new(orderId, new() { book }, customer, DateTime.Now, book.Price * quantity);
                _orders.Add(order);
                Console.WriteLine("Order created: " + order);

                // Handle inventory and order creation
                orderId++;
                book.Quantity -= quantity;
                break;
            }
        }
        public void PrintAllOrders()
        {
            if (_orders.Count == 0)
            {
                Console.WriteLine("No orders in the store.");
            }
            else
            {
                Console.WriteLine("All orders:");
                foreach (var order in _orders)
                {
                    Console.WriteLine(order);
                }
            }
        }
        public void NewOrder(Order order)
        {
            _orders.Add(order);
        }
        public void RemoveOrder(Order order)
        {
            _orders.Remove(order);
        }
        public Order GetOrderByOrderId(int orderId)
        {
            return _orders.FirstOrDefault(o => o.OrderId == orderId);
        }
        public List<Order> GetOrdersByCustomerName(Customer customer)
        {
            return _orders.Where(o => o.Customer == customer).ToList();
        }
        public void CheckIfUserWantsToExit()
        {
            Console.WriteLine("Do you want to exit the program? (yes/no)");
            string input = Console.ReadLine() ?? string.Empty;
            if (input == "yes" || input == "y")
            {
                Environment.Exit(0);
            }
            else if (input == "no" || input == "n")
            {
                return;
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
                CheckIfUserWantsToExit();
            }
        }
    }
}