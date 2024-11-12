using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;
using UTExLMS.Models;

namespace UTExLMS.Service
{
    internal class TestService
    {
        private Addition _addition { get; set; }
        public TestService()
        {
            _addition = new Addition();
        }
        public void AddTest(int idTest, string nameTest, int statu, DateTime startDate, DateTime endDate, int timeLimit, string descript, int idSection, int idCourse)
        {
            _addition.Database.ExecuteSqlRaw($"exec AddTest " +
                $"@idTest = {idTest}," +
                $"@nameTest = '{nameTest}', " +
                $"@statu = {statu}, " +
                $"@startDate = '{startDate}', " +
                $"@endDate = '{endDate}', " +
                $"@timeLimit = {timeLimit}, " +
                $"@descript = '{descript}', " +
                $"@idSection = {idSection}, " +
                $"@idCourse = {idCourse}");
        }
        public void UpdateTest(int idTest, string nameTest, int statu, DateTime startDate, DateTime endDate, int timeLimit, string descript, int idSection, int idCourse)
        {
            _addition.Database.ExecuteSqlRaw($"exec UpdateTest " +
                $"@idTest = {idTest}, " +
                $"@nameTest = '{nameTest}', " +
                $"@statu = {statu}, " +
                $"@startDate = '{startDate}', " +
                $"@endDate = '{endDate}', " +
                $"@timeLimit = {timeLimit}, " +
                $"@descript = '{descript}', " +
                $"@idSection = {idSection}, " +
                $"@idCourse = {idCourse}");
        }

        public void UpdateTest(Test test)
        {
            UpdateTest(
                test.IdTest,
                test.NameTest,
                test.Statu.HasValue && test.Statu.Value ? 1 : 0,
                test.StartDate.HasValue ? test.StartDate.Value : DateTime.Now,
                test.EndDate.HasValue ? test.EndDate.Value : DateTime.Now,
                test.TimeLimit.HasValue ? test.TimeLimit.Value : 0,
                test.Descript,
                test.IdSection,
                test.IdCourse
            );
        }

        public Test CreateTempTest(Section section)
        {
            Test temp = new Test();
            temp.IdCourse = section.IdCourse;
            temp.IdSection = section.IdSection;
            temp.NameTest = "Temp";
            temp.Statu = false;
            temp.StartDate = DateTime.Now;
            temp.EndDate = DateTime.Now;
            temp.TimeLimit = 100;
            temp.Descript = "Temp";
            temp.IdTest = GetMaxIdTest(section);
            return temp;
        }
        public int GetMaxIdTest(Section section)
        {
            var maxIdTest = _addition.Elements
                            .Where(t => t.IdCourse == section.IdCourse)
                            .Select(t => t.IdElement)
                            .AsEnumerable()
                            .DefaultIfEmpty(0)
                            .Max();
            return maxIdTest + 1;
        }
    }
}
