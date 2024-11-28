using Imtahanlar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imtahanlar.Services
{
    public class FileService
    {
        public string filepath = @"C:\Test\test.txt";
        
        List<string> files = new List<string>();

        public void WriteToFile(Result result)
        {
            files.Add($"Name: {result.Name}");
            files.Add($"Surname: {result.Surname}");
            files.Add($"Result: {result.ExamPercentage}");
            files.Add($"Status: {result.Status}\n");

            File.WriteAllLines(filepath, files);
        }

        public void ReadFromFile()
        {
            // Fayldan xətləri oxuyur
            var lines = File.ReadAllLines(filepath).ToList();

            List<Result> results = new List<Result>();

            for (int i = 0; i < lines.Count; i += 4) // Hər nəticə 4 xətdən ibarətdir
            {
                if (i + 3 >= lines.Count) // Faylda kifayət qədər xətt yoxdursa
                {
/*                    Console.WriteLine("Fayl tam məlumat içermir.");*/
                    break;
                }

                // Məlumatları oxuyub emal edir
                string name = lines[i].Replace("Name: ", "").Trim();
                string surname = lines[i + 1].Replace("Surname: ", "").Trim();

                if (!double.TryParse(lines[i + 2].Replace("Result: ", "").Trim(), out double examPercentage))
                {
/*                    Console.WriteLine($"Faylın nəticə xətti düzgün deyil: {lines[i + 2]}");*/
                    continue;
                }

                string status = lines[i + 3].Replace("Status: ", "").Trim();

                // Nəticəni siyahıya əlavə edir
                results.Add(new Result(name, surname, examPercentage, status));
            }

            // Nəticələri ekrana yazır
            foreach (var result in results)
            {
                Console.WriteLine($"Name: {result.Name}, Surname: {result.Surname}, Result: {result.ExamPercentage}, Status: {result.Status}");
            }
        }

    }
}
