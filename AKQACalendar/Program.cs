using BookingCalendar.Model;
using BookingCalendar.Model.Entities;
using BookingCalendar.Model.Interfaces;
using BookingCalendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingCalendar
{
    class Program
    {
        private const string fileName = "AKQAInput.txt";
        static void Main(string[] args)
        {
            //Read file. result is an object InputContent
            IInputReader reader = new AKQAFileReader(fileName); //should be injected
            var input = reader.ReadInput();

            //Parse text. Result is a collection of booking request objects           
            IBookingInputParser parser = new BookingInputParser(); //should be injected
            var bookings = parser.Parse(input);

            //Assemble calendar. result: calendar
            ICalendarAssembler calendarAssembler = new CalendarAssembler(); //should be injected

            //setup booking rules
            var bookingRules = new List<Func<List<BookingRequest>, List<BookingRequest>>>();
            bookingRules.Add(CalendarRules.OfficeHoursRule);
            bookingRules.Add(CalendarRules.NoOverlapRule);

            var calendar = calendarAssembler.Assemble(bookings, bookingRules);

            //Output calendar
            //TODO: create the output services
            foreach (var date in calendar.Dates.Keys)
            {
                Console.WriteLine(date.ToString());
                foreach(var booking in calendar.Dates[date])
                {
                    Console.WriteLine(string.Format("{0} {1} {2}", booking.MeetingStartTime.TimeOfDay, booking.MeetingEndTime.TimeOfDay, booking.EmployeeId));
                }                
            }

            Console.ReadLine();
        }
    }
}
