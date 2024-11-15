using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UTExLMS.Models;
using UTExLMS.ViewModels.UCViewModel;

using UTExLMS.Views;


namespace UTExLMS.ViewModels
{
    public class ElementChosenWViewModel : ViewModelBase
    {
        private Section _section { get; set; }

        public Action CloseAction { get; set; }
        public ICommand CreateNewAssignment { get; set; }

        public ICommand AddFile { get; set; }

        public ICommand AddTest { get; set; }


        private SectionUCViewModel _sectionUCViewModel { get; set; }
        public ElementChosenWViewModel() { }
        public ElementChosenWViewModel(Section section, SectionUCViewModel sectionUCViewModel)
        {
            _section = section;
            CreateNewAssignment = new RelayCommand(CreateAssignment);
            AddFile = new RelayCommand(AddNewFile);
            AddTest = new RelayCommand(AddNewTest);
            _sectionUCViewModel = sectionUCViewModel;
        }
        private void CreateAssignment()
        {
            CreateAssignmentWView createAssignmentWView = new CreateAssignmentWView(_section, _sectionUCViewModel);

            CloseAction();
            createAssignmentWView.Show();
        }
        private void AddNewFile()
        {
            AddDocumentWView addDocumentWView = new AddDocumentWView(_section, _sectionUCViewModel);
            addDocumentWView.Show();
            CloseAction();
        }

        private void AddNewTest()
        {
            AddTestWView addTestWView = new AddTestWView(_section, _sectionUCViewModel);
            addTestWView.Show();
            CloseAction();
        }


    }
}