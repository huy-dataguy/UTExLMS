using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTExLMS.Models
{
    public class NotificationPanel
    {
        public int IdNotification { get; set; }     
        public int IdStudent { get; set; }           
        public int IdCourse { get; set; }            
        public int IdSection { get; set; }           
        public int IdElement { get; set; }            
        public string TypeElement { get; set; }       
        public string NameElement { get; set; }     
        public DateTime StartDate { get; set; }      
        public DateTime EndDate { get; set; }        
        public DateTime NotificationDate { get; set; } 
        public bool IsCompleted { get; set; }      
        public NotificationPanel() { }
    }

}

