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
            files.Add($"Status: {result.Status}");

            File.WriteAllLines(filepath, files);
        }
    }
}
