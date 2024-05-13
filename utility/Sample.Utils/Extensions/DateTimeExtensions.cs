using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Utils.Extensions;

public static class DateTimeExtensions
{
    public static bool IsNullDateTime(this DateTime value)
        => value.IsNull() || value == DateTime.MinValue || value == default;

    public static int CalculateAge(this DateTime birthdate, DateTime? currentDate = null)
    {
        if (currentDate.IsNull())
            currentDate = DateTime.Today;

        var age = currentDate.Value.Year - birthdate.Year;
        
        if (birthdate > currentDate.Value.AddYears(-age))
        	age--;
        		 
        return age;
    }
}
