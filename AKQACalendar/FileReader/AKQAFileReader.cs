using BookingCalendar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingCalendar.Model.Entities;
using System.IO;

namespace BookingCalendar
{
    public class AKQAFileReader : IInputReader
    {
        private string _fileName;
        public AKQAFileReader(string fileName)
        {
            _fileName = fileName;
        }

        public InputContent ReadInput()
        {
            string[] input = File.ReadAllLines(_fileName);
            var inputContent = new InputContent() { OfficeHours = input[0] };
            for (var i=1; i < input.Length - 1; i = i + 2)
            {
                inputContent.BookingRequests.Add(string.Format("{0} {1}", input[i], input[i + 1]));
            }
            return inputContent;
        }
    }
}
