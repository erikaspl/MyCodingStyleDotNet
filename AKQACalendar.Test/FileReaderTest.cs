using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookingCalendar.Test
{
    [TestClass]
    [DeploymentItem("AKQAInput.txt")]
    public class FileReaderTest
    {
        private string filePath = @".\AKQAInput.txt";
        [TestMethod]
        public void ReadFileTest_Execute()
        {
            var reader = new AKQAFileReader(filePath);

            var result = reader.ReadInput();

            Assert.AreEqual(result.BookingRequests.Count, 5);
        }

        //TODO File not found tests, incorrect format files. out of scope for now

    }
}
