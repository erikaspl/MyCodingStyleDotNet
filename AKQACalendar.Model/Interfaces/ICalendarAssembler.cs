using BookingCalendar.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingCalendar.Model.Interfaces
{
    public interface ICalendarAssembler
    {
        Calendar Assemble(IList<BookingRequest> bookingRequests, IList<Func<List<BookingRequest>, List<BookingRequest>>> calendarRules);
    }
}
