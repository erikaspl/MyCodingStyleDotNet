using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookingCalendar.Model.Entities;
using System.Collections.Generic;
using BookingCalendar.Model;

namespace BookingCalendar.Test
{
    [TestClass]
    public class CalendarRuleTests
    {
        [TestMethod]
        public void OfficeHourTest_AllBookingsInside()
        {
            List<BookingRequest> bookings = new List<BookingRequest>();
            bookings.Add(new BookingRequest{MeetingStartTime = new DateTime(2011, 11, 10, 9, 30, 0), Duration = 2, OfficeHourFrom = "0900", OfficeHourTo = "1730"});
            bookings.Add(new BookingRequest { MeetingStartTime = new DateTime(2011, 11, 10, 14, 30, 0), Duration = 2, OfficeHourFrom = "0900", OfficeHourTo = "1730" });

            var calendarBookings = CalendarRules.OfficeHoursRule(bookings);

            Assert.AreEqual(calendarBookings.Count, 2);
        }

        [TestMethod]
        public void OfficeHourTest_SomeBookingsOutside()
        {
            List<BookingRequest> bookings = new List<BookingRequest>();
            bookings.Add(new BookingRequest { MeetingStartTime = new DateTime(2011, 11, 10, 9, 30, 0), Duration = 2, OfficeHourFrom = "0900", OfficeHourTo = "1730" });
            bookings.Add(new BookingRequest { MeetingStartTime = new DateTime(2011, 11, 10, 14, 30, 0), Duration = 8, OfficeHourFrom = "0900", OfficeHourTo = "1730" });

            var calendarBookings = CalendarRules.OfficeHoursRule(bookings);

            Assert.AreEqual(calendarBookings.Count, 1);
        }

        [TestMethod]
        public void OfficeHourTest_Boundary()
        {
            List<BookingRequest> bookings = new List<BookingRequest>();
            bookings.Add(new BookingRequest { MeetingStartTime = new DateTime(2011, 11, 10, 9, 00, 0), Duration = 2, OfficeHourFrom = "0900", OfficeHourTo = "1730" });
            bookings.Add(new BookingRequest { MeetingStartTime = new DateTime(2011, 11, 10, 14, 30, 0), Duration = 3, OfficeHourFrom = "0900", OfficeHourTo = "1730" });

            var calendarBookings = CalendarRules.OfficeHoursRule(bookings);

            Assert.AreEqual(calendarBookings.Count, 2);
        }

        [TestMethod]
        public void NoOverlapRule_MeetingsNotOvelaping()
        {
            List<BookingRequest> bookings = new List<BookingRequest>();
            bookings.Add(new BookingRequest { MeetingStartTime = new DateTime(2011, 11, 10, 9, 00, 0), Duration = 2, OfficeHourFrom = "0900", OfficeHourTo = "1730" });
            bookings.Add(new BookingRequest { MeetingStartTime = new DateTime(2011, 11, 10, 14, 30, 0), Duration = 3, OfficeHourFrom = "0900", OfficeHourTo = "1730" });

            var calendarBookings = CalendarRules.NoOverlapRule(bookings);

            Assert.AreEqual(calendarBookings.Count, 2);
        }

        [TestMethod]
        public void NoOverlapRule_MeetingsOvelapingDifferentDuration()
        {
            List<BookingRequest> bookings = new List<BookingRequest>();
            bookings.Add(new BookingRequest { MeetingStartTime = new DateTime(2011, 11, 10, 9, 00, 0), Duration = 2, OfficeHourFrom = "0900", OfficeHourTo = "1730", SubmissionTime = new DateTime(2011, 11, 07, 9, 11, 47) });
            bookings.Add(new BookingRequest { MeetingStartTime = new DateTime(2011, 11, 10, 14, 30, 0), Duration = 3, OfficeHourFrom = "0900", OfficeHourTo = "1730", SubmissionTime = new DateTime(2011, 11, 06, 9, 55, 47) });
            bookings.Add(new BookingRequest { MeetingStartTime = new DateTime(2011, 11, 10, 14, 30, 0), Duration = 2, OfficeHourFrom = "0900", OfficeHourTo = "1730", SubmissionTime = new DateTime(2011, 11, 06, 10, 12, 47) });

            var calendarBookings = CalendarRules.NoOverlapRule(bookings);

            Assert.AreEqual(calendarBookings.Count, 2);
        }

