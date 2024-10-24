﻿using System;
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
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}