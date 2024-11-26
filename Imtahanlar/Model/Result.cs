using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imtahanlar.Model
{
    public class Result
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public double ExamPercentage { get; set; }
        public string Status { get; set; }

        public Result(string name, string surname, double ExamPercentage, string status)
        {
            this.Name = name;
            this.Surname = surname;
            this.ExamPercentage = ExamPercentage;
            Status = status;

        }
    }
}
