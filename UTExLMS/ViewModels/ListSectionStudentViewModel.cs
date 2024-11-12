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

        public ListSectionStudentViewModel()
        {
            SectionToggles = new ObservableCollection<SectionToggle>();
            LoadSectionsAndElements();
            ElementSelectedCommand = new RelayCommand<int>(new ElementUCViewModel().ShowTestt);
        }

        private void LoadSectionsAndElements()
        {
            var sections = new ListSectionService().GetListSection(1);

            foreach (var section in sections)
            {
                var elements = new ListElementService().GetListElement(1, section.IdSection);

                var sectionToggle = new SectionToggle
                {
                    HeaderSections = section,
                    ElementSections = elements
                };

                SectionToggles.Add(sectionToggle);
            }
        }
   

    }
}
