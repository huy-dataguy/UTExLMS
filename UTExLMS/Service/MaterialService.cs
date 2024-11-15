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
        private UTExLMSContext _context { get; set; }
        public MaterialService()
        {
            _context = new UTExLMSContext();
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

            _context.Database.ExecuteSqlRaw(sql, parameters);
        }

        public Material GetDocument(int idCourse, int idSection, int idElement)
        {
            var document = _context.Materials
                .FromSqlRaw("SELECT * FROM GetMaterialByElement({0}, {1}, {2})", idCourse, idSection, idElement)
                .FirstOrDefault();

            return document;
        }

    }
}
