using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UTExLMS.Models;

namespace UTExLMS.Service
{
    internal class ProfileService
    {
        private readonly UTExLMSContext _context;
        private Addition _addition { get; set; }
        public ProfileService()
        {
            _context = new UTExLMSContext();
            _addition = new Addition();

        }

        public Person GetProfile(int idPerson)
        {

            var person = _context.People.FromSqlRaw($"select * from GetProfile({idPerson})").FirstOrDefault();
            return person;
        }

        public Person loginAuth(string Email, string Pass)
        {
            var person = _context.People.FromSqlRaw($"select * from LoginAuth('{Email}','{Pass}')").FirstOrDefault();
            return person;
            
        }
        public void UpdateProfile(Person person)
        {
            _context.Database.ExecuteSqlRaw(
                "EXEC UpdatePersonProfile @IdPerson, @FirstName, @LastName, @Email, @Birthday, @Gender, @PhoneNum, @Pass",
                new SqlParameter("IdPerson", person.IdPerson),
                new SqlParameter("FirstName", person.FirstName),
                new SqlParameter("LastName", person.LastName),
                new SqlParameter("Email", person.Email),
                new SqlParameter("Birthday", person.Birthday),
                new SqlParameter("Gender", person.Gender),
                new SqlParameter("PhoneNum", person.PhoneNum),
                new SqlParameter("Pass", person.Pass)
            );
            MessageBox.Show("Save success!!!");
        }
    }
}