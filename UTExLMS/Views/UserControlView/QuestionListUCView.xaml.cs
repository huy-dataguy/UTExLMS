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
using UTExLMS.ViewModels.UCViewModel;
using UTExLMS.Models;
using UTExLMS.ViewModels;
namespace UTExLMS.Views.UserControlView
{
    /// <summary>
    /// Interaction logic for QuestionListUCView.xaml
    /// </summary>
    public partial class QuestionListUCView : UserControl
    {
        public QuestionListUCView()
        {
            InitializeComponent();
            
        }
        public QuestionListUCView(Question question, ElementSection elemenInfor)
        {
            MessageBox.Show("OKOK");
            DataContext = new QuestionListUCViewModel(question, elemenInfor);
        }
    }
}
