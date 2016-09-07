using System;
using System.Text;

namespace ICalendar.ValueTypes
{
    public class Recur
    {
        public RecurValues.Frequencies? Frequency { get; set; }

        public DateTime? Until { get; set; }

        public int? Count { get; set; }

        public int? Interval { get; set; }

        public int[] BySeconds { get; set; }

        public int[] ByMinutes { get; set; }

        public int[] ByHours { get; set; }

        public WeekDayType[] ByDays { get; set; }

        public int[] ByMonthDay { get; set; }

        public int[] ByYearDay { get; set; }

        public int[] ByWeekNo { get; set; }

        public int[] ByMonth { get; set; }

        public int[] BySetPos { get; set; }

        private DayOfWeek? _weekStart;

        public DayOfWeek Wkst
        {
            get { return _weekStart ?? DayOfWeek.Monday; }
            set { _weekStart = value; }
        }

        public override string ToString()
        {
            var strBuilder = new StringBuilder();
            if (Frequency == null)
                return "Frequency is Required for this valueType";

            strBuilder.Append("FREQ=");
            strBuilder.Append(RecurValues.ToString(Frequency.Value));

            if (Until != null)
            {
                strBuilder.Append(";UNTIL=");
                strBuilder.Append(Until.Value.ToString("yyyyMMddTHHmmss") +
                                  (Until.Value.Kind == DateTimeKind.Utc ? "Z" : ""));
            }
            if (Count != null)
            {
                strBuilder.Append(";COUNT=");
                strBuilder.Append(Count);
            }
            if (Interval != null)
            {
                strBuilder.Append(";INTERVAL=");
                strBuilder.Append(Interval);
            }
            if (BySeconds != null && BySeconds.Length > 0)
            {
                strBuilder.Append(";BYSECOND=");
                AppendAllMembers(strBuilder, BySeconds);
            }
            if (ByMinutes != null && ByMinutes.Length > 0)
            {
                strBuilder.Append(";BYMINUTE=");
                AppendAllMembers(strBuilder, ByMinutes);
            }
            if (ByHours != null && ByHours.Length > 0)
            {
                strBuilder.Append(";BYHOUR=");
                AppendAllMembers(strBuilder, ByHours);
            }
            if (ByDays != null && ByDays.Length > 0)
            {
                strBuilder.Append(";BYDAY=");
                AppendAllMembers(strBuilder, ByDays);
            }
            if (ByMonthDay != null && ByMonthDay.Length > 0)
            {
                strBuilder.Append(";BYMONTHDAY=");
                AppendAllMembers(strBuilder, ByMonthDay);
            }
            if (ByYearDay != null && ByYearDay.Length > 0)
            {
                strBuilder.Append(";BYYEARDAY=");
                AppendAllMembers(strBuilder, ByYearDay);
            }
            if (ByWeekNo != null && ByWeekNo.Length > 0)
            {
                strBuilder.Append(";BYWEEKNO=");
                AppendAllMembers(strBuilder, ByWeekNo);
            }
            if (ByMonth != null && ByMonth.Length > 0)
            {
                strBuilder.Append(";BYMONTH=");
                AppendAllMembers(strBuilder, ByMonth);
            }
            if (BySetPos != null && BySetPos.Length > 0)
            {
                strBuilder.Append(";BYSETPOS=");
                AppendAllMembers(strBuilder, BySetPos);
            }
            if (_weekStart != null)
            {
                strBuilder.Append(";WKST=");
                strBuilder.Append(RecurValues.ToString(Wkst));
            }

            return strBuilder.ToString();
        }

        private static void AppendAllMembers<T>(StringBuilder stringBuilder, T[] array)
        {
            stringBuilder.Append(array[0]);
            for (var i = 1; i < array.Length; i++)
            {
                stringBuilder.Append(",");
                stringBuilder.Append(array[i]);
            }
        }
    }

