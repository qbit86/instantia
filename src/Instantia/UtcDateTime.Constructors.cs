using System;

#pragma warning disable CA1303 // Do not pass literals as localized parameters

namespace Instantia
{
    public readonly partial struct UtcDateTime
    {
        public UtcDateTime(long ticks) : this(new DateTime(ticks, DateTimeKind.Utc), false) { }

        public UtcDateTime(long ticks, DateTimeKind kind)
        {
            if (kind != DateTimeKind.Utc)
                throw new ArgumentException(ArgumentInvalidDateTimeKind, nameof(kind));

            _dateTime = new DateTime(ticks, DateTimeKind.Utc);
        }

        public UtcDateTime(int year, int month, int day) :
            this(new DateTime(year, month, day, 0, 0, 0, DateTimeKind.Utc))
        { }

        public UtcDateTime(int year, int month, int day, int hour, int minute, int second) :
            this(new DateTime(year, month, day, hour, minute, second, DateTimeKind.Utc))
        { }

        public UtcDateTime(int year, int month, int day, int hour, int minute, int second, DateTimeKind kind)
        {
            if (kind != DateTimeKind.Utc)
                throw new ArgumentException(ArgumentInvalidDateTimeKind, nameof(kind));

            _dateTime = new DateTime(year, month, day, hour, minute, second, DateTimeKind.Utc);
        }

        public UtcDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond) :
            this(new DateTime(year, month, day, hour, minute, second, millisecond, DateTimeKind.Utc))
        { }

        public UtcDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond,
            DateTimeKind kind)
        {
            if (kind != DateTimeKind.Utc)
                throw new ArgumentException(ArgumentInvalidDateTimeKind, nameof(kind));

            _dateTime = new DateTime(year, month, day, hour, minute, second, millisecond, DateTimeKind.Utc);
        }
    }
}
