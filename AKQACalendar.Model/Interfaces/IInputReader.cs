using BookingCalendar.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingCalendar.Model
{
    public interface IInputReader
    {
        InputContent ReadInput();
    }
}
