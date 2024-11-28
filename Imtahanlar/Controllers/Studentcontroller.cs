using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imtahanlar.Controllers
{
        public class StudentController
        {
            // List<string> tipi ilə tələbələri saxlamaq
            public List<string> Students = new List<string>();

            public StudentController()
            {
                // List<string> ilə istifadə olunur
                Students = new List<string>();
            }

            public void AddStudents(string name, string surname)
            {
                // Tələbə adını və soyadını siyahıya əlavə etmək
                Students.Add(name);
                Students.Add(surname);
            }

            public void ShowStudents()
            {
                // Hər bir tələbəni ekrana yazdırmaq
                for (int i = 0; i < Students.Count; i += 2)
                {
                    Console.WriteLine($"Name: {Students[i]},\n" +
                                      $"Surname: {Students[i + 1]}\n");
                }
            }
        }

 
}