        [TestMethod]
        public void NoOverlapRule_MeetingsOvelapingSameDuration()
        {
            List<BookingRequest> bookings = new List<BookingRequest>();
            bookings.Add(new BookingRequest { MeetingStartTime = new DateTime(2011, 11, 10, 9, 00, 0), Duration = 2, OfficeHourFrom = "0900", OfficeHourTo = "1730", SubmissionTime = new DateTime(2011, 11, 07, 9, 11, 47) });
            bookings.Add(new BookingRequest { MeetingStartTime = new DateTime(2011, 11, 10, 14, 30, 0), Duration = 3, OfficeHourFrom = "0900", OfficeHourTo = "1730", SubmissionTime = new DateTime(2011, 11, 06, 9, 55, 47) });
            bookings.Add(new BookingRequest { MeetingStartTime = new DateTime(2011, 11, 10, 14, 30, 0), Duration = 3, OfficeHourFrom = "0900", OfficeHourTo = "1730", SubmissionTime = new DateTime(2011, 11, 06, 10, 12, 47) });

            var calendarBookings = CalendarRules.NoOverlapRule(bookings);

            Assert.AreEqual(calendarBookings.Count, 2);
        }

        [TestMethod]
        public void NoOverlapRule_MeetingsOvelapingDurationTest()
        {
            List<BookingRequest> bookings = new List<BookingRequest>();
            bookings.Add(new BookingRequest { MeetingStartTime = new DateTime(2011, 11, 10, 9, 00, 0), Duration = 2, OfficeHourFrom = "0900", OfficeHourTo = "1730", SubmissionTime = new DateTime(2011, 11, 07, 9, 11, 47) });
            bookings.Add(new BookingRequest { MeetingStartTime = new DateTime(2011, 11, 10, 15, 30, 0), Duration = 3, OfficeHourFrom = "0900", OfficeHourTo = "1730", SubmissionTime = new DateTime(2011, 11, 06, 9, 55, 47) });
            bookings.Add(new BookingRequest { MeetingStartTime = new DateTime(2011, 11, 10, 14, 30, 0), Duration = 4, OfficeHourFrom = "0900", OfficeHourTo = "1730", SubmissionTime = new DateTime(2011, 11, 06, 8, 12, 47) });

            var calendarBookings = CalendarRules.NoOverlapRule(bookings);

            Assert.AreEqual(calendarBookings.Count, 2);
        }

        [TestMethod]
        public void NoOverlapRule_MeetingsOvelapingStartTimeDontMatch()
        {
            List<BookingRequest> bookings = new List<BookingRequest>();
            bookings.Add(new BookingRequest { MeetingStartTime = new DateTime(2011, 11, 10, 9, 00, 0), Duration = 2, OfficeHourFrom = "0900", OfficeHourTo = "1730", SubmissionTime = new DateTime(2011, 11, 07, 9, 11, 47), EmployeeId = "EMP001" });
            bookings.Add(new BookingRequest { MeetingStartTime = new DateTime(2011, 11, 10, 13, 30, 0), Duration = 3, OfficeHourFrom = "0900", OfficeHourTo = "1730", SubmissionTime = new DateTime(2011, 11, 06, 9, 55, 47), EmployeeId = "EMP002" });
            bookings.Add(new BookingRequest { MeetingStartTime = new DateTime(2011, 11, 10, 14, 30, 0), Duration = 4, OfficeHourFrom = "0900", OfficeHourTo = "1730", SubmissionTime = new DateTime(2011, 11, 06, 8, 12, 47), EmployeeId = "EMP003" });

            var calendarBookings = CalendarRules.NoOverlapRule(bookings);

            Assert.AreEqual(calendarBookings.Count, 2);
        }

        [TestMethod]
        public void NoOverlapRule_MeetingsNotOvelapingStartOneAfterAnother()
        {
            List<BookingRequest> bookings = new List<BookingRequest>();
            bookings.Add(new BookingRequest { MeetingStartTime = new DateTime(2011, 11, 10, 9, 00, 0), Duration = 2, OfficeHourFrom = "0900", OfficeHourTo = "1730", SubmissionTime = new DateTime(2011, 11, 07, 9, 11, 47), EmployeeId = "EMP001" });
            bookings.Add(new BookingRequest { MeetingStartTime = new DateTime(2011, 11, 10, 13, 30, 0), Duration = 1, OfficeHourFrom = "0900", OfficeHourTo = "1730", SubmissionTime = new DateTime(2011, 11, 06, 9, 55, 47), EmployeeId = "EMP002" });
            bookings.Add(new BookingRequest { MeetingStartTime = new DateTime(2011, 11, 10, 14, 30, 0), Duration = 2, OfficeHourFrom = "0900", OfficeHourTo = "1730", SubmissionTime = new DateTime(2011, 11, 06, 8, 12, 47), EmployeeId = "EMP003" });

            var calendarBookings = CalendarRules.NoOverlapRule(bookings);

            Assert.AreEqual(calendarBookings.Count, 3);
        }
    }
}
