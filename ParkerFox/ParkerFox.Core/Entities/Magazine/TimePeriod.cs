using System;

namespace ParkerFox.Core.Entities.Magazine
{
    public class TimePeriod
    {
        public TimePeriodIntervals Interval { get; set; }
        public int Quantity { get; set; }

        public DateTime GetExtent(DateTime startDate)
        {
            switch(Interval)
            {
                case TimePeriodIntervals.Days:
                    return startDate.AddDays(Quantity);
                case TimePeriodIntervals.Months:
                    return startDate.AddMonths(Quantity);
                case TimePeriodIntervals.Years:
                    return startDate.AddYears(Quantity);
            }
            return startDate;
        }
    }
}
