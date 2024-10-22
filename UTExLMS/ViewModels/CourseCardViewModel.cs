using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTExLMS.Models;

namespace UTExLMS.ViewModels
{
    public class CourseCardViewModel
    {
        private IList<CourseCard> _dataList;
        public CourseCardViewModel()
        {
            DataList = GetCardDataList();
        }

        internal ObservableCollection<CourseCard> GetCardDataList()
        {
            return new ObservableCollection<CourseCard>
        {
            new CourseCard
            {
                Header = "Atomic",
                Content = "/Assets/cou",
                Footer = "Stive Morgan"
            },
            new CourseCard
            {
                Header = "Zinderlong",
                Content = "2.jpg",
                Footer = "Zonderling"
            },
            new CourseCard
            {
                Header = "Busy Doin' Nothin'",
                Content = "3.jpg",
                Footer = "Ace Wilder"
            },
            new CourseCard
            {
                Header = "Wrongggggggggggggggggggggggggggggggggggg",
                Content = "4.jpg",
                Footer = "Blaxy Girls"
            },
            new CourseCard
            {
                Header = "The Lights",
                Content = "5.jpg",
                Footer = "Panda Eyes"
            },
            new CourseCard
            {
                Header = "EA7-50-Cent Disco",
                Content = "6.jpg",
                Footer = "еяхат музыка"
            },
            new CourseCard
            {
                Header = "Monsters",
                Content = "7.jpg",
                Footer = "Different Heaven"
            },
            new CourseCard
            {
                Header = "Gangsta Walk",
                Content = "8.jpg",
                Footer = "Illusionize"
            },
            new CourseCard
            {
                Header = "Won't Back Down",
                Content = "9.jpg",
                Footer = "Boehm"
            },
            new CourseCard
            {
                Header = "Katchi",
                Content = "10.jpg",
                Footer = "Ofenbach"
            }
        };
        }
        public IList<CourseCard> DataList { get => _dataList; set => _dataList = value; }
    }
}
