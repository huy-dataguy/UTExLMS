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

        private int _id = 1;
        public ObservableCollection<AssignmentStudent> Assignments { get; private set; }

        public AssignmentsViewModel()
        {
            AssignmentService assignmentService = new AssignmentService();
            Assignments = assignmentService.GetAssignmentStudents(101, 1001, 1, 1);
        }
    }

}

