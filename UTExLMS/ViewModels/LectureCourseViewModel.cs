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
using UTExLMS.ViewModels.UCViewModel;
using UTExLMS.Views;

namespace UTExLMS.ViewModels
{
    class LectureCourseViewModel : ViewModelBase
    {
        private OverviewLectureCourse _overviewCourse { get; set; }

        public ObservableCollection<Section> Sections { get; set; }

        public ObservableCollection<SectionUCViewModel>SectionUCs {get; set;}

        public ICommand AddSection { get; set; }

        

        public LectureCourseViewModel() { }

        public int idCourse = 1;
        public LectureCourseViewModel(OverviewLectureCourse overviewCourse)
        {
            AddSection = new RelayCommand(AddNewSection);
            SectionService sectionService = new SectionService();
            Sections = sectionService.GetSections(idCourse);
            UpdateSections();

        }

        public void UpdateSections()
        {
            SectionUCs = new ObservableCollection<SectionUCViewModel>();
            foreach (Section section in Sections)
            {
                SectionUCs.Add(new SectionUCViewModel(section));
            }
            OnPropertyChanged(nameof(SectionUCs));
        }

        private void AddNewSection()
        {
            SectionService sectionService = new SectionService();
            sectionService.AddNewSection(idCourse);
            Sections = sectionService.GetSections(idCourse);
            UpdateSections();

            
        }

    }
}
