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
        //public ObservableCollection<ElementPreview> GetElementPreviews(Section section)
        //{
        //    var elementPreviews = _addition.ElementPreviews
        //        .FromSqlRaw($"Select * from GetElementPreviews({section.IdSection},{section.IdCourse})").ToList();
        //    foreach (ElementPreview e in elementPreviews){
        //        string path = Environment.CurrentDirectory;
        //        string path1 = Directory.GetParent(path).Parent.Parent.FullName;

        //        e.Icon = Path.Combine(path1, "Assets", e.Icon + ".png");
        //        //MessageBox.Show(e.Icon);
        //    }
        //    return new ObservableCollection<ElementPreview>(elementPreviews);
        //}


        public ObservableCollection<ElementPreview> GetElementPreviews(Section section)
        {
            try
            {
                // Fetch data from the database using SQL query
                var elementPreviews = _addition.ElementPreviews
                    .FromSqlRaw($"Select * from GetElementPreviews({section.IdSection},{section.IdCourse})")
                    .ToList();

                // If data is null or empty, return an empty ObservableCollection
                if (elementPreviews == null || !elementPreviews.Any())
                {
                    return new ObservableCollection<ElementPreview>();
                }

                // Process each element preview and set the icon path
                foreach (ElementPreview e in elementPreviews)
                {
                    string path = Environment.CurrentDirectory;
                    string path1 = Directory.GetParent(path)?.Parent?.Parent?.FullName;

                    if (path1 != null)
                    {
                        e.Icon = Path.Combine(path1, "Assets", e.Icon + ".png");
                    }
                    else
                    {
                        // If path1 is null, handle the case (for example, set a default icon or log an error)
                        e.Icon = "default_icon.png";
                    }
                }

                // Return the processed list as an ObservableCollection
                return new ObservableCollection<ElementPreview>(elementPreviews);
            }
            catch (Exception ex)
            {
                // Log the exception or show a message if needed
                // Example: MessageBox.Show($"Error: {ex.Message}");

                // Return an empty ObservableCollection in case of error
                return new ObservableCollection<ElementPreview>();
            }
        }

    }
}
