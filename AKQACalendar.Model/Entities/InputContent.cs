using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingCalendar.Model.Entities
{
    public class InputContent
    {
        /// <summary>
        /// represents the company office hours, in 24 hour clock format: HHMM HHMM
        /// </summary>
        public string OfficeHours { get; set; }

        public List<string> _bookingRequests = new List<string>();
        /// <summary>
        /// Each booking request is in the following format: 
        /// [request submission time, in the format [YYYY-MM-DD HH:MM:SS] [ARCH:employee id] [meeting start time, in the format YYYY-MM-DD HH:MM] [ARCH:meeting duration in hours]
        /// </summary>
        public List<string> BookingRequests 
        {
            get
            {
                return _bookingRequests;
            }
        }
    }
}
