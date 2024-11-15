using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTExLMS.Models;

namespace UTExLMS.Service
{
    public class CourseService
    {
        private readonly UTExLMSContext _context;

        public CourseService(UTExLMSContext context)
        {
            _context = context;
        }

        
    }
}
