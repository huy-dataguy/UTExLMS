using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UTExLMS.Models;
using UTExLMS.Views;


namespace UTExLMS.ViewModels
{
    public class ElementChosenWViewModel : ViewModelBase
    {
        private Section _section { get; set; }

        public Action CloseAction { get; set; }
        public ICommand CreateNewAssignment { get; set; }
        public ElementChosenWViewModel() { }
        public ElementChosenWViewModel(Section section)
        {
            _section = section;
            CreateNewAssignment = new RelayCommand(CreateAssignment);
        }
        private void CreateAssignment()
        {
            CreateAssignmentWView createAssignmentWView = new CreateAssignmentWView(_section);
            
            CloseAction();
            createAssignmentWView.Show();
        } 

        

        
    }
}
