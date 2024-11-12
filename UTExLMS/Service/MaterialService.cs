using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTExLMS.Models;

namespace UTExLMS.Service
{
    internal class MaterialService
    {
        private Addition _addition { get; set; }
        public MaterialService()
        {
            _addition = new Addition();
        }
        public void AddNewDocument(string filePath, bool statu, string nameMaterial, string typeMaterial, int idSection, int idCourse)
        {
            var sql = "EXEC AddFile @FilePath, @Statu, @NameMaterial, @TypeMaterial, @IdSection, @IdCourse";
            var parameters = new[]
            {
                new SqlParameter("@FilePath", filePath),
                new SqlParameter("@Statu", statu),
                new SqlParameter("@NameMaterial", nameMaterial),
                new SqlParameter("@TypeMaterial", typeMaterial),
                new SqlParameter("@IdSection", idSection),
                new SqlParameter("@IdCourse", idCourse)
            };

            _addition.Database.ExecuteSqlRaw(sql, parameters);
        }
    }
}
