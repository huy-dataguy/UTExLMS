using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTExLMS.Models;

namespace UTExLMS.ViewModels
{
    public class TestStudentViewModel : ViewModelBase
    {
        private readonly TestStudent _testStudent;

        public int ID => _testStudent.ID;
        public string Name => _testStudent.Name;
        public string Crush => _testStudent.Crush;

        public TestStudentViewModel(TestStudent testStudent)
        {
            _testStudent = testStudent;
        }
    }
}
