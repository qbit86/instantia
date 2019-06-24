using System;

namespace Instantia
{
    public readonly partial struct UtcDateTime
    {
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

        public DateTime Value => IsDefault ? s_defaultDateTime : _dateTime;

        public static UtcDateTime FromDateTime(DateTime dateTime)
        {
            if (dateTime.Kind != DateTimeKind.Utc)
                return new UtcDateTime(dateTime.ToUniversalTime(), false);

            return new UtcDateTime(dateTime, false);
        }
    }
}
