using congestion.calculator.DAL.Contracts;
using congestion.calculator.Entities;
using congestion.calculator.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace congestion.calculator.DAL.Repositories
{
    public class TaxRepository : ITaxRepository
    {
        private readonly TaxContext _taxContext;

        public TaxRepository(TaxContext taxContext)
        {
            _taxContext = taxContext;
        }

        public List<TaxTime> GetTaxes() => _taxContext.TaxTimes.ToList();

        public TaxTime GetTaxesBySearch(TaxTimeSearchModel searchModel) => _taxContext.TaxTimes
        .FirstOrDefault(x => (searchModel.Hour > x.StartHour || (searchModel.Hour == x.StartHour && searchModel.Minute >= x.StartMinute)) &&
                (searchModel.Hour < x.EndHour || (searchModel.Hour == x.EndHour && searchModel.Minute <= x.EndMinute)));
    }
}
