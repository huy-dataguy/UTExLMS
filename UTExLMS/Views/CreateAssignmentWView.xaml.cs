using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using UTExLMS.Models;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UTExLMS.ViewModels;

namespace UTExLMS.Views
{
    /// <summary>
    /// Interaction logic for CreateAssignmentWView.xaml
    /// </summary>
    public partial class CreateAssignmentWView : Window
    {
        public CreateAssignmentWView()
        {
            InitializeComponent();
        }
        public CreateAssignmentWView(Section section)
        {
            InitializeComponent();
            CreateAssignmentViewModel createAssignmentViewModel = new CreateAssignmentViewModel(section);
            createAssignmentViewModel.CloseAction = () => this.Close();
            this.DataContext = createAssignmentViewModel;

        }
    }
}
