using System;

namespace Instantia
{
    public readonly partial struct UtcDateTime
    {
        public UtcDateTime(long ticks) : this(new DateTime(ticks, DateTimeKind.Utc), false) { }

        public UtcDateTime(long ticks, DateTimeKind kind)
        {
            if (kind != DateTimeKind.Utc)
                throw new ArgumentException("Invalid DateTimeKind value.", nameof(kind));

            _dateTime = new DateTime(ticks, DateTimeKind.Utc);
        }

        public UtcDateTime(int year, int month, int day) :
            this(new DateTime(year, month, day, 0, 0, 0, DateTimeKind.Utc))
        { }
    }
}
