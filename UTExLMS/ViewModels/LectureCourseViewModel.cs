using CommunityToolkit.Mvvm.Input;
using HandyControl.Tools.Extension;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UTExLMS.Models;
using UTExLMS.Service;
using UTExLMS.Views;

namespace UTExLMS.ViewModels
{
    class LectureCourseViewModel: ViewModelBase
    {
        private OverviewCourse _overviewCourse  { get; set; }

        public ObservableCollection<Section> Sections { get; set; }



        public ICommand AddSection { get; set; }

        

        public LectureCourseViewModel() { }

        public int idCourse = 1;
        public LectureCourseViewModel(OverviewCourse overviewCourse)
        {
            AddSection = new RelayCommand(AddNewSection);
            SectionService sectionService = new SectionService();
            Sections = sectionService.GetSections(idCourse) ;
            OnPropertyChanged(nameof(Sections));
        }

        
        private void AddNewSection()
        {
            SectionService sectionService = new SectionService();
            sectionService.AddNewSection(idCourse);
            Sections = sectionService.GetSections(idCourse);
            OnPropertyChanged(nameof(Sections));
        }
    }
}
