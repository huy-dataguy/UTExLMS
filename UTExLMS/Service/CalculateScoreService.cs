using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UTExLMS.Models;
namespace UTExLMS.Service
{
    class CalculateScoreService
    {
        private Addition _addition;
        public CalculateScoreService()
        {
            _addition = new Addition();
        }
        public void CalculateScore(int idStudent, int idCourse, int idSection, int idTest)
        {
            var parameters = new[]
{
                new SqlParameter("@idStudent", SqlDbType.Int) { Value = idStudent },
                new SqlParameter("@idCourse", SqlDbType.Int) { Value = idCourse },
                new SqlParameter("@idSection", SqlDbType.Int) { Value = idSection },
                new SqlParameter("@idTest", SqlDbType.Int) { Value = idTest }
            };

            _addition.Database.ExecuteSqlRaw("EXEC CalculateStudentScore  @idStudent, @idCourse, @idSection, @idTest", parameters);
            MessageBox.Show("Nộp bài thành công ");
        }
            public int GetStudentScore(int idStudent, int idCourse, int idSection, int idTest)
            {
                var parameters = new[]
                {
            new SqlParameter("@IdStudent", idStudent),
            new SqlParameter("@IdCourse", idCourse),
            new SqlParameter("@IdSection", idSection),
            new SqlParameter("@IdTest", idTest)
        };

                var result = _addition.StudentScoreResults
                    .FromSqlRaw("SELECT Score = dbo.GetStudentScore(@IdStudent, @IdCourse, @IdSection, @IdTest)", parameters)
                    .AsEnumerable()
                    .FirstOrDefault();

                return result?.score ?? 0; // Trả về 0 nếu không có kết quả
            }
    }

}
