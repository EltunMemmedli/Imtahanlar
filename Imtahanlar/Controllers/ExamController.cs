using Imtahanlar.Enums;
using Imtahanlar.Model;
using Imtahanlar.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imtahanlar.Controllers
{
    public class ExamController
    {
        QuestionController questions = new();

        ArrayList Exams;


        public ExamController()
        {
            Exams = new ArrayList();
        }

        public void CollectExams(Exam exams)
        {
            Exams.Add(exams);
        }

        public void ShowExams()
        {
            foreach (Exam exam in Exams)
            {
                Console.WriteLine($"Exam ID: {exam.ID}" +
                                  $"Exam category: {exam.Category}" +
                                  $"Exam date: {exam.Date}");
            }
        }

        public void StartExam(string category, string name, string surname)
        {
            ArrayList Questions = questions.GetQuestions();

            if(Questions.Count == 0)
            {
                Console.WriteLine("bos");
                return;
            }
            int a = 0;
            int s = 0;

            if(category.ToLower() == ExamCategory.Riyaziyyat.ToString().ToLower())
            {
                foreach (Question sual in Questions)
                {

                        Console.WriteLine($"{sual.Questions}\n" +
                                          $"A) {sual.FirstVariant}\n" +
                                          $"B) {sual.SecondVariant}\n" +
                                          $"C) {sual.ThirdVariant}");

                        string cavab = Console.ReadLine();

                        if (cavab.ToLower() == sual.TrueVariant.ToLower())
                        {
                            a++;
                        }
                        else
                        {
                            s++;
                        }
                    
                }
            }
            else if(category.ToLower() == ExamCategory.Tarix.ToString().ToLower())
            {
                foreach (Question sual in Questions)
                {


                        Console.WriteLine($"{sual.Questions}\n" +
                                          $"A) {sual.FirstVariant}\n" +
                                          $"B) {sual.SecondVariant}\n" +
                                          $"C) {sual.ThirdVariant}");

                        string cavab = Console.ReadLine();

                        if (cavab.ToLower() == sual.TrueVariant.ToLower())
                        {
                            a++;
                        }
                        else
                        {
                            s++;
                        }
                    
                }
            }
            else if(category.ToLower() == ExamCategory.IT.ToString().ToLower())
            {
                foreach (Question sual in Questions)
                {


                    Console.WriteLine($"{sual.Questions}\n" +
                                      $"A) {sual.FirstVariant}\n" +
                                      $"B) {sual.SecondVariant}\n" +
                                      $"C) {sual.ThirdVariant}");

                    string cavab = Console.ReadLine();

                    if (cavab.ToLower() == sual.TrueVariant.ToLower())
                    {
                        a++;
                    }
                    else
                    {
                        s++;
                    }

                }
            }

            int total = a + s;
            double resultPercentage = total > 0 ? (double)a / total * 100 : 0; // Faiz hesablanır
            string status = resultPercentage >= 50 ? "İmtahandan keçib!" : "İmtahandan keçməyib.";

            /* Console.WriteLine($"Netice: {resultPercentage}% {status}");*/

            Result newResult = new(name, surname, resultPercentage, status);
        }
    }
}
