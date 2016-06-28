﻿ 
using System;
using System.Collections.Generic;

namespace WellBell.Scheduler
{
    public class Event : Entity 
    {
        public int CalendarId { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public string Color { get; set; }

        public DateTime StartDateTimeUTC { get; set; }

        public DateTime EndDateTimeUTC { get; set; }

        public DateTime? SeriesEndDateUTC { get; set; }

        public FrequencyType FreqType { get; set; }

        public FrequencySubtype FreqSubtype { get; set; }

        public int FreqInterval { get; set; }

        public Calendar Calendar { get; set; }

        public IEnumerable<DateTime> GetSeriesOccurrences(DateTime endDateTimeUTC)
        {
            IEnumerable<DateTime> occurrences = new List<DateTime>();

            DateTime eventEndDateTime = SeriesEndDateUTC.HasValue 
                                        ? (SeriesEndDateUTC.Value < endDateTimeUTC ? SeriesEndDateUTC.Value : endDateTimeUTC) 
                                        : endDateTimeUTC;

            Scheduler scheduler = null;

            switch(FreqType)
            {
                case FrequencyType.Daily:
                    scheduler = new DailyScheduler(FreqSubtype, FreqInterval);
                    break;

                case FrequencyType.Weekly:
                    scheduler = new WeeklyScheduler(FreqSubtype, FreqInterval);
                    break;

                case FrequencyType.Monthly:
                    scheduler = new MonthlyScheduler(FreqSubtype, FreqInterval);
                    break;

                case FrequencyType.Yearly:
                    scheduler = new YearlyScheduler(FreqSubtype, FreqInterval);
                    break;

                case FrequencyType.EveryEvenWeekday:
                case FrequencyType.EveryOddWeekday:
                case FrequencyType.EveryWeekday:
                    throw new NotImplementedException();
            }

            occurrences = scheduler.GetOccurrences(StartDateTimeUTC, eventEndDateTime);

            return occurrences;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
