using System;
using System.Collections.Generic;

namespace UTExLMS.Models
{
    public partial class VwStudentCourse
    {
        public int IdStudent { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? NameClass { get; set; }
        public double? Progress { get; set; }

        // Chỉ lấy ngày, không lấy giờ
        public DateTime? StartDate
        {
            get => _startDate?.Date;
            set => _startDate = value;
        }
        private DateTime? _startDate;

        public DateTime? EndDate
        {
            get => _endDate?.Date;
            set => _endDate = value;
        }
        private DateTime? _endDate;
    }
}
