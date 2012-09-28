using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CECRunningChart.Common
{
    public static class Extensions
    {
        public static string ConvertToDecimalString(this decimal value)
        {
            return String.Format("{0:0.00}", Math.Truncate(value * 100) / 100);
        }
    }
}
