using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab2
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Group { get; set; }

    }
    public class Session
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Test { get; set; }
        public int Score { get; set; }
        public DateTime TestDate { get; set; }
        
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>
            {
                new Student { Id = 1, Name="AStud1", Group=1},
                new Student { Id = 2, Name="GStud2", Group=2},
                new Student { Id = 3, Name="DStud3", Group=3},
                new Student { Id = 4, Name="TStud4", Group=1},
                new Student { Id = 5, Name="TStud5", Group=1},
                new Student { Id = 6, Name="JStud6", Group=3},
                new Student { Id = 7, Name="LStud7", Group=2}
            };
            var session = new List<Session>
            {
                new Session { Id = 1, Subject="Subject 1", Test="Exam", Score= 40, TestDate= new DateTime(2024,11,7)},
                new Session { Id = 2, Subject="Subject 2", Test="Credit", Score= 73, TestDate= new DateTime(2024,11,9)},
                new Session { Id = 3, Subject="Subject 3", Test="Exam", Score= 59, TestDate= new DateTime(2024,11,10)},
                new Session { Id = 4, Subject="Subject 1", Test="Exam", Score= 88, TestDate= new DateTime(2024,11,7)},
                new Session { Id = 5, Subject="Subject 2", Test="Credit", Score= 50, TestDate= new DateTime(2024,11,9)},
                new Session { Id = 6, Subject="Subject 3", Test="Credit", Score= 70, TestDate= new DateTime(2024,11,10)},
                new Session { Id = 7, Subject="Subject 1", Test="Exam", Score= 40, TestDate= new DateTime(2024,11,7)}
            };
            Console.Write("Letters: ");
            char letter = Convert.ToChar(Console.ReadLine());
            var filter = students.Where(s=>s.Name.StartsWith(letter.ToString(),StringComparison.OrdinalIgnoreCase));
            foreach(var stud in filter)
            {
                Console.WriteLine(stud.Name,stud.Id);
            }

            int currentYear = DateTime.Now.Year; 
            var failedGroups = session
                .Where(s => s.Test == "Exam" && s.Score < 60 && s.TestDate.Year == currentYear)
                .Join(students, ses => ses.Id, stud => stud.Id, (ses, stud) => new { stud.Group })
                .GroupBy(g => g.Group)
                .Where(gr => gr.Count() <= 2)
                .Select(gr => gr.Key)
                .ToList();
            Console.WriteLine("Less then two");
            foreach (var group in failedGroups)
            {
                Console.WriteLine(group);
            }

            var studentRatings = students
                .Select(stud => new
                {
                    StudentName = stud.Name,
                    AverageScore = session.Where(s => s.Id == stud.Id).Average(s => s.Score)
                })
                .OrderByDescending(stud => stud.AverageScore)
                .ToList();
            foreach (var student in studentRatings)
            {
                Console.WriteLine($"{student.StudentName}: {student.AverageScore:F2}");
            }
            Console.ReadLine();
        }   
    }
}
