using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    public class DateModifier
    {
        public DateModifier(string first, string second)
        {
            FirstDate = first;
            SecondDate = second;
        }
        public string FirstDate { get; set; }
        public string SecondDate { get; set; }

        public double Difference()
        {
            DateTime startDate = DateTime.ParseExact(FirstDate, "yyyy MM dd",
                                System.Globalization.CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(SecondDate, "yyyy MM dd",
                                System.Globalization.CultureInfo.InvariantCulture);

            double difference = (endDate - startDate).TotalDays;
            return difference;
        }
    }
}