    public class WeekDayType
    {
        /// <summary>
        /// Use this contructor for building this type.
        /// The other is still for compatibilities reason
        /// </summary>
        /// <param name="ordDay"></param>
        /// <param name="day"></param>
        public WeekDayType(int? ordDay, DayOfWeek day)
        {
            OrdDay = ordDay;
            DayOfWeek = day;
        }

        public int? OrdDay { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            if (OrdDay != null)
                str.Append(OrdDay);
            str.Append(RecurValues.ToString(DayOfWeek));
            return str.ToString();
        }
    }

    public class RecurValues
    {
        public enum Frequencies
        {
            SECONDLY, MINUTELY, HOURLY, DAILY, WEEKLY, MONTHLY, YEARLY
        }

        /// <summary>
        /// Convert an Frequency to its string representation
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToString(Frequencies value)
        {
            switch (value)
            {
                case Frequencies.MINUTELY:
                    return "MINUTELY";

                case Frequencies.HOURLY:
                    return "HOURLY";

                case Frequencies.DAILY:
                    return "DAILY";

                case Frequencies.WEEKLY:
                    return "WEEKLY";

                case Frequencies.MONTHLY:
                    return "MONTHLY";

                case Frequencies.YEARLY:
                    return "YEARLY";

                case Frequencies.SECONDLY:
                    return "SECONDLY";

                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }

        /// <summary>
        /// Convert an WeekDay to its string representation
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToString(DayOfWeek value)
        {
            switch (value)
            {
                case DayOfWeek.Monday:
                    return "MO";

                case DayOfWeek.Tuesday:
                    return "TU";

                case DayOfWeek.Wednesday:
                    return "WE";

                case DayOfWeek.Thursday:
                    return "TH";

                case DayOfWeek.Friday:
                    return "FR";

                case DayOfWeek.Saturday:
                    return "SA";

                case DayOfWeek.Sunday:
                    return "SU";

                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }

        /// <summary>
        /// Convert the string representation of
        /// a Frequency to a Frequency
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Frequencies? ParseValue(string value)
        {
            switch (value)
            {
                case "MINUTELY":
                    return Frequencies.MINUTELY;

                case "HOURLY":
                    return Frequencies.HOURLY;

                case "DAILY":
                    return Frequencies.DAILY;

                case "WEEKLY":
                    return Frequencies.WEEKLY;

                case "MONTHLY":
                    return Frequencies.MONTHLY;

                case "YEARLY":
                    return Frequencies.YEARLY;

                case "SECONDLY":
                    return Frequencies.SECONDLY;

                default:
                    return null;
            }
        }

        /// <summary>
        /// Convert the string representation of
        /// a Weekday to a Weekday
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DayOfWeek ParseValues(string value)
        {
            switch (value)
            {
                case "MO":
                    return DayOfWeek.Monday;

                case "TU":
                    return DayOfWeek.Tuesday;

                case "WE":
                    return DayOfWeek.Wednesday;

                case "TH":
                    return DayOfWeek.Thursday;

                case "FR":
                    return DayOfWeek.Friday;

                case "SA":
                    return DayOfWeek.Saturday;

                case "SU":
                    return DayOfWeek.Sunday;

                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }

        public static bool TryParseValue(string value, out DayOfWeek weekday)
        {
            switch (value)
            {
                case "MO":
                    weekday = DayOfWeek.Monday;
                    return true;

                case "TU":
                    weekday = DayOfWeek.Tuesday;
                    return true;

                case "WE":
                    weekday = DayOfWeek.Wednesday;
                    return true;

                case "TH":
                    weekday = DayOfWeek.Thursday;
                    return true;

                case "FR":
                    weekday = DayOfWeek.Friday;
                    return true;

                case "SA":
                    weekday = DayOfWeek.Saturday;
                    return true;

                case "SU":
                    weekday = DayOfWeek.Sunday;
                    return true;

                default:
                    weekday = DayOfWeek.Wednesday;
                    return false;
            }
        }
    }
}