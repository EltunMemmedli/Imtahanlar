using Imtahanlar.Enums;
using Imtahanlar.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imtahanlar.Model
{
    public class Question
    {
        public int ID { get; set; }
        public string Questions { get; set; }
        public string FirstVariant { get; set; }
        public string SecondVariant { get; set; }
        public string ThirdVariant { get; set; }
        public string TrueVariant {  get; set; }
        public ExamCategory Category { get; set; }

        public Question(string question, string Firstvariant, string secondvariant, string thirdvariant, string truevariant, ExamCategory category)
        {

            if (category == ExamCategory.Riyaziyyat)
            {
                QuestionID.currentRiyaziyyatQuestionId += 1;
                this.ID = QuestionID.currentRiyaziyyatQuestionId;
            }
            else if (category == ExamCategory.IT)
            {
                QuestionID.currentITquestionId += 1;
                this.ID = QuestionID.currentITquestionId;
            }
            else if (category == ExamCategory.Tarix)
            {
                QuestionID.currentTarixQuestionId += 1;
                this.ID = QuestionID.currentTarixQuestionId;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Bele bir categorya tapilmadir!");
            }

            this.Questions = question;
            this.FirstVariant = Firstvariant;
            this.SecondVariant = secondvariant;
            this.ThirdVariant = thirdvariant;
            this.TrueVariant = truevariant;  
            this.Category = category;
        }

    }
}
