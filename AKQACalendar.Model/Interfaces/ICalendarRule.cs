using BookingCalendar.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingCalendar.Model.Interfaces
{
    public abstract class CalendarRule
    {
        public abstract List<BookingRequest> Execute(List<BookingRequest> bookings);
    }
}
