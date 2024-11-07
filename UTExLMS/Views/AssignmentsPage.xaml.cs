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
using System.Windows.Shapes;
using UTExLMS.ViewModels;
namespace UTExLMS.Views
{
    public partial class AssignmentsPage : Window
    {
        public AssignmentsPage()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DataGrid dataGrid && dataGrid.SelectedItem is UTExLMS.ViewModels.AssignmentsViewModel selectedAssignment)
            {
                // Display the assignment name and score in a message box
                //MessageBox.Show($"Tên bài tập: {selectedAssignment.Name}\nĐiểm: {selectedAssignment.Score}", "Assignment Details");
            }
        }
    }
}
