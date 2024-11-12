using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTExLMS.Models;

namespace UTExLMS.Service
{
    public class ListElementService
    {
        private readonly Addition _context;
        public ListElementService()
        {
            _context = new Addition();

        }

        public ObservableCollection<ElementSection> GetListElement(int idCourse, int idSection)
        {
            var listElements = new ObservableCollection<ElementSection>(
                _context.ElementSections.FromSqlRaw($"Select * from GetElementsByCourseAndSection({idCourse}, {idSection})").ToList()
            );
            return listElements;
        }

    }
}
