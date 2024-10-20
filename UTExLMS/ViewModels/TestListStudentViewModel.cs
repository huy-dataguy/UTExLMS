using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UTExLMS.Models;
using UTExLMS.Commands;

namespace UTExLMS.ViewModels
{
    public class TestListStudentViewModel : ViewModelBase
    {
        private readonly ObservableCollection<TestStudentViewModel> _student;

        public IEnumerable<TestStudentViewModel> Student => _student;
        public ICommand SubmitBtn { get; }

        public TestListStudentViewModel()
        {
            _student = new ObservableCollection<TestStudentViewModel>();

            _student.Add(new TestStudentViewModel(new TestStudent(1, "Huy", "Duyen Duyen")));
            _student.Add(new TestStudentViewModel(new TestStudent(1, "Huy", "Na Na")));
            _student.Add(new TestStudentViewModel(new TestStudent(1, "Huy", "Ni Ni")));
            SubmitBtn = new TestButtonCommand();
        }





    }
}
