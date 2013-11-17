using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingCalendar.Model.Entities
{
    public class Calendar
    {
        public Dictionary<DateTime, List<BookingRequest>> Dates = new Dictionary<DateTime, List<BookingRequest>>();

        public void AddBooking(DateTime date, BookingRequest booking)
        {
            if (!Dates.ContainsKey(date))
            {
                Dates.Add(date, new List<BookingRequest>());
            }

            Dates[date].Add(booking);
        }

    }
}
