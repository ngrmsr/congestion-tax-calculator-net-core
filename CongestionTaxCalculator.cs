using System;
using System.Collections.Generic;
using System.Linq;
using congestion.calculator;
using congestion.calculator.DAL.Contracts;
public class CongestionTaxCalculator
{
    /**
         * Calculate the total toll fee for one day
         *
         * @param vehicle - the vehicle
         * @param dates   - date and time of all passes on one day
         * @return - the total congestion tax for that day
         */
    private readonly ITaxRepository _taxRepository;
    private readonly IHolidayRepository _holidayRepository;

    public CongestionTaxCalculator(ITaxRepository taxRepository, IHolidayRepository holidayRepository)
    {
        _taxRepository = taxRepository;
        _holidayRepository = holidayRepository;
    }
    public int GetTax(Vehicle vehicle, DateTime[] dates)
    {
        if (dates == null || dates.Length == 0) return 0;
        dates = dates.OrderBy(d => d).ToArray();
        DateTime intervalStart = dates[0];
        int totalFee = 0;
        int currentFee = 0;

        foreach (var date in dates)
        {
            int nextFee = GetTollFee(date, vehicle);
            var minute = (date - intervalStart).TotalMinutes;

            if (minute <= 60 && minute != 0)
            {
                totalFee = 60;
            }
            else
            {
                totalFee += currentFee;
                currentFee = nextFee;
                intervalStart = date;
            }
        }

        return totalFee;
    }

    private bool IsTollFreeVehicle(Vehicle vehicle)
    {
        if (vehicle == null) return false;

        string vehicleType = vehicle.GetVehicleType();
        return TollFreeVehicleTypes.Contains(vehicleType);
    }

    public int GetTollFee(DateTime date, Vehicle vehicle)
    {
        if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle)) return 0;

        congestion.calculator.Models.TaxTimeSearchModel search = new congestion.calculator.Models.TaxTimeSearchModel
        {
            Hour = date.Hour,
            Minute = date.Minute
        };
        return _taxRepository.GetTaxesBySearch(search).Tax;
    }

    private Boolean IsTollFreeDate(DateTime date)
    {
        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            return true;

        if (date.Year == 2013)
            return _holidayRepository.IsHoliday(date);

        return false;
    }

    private static readonly HashSet<string> TollFreeVehicleTypes = new HashSet<string>
    {
      TollFreeVehicles.Motorcycle.ToString(),
      TollFreeVehicles.Tractor.ToString(),
      TollFreeVehicles.Emergency.ToString(),
      TollFreeVehicles.Diplomat.ToString(),
      TollFreeVehicles.Foreign.ToString(),
      TollFreeVehicles.Military.ToString()
    };
    private enum TollFreeVehicles
    {
        Motorcycle = 0,
        Tractor = 1,
        Emergency = 2,
        Diplomat = 3,
        Foreign = 4,
        Military = 5
    }
}