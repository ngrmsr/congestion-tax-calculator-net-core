using congestion.calculator;
using congestion.calculator.DAL;
using congestion.calculator.DAL.Contracts;
using congestion.calculator.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;


class Program
{
    static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);


        var serviceProvider = serviceCollection.BuildServiceProvider();

        using (var scope = serviceProvider.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<TaxContext>();

            var taxRepository = services.GetRequiredService<ITaxRepository>();
            var holidayRepository = services.GetRequiredService<IHolidayRepository>();
            var vehicle = new Car();
            DateTime[] dates = {
                new DateTime(2013, 3, 28, 14, 35, 0),
                new DateTime(2013, 3, 28, 14, 55, 0),
                new DateTime(2013, 3, 28, 15, 05, 0)
            };

            int totalFee = new CongestionTaxCalculator(taxRepository, holidayRepository).GetTax(vehicle, dates);
            Console.WriteLine($"Total tax: SEK {totalFee} ");
        }
        Console.ReadKey();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<TaxContext>(options =>
            options.UseSqlServer("Server=.;Database=Tax_Calculator;Trusted_Connection=True;"));

        services.AddScoped<ITaxRepository, TaxRepository>();
        services.AddScoped<IHolidayRepository, HolidayRepository>();
    }
}

