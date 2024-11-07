using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows.Input;
using UTExLMS.Models;
using UTExLMS.Commands;
using System.Windows;

namespace UTExLMS.ViewModels
{
    public class ProfileLecturerViewModel : ViewModelBase
    {
        public Lecturer Profile { get; set; }

        private MainViewModel _mainViewModel {  get; set; }

        // ICommand to execute profile updates
        public ICommand SaveProfile { get; set; }

        public ProfileLecturerViewModel() { }

        public ProfileLecturerViewModel(MainViewModel mainViewModel)
        {
            //Profile = LoadProfile();
           // MessageBox.Show( Profile.Email);
           _mainViewModel = mainViewModel;
            //SaveProfile = new RelayCommand(ExecuteSaveProfile, CanExecuteSaveProfile);
        }

        // Load lecturer information from the database
        //private Lecturer LoadProfile()
        //{
        //    var idLecturer = 2; // Change the ID as needed

        //    // Retrieve lecturer information
        //    Lecturer profile = _context.Lecturers
        //            .Where(c => c.IdLecturer == idLecturer)
        //            .FirstOrDefault();

        //    return profile;
        //}

        //public void UpdateLecturer(Lecturer lecturer)
        //{
        //    _context.Database.ExecuteSqlRaw(
        //        "EXEC UpdateLecturerInfo @IdLecturer, @FirstName, @LastName, @Email, @Birthday, @Gender, @PhoneNum, @Pass",
        //        new SqlParameter("IdLecturer", lecturer.IdLecturer),
        //        new SqlParameter("FirstName", lecturer.FirstName),
        //        new SqlParameter("LastName", lecturer.LastName),
        //        new SqlParameter("Email", lecturer.Email),
        //        new SqlParameter("Birthday", lecturer.Birthday),
        //        new SqlParameter("Gender", lecturer.Gender),
        //        new SqlParameter("PhoneNum", lecturer.PhoneNum),
        //        new SqlParameter("Password", lecturer.Pass)
        //    );
        //    MessageBox.Show("Save success!!!");
        //}

        //private void ExecuteSaveProfile(object parameter)
        //{
        //    if (Profile != null)
        //    {
        //        UpdateLecturer(Profile);
        //    }
        //}

        //// Check condition to execute SaveProfile command
        //private bool CanExecuteSaveProfile(object parameter)
        //{
        //    return Profile != null; // Execute only if Profile information exists
        //}

        //public bool IsMale
        //{
        //    get => Profile != null && Profile.Gender == "Male";
        //    set
        //    {
        //        if (value)
        //        {
        //            Profile.Gender = "Male";
        //            OnPropertyChanged(nameof(IsMale));
        //            OnPropertyChanged(nameof(IsFemale));
        //        }
        //    }
        //}

        //public bool IsFemale
        //{
        //    get => Profile != null && Profile.Gender == "Female";
        //    set
        //    {
        //        if (value)
        //        {
        //            Profile.Gender = "Female";
        //            OnPropertyChanged(nameof(IsMale));
        //            OnPropertyChanged(nameof(IsFemale));
        //        }
        //    }
        //}

    }
}
