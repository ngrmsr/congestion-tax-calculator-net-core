using System;
using System.Collections.Generic;
using System.Text;

namespace congestion.calculator.DAL.Contracts
{
    public interface IHolidayRepository
    {
        bool IsHoliday(DateTime date);
    }
}
