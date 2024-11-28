using Imtahanlar.Enums;
using Imtahanlar.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Imtahanlar.Controllers
{
    public class ProfilController
    {
        ArrayList Profils;

        public ProfilController()
        {
            Profils = new ArrayList();
        }

        public void AddUser(Profil profil)
        {
            Profils.Add(profil);
        }

        public ArrayList GetUsers()
        {
            return Profils;
        }

        public void ShowProfils()
        {
            foreach (Profil profil in Profils)
            {
                if(profil.Category == ProfilCategory.User)
                {
                    Console.WriteLine($"\nID : {profil.ID}\n" +
                                  $"Name: {profil.Name},\n" +
                                  $"Surname: {profil.Surname}");
                }
            }
        }

        public bool SignIn(string email, string password)
        {
            bool valid = false;
            foreach (Profil profil in Profils)
            {
                if (email == profil.Email && password == profil.Password)
                {
                    valid = true;
                }
            }
            return valid;
        }

        public bool SignUp(Profil newProfile)
        {
            Profils.Add(newProfile);
            return true;
        }

        public bool AddNewUser(Profil profils)
        {
            Profils.Add(profils);
            return true;
        }

        public bool RemoveProfil(int ID)
        {
            Profils.RemoveAt(ID);
            return true;
        }

    }
}
