

using Imtahanlar.Controllers;
using Imtahanlar.Enums;
using Imtahanlar.Model;
using Imtahanlar.Services;
using System.Collections;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

ProfilController Profils = new ProfilController();
ExamController exams = new ExamController();
QuestionController questions = new();

#region Profils
Profil Admin = new("Eltun", "Memmedli", "eltun.memmedli.06@gmail.com", "Eltun2006", ProfilCategory.Admin);
Profil User_1 = new("Cavid", "Memmedli", "cavid.memmedli.09@gmail.com", "Cavid2009", ProfilCategory.User);
Profil User_2 = new("Nicat", "Qurbanli", "nicat.qurbanov.08@gmail.com", "Nicat2008", ProfilCategory.User);
Profil User_3 = new("Eltun", "Xan", "eltun.xan.11@gmail.com", "Eltun2005", ProfilCategory.User);
Profil User_4 = new("Musa", "Mehdiyev", "musa.mehdiyev.09@gmail.com", "Musa2009", ProfilCategory.User);
Profil User_5 = new("Aysel", "Huseynova", "aysel.huseynova.10@gmail.com", "Aysel2010", ProfilCategory.User);
Profil User_6 = new("Leyla", "Aliyeva", "leyla.aliyeva.07@gmail.com", "Leyla2007", ProfilCategory.User);
Profil User_7 = new("Ramil", "Ismayilov", "ramil.ismayilov.12@gmail.com", "Ramil2012", ProfilCategory.User);
Profil User_8 = new("Sara", "Sadiqova", "sara.sadiqova.06@gmail.com", "Sara2006", ProfilCategory.User);
Profil User_9 = new("Samir", "Huseynov", "samir.huseynov.14@gmail.com", "Samir2014", ProfilCategory.User);
Profil User_10 = new("Aygun", "Mammadova", "aygun.mammadova.13@gmail.com", "Aygun2013", ProfilCategory.User);

Profils.AddUser(Admin);
Profils.AddUser(User_1);
Profils.AddUser(User_2);
Profils.AddUser(User_3);
Profils.AddUser(User_4);
Profils.AddUser(User_5);
Profils.AddUser(User_6);
Profils.AddUser(User_7);    
Profils.AddUser(User_8);
Profils.AddUser(User_9);
Profils.AddUser(User_10);
#endregion

#region Riyaziyyat
Question math_questions_1 = new("15 ile 8-in ceminden 5-i çıxın.", "18", "23", "20", "C", ExamCategory.Riyaziyyat);
Question math_questions_2 = new("36-nın kvadrat kokunu tapın.", "6", "5", "9", "A", ExamCategory.Riyaziyyat);
Question math_questions_3 = new("7 ile 3-ü vurun və neticeni 5-e bölün.", "5", "4", "6", "A", ExamCategory.Riyaziyyat);

RiyaziyyatController riyaziyyat = new RiyaziyyatController();

riyaziyyat.AddQuestions(math_questions_1);
riyaziyyat.AddQuestions(math_questions_2);
riyaziyyat.AddQuestions(math_questions_3);

questions.AddQuestions(math_questions_1);
questions.AddQuestions(math_questions_2);
questions.AddQuestions(math_questions_3);
#endregion

#region IT
Question IT_question_1 = new("HTML-de en böyük başlıq etiketi hansıdır?", "<h6>", "<h1>", "<h3>", "B", ExamCategory.IT);
Question IT_question_2 = new("Hansı protokol veb sehifelerin şifrlenmiş oturulmesini temin edir?", "HTTP", "FTP", "HTTPS", "C", ExamCategory.IT);
Question IT_question_3 = new("Hansı emeliyyat sistemi açıq menbeli (open-source) hesab edilir?", "Windows", "Linux", "macOS", "B", ExamCategory.IT);

ITController IT = new();

IT.AddQuestions(IT_question_1);
IT.AddQuestions(IT_question_2);
IT.AddQuestions(IT_question_3);

questions.AddQuestions(IT_question_1);
questions.AddQuestions(IT_question_2);
questions.AddQuestions(IT_question_3);
#endregion

#region Tarix
Question Tarix_question_1 = new("Azerbaycan Xalq Cumhuriyyeti ne vaxt elan edilib?", "28 May 1918", "18 Oktyabr 1991", "20 Yanvar 1990", "A", ExamCategory.Tarix);
Question Tarix_question_2 = new("İkinci Dünya Müharibesi hansı iller arasında baş verib?", "1914-1918", "1939-1945", "1947-1953", "B", ExamCategory.Tarix);
Question Tarix_question_3 = new("Sumer medeniyyeti harada formalaşıb?", "Misir", "Mesopotamiya", "Hindistan", "B", ExamCategory.Tarix);

TarixController Tarix = new();

Tarix.AddQuestions(Tarix_question_1);
Tarix.AddQuestions(Tarix_question_2);
Tarix.AddQuestions(Tarix_question_3);

questions.AddQuestions(Tarix_question_1);
questions.AddQuestions(Tarix_question_2);
questions.AddQuestions(Tarix_question_3);
#endregion

Main_Menu:
Console.WriteLine("Choose one option:\n" +
                  "1.Sign In\n" +
                  "2.Sign Up\n" +
                  "3.Guest\n" +
                  "-----------------------");
string Option = Console.ReadLine();
int option;
if(int.TryParse(Option, out option) && option > 0 && option < 4)
{
    if (option == 1)
    {

        Console.Clear();
    email:
        string pattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
        Regex regex = new Regex(pattern);


        Console.WriteLine("Please, enter your email");
        string email = Console.ReadLine();
        Console.Clear();

        bool Ismatch = regex.IsMatch(email);
        if (!(string.IsNullOrEmpty(email)) && Ismatch)
        {
            Console.Clear();
        password:
            Console.WriteLine("Please, enter your password");
            string password = Console.ReadLine();
            if (!(string.IsNullOrEmpty(password)))
            {
                bool valid = Profils.SignIn(email, password);
                if (valid is false)
                {
                    Console.Clear();
                    Console.WriteLine("Email ve ya password sehvdir!");
                    goto email;
                }
                else
                {
                    //Admin
                    if (email.ToLower() == Admin.Email)
                    {
                        Admin_Menu:
                        Console.Clear();
                        Console.WriteLine($"Welcome {Admin.Name}\n" +
                                          $"1.Show All Users,\n" +
                                          $"2.Add new Users,\n" +
                                          $"3.Remove a User,\n" +
                                          $"4.See Questions\n" +
                                          $"5.Update Questions,\n" +
                                          $"6.Add new Question,\n" +
                                          $"7.Control Exams,\n" +
                                          $"8.See Users which give exam\n" +
                                          $"----------------------------------");
                        string Menu = Console.ReadLine();
                        int menu;
                        if(int.TryParse(Menu, out menu) && menu > 0 && menu < 9)
                        {
                            if (menu == 1)
                            {
                                Console.Clear();
                                Profils.ShowProfils();
                            AnaMenuKecini:
                                Console.WriteLine("\nPress 'f' to return Main Menu");
                                string AnaMenu = Console.ReadLine();
                                if (!(string.IsNullOrEmpty(AnaMenu)) && AnaMenu.ToLower() == "F".ToLower())
                                {
                                    Console.Clear();
                                    goto Admin_Menu;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Be sure to press correct button!");
                                    goto AnaMenuKecini;
                                }
                            }

                            else if (menu == 2)
                            {
                                Console.Clear();
                            name:
                                Console.WriteLine("Add new user's name");
                                string name = Console.ReadLine();
                                if (!(string.IsNullOrEmpty(name)))
                                {
                                    Console.Clear();
                                surname:
                                    Console.WriteLine("Add new user's surname");
                                    string surname = Console.ReadLine();
                                    if (!(string.IsNullOrEmpty(surname)))
                                    {
                                        Console.Clear();
                                    Email:
                                        string Pattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
                                        Regex Regex = new Regex(pattern);


                                        Console.WriteLine("Add new user's email");
                                        string Email = Console.ReadLine();
                                        Console.Clear();

                                        bool IsMatch = regex.IsMatch(email);
                                        if (!(string.IsNullOrEmpty(Email)) && IsMatch)
                                        {
                                            Console.Clear();
                                        Password:
                                            Console.WriteLine("Add new user's password");
                                            string Password = Console.ReadLine();
                                            if (!(string.IsNullOrEmpty(Password)))
                                            {
                                                Profil newProfil = new(name, surname, Email, Password, ProfilCategory.User);
                                                bool valid_ = Profils.AddNewUser(newProfil);
                                                if (valid_ is false)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Informations are not correct!");
                                                    goto name;
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("User succesfully added!");

                                                AnaMenuKecini:
                                                    Console.WriteLine("\nPress 'f' to return Main Menu");
                                                    string AnaMenu = Console.ReadLine();
                                                    if (!(string.IsNullOrEmpty(AnaMenu)) && AnaMenu.ToLower() == "F".ToLower())
                                                    {
                                                        Console.Clear();
                                                        goto Admin_Menu;
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Be sure to press correct button!");
                                                        goto AnaMenuKecini;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Invalid password!");
                                                goto Password;
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Invalid Email!");
                                            goto Email;
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Invalid surname!");
                                        goto surname;
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Invalid name!");
                                    goto name;
                                }
                            }

                            else if (menu == 3)
                            {
                                ArrayList NewList = Profils.GetUsers();
                                int a = NewList.Count;
                                Console.Clear();
                            ID:
                                Profils.ShowProfils();
                                Console.WriteLine("\nWrite ID of the user which will be removed");
                                string id = Console.ReadLine();
                                int ID;
                                if (int.TryParse(id, out ID) && ID < a + 1 && ID > 0)
                                {
                                    bool valid_1 = Profils.RemoveProfil(ID);
                                    if (valid_1 is false)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Informations are not correct!");
                                        goto ID;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("User have been removed succesfully");
                                    AnaMenuKecini:
                                        Console.WriteLine("\nPress 'f' to return Main Menu");
                                        string AnaMenu = Console.ReadLine();
                                        if (!(string.IsNullOrEmpty(AnaMenu)) && AnaMenu.ToLower() == "F".ToLower())
                                        {
                                            Console.Clear();
                                            goto Admin_Menu;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Be sure to press correct button!");
                                            goto AnaMenuKecini;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("ID duzgun daxil edin!");
                                    goto ID;
                                }
                            }

                            else if (menu == 4)
                            {
                                Console.Clear();
                                riyaziyyat.ShowQuestions();
                                IT.ShowQuestions();
                                Tarix.ShowQuestions();
                            AnaMenuKecini:
                                Console.WriteLine("\nPress 'f' to return Main Menu");
                                string AnaMenu = Console.ReadLine();
                                if (!(string.IsNullOrEmpty(AnaMenu)) && AnaMenu.ToLower() == "F".ToLower())
                                {
                                    Console.Clear();
                                    goto Admin_Menu;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Be sure to press correct button!");

                                }
                            }

                            else if(menu == 5)
                            {
                                ArrayList NewRiyaziyyat = riyaziyyat.GetQuestions();
                                ArrayList NewIT = IT.GetQuestions();
                                ArrayList NewTarix = Tarix.GetQuestions();
                                int s = 0;
                                Console.Clear();
                                Category:
                                Console.WriteLine("Please, enter category of the questions");
                                string Category = Console.ReadLine();
                                if (!(string.IsNullOrEmpty(Category)))
                                {
                                    if(Category.ToLower() == ExamCategory.Tarix.ToString().ToLower())
                                    {
                                        Console.Clear();
                                        s = NewTarix.Count;
                                        Tarix.ShowQuestions();
                                    }
                                    else if(Category.ToLower() == ExamCategory.Riyaziyyat.ToString().ToLower())
                                    {
                                        Console.Clear();
                                        s = NewTarix.Count;
                                        riyaziyyat.ShowQuestions();
                                    }
                                    else if(Category.ToLower() == ExamCategory.IT.ToString().ToLower())
                                    {
                                        Console.Clear();
                                        s = NewIT.Count;
                                        IT.ShowQuestions();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Can not find category!");
                                        goto Category;
                                    }


                                    
                                    Console.WriteLine("Please, enter the ID of the question");
                                    string id = Console.ReadLine();
                                    int ID;
                                    if(int.TryParse(id, out ID) && ID <= s && ID > 0)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Enter the new question");
                                        string newQuestion = Console.ReadLine();
                                        if (!(string.IsNullOrEmpty(newQuestion)))
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Enter the first variant");
                                            string firstvariant = Console.ReadLine();
                                            if (!(string.IsNullOrEmpty(firstvariant)))
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Enter the second variant");
                                                string secondvariant = Console.ReadLine();
                                                if (!(string.IsNullOrEmpty(secondvariant)))
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Enter the third question");
                                                    string thirdvariant = Console.ReadLine();
                                                    if (!(string.IsNullOrEmpty(thirdvariant)))
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Enter the truevariant");
                                                        string truevariant = Console.ReadLine();
                                                        if (!(string.IsNullOrEmpty(truevariant)))
                                                        {
                                                            {
                                                                if (Category.ToLower() == ExamCategory.Tarix.ToString().ToLower())
                                                                {
                                                                    Tarix.UpdateQuestion(Category, ID, newQuestion, firstvariant, secondvariant, thirdvariant, truevariant);
                                                                AnaMenuKecini:
                                                                    Console.WriteLine("\nPress 'f' to return Main Menu");
                                                                    string AnaMenu = Console.ReadLine();
                                                                    if (!(string.IsNullOrEmpty(AnaMenu)) && AnaMenu.ToLower() == "F".ToLower())
                                                                    {
                                                                        Console.Clear();
                                                                        goto Admin_Menu;
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine("Be sure to press correct button!");

                                                                    }
                                                                }
                                                                else if (Category.ToLower() == ExamCategory.Riyaziyyat.ToString().ToLower())
                                                                {
                                                                    riyaziyyat.UpdateQuestion(Category, ID, newQuestion, firstvariant, secondvariant, thirdvariant, truevariant);
                                                                AnaMenuKecini:
                                                                    Console.WriteLine("\nPress 'f' to return Main Menu");
                                                                    string AnaMenu = Console.ReadLine();
                                                                    if (!(string.IsNullOrEmpty(AnaMenu)) && AnaMenu.ToLower() == "F".ToLower())
                                                                    {
                                                                        Console.Clear();
                                                                        goto Admin_Menu;
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine("Be sure to press correct button!");


                                                                    }
                                                                }
                                                                else if (Category.ToLower() == ExamCategory.IT.ToString().ToLower())
                                                                {
                                                                    IT.UpdateQuestion(Category, ID, newQuestion, firstvariant, secondvariant, thirdvariant, truevariant);
                                                                AnaMenuKecini:
                                                                    Console.WriteLine("\nPress 'f' to return Main Menu");
                                                                    string AnaMenu = Console.ReadLine();
                                                                    if (!(string.IsNullOrEmpty(AnaMenu)) && AnaMenu.ToLower() == "F".ToLower())
                                                                    {
                                                                        Console.Clear();
                                                                        goto Admin_Menu;
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine("Be sure to press correct button!");

                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            else if(menu == 6)
                            {
                                Console.Clear();
                                category:
                                Console.WriteLine("Enter the category");
                                string category = Console.ReadLine();
                                if (!(string.IsNullOrEmpty(category)))
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enter the new qeustion");
                                    string question = Console.ReadLine();
                                    if (!(string.IsNullOrEmpty(question)))
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Enter the first variant");
                                        string firstvariant = Console.ReadLine();
                                        if (!(string.IsNullOrEmpty(firstvariant)))
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Enter the second variant");
                                            string secondavriant = Console.ReadLine();
                                            if (!(string.IsNullOrEmpty(secondavriant)))
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Enter the third variant");
                                                string thirdvariant = Console.ReadLine();
                                                if (!(string.IsNullOrEmpty(thirdvariant)))
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Enter the true variant");
                                                    string thruevariant = Console.ReadLine();
                                                    if (!(string.IsNullOrEmpty(thruevariant)))
                                                    {
                                                        if(category.ToLower() == ExamCategory.Tarix.ToString().ToLower())
                                                        {
                                                            Tarix.AddNewQuestion(category, question, firstvariant, secondavriant, thirdvariant, thruevariant);
                                                        AnaMenuKecini:
                                                            Console.WriteLine("\nPress 'f' to return Main Menu");
                                                            string AnaMenu = Console.ReadLine();
                                                            if (!(string.IsNullOrEmpty(AnaMenu)) && AnaMenu.ToLower() == "F".ToLower())
                                                            {
                                                                Console.Clear();
                                                                goto Admin_Menu;
                                                            }
                                                            else
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine("Be sure to press correct button!");

                                                            }
                                                        }
                                                        else if(category.ToLower() == ExamCategory.Riyaziyyat.ToString().ToLower())
                                                        {
                                                            riyaziyyat.AddNewQuestion(category, question, firstvariant, secondavriant, thirdvariant, thruevariant);
                                                        AnaMenuKecini:
                                                            Console.WriteLine("\nPress 'f' to return Main Menu");
                                                            string AnaMenu = Console.ReadLine();
                                                            if (!(string.IsNullOrEmpty(AnaMenu)) && AnaMenu.ToLower() == "F".ToLower())
                                                            {
                                                                Console.Clear();
                                                                goto Admin_Menu;
                                                            }
                                                            else
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine("Be sure to press correct button!");

                                                            }

                                                        }
                                                        else if(category.ToLower() == ExamCategory.IT.ToString().ToLower())
                                                        {
                                                            IT.AddNewQuestion(category, question, firstvariant, secondavriant, thirdvariant, thruevariant);
                                                        AnaMenuKecini:
                                                            Console.WriteLine("\nPress 'f' to return Main Menu");
                                                            string AnaMenu = Console.ReadLine();
                                                            if (!(string.IsNullOrEmpty(AnaMenu)) && AnaMenu.ToLower() == "F".ToLower())
                                                            {
                                                                Console.Clear();
                                                                goto Admin_Menu;
                                                            }
                                                            else
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine("Be sure to press correct button!");

                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("Can not find category");
                                                            goto category;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            else if(menu == 7)
                            {
                                Console.Clear();
                                exams.ShowExams();
                            }
                            else if(menu == 8)
                            {

                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Try again!");
                            goto Admin_Menu;
                        }
                    }

                    //User
                    else
                    {
                        User_Menu:
                        Console.WriteLine("1.Start the exam,\n" +
                                          "2.See result,\n" +
                                          "3.Log out\n" +
                                          "---------------------");
                        string Secim = Console.ReadLine();
                        int secim;
                        if(int.TryParse(Secim, out secim) && secim > 0 && secim < 4)
                        {
                            if(secim == 1)
                            {
                                Console.Clear();
                                Console.WriteLine("Enter your name");
                                string name = Console.ReadLine();
                                if (!(string.IsNullOrEmpty(name)))
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enter your surname");
                                    string surname = Console.ReadLine();
                                    if (!(string.IsNullOrEmpty(surname)))
                                    {
                                        Console.Clear();
                                        Console.WriteLine("1.Tarix\n" +
                                                          "2.Riyaziyyat\n" +
                                                          "3.IT\n" +
                                                          "---Write the category-----\n");
                                        string category = Console.ReadLine();
                                        if (!(string.IsNullOrEmpty(category)))
                                        {
                                            exams.StartExam(name, surname, category);

                                        }
                                    }
                                }
                               
                            }
                        }

                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Try again!");
                goto password;
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Try again!");
            goto email;
        }
    }
}
else
{
    Console.Clear();
    Console.WriteLine("Try Again!");
    goto Main_Menu;
}





/*
    Profil - [Admin, User]
    
    Exams - [ExamID, ExamDate, ExamResult, ExamCategory]

    Questions - [QuestionID, Question, Variants, CorrectAnswer]
 
    Controllers - ProfilControolller{}, ExamController{}, QuestionController{}
    
    Models - Exam{}, Profil{}, Questions{}

    ID - ExamID, ProfilID, QuestionID
    
 */




/*   
 
    Admin - [
                                          "1.Istifadecileri gormek\n" +
                                          "2.Yeni istifadeci elave etmek,\n" +
                                          "3.Istifadeci silmek,\n" +
                                          "4.Suallari categoriyaya esasen gormek,\n" +
                                          "5.Suallari yenilemek,\n" +
                                          "6.Yeni sual elave etmek,\n" +
                                          "7.Imtahanlari idare etmek\n" +
                                          "8.Imtahan veren telebeleri gormek\n" +

                ]
 
 
 
 */