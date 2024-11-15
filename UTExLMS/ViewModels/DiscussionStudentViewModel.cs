using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTExLMS.Models;
using UTExLMS.Service;
using UTExLMS.Commands;
using System.Windows.Input;
using UTExLMS.Views;
using UTExLMS.ViewModels;
namespace UTExLMS.ViewModels
{
    public class DiscussionStudentViewModel :ViewModelBase
    {
        public Discussion Discussion { get; set; }
        public ICommand AddComment { get; set; }
        public ObservableCollection<Comment> Comments { get; set; }
        public DiscussionStudentViewModel(ElementSection elementInfor)
        {

            Discussion = new DiscussionStudentService().GetDiscussion(elementInfor.IdCourse, elementInfor.IdSection, elementInfor.IdElement);
            Comments = new DiscussionStudentService().GetAllComment(elementInfor.IdCourse, elementInfor.IdSection, Discussion.IdDiscuss);

            AddComment = new RelayCommand(_ => OpenNewComment(elementInfor.IdStudent, Discussion) );

        } 

        private void OpenNewComment(int idStudent, Discussion discussion)
        {
            //new CommentWView(idStudent, discussion).Show();

            var commentViewModel = new CommentViewModel(idStudent, discussion);
            commentViewModel.CommentPosted += OnCommentPosted;

            new CommentWView(commentViewModel).Show();
        }


        private void OnCommentPosted()
        {
            Comments = new DiscussionStudentService().GetAllComment(Discussion.IdCourse, Discussion.IdSection, Discussion.IdDiscuss);
            OnPropertyChanged(nameof(Comments));
        }
    }
}


