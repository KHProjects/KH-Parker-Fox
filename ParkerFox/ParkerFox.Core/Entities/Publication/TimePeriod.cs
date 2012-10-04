using System;

namespace ParkerFox.Core.Entities.Publication
{
    public class TimePeriod
    {
        public virtual TimePeriodIntervals Interval { get; set; }
        public virtual int Quantity { get; set; }

        //public virtual DateTime GetExtent(DateTime startDate)
        //{
        //    switch(Interval)
        //    {
        //        case TimePeriodIntervals.Days:
        //            return startDate.AddDays(Quantity);
        //        case TimePeriodIntervals.Months:
        //            return startDate.AddMonths(Quantity);
        //        case TimePeriodIntervals.Years:
        //            return startDate.AddYears(Quantity);
        //    }
        //    return startDate;
        //}
    }
}