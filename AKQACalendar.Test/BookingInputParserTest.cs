using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookingCalendar;
using BookingCalendar.Model.Entities;
using System.Linq;


namespace BookingCalendar.Test
{
    [TestClass]
    public class BookingInputParserTest
    {

        private InputContent GetInputContent()
        {
            var inputContent = new InputContent();
            inputContent.OfficeHours = "0900 1730";

            return inputContent;
        }
        [TestMethod]
        public void BookingInputParser_OneRecordCount()
        {
            var inputContent = new InputContent();
            inputContent.OfficeHours = "0900 1730";
            inputContent.BookingRequests.Add("2011-03-17 10:17:06 EMP001 2011-03-21 09:00 2");
            var bookingInputParser = new BookingInputParser();
            var bookingRequests = bookingInputParser.Parse(inputContent);
            Assert.AreEqual(bookingRequests.Count, 1);
        }

        [TestMethod]
        public void BookingInputParser_OneRecordAllPartsCheck()
        {
            var inputContent = new InputContent();
            inputContent.OfficeHours = "0900 1730";
            inputContent.BookingRequests.Add("2011-03-17 10:17:06 EMP001 2011-03-21 09:00 2");
            var bookingInputParser = new BookingInputParser();
            var bookingRequests = bookingInputParser.Parse(inputContent);
            Assert.AreEqual(bookingRequests.First().OfficeHourFrom, "0900");
            Assert.AreEqual(bookingRequests.First().OfficeHourTo, "1730");
            Assert.AreEqual(bookingRequests.First().SubmissionTime, new DateTime(2011, 03, 17, 10, 17, 6));
            Assert.AreEqual(bookingRequests.First().EmployeeId, "EMP001");
            Assert.AreEqual(bookingRequests.First().MeetingStartTime, new DateTime(2011, 03, 21, 9, 0, 0));
            Assert.AreEqual(bookingRequests.First().Duration, 2);
        }

        [TestMethod]
        public void BookingInputParser_TwoRecordsAllPartsCheck()
        {
            var inputContent = new InputContent();
            inputContent.OfficeHours = "0900 1730";
            inputContent.BookingRequests.Add("2013-03-17 11:17:06 EMP0112 2011-03-21 09:00 3");
            inputContent.BookingRequests.Add("2011-03-17 10:17:06 EMP001 2011-03-21 09:00 2");
            var bookingInputParser = new BookingInputParser();
            var bookingRequests = bookingInputParser.Parse(inputContent);
            Assert.AreEqual(bookingRequests.Count, 2);
            Assert.AreEqual(bookingRequests.First().OfficeHourFrom, "0900");
            Assert.AreEqual(bookingRequests.First().OfficeHourTo, "1730");
            Assert.AreEqual(bookingRequests.First().SubmissionTime, new DateTime(2013, 03, 17, 11, 17, 6));
            Assert.AreEqual(bookingRequests.First().EmployeeId, "EMP0112");
            Assert.AreEqual(bookingRequests.First().MeetingStartTime, new DateTime(2011, 03, 21, 9, 0, 0));
            Assert.AreEqual(bookingRequests.First().Duration, 3);
        }
    }
}
