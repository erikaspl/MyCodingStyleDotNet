using BookingCalendar.Model.Entities;
using BookingCalendar.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingCalendar
{
    public class BookingInputParser : IBookingInputParser
    {
        /// <summary>
        /// This class is designed to parse input of this format:
        /// working hours: HHMM HHMM
        /// submissions: [YYYY-MM-DD HH:MM:SS] [employee id] [meeting start time, in the format YYYY-MM-DD HH:MM] [meeting duration in hours]
        /// </summary>
        /// <param name="inputContent"></param>
        /// <returns></returns>
        public List<BookingRequest> Parse(InputContent inputContent)
        {
            var resultBookings = new List<BookingRequest>();
            var workingHours = inputContent.OfficeHours.Split(' ');
            string workingHoursFrom = workingHours[0];
            string workingHoursTo = workingHours[1]; 
            foreach (var bookingRequest in inputContent.BookingRequests)
            {
                var requestParts = bookingRequest.Split(' ');
                string submissionDate = requestParts[0];
                string submissionTime = requestParts[1];

                string employeeId = requestParts[2];

                string meetingStartDate = requestParts[3];
                string meetingStartTime = requestParts[4];
                string duration = requestParts[5];

                resultBookings.Add(new BookingRequest(){
                    OfficeHourFrom = workingHoursFrom,
                    OfficeHourTo = workingHoursTo,
                    SubmissionTime = DateTime.Parse(string.Format("{0} {1}", submissionDate, submissionTime)),
                    EmployeeId = employeeId,
                    MeetingStartTime = DateTime.Parse(string.Format("{0} {1}", meetingStartDate, meetingStartTime)),
                    Duration = int.Parse(duration)
                });
            }
            return resultBookings; 
        }

        //TODO: Not entirely happy with this implementation. A lot of unsafe parsing.
        //There is a good chance for exception to occur here, which will not provide any good information.
    }
}
