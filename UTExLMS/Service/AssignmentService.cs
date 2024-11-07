using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTExLMS.Models;

namespace UTExLMS.Service
{
    class AssignmentService
    {
        private Addition _additon;
        public AssignmentService()
        {
            _additon = new Addition();
        }
        public void CreateAssignment(int idSection, int idCourse, string nameAssign, string descript, DateTime startDate, DateTime endDate)
        {
            // Tạo parameters để truyền vào thủ tục
            var parameters = new[]
            {
        new SqlParameter("@nameAssign", SqlDbType.VarChar) { Value = nameAssign },
        new SqlParameter("@statu", SqlDbType.Bit) { Value = 0 },  // Giá trị mặc định là 0
        new SqlParameter("@startDate", SqlDbType.Date) { Value = startDate },
        new SqlParameter("@endDate", SqlDbType.Date) { Value = endDate },
        new SqlParameter("@descript", SqlDbType.VarChar) { Value = descript },
        new SqlParameter("@grade", SqlDbType.Float) { Value = 0 },  // Giá trị mặc định là 0
        new SqlParameter("@idSection", SqlDbType.Int) { Value = idSection },
        new SqlParameter("@idCourse", SqlDbType.Int) { Value = idCourse }
    };

            // Thực thi thủ tục
            _additon.Database.ExecuteSqlRaw("EXEC AddAssignment @nameAssign, @statu, @startDate, @endDate, @descript, @grade, @idSection, @idCourse", parameters);
        }

    }
}
