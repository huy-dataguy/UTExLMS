using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTExLMS.Models;
namespace UTExLMS.Service
{
    public class PersonService
    {
        public UTExLMSContext _context { get; set; }
        public PersonService()
        {
            _context = new UTExLMSContext();
        }


        public Person GetInforPerson(int idPerson)
        {
            var person = _context.People
               .FromSqlRaw($"SELECT * FROM GetPersonInfoById({idPerson})")
                .FirstOrDefault();
            return person;
        }
    }
}
