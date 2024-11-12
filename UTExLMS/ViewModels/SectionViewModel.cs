using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTExLMS.Models;

namespace UTExLMS.ViewModels
{
    public class SectionViewModel
    {
        public string SectionTitle { get; set; }
        public string SectionDescription { get; set; }

        public ObservableCollection<TestLessonViewModel> LessonItems { get; set; }
        public bool IsExpanded { get; set; }
    }
}
