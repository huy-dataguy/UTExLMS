using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UTExLMS.Models;

namespace UTExLMS.Service
{
    internal class QuestionService
    {
        private Addition _addition { get; set; }
        public QuestionService()
        {
            _addition = new Addition();
        }
        public void AddQuestion(string nameQues, string A, string B, string C, string D, string trueAns, int idTest, int idCourse, int idSection)
        {
            
            _addition.Database.ExecuteSqlRaw($"exec [dbo].[AddQuestion] " +
                $"@nameQues = '{nameQues}', " +
                $"@A = '{A}', " +
                $"@B = '{B}', " +
                $"@C = '{C}', " +
                $"@D = '{D}', " +
                $"@trueAns = '{trueAns}', " +
                $"@idTest = {idTest}, " +
                $"@idCourse = {idCourse}, " +
                $"@idSection = {idSection}");
        }

        public ObservableCollection<Question> GetQuestions(int idTest, int idSection, int idCourse)
        {
            
            var questions = _addition.Questions.FromSqlRaw($"select * from GetQuestions({idTest},{idCourse},{idSection})").ToList();
            return new ObservableCollection<Question>(questions);
        }
        public ObservableCollection<Result> GetResults(int idStudent,int idCourse, int idSection, int idTest)
        {

            var results = _addition.Results.FromSqlRaw($"select * from GetStudentAns({idStudent},{idCourse},{idSection},{idTest})").ToList();
            return new ObservableCollection<Result>(results);
        }

        public void AddStudentAnswer(string ans, int idStudent, int idCourse, int idSection, int idTest, int idQues)
        {
            _addition.Database.ExecuteSqlRaw($"exec AddStudentAnswer " +
            $"@ans = '{ans}', " +
            $"@idStudent = {idStudent}, " +
            $"@idCourse = {idCourse}, " +
            $"@idSection = {idSection},"+
            $"@idTest = {idTest}, " +
            $"@idQues= {idQues}");

        }

     

        public void UpdateQuestion(int idQues, string nameQues, string A, string B, string C, string D, string trueAns, int idTest, int idCourse, int idSection)
        {
            _addition.Database.ExecuteSqlRaw($"exec UpdateQuestion " +
                $"@idQues = {idQues}, " +
                $"@nameQues = '{nameQues}', " +
                $"@A = '{A}', " +
                $"@B = '{B}', " +
                $"@C = '{C}', " +
                $"@D = '{D}', " +
                $"@trueAns = '{trueAns}', " +
                $"@idTest = {idTest}, " +
                $"@idCourse = {idCourse}, " +
                $"@idSection = {idSection}");
        }
    }
}
