using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace lab4
{
    class Book
    {
        public int Code { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }
        public double Price { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\MSI\\source\\C#\\lab4\\lab4\\jsconfig2.json";

            var jsonData = File.ReadAllText(filePath);
            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(jsonData);

            Console.WriteLine("Book list");
            books.ForEach(book =>
                Console.WriteLine($"{book.Code}: {book.Author}, \"{book.Title}\", {book.Year}, pages: {book.Pages}, price: {book.Price}")
            );

            Console.Write("Book code: ");
            int code = int.Parse(Console.ReadLine());

            var bookByCode = books
                .Where(b => b.Code == code)
                .Select(b => new { b.Author, b.Title, b.Year })
                .FirstOrDefault();

            if (bookByCode != null)
            {
                Console.WriteLine($"Author: {bookByCode.Author}, Title: \"{bookByCode.Title}\", Year: {bookByCode.Year}");
            }
            else
            {
                Console.WriteLine("No book like that");
            }

            Console.Write("Yaer: ");
            int year = int.Parse(Console.ReadLine());

            var totalCost = books
                .Where(b => b.Pages >= 100 && b.Pages <= 200 && b.Year == year)
                .Sum(b => b.Price);
            Console.WriteLine(totalCost);
        }
    }
}

    
