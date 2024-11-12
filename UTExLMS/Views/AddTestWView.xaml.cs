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
using UTExLMS.Views.UserControlView;
using UTExLMS.Models;
using UTExLMS.Service;

namespace UTExLMS.Views
{
    /// <summary>
    /// Interaction logic for AddTestWView.xaml
    /// </summary>
    public partial class AddTestWView : Window
    {
        public AddTestWView()
        {
            InitializeComponent();
        }
        public AddTestWView(Section section, SectionUCViewModel sectionUCViewModel)
        {
            InitializeComponent();
            TestService testService = new TestService();
            Test temp = testService.CreateTempTest(section);
            testService.AddTest
            (
                temp.IdTest,
                temp.NameTest,
                temp.Statu.HasValue ? (temp.Statu.Value ? 1 : 0) : 0,
                temp.StartDate ?? DateTime.Now,
                temp.EndDate ?? DateTime.Now,
                temp.TimeLimit ?? 0,
                temp.Descript,
                temp.IdSection,
                temp.IdCourse
            );
            AddTestWViewModel addTestWViewModel = new AddTestWViewModel(sectionUCViewModel,temp);
            addTestWViewModel.closeAction = new Action(() => this.Close());
            this.DataContext = addTestWViewModel;
        }
    }
}
