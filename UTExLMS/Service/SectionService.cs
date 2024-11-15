using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTExLMS.Models;

namespace UTExLMS.Service
{
    internal class SectionService
    {
        private Addition _addition;
        public SectionService()
        {
            _addition = new Addition();
        }
        public ObservableCollection<Section> GetSections(int idCourse)
        {
            var sections = _addition.Sections
            .Where(s => s.IdCourse == idCourse)
            .ToList();

            return new ObservableCollection<Section>(sections);
        }

        public void AddNewSection(int idCourse)
        {
            _addition.Database.ExecuteSqlRaw($"EXEC AddNewSection @idCourse = {idCourse}");
        }
        public void UpdateSection(int idCourse, int idSection, string nameSection, string descript)
        {
       
            _addition.Database.ExecuteSqlRaw($"EXEC UpdateSection " +
                $"@idCourse={idCourse}, " +
                $"@idSection = {idSection}, " +
                $"@nameSection ='{nameSection}', " +
                $"@descript = '{descript}'");
        }
        
    }
}
