using System;
using System.Globalization;

#pragma warning disable CA1303 // Do not pass literals as localized parameters

namespace Instantia
{
    // TODO: Implement interfaces.
    public readonly partial struct UtcDateTime : IComparable, IComparable<UtcDateTime>, IEquatable<UtcDateTime>
    {
        private const string Arg_MustBeDateTime = "Object must be of type DateTime.";
        private const string Argument_InvalidDateTimeKind = "Invalid DateTimeKind value.";

        private static readonly DateTime s_defaultDateTime = new DateTime(0L, DateTimeKind.Utc);

        public static readonly UtcDateTime MinValue = new UtcDateTime(DateTime.MinValue.Ticks);

        public static readonly UtcDateTime MaxValue = new UtcDateTime(DateTime.MaxValue.Ticks);

        private readonly DateTime _dateTime;

        public UtcDateTime(DateTime dateTime)
        {
            if (dateTime.Kind != DateTimeKind.Utc)
                throw new ArgumentException(Argument_InvalidDateTimeKind, nameof(dateTime));

            _dateTime = dateTime;
        }

        private UtcDateTime(DateTime dateTime, bool _)
        {
            _dateTime = dateTime;
        }

        public UtcDateTime Date => IsDefault ? new UtcDateTime(0L) : new UtcDateTime(_dateTime.Date, false);

        public int Day => _dateTime.Day;

        public DayOfWeek DayOfWeek => _dateTime.DayOfWeek;

        public int DayOfYear => _dateTime.DayOfYear;

        public int Hour => _dateTime.Hour;

        public bool IsDefault => _dateTime.Kind == default;

        public DateTimeKind Kind => DateTimeKind.Utc;

        public int Millisecond => _dateTime.Millisecond;

        public int Minute => _dateTime.Minute;

        public int Month => _dateTime.Month;

        public int Second => _dateTime.Second;

        public long Ticks => _dateTime.Ticks;

        public TimeSpan TimeOfDay => _dateTime.TimeOfDay;

        public static UtcDateTime Today => UtcNow.Date;

        public static UtcDateTime UtcNow => new UtcDateTime(DateTime.UtcNow, false);

        public int Year => _dateTime.Year;

        public static int Compare(UtcDateTime t1, UtcDateTime t2)
        {
            return t1.Ticks.CompareTo(t2.Ticks);
        }

        public static bool Equals(UtcDateTime t1, UtcDateTime t2)
        {
            return t1.Ticks == t2.Ticks;
        }

        public static int DaysInMonth(int year, int month)
        {
            return DateTime.DaysInMonth(year, month);
        }

        public static UtcDateTime FromBinary(long dateData)
        {
            DateTime dateTime = DateTime.FromBinary(dateData);
            return FromDateTime(dateTime);
        }

        public static UtcDateTime FromDateTime(DateTime dateTime)
        {
            return dateTime.Kind == DateTimeKind.Utc
                ? new UtcDateTime(dateTime, false)
                : new UtcDateTime(dateTime.ToUniversalTime(), false);
        }

        public static UtcDateTime FromFileTimeUtc(long fileTime)
        {
            DateTime dateTime = DateTime.FromFileTimeUtc(fileTime);
            return new UtcDateTime(dateTime, false);
        }

        public static UtcDateTime Parse(string s, IFormatProvider provider)
        {
            DateTime dateTime = DateTime.Parse(s, provider);
            return new UtcDateTime(dateTime, false);
        }

        public static UtcDateTime Parse(string s, IFormatProvider provider, DateTimeStyles styles)
        {
            DateTime dateTime = DateTime.Parse(s, provider, styles);
            return new UtcDateTime(dateTime, false);
        }

#if NETCOREAPP2_1 || NETSTANDARD2_1
        public static UtcDateTime Parse(ReadOnlySpan<char> s, IFormatProvider provider = null,
            DateTimeStyles styles = DateTimeStyles.None)
        {
            DateTime dateTime = DateTime.Parse(s, provider, styles);
            return new UtcDateTime(dateTime, false);
        }
#endif

        public UtcDateTime Add(TimeSpan value)
        {
            return new UtcDateTime(_dateTime.Ticks + value.Ticks);
        }

        public UtcDateTime AddDays(double value)
        {
            DateTime dateTime = ToDateTime().AddDays(value);
            return new UtcDateTime(dateTime, false);
        }

        public UtcDateTime AddHours(double value)
        {
            DateTime dateTime = ToDateTime().AddHours(value);
            return new UtcDateTime(dateTime, false);
        }
        public UtcDateTime AddMilliseconds(double value)
        {
            DateTime dateTime = ToDateTime().AddMilliseconds(value);
            return new UtcDateTime(dateTime, false);
        }
        public UtcDateTime AddMinutes(double value)
        {
            DateTime dateTime = ToDateTime().AddMinutes(value);
            return new UtcDateTime(dateTime, false);
        }

        public UtcDateTime AddMonths(int months)
        {
            DateTime dateTime = ToDateTime().AddMonths(months);
            return new UtcDateTime(dateTime, false);
        }

        public UtcDateTime AddSeconds(double value)
        {
            DateTime dateTime = ToDateTime().AddSeconds(value);
            return new UtcDateTime(dateTime, false);
        }

        public UtcDateTime AddTicks(long value)
        {
            return new UtcDateTime(_dateTime.Ticks + value);
        }

        public UtcDateTime AddYears(int value)
        {
            DateTime dateTime = ToDateTime().AddYears(value);
            return new UtcDateTime(dateTime, false);
        }

        public int CompareTo(UtcDateTime other)
        {
            return Compare(this, other);
        }

        public int CompareTo(object obj)
        {
            if (obj is UtcDateTime other)
                return Compare(this, other);

            if (obj is null)
                return 1;

            throw new ArgumentException(Arg_MustBeDateTime, nameof(obj));
        }

        public bool Equals(UtcDateTime other)
        {
            return Ticks == other.Ticks;
        }

        public override bool Equals(object obj)
        {
            return obj is UtcDateTime other && Equals(other);
        }

        public string[] GetDateTimeFormats(IFormatProvider provider)
        {
            return ToDateTime().GetDateTimeFormats(provider);
        }

        public string[] GetDateTimeFormats(char format, IFormatProvider provider)
        {
            return ToDateTime().GetDateTimeFormats(format, provider);
        }

        public override int GetHashCode()
        {
            return Ticks.GetHashCode();
        }

        public DateTime ToDateTime()
        {
            return IsDefault ? s_defaultDateTime : _dateTime;
        }
    }
}
