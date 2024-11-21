using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows.Input;
using UTExLMS.Models;
using UTExLMS.Commands;
using System.Windows;
using UTExLMS.Service;
using System.Data.Entity;
using System;
namespace UTExLMS.ViewModels
{
    public class ProfileLecturerViewModel : ViewModelBase
    {
        public Person _profile { get; set; }
        private readonly UTExLMSContext _context;
        public ICommand SaveProfile { get; set; }
        private MainViewModel _mainViewModel {  get; set; }   

        public ProfileLecturerViewModel()
        {

        }
        public ProfileLecturerViewModel(Person person)
        {
            _profile = person;
           // _profile = LoadProfile();
            SaveProfile = new RelayCommand(_ => UpdatePersonProfile());
        }

        private Person LoadProfile()
        {
            var idPerson = 102; 
            ProfileService profileService = new ProfileService();
            _profile = profileService.GetProfile(idPerson);
            return _profile;
        }

        public void UpdatePersonProfile() { 
            ProfileService profileService = new ProfileService();
            profileService.UpdateProfile(_profile);
        }


    public bool IsMale
        {
            get => _profile != null &&_profile.Gender == "Male";
            set
            {
                if (value)
                {
                    _profile.Gender = "Male";
                    OnPropertyChanged(nameof(IsMale));
                    OnPropertyChanged(nameof(IsFemale));
                }
            }
        }

        public bool IsFemale
        {
            get => _profile != null && _profile.Gender == "Female";
            set
            {
                if (value)
                {
                    _profile.Gender = "Female";
                    OnPropertyChanged(nameof(IsMale));
                    OnPropertyChanged(nameof(IsFemale));
                }
            }
        }

    }
}
