using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_c_1
{
    internal class Program
    {
        static void Main(string[] args)
        {  //1
            Console.WriteLine("1.1");
            Dictionary<int,string> reg = new Dictionary<int,string>();
            reg.Add(1, "Волинська");
            reg.Add(2, "Закарпатська");
            reg.Add(3, "Донецька");
            reg.Add(4, "Львівська");
            reg.Add(5, "Харківська");
            reg.Add(6, "Чернігівська");
            foreach (var item in reg)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("1.2");
            for(int i = reg.Count-1; i>=0; i--)
            {
                Console.WriteLine(reg.ElementAt(i));
            }
            Console.WriteLine("1.3");
            Console.WriteLine(reg.Count);
            Console.WriteLine("1.4");
            reg.Clear();
            Console.WriteLine(reg.Count);

            //2
            Console.WriteLine("2 v");
            Queue<int> numbers = new Queue<int>();
            Random ran = new Random();
            Console.Write("n=");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int rand = ran.Next(1, 1001);
                numbers.Enqueue(rand);
            }
            int count = 0;

            foreach (int i in numbers)
            {
                if (i % 7 == 0)
                {
                    count++;
                }

            }
            if (count > 0)
            {
                Console.WriteLine($"Numbers that / 7 = {count}");
            }
            else
            {
                Console.WriteLine("No numbers /7 ");
            }
            
            Console.ReadLine();
        }
    }
}
