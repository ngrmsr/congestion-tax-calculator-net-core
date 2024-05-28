using congestion.calculator.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace congestion.calculator.DAL.Repositories
{
    public class HolidayRepository : IHolidayRepository
    {
        private readonly TaxContext _taxContext;

        public HolidayRepository(TaxContext taxContext)
        {
            _taxContext = taxContext;
        }

        public bool IsHoliday(DateTime date) => _taxContext.Holidays.Any(h => h.Date == date);
    }
}
