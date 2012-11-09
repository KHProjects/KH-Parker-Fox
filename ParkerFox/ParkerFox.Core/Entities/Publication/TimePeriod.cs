using System;

namespace ParkerFox.Core.Entities.Publication
{
    public class TimePeriod
    {
        [Obsolete("only for NHibernate")]
        protected TimePeriod(){}
        public TimePeriod(TimePeriodIntervals interval, int quantity)
        {
            _interval = interval;
            _quantity = quantity;
        }

        private TimePeriodIntervals _interval;
        private int _quantity;

        public virtual DateTime GetExtent(DateTime startDate)
        {
            switch (_interval)
            {
                case TimePeriodIntervals.Days:
                    return startDate.AddDays(_quantity);
                case TimePeriodIntervals.Months:
                    return startDate.AddMonths(_quantity);
                case TimePeriodIntervals.Years:
                    return startDate.AddYears(_quantity);
            }
            return startDate;
        }
    }
}