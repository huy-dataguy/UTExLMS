using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UTExLMS.Models;
using UTExLMS.Service;
using UTExLMS.Commands;
using UTExLMS.ViewModels.UCViewModel;
using Microsoft.Win32;
using Microsoft.Win32;
using System.Windows;
using System.IO;


namespace UTExLMS.ViewModels
{
    internal class AddDocumentWViewModel : ViewModelBase
    {
        public AddDocumentWViewModel()
        {

        }



        public ICommand AddFile { get; set; }

        public ICommand ChooseFile { get; set; }
        private Section _section { get; set; }
        private SectionUCViewModel _sectionUCViewModel { get; set; }
        
        public Action closeAction { get; set; }
        public AddDocumentWViewModel(Section section, SectionUCViewModel sectionUCViewModel)
        {
            _nameMaterial = "";
            _section = section;
            _sectionUCViewModel = sectionUCViewModel;
            AddFile = new RelayCommand(_ => AddNewDocument());
            ChooseFile = new RelayCommand(_ => ChooseDocument());
        }

        private string _filePath { get; set; }
        
        private string _nameMaterial {  get; set; }

        public string NameMaterial
        {
            get => _nameMaterial;
            set
            {
                _nameMaterial = value;
                OnPropertyChanged(nameof(NameMaterial));
            }
        }

        private string _typeMaterial { get; set; }


        private void ChooseDocument()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                _filePath = openFileDialog.FileName;
                MessageBox.Show("File chosen: " + _filePath);
                _typeMaterial = Path.GetExtension(_filePath);
            }
            
        }

        private void AddNewDocument()
        {
            // Add new document to the section
            MaterialService materialService = new MaterialService();
            materialService.AddNewDocument(_filePath, false, _nameMaterial, _typeMaterial, _section.IdSection, _section.IdCourse);
            _sectionUCViewModel.UpdateElementList();
            closeAction();
        }

    }
}
