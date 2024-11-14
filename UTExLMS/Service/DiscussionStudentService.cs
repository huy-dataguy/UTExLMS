  using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

using UTExLMS.Models;
namespace UTExLMS.Service
{
    public class DiscussionStudentService
    {
        public UTExLMSContext _context;

        public DiscussionStudentService() {
            _context = new UTExLMSContext();
        }


        public Discussion GetDiscussion(int idCourse, int idSection, int idElement)
        {
            var discuss = _context.Discussions
                .FromSqlRaw($"SELECT * FROM GetDiscussion({idCourse}, {idSection}, {idElement})")
                .FirstOrDefault();
            return discuss;
        }


        public ObservableCollection<Comment> GetAllComment(int idCourse, int idSection, int idDiscussion)
        {
            var comments = new ObservableCollection<Comment>(_context.Comments
                .FromSqlRaw($"SELECT * FROM GetAllComment({idCourse}, {idSection}, {idDiscussion})")
                 .Include(p => p.IdPersonNavigation)
                 .ToList());
            return comments;
        }

        public void AddNewComment(int idCourse, int idSection, int idDiscussion, int idPerson, string commentContent, DateTime date)
        {
            var newCommentId = _context.Database.ExecuteSqlRaw(
            "EXEC CreateNewComment @p0, @p1, @p2, @p3, @p4, @p5",
            commentContent, date, idCourse, idSection, idDiscussion, idPerson);

        }

    }
}
