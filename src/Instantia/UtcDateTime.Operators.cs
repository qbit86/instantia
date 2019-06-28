using System;

namespace Instantia
{
    public readonly partial struct UtcDateTime
    {
        public static UtcDateTime operator +(UtcDateTime d, TimeSpan t) =>
            new UtcDateTime(d.ToDateTime().Add(t), false);

        public static bool operator ==(UtcDateTime d1, UtcDateTime d2) => d1.Ticks == d2.Ticks;

        public static bool operator !=(UtcDateTime d1, UtcDateTime d2) => d1.Ticks != d2.Ticks;

        public static bool operator <(UtcDateTime t1, UtcDateTime t2) => t1.Ticks < t2.Ticks;

        public static bool operator <=(UtcDateTime t1, UtcDateTime t2) => t1.Ticks <= t2.Ticks;

        public static bool operator >(UtcDateTime t1, UtcDateTime t2) => t1.Ticks > t2.Ticks;

        public static bool operator >=(UtcDateTime t1, UtcDateTime t2) => t1.Ticks >= t2.Ticks;

        public static TimeSpan operator -(UtcDateTime d1, UtcDateTime d2) => new TimeSpan(d1.Ticks - d2.Ticks);

        public static UtcDateTime operator -(UtcDateTime d, TimeSpan t) =>
            new UtcDateTime(d.ToDateTime().Subtract(t), false);

        public static explicit operator DateTime(UtcDateTime d) => d.ToDateTime();
    }
}
