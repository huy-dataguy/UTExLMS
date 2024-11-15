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
using UTExLMS.ViewModels;
using UTExLMS.ViewModels.UCViewModel;

using UTExLMS.Models;

namespace UTExLMS.Views
{
    /// <summary>
    /// Interaction logic for ElementChosenWView.xaml
    /// </summary>
    public partial class ElementChosenWView : Window
    {
        public ElementChosenWView()
        {
            InitializeComponent();
        }
        public ElementChosenWView(Section section, SectionUCViewModel sectionUCViewModel)
        {
            InitializeComponent();
            ElementChosenWViewModel elementViewModel = new ElementChosenWViewModel(section, sectionUCViewModel);
            elementViewModel.CloseAction = () => this.Close();
            this.DataContext = elementViewModel;
            
        }
    }
}
