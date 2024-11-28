using Imtahanlar.Enums;
using Imtahanlar.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imtahanlar.Model
{
    public class Exam
    {
        public DateTime Date { get; set; }
        public int ID { get; set; }
        public ExamCategory Category { get; set; }

        public Exam(DateTime Time, ExamCategory category)
        {
            if (category == ExamCategory.IT)
            {
                ExamID.currentITexamId += 1;
                this.ID = ExamID.currentITexamId;
            }
            else if (category == ExamCategory.Tarix)
            {
                ExamID.currentTarixExamId += 1;
                this.ID = ExamID.currentTarixExamId;
            }
            else if (category == ExamCategory.Riyaziyyat)
            {
                ExamID.currentRiyaziyyatExamId += 1;
                this.ID = ExamID.currentRiyaziyyatExamId;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Bele bir categorya tapilmadi");
            }

            this.Date = Time;
            this.Category = category;
        }


    }
}
