using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ConsoleAppDBBasics.Models;


namespace Module
{
    public class ElectricityUsage
    {
        public int Id { get; set; } 
        public string Month { get; set; } 
        public double ConsumedKwh { get; set; } 
        public double Rate { get; set; } 
        public double Cost { get; set; } 
    }
    public class ApplicationContext : DbContext
    {
        public DbSet<ElectricityUsage> ElectricityUsages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MSI-PC59\\TEMP;Database=ElectricityUsage:;Trusted_Connection=True;");
        }
    }
    internal class Program
    {
        public static void CalculateTotalCost(params string[] months)
        {
            using (var context = new ApplicationContext())
            {
                var totalCost = context.ElectricityUsages
                    .Where(e => months.Contains(e.Month))
                    .Sum(e => e.Cost);

                Console.WriteLine($"Total cost for month {string.Join(", ", months)}: {totalCost}");
            }
        }
        public static void ExportToXml()
        {
            using (var context = new ApplicationContext())
            {
                var data = context.ElectricityUsages.ToList();
                var dataTable = new DataTable("ElectricityUsage");

                dataTable.Columns.Add("Id", typeof(int));
                dataTable.Columns.Add("Month", typeof(string));
                dataTable.Columns.Add("ConsumedKwh", typeof(double));
                dataTable.Columns.Add("Rate", typeof(double));
                dataTable.Columns.Add("Cost", typeof(double));

                foreach (var usage in data)
                {
                    dataTable.Rows.Add(usage.Id, usage.Month, usage.ConsumedKwh, usage.Rate, usage.Cost);
                }

                var dataSet = new DataSet("ElectricityData");
                dataSet.Tables.Add(dataTable);

                string filePath = "ElectricityUsage.xml";
                dataSet.WriteXml(filePath);
                Console.WriteLine($"Savet in file {filePath}");
            }
        }
        static void Main(string[] args)
        {

            // 1
            Console.WriteLine("Enter months (comma separated, e.g., January,February):");
            string[] months = Console.ReadLine()?.Split(',');
            CalculateTotalCost(months);

            // 2
            ExportToXml();


        }
    }
}
