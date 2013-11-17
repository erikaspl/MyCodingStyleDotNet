using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingCalendar.Model.Entities
{
    public class BookingRequest
    {
        public string OfficeHourFrom { get; set; }
        public string OfficeHourTo { get; set; }

        public TimeSpan HourFrom
        {
            get
            {
                return DateTime.ParseExact(OfficeHourFrom, "HHmm", CultureInfo.InvariantCulture).TimeOfDay;
            }
        }

        public TimeSpan HourTo
        {
            get
            {
                return DateTime.ParseExact(OfficeHourTo, "HHmm", CultureInfo.InvariantCulture).TimeOfDay;
            }
        }

        public DateTime SubmissionTime { get; set; }
        public string EmployeeId { get; set; }
        public DateTime MeetingStartTime { get; set; }
        public int Duration { get; set; }

        public DateTime MeetingEndTime
        {
            get
            {
                return MeetingStartTime.AddHours(Duration);
            }
        }

    }
}
