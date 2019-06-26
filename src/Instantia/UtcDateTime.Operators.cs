namespace Instantia
{
    public readonly partial struct UtcDateTime
    {
        public static bool operator ==(UtcDateTime d1, UtcDateTime d2) => d1.Ticks == d2.Ticks;

        public static bool operator !=(UtcDateTime d1, UtcDateTime d2) => d1.Ticks != d2.Ticks;

        public static bool operator <(UtcDateTime t1, UtcDateTime t2) => t1.Ticks < t2.Ticks;

        public static bool operator <=(UtcDateTime t1, UtcDateTime t2) => t1.Ticks <= t2.Ticks;

        public static bool operator >(UtcDateTime t1, UtcDateTime t2) => t1.Ticks > t2.Ticks;

        public static bool operator >=(UtcDateTime t1, UtcDateTime t2) => t1.Ticks >= t2.Ticks;
    }
}
