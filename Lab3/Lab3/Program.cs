using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XDocument xmlDoc = XDocument.Load("C:\\Users\\MSI\\source\\C#\\Lab3\\Lab3\\Biblioteka.xml");

            Console.WriteLine("Xml file:");
            Console.WriteLine(xmlDoc);

            Console.WriteLine("\nCode of the book:");
            string inputCode = Console.ReadLine();

            var book = xmlDoc.Descendants("book")
                             .FirstOrDefault(b => b.Element("id").Value == inputCode);

            if (book != null)
            {
                string author = book.Element("author").Value;
                string title = book.Element("title").Value;
                string year = book.Element("year").Value;

                Console.WriteLine($"\nBoor with code {inputCode}:");
                Console.WriteLine($"Author: {author}");
                Console.WriteLine($"Title: {title}");
                Console.WriteLine($"Year: {year}");
            }
            else
            {
                Console.WriteLine("No book with this code");
            }

            Console.WriteLine("\nYear when created");
            string inputYear = Console.ReadLine();

            var books = xmlDoc.Descendants("book")
                              .Where(b => int.Parse(b.Element("pages").Value) >= 100 &&
                                          int.Parse(b.Element("pages").Value) <= 200 &&
                                          b.Element("year").Value == inputYear);

            if (books.Any())
            {
                decimal totalPrice = books.Sum(b => decimal.Parse(b.Element("price").Value));

                Console.WriteLine($"\nSum of books created in {inputYear} year with 100 to 200 pages: {totalPrice} UAH");
            }
            else
            {
                Console.WriteLine($"No books like that");
            }
            
        }
    }
}
