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
    /// Interaction logic for CommentWView.xaml
    /// </summary>
    public partial class CommentWView : Window
    {
        //public CommentWView(int idStudent, Discussion discussion)
        //{
        //    InitializeComponent();
        //    var viewModel = new CommentViewModel(idStudent, discussion);
        //    DataContext = viewModel;

        //    viewModel.CommentPosted += () => this.Close();

        //}
        public CommentWView(CommentViewModel commentViewModel)
        {
            InitializeComponent();

            DataContext = commentViewModel;

            commentViewModel.CommentPosted += () => this.Close();
        }
    }
}

