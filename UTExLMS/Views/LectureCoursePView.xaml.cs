﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UTExLMS.Models;
using UTExLMS.ViewModels;

namespace UTExLMS.Views
{
    /// <summary>
    /// Interaction logic for LectureCoursePView.xaml
    /// </summary>
    public partial class LectureCoursePView : Page
    {
        public LectureCoursePView()
        {
            InitializeComponent();
        }
        public LectureCoursePView(OverviewLectureCourse overviewCourse)
        {
            InitializeComponent();
            DataContext = new LectureCourseViewModel(overviewCourse);
        }
    }
}
