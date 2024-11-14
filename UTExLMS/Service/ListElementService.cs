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

        public ObservableCollection<ElementSection> GetListElement(int idCourse, int idSection, int idStudent)
        {
            var tmplistElements = new ObservableCollection<ElementSection>(
                _context.ElementSections.FromSqlRaw($"Select * from GetElementsByCourseAndSection({idCourse}, {idSection}, {idStudent})").ToList()
            );


            //var listElements = new ObservableCollection<ElementSection>();


            //foreach (var item in tmplistElements)
            //{
            //    listElements.Add(new ElementSection
            //    {
            //        IdElement = item.IdElement,
            //        ElementName = item.ElementName,
            //        NameType = item.NameType,
            //        section = new Section(idCourse, idSection, null, null),
            //    });
            //}

            return tmplistElements;
        }

    }
}
