using Imtahanlar.Enums;
using Imtahanlar.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Imtahanlar.Controllers
{
    public class QuestionController
    {
        ArrayList Questions;

        public QuestionController()
        {
            Questions = new ArrayList();
        }

        public void AddQuestions(Question questions)
        {
            Questions.Add(questions);
        }

        public ArrayList GetQuestions()
        {
            return Questions;
        }

        public void ShowQuestions()
        {
            string currentCategory = null;

            foreach (Question question in Questions)
            {
                if (currentCategory != question.Category.ToString())
                {
                    currentCategory = question.Category.ToString();
                    Console.WriteLine($"\nCategory: {currentCategory}");
                }

                Console.WriteLine($"\nID: {question.ID}\n" +
                                  $"Question: {question.Questions}\n" +
                                  $"A) {question.FirstVariant}\n" +
                                  $"B) {question.SecondVariant}\n" +
                                  $"C) {question.ThirdVariant}\n");
            }
        }

        public void UpdateQuestion(string category,
                                    int Index,
                                    string newQuestion,
                                    string newFirstVariant,
                                    string newSecondVariant,
                                    string newThirdVariant,
                                    string newTrueVariant)
        {
            if(category.ToLower() == ExamCategory.Riyaziyyat.ToString().ToLower())
            {
                Question question = new Question(newQuestion, newFirstVariant, newSecondVariant, newThirdVariant, newTrueVariant, ExamCategory.Riyaziyyat);
                Questions[Index - 1] = question;
            }
            else if(category.ToLower() == ExamCategory.Tarix.ToString().ToLower())
            {
                Question question = new Question(newQuestion, newFirstVariant, newSecondVariant, newThirdVariant, newTrueVariant, ExamCategory.Tarix);
                Questions[Index - 1] = question;
            }
            else if(category.ToLower() == ExamCategory.IT.ToString().ToLower())
            {
                Question question = new Question(newQuestion, newFirstVariant, newSecondVariant, newThirdVariant, newTrueVariant, ExamCategory.IT);
                Questions[Index - 1] = question;
            }
        }

        public void AddNewQuestion(string category, string question, string firstvariant, string secondvariant, string thirdvariant, string truevariant)
        {
            if(category.ToLower() == ExamCategory.IT.ToString().ToLower())
            {
                Question NeqQuestion = new(question, firstvariant, secondvariant, thirdvariant, truevariant, ExamCategory.IT);
                Questions.Add(NeqQuestion);
            }
            else if(category.ToLower() == ExamCategory.Riyaziyyat.ToString().ToLower())
            {
                Question NeqQuestion = new(question, firstvariant, secondvariant, thirdvariant, truevariant, ExamCategory.IT);
                Questions.Add(NeqQuestion);
            }
            else if(category.ToLower() == ExamCategory.Tarix.ToString().ToLower())
            {
                Question NeqQuestion = new(question, firstvariant, secondvariant, thirdvariant, truevariant, ExamCategory.IT);
                Questions.Add(NeqQuestion);
            }
        }
    }
}
