using System;
using System.Globalization;

public class ThousandDaysAfterBirthDateCalculator
{
    public static void Main()
    {
        const string dateFormat = "dd-MM-yyyy";

        var birthDate = DateTime.ParseExact(Console.ReadLine(), dateFormat,
            CultureInfo.InvariantCulture);

        var thousandDaysAfterBirthDate = birthDate.AddDays(1000);

        var outputDateFormatted = thousandDaysAfterBirthDate.ToString(dateFormat);
        Console.WriteLine(outputDateFormatted);
    }
}