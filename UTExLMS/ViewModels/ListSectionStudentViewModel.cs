using System.Collections.ObjectModel;
using System.Windows.Input;
using UTExLMS.Models;
using UTExLMS.Service;
using UTExLMS.Commands;
using System.Windows;
using UTExLMS.ViewModels.UCViewModel;

namespace UTExLMS.ViewModels
{
    public class ListSectionStudentViewModel : ViewModelBase
    {
        public ICommand ElementSelectedCommand { get; set; }
        public ObservableCollection<SectionToggle> SectionToggles { get; set; }

        public ListSectionStudentViewModel(OverviewCourse overviewCourse)
        {
            SectionToggles = new ObservableCollection<SectionToggle>();
            LoadSectionsAndElements(overviewCourse);
            ElementSelectedCommand = new RelayCommand<ElementSection>(LoadElement);
        }

        private void LoadSectionsAndElements(OverviewCourse overviewCourse)
        {
            var sections = new ListSectionService().GetListSection(overviewCourse.IdCourse);

            foreach (var section in sections)
            {
                ObservableCollection<ElementSection> elements = new ListElementService().GetListElement(overviewCourse.IdCourse, section.IdSection, overviewCourse.IdPerson);

            

                    var sectionToggle = new SectionToggle
                    {
                        HeaderSections = section,
                        ElementSections = elements
                    };

                    SectionToggles.Add(sectionToggle);
                
            }
        }

            private void LoadElement(ElementSection elementInfor)
            {
                new ElementUCViewModel(elementInfor);
            }

    }

}
