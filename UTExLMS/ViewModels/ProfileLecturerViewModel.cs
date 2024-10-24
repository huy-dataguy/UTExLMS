using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows.Input;
using UTExLMS.Models;
using UTExLMS.Models;
using UTExLMS.Commands;
using System.Windows;

namespace UTExLMS.ViewModels
{
    public class ProfileLecturerViewModel : ViewModelBase
    {
        public Lecturer Profile { get; set; }
        private readonly UTExLMSContext _context;

        // ICommand để thực thi cập nhật hồ sơ
        public ICommand SaveProfile { get; set; }
        public ProfileLecturerViewModel() { }
        public ProfileLecturerViewModel(UTExLMSContext context)
        {
            _context = context;
            Profile = LoadProfile();

            SaveProfile = new RelayCommand(ExecuteSaveProfile, CanExecuteSaveProfile);
        }

        // Tải thông tin giảng viên từ cơ sở dữ liệu
        private Lecturer LoadProfile()
        {
            var idLecturer = 1; // Thay đổi ID theo yêu cầu

            // Lấy thông tin giảng viên
            Lecturer profile = _context.Lecturers
                    .Where(c => c.IdLecturer == idLecturer)
                    .FirstOrDefault();

            return profile;
        }

        public void UpdateLecturer(Lecturer lecturer)
        {
            _context.Database.ExecuteSqlRaw(
                "EXEC UpdateLecturerInfo @IdLecturer, @FirstName, @LastName, @Email, @Birthday, @Gender, @PhoneNum, @Password",
                new SqlParameter("IdLecturer", lecturer.IdLecturer),
                new SqlParameter("FirstName", lecturer.FirstName),
                new SqlParameter("LastName", lecturer.LastName),
                new SqlParameter("Email", lecturer.Email),
                new SqlParameter("Birthday", lecturer.Birthday),
                new SqlParameter("Gender", lecturer.Gender),
                new SqlParameter("PhoneNum", lecturer.PhoneNum),
                new SqlParameter("Password", lecturer.Password) 
            );
            MessageBox.Show("Save success!!!");
        }

        private void ExecuteSaveProfile(object parameter)
        {
            if (Profile != null)
            {
                UpdateLecturer(Profile);
            }
        }

        // Kiểm tra điều kiện thực thi lệnh SaveProfile
        private bool CanExecuteSaveProfile(object parameter)
        {
            return Profile != null; // Chỉ thực thi nếu có thông tin Profile
        }
    }
}
