using System;
using System.Windows;
using System.Windows.Controls;

namespace UTExLMS.Views
{
    /// <summary>
    /// Interaction logic for DropdownMenuView.xaml
    /// </summary>
    public partial class DropdownMenuView : Window
    {
        public DropdownMenuView()
        {
            InitializeComponent();
        }

        private void IconButton_Click(object sender, RoutedEventArgs e)
        {
            IconContextMenu.PlacementTarget = IconButton; // Đặt vị trí hiển thị ngay dưới icon
            IconContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            IconContextMenu.HorizontalOffset = -50; // Điều chỉnh giá trị này theo nhu cầu của bạn
            IconContextMenu.IsOpen = true; // Mở ContextMenu
        }
    }
}
