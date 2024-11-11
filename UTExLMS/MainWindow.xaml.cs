using System.Text;
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
using UTExLMS.Views;

namespace UTExLMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModels.MainViewModel();
        }
        private void IconButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("HELOOO");
            IconContextMenu.PlacementTarget = IconButton; // Đặt vị trí hiển thị ngay dưới icon
            IconContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            IconContextMenu.HorizontalOffset = -50; // Điều chỉnh giá trị này theo nhu cầu của bạn
            IconContextMenu.IsOpen = true; // Mở ContextMenu
        }
        private void OpenProfile(object sender, RoutedEventArgs e)
        {
            ProfilePView profilePView = new ProfilePView();
            profilePView.Show();
        }
    }
}