using System;
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

namespace UTExLMS.Views.UserControlView
{
    /// <summary>
    /// Interaction logic for CourseCardUCView.xaml
    /// </summary>
    public partial class CourseCardUCView : UserControl
    {
        public CourseCardUCView()
        {
            InitializeComponent();
            //UTExLMSContext context = new UTExLMSContext();
            ////this.DataContext = new ViewModels.StudentClassViewModel(context);

        }
    }
}
