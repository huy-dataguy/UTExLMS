using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UTExLMS.Models;
using UTExLMS.Service;
using UTExLMS.ViewModels.UCViewModel;


namespace UTExLMS.ViewModels
{
    public class CreateAssignmentViewModel: ViewModelBase
    {
        private Section _section { get; set; }

        public Action CloseAction {  get; set; }
        private string _assignName;
        
        public string AssignName
        {
            get => _assignName;
            set => _assignName = value;
        }

        private string _descript;
        public string Descript
        {
            get => _descript;
            set => _descript = value;   
        }

        private DateTime _startDate;
        public DateTime StartDate
        {
            get => _startDate;
            set => _startDate = value;
        }
        
        private DateTime _endDate;

        public DateTime EndDate
        {
            get =>_endDate; 
            set => _endDate = value;
        }

        private SectionUCViewModel _sectionUCViewModel { get; set; }

        public ICommand CreateAssignment {  get; set; } 
        public CreateAssignmentViewModel() { }

        public CreateAssignmentViewModel(Section section, SectionUCViewModel sectionUCViewModel)
        {
            _section = section;
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            CreateAssignment = new RelayCommand(CreateNewAssignment);
            _sectionUCViewModel = sectionUCViewModel;
        } 
        public void CreateNewAssignment()
        {
            AssignmentService assignmentService = new AssignmentService();
            assignmentService.CreateAssignment(_section.IdSection,_section.IdCourse,_assignName,_descript,_startDate, _endDate);
            MessageBox.Show("Create assignment sucessful");
            _sectionUCViewModel.UpdateElementList();
            CloseAction();
        }

    }
}
