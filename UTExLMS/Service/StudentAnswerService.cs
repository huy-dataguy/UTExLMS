using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTExLMS.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace UTExLMS.Service
{
    class StudentAnswerService
    {
        private readonly Addition _addition;

        public StudentAnswerService()
        {
            _addition = new Addition();
        }

        public void AddStudentAnswer(string ans, int idStudent, int idCourse, int idSection, int idTest, int idQues)
        {
            var parameters = new[]
            {
                new SqlParameter("@ans", SqlDbType.VarChar) { Value = ans },
                new SqlParameter("@idStudent", SqlDbType.Int) { Value = idStudent },
                new SqlParameter("@idCourse", SqlDbType.Int) { Value = idCourse },
                new SqlParameter("@idSection", SqlDbType.Int) { Value = idSection },
                new SqlParameter("@idTest", SqlDbType.Int) { Value = idTest },
                new SqlParameter("@idQues", SqlDbType.Int) { Value = idQues }
            };

            _addition.Database.ExecuteSqlRaw("EXEC AddStudentAnswer @ans, @idStudent, @idCourse, @idSection, @idTest, @idQues", parameters);
        }
    }
}
