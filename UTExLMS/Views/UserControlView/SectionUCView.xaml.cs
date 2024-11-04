using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UTExLMS.ViewModels.UCViewModel;
using UTExLMS.Models;


namespace UTExLMS.Views.UserControlView
{
    /// <summary>
    /// Interaction logic for SectionUCView.xaml
    /// </summary>
    public partial class SectionUCView : UserControl
    {
        public SectionUCView()
        {
            InitializeComponent();
            //this.DataContext = new SectionUCViewModel();
        }
        public SectionUCView(Section section)
        {
            MessageBox.Show("OKOK");
            this.DataContext = new SectionUCViewModel(section);
        }
    }
}
