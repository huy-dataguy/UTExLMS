using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UTExLMS.Service;
using UTExLMS.Models;
using System.Windows;


namespace UTExLMS.ViewModels.UCViewModel
{
    public class SectionUCViewModel : ViewModelBase
    {

        private Section _section { get; set; }

        private string _nameSection;

        private string _descript;

        private int _idSection { get; set; }

        private int _idCourse { get; set; }

        public int IdSection
        {
            get => _section.IdSection;
        }
        public int IdCourse
        {
            get => _section.IdCourse;
        }

        public string NameSection
        {
            get => _nameSection;
            set
            {
                if (SetProperty(ref _nameSection, value))
                    UpdateSection();
            }
        }



        public string Descript
        {
            get => _descript;
            set
            {
                if (SetProperty(ref _descript, value))
                    UpdateSection();
            }
        }


        public SectionUCViewModel() { }


        public SectionUCViewModel(Section section)
        {

            //MessageBox.Show(section.);
            _section = section;
            _idSection= section.IdSection;
            _idCourse= section.IdCourse;
            _nameSection = _section.NameSection;
            _descript = _section.Descript;

        }

        private void UpdateSection()
        {
            SectionService sectionService = new SectionService();
            //MessageBox.Show(_nameSection);
            sectionService.UpdateSection(_idCourse, _idSection, _nameSection, _descript);
            OnPropertyChanged(nameof(NameSection));
            OnPropertyChanged(nameof(Descript));
            OnPropertyChanged(nameof(IdCourse));
            OnPropertyChanged(nameof(IdSection));
        }
    }
}
