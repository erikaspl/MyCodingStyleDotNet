using BookingCalendar.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingCalendar.Model
{
    public class CalendarRules
    {

        public static List<BookingRequest> OfficeHoursRule(List<BookingRequest> bookings)
        {
            return bookings.Where(b => b.HourFrom <= b.MeetingStartTime.TimeOfDay && b.HourTo >= b.MeetingEndTime.TimeOfDay).ToList();
        }

        public static List<BookingRequest> NoOverlapRule(List<BookingRequest> bookings)
        {
            List<BookingRequest> clonedList = bookings.ConvertAll<BookingRequest>(item => item).OrderBy(b => b.SubmissionTime).ToList();
            List<BookingRequest> resultList = new List<BookingRequest>();
            foreach (var booking in clonedList)
            {
                if ((resultList.Count(b => b.MeetingStartTime <= booking.MeetingStartTime && b.MeetingEndTime > booking.MeetingStartTime) == 0) &&
                     (resultList.Count(b => b.MeetingStartTime < booking.MeetingEndTime && b.MeetingEndTime >= booking.MeetingEndTime ) == 0))
                {
                    resultList.Add(booking);
                }                
            }
            return resultList;
        }

        //TODO: this rule hasn't been tested for all posible scenarious.
    }
}
