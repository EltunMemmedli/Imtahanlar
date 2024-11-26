using Imtahanlar.Enums;
using Imtahanlar.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imtahanlar.Model
{
    public class Profil
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ProfilCategory Category { get; set; }

        public Profil(string name, string surname, string email, string password, ProfilCategory category)
        {
            if(category == ProfilCategory.Admin)
            {
                UserID.currentAdminid += 1;
                this.ID = UserID.currentAdminid;
            }
            else if(category == ProfilCategory.User)
            {
                UserID.currentStudentId += 1;
                this.ID= UserID.currentStudentId;
            }

            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.Password = password;
            this.Category = category;
        }
    }
}
