using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UTExLMS.Models;

namespace UTExLMS.Service
{
    public class ElementPreviewService
    {
        private Addition _addition { get; set; }   
        
        public ElementPreviewService()
        {
            _addition = new Addition();
        }
        public ObservableCollection<ElementPreview> GetElementPreviews(Section section)
        {
            var elementPreviews = _addition.ElementPreviews
                .FromSqlRaw($"Select * from GetElementPreviews({section.IdSection},{section.IdCourse})").ToList();
            foreach (ElementPreview e in elementPreviews){
                string path = Environment.CurrentDirectory;
                string path1 = Directory.GetParent(path).Parent.Parent.FullName;
                
                e.Icon = Path.Combine(path1, "Assets", e.Icon + ".png");
                //MessageBox.Show(e.Icon);
            }
            return new ObservableCollection<ElementPreview>(elementPreviews);
        }
    }
}
