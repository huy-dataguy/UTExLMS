using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UTExLMS.Models;
using UTExLMS.Service;
using UTExLMS.Commands;
using System.Windows;
using UTExLMS.ViewModels;

namespace UTExLMS.ViewModels
{
    public class CommentViewModel : ViewModelBase
    {
        public ICommand Post { get; set; }
        public string CommentContent {get; set ;}
        public event Action CommentPosted;


        public CommentViewModel(int idStudent, Discussion discussion) 
        {
           

            Post = new Commands.RelayCommand(_ => createComment(idStudent, discussion, CommentContent));

        }

        public void createComment(int idStudent, Discussion discussion, string commentContent)
        {
            new DiscussionStudentService().AddNewComment(discussion.IdCourse, discussion.IdSection, discussion.IdDiscuss, idStudent, commentContent, DateTime.Now);
            MessageBox.Show("Đăng thảo luận thành công");
            CommentPosted?.Invoke();


        }
    }
}


