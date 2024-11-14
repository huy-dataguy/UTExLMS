using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using UTExLMS.Models;
using UTExLMS.Service;

namespace UTExLMS.ViewModels
{
    public class AssignmentsViewModel: ViewModelBase
    {
        private readonly UTExLMSContext _context;

        private AssignmentStudentService _assignment;
        private int _id = 1;
        public ObservableCollection<AssignmentStudent> Assignments { get; private set; }
        public AssignmentsViewModel(UTExLMSContext context)
        {
            //_context = context;
            //UpdateAssignment();
        }
        //private void UpdateAssignment()  
        //{
        //    _assignment = new AssignmentStudentService(_context, _id);
        //    Assignments = new ObservableCollection<AssignmentStudent>(_assignment.AssignmentStudent);
        //    //OnPropertyChanged(nameof(StudentClasses));
        //}
    }

}

//private void UpdateStudentClasses()
//{
//    _studentClasses = new StudentClassService(_context, _id, SelectedFilter, SearchTerm);
//    StudentClasses = new ObservableCollection<OverviewClass>(_studentClasses.OverviewClasses);
//    OnPropertyChanged(nameof(StudentClasses));
//}