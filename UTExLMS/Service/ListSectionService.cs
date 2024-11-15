using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTExLMS.Models;

namespace UTExLMS.Service
{
    public class ListSectionService
    {
        private readonly UTExLMSContext _context;



        public ListSectionService()
        {
            _context = new UTExLMSContext();
        }

        public ObservableCollection<Section> GetListSection(int idCourse)
        {
            var listSection = new ObservableCollection<Section>(
        _context.Sections.FromSqlRaw($"SELECT * FROM GetSectionsByCourse({idCourse})").ToList()
    );

            return listSection;
        }

    }
}
