using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HIOF.V2025.Arbeidskrav1.BookStore;
namespace HIOF.V2025.Arbeidskrav1.BookStoreCLI


// TODO!
/*
    1. Implementer ordre-funksjonalitet i BookStoreManager
    2. Implementer funksjonalitet rundt beholdning, rabatter og bestillinger

    3. Implementer en CLI (Command Line Interface) som lar brukeren interagere med BookStoreManager
        - CLI-en skal kunne legge til og fjerne bøker og kunder
        - CLI-en skal kunne vise en liste over alle bøker og kunder
        - CLI-en skal kunne vise detaljer om en spesifikk bok eller kunde
        - CLI-en skal kunne opprette en ordre for en kunde
        - CLI-en skal kunne vise en liste over alle ordre
        - CLI-en skal kunne vise detaljer om en spesifikk ordre
        - CLI-en skal kunne avslutte programmet

    4. Se over dokument for mer


*/
{
    public class Program
    {
        static void Main(string[] args) 
        {
            BookStoreManager bookStoreManager = new BookStoreManager();
            Book book1 = new Book("The Hobbit", "J.R.R. Tolkien", "978-0-395-07122-1", 149.50);
            Book book2 = new Book("The Lord of the Rings", "J.R.R. Tolkien", "978-0-395-19395-7", 199.50);
            Customer customer1 = new Customer("Emil", "Berglund", "emilbe@hiof.no", 98189601);

            bookStoreManager.AddBook(book1);
            bookStoreManager.AddBook(book2);
            bookStoreManager.AddCustomer(customer1);

            Book foundBook = bookStoreManager.FindBookByTitle("The Hobbit");
            Console.WriteLine($"Hobbit: {foundBook}");

            Book foundBook1 = bookStoreManager.FindBookByIsbn("978-0-395-07122-1");
            Console.WriteLine(foundBook1);

            Customer foundCustomer = bookStoreManager.FindCustomer("Emil");
            Console.WriteLine(foundCustomer);
        }
    }
};