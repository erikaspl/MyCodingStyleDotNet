using BookingCalendar.Model.Entities;
using BookingCalendar.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingCalendar
{
    public class CalendarAssembler : ICalendarAssembler
    {
        public Calendar Assemble(IList<BookingRequest> bookingRequests, IList<Func<List<BookingRequest>, List<BookingRequest>>> calendarRules)
        {
            var calendar = new Calendar();
            var calendarBookings = bookingRequests.ToList().ConvertAll<BookingRequest>(item => item);
            foreach (var rule in calendarRules)
            {
                calendarBookings = rule(calendarBookings);
            }

            calendarBookings.OrderBy(b => b.MeetingStartTime).ToList().ForEach(booking => calendar.AddBooking(booking.MeetingStartTime.Date, booking));
            return calendar;
        }
    }
}
