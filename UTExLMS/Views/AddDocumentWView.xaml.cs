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
using System.Windows.Shapes;
using UTExLMS.ViewModels.UCViewModel;
using UTExLMS.Models;
using UTExLMS.ViewModels;

namespace UTExLMS.Views
{
    /// <summary>
    /// Interaction logic for AddDocumentWView.xaml
    /// </summary>
    public partial class AddDocumentWView : Window
    {
        public AddDocumentWView()
        {
            InitializeComponent();
        }
        public AddDocumentWView(Section section, SectionUCViewModel sectionUCViewModel)
        {
            InitializeComponent();
            AddDocumentWViewModel addDocumentWViewModel = new AddDocumentWViewModel(section, sectionUCViewModel);
            addDocumentWViewModel.closeAction = new Action(() => this.Close());
            this.DataContext = addDocumentWViewModel;
        }
    }
}
