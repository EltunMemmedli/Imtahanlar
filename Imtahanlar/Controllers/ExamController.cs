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


        FileService File = new();


        ArrayList Exams;

        public ExamController(QuestionController questionsInstance)
        {
            questions = questionsInstance;
        }

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

        public void StartExam(string name, string surname, string category)
        {
            ArrayList Questions = questions.GetQuestions();

            if (Questions.Count == 0)
            {
                Console.WriteLine("Can not find the questions");
                return;
            }

            int a = 0, s = 0;

            foreach (Question sual in Questions)
            {
                if (sual.Category.ToString().ToLower() == category.ToLower())
                {
                    Console.Clear();
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
            double resultPercentage = total > 0 ? (double)a / total * 100 : 0;
            string status = resultPercentage >= 50 ? "Passed!" : "Did not passed!";

            Console.WriteLine($"Name: {name}, \nSurname: {surname}, \nResult: {resultPercentage}% ,\nStatus:{status}");

            Result newResult = new(name, surname, resultPercentage, status);


            File.WriteToFile(newResult);
        }

        public void SeeResults()
        {
            File.ReadFromFile();
        }
    }

}
