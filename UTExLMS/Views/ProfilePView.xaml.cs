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
using UTExLMS.Models;
using UTExLMS.ViewModels;


namespace UTExLMS.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class ProfilePView : Window
    {
        public ProfilePView(Person person)
        {
            InitializeComponent();
            UTExLMSContext context = new UTExLMSContext();
            this.DataContext = new ProfileLecturerViewModel(person);

        }
        //public ProfilePView(MainViewModel mainViewModel)
        //{
        //    InitializeComponent();
        //    this.DataContext = ProfileLecturerViewModel(mainViewModel);
        //}


    }
}
