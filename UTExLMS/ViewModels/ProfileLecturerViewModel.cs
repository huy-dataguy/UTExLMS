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
        public Person profile { get; set; }
        private readonly UTExLMSContext _context;
        public ICommand SaveProfile { get; set; }
        private MainViewModel _mainViewModel {  get; set; }   

        public ProfileLecturerViewModel()
        {

        }
        public ProfileLecturerViewModel(UTExLMSContext context)
        {
            _context = context;
            profile = LoadProfile();
            //_mainViewModel = mainViewModel;
            SaveProfile = new RelayCommand(_ => UpdatePersonProfile());
        }

        private Person LoadProfile()
        {
            var idPerson = 102; 
            ProfileService profileService = new ProfileService();
            profile = profileService.GetProfile(idPerson);
            return profile;
        }

        public void UpdatePersonProfile() { 
            ProfileService profileService = new ProfileService();
            profileService.UpdateProfile(profile);
        }


    public bool IsMale
        {
            get => profile != null &&profile.Gender == "Male";
            set
            {
                if (value)
                {
                    profile.Gender = "Male";
                    OnPropertyChanged(nameof(IsMale));
                    OnPropertyChanged(nameof(IsFemale));
                }
            }
        }

        public bool IsFemale
        {
            get => profile != null && profile.Gender == "Female";
            set
            {
                if (value)
                {
                    profile.Gender = "Female";
                    OnPropertyChanged(nameof(IsMale));
                    OnPropertyChanged(nameof(IsFemale));
                }
            }
        }

    }
}
