using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using UTExLMS.Models;
using UTExLMS.Service;
using UTExLMS.Views;

namespace UTExLMS.ViewModels
{
    public class StudentClassViewModel : ViewModelBase
    {
        private readonly UTExLMSContext _context;

        private StudentClassService _studentClasses;

        public ObservableCollection<OverviewClass> StudentClasses {  get; private set; }

        public FilterListClass FilterOption { get; private set; }


        private int _id = 1;
        private string _selectedFilter;
        private string _searchTerm;
        public string SelectedFilter
        {
            get => _selectedFilter;
            set
            {
                if (SetProperty(ref _selectedFilter, value))
                {
                    PendingSearchTerm = string.Empty;
                    SearchTerm = null;
                    UpdateStudentClasses();  
                }
            }
        }


        private string _pendingSearchTerm;
        public string PendingSearchTerm  
        {
            get => _pendingSearchTerm;
            set => SetProperty(ref _pendingSearchTerm, value);
        }
        public string SearchTerm { get; private set;}
        public ICommand SearchCmd { get; }


        public StudentClassViewModel(UTExLMSContext context)
        {
            _context = context;
            FilterOption = new FilterListClass();

            _selectedFilter = FilterOption.SelectedName[0];
            SearchCmd = new RelayCommand(OnSearch);
            UpdateStudentClasses();
        }

        private void UpdateStudentClasses()
        {
            _studentClasses = new StudentClassService(_context, _id, SelectedFilter, SearchTerm);
            StudentClasses = new ObservableCollection<OverviewClass>(_studentClasses.OverviewClasses);
            OnPropertyChanged(nameof(StudentClasses));
        }
        public StudentClassViewModel() { }



        private void OnSearch()
        {
            SearchTerm = string.IsNullOrWhiteSpace(PendingSearchTerm) ? null : PendingSearchTerm;
            UpdateStudentClasses();

        }

    }
}
