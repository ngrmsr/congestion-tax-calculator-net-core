using congestion.calculator.Entities;
using congestion.calculator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace congestion.calculator.DAL.Contracts
{
    public interface ITaxRepository
    {
        List<TaxTime> GetTaxes();
        TaxTime GetTaxesBySearch(TaxTimeSearchModel searchModel);
    }
}
