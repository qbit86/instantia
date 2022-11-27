using System;
using System.Globalization;

#pragma warning disable CA1303 // Do not pass literals as localized parameters

namespace Instantia;

public readonly partial struct UtcDateTime : IComparable, IFormattable, IComparable<UtcDateTime>,
    IEquatable<UtcDateTime>
{
    private const string ArgMustBeDateTime = "Object must be of type DateTime.";
    private const string ArgumentInvalidDateTimeKind = "Invalid DateTimeKind value.";
    private static readonly DateTime s_defaultDateTime = new(0L, DateTimeKind.Utc);

    public static readonly UtcDateTime MinValue = new(DateTime.MinValue.Ticks);

    public static readonly UtcDateTime MaxValue = new(DateTime.MaxValue.Ticks);

#if NETCOREAPP3_1 || NETSTANDARD2_1
    public static readonly UtcDateTime UnixEpoch = new(DateTime.UnixEpoch, false);
#endif

    private readonly DateTime _dateTime;

    public UtcDateTime Date => IsDefault ? new(0L) : new UtcDateTime(_dateTime.Date, false);

    public int Day => _dateTime.Day;

    public DayOfWeek DayOfWeek => _dateTime.DayOfWeek;

    public int DayOfYear => _dateTime.DayOfYear;

    public int Hour => _dateTime.Hour;

    public bool IsDefault => _dateTime.Kind == default;

#pragma warning disable CA1822 // Mark members as static
    public DateTimeKind Kind => DateTimeKind.Utc;
#pragma warning restore CA1822 // Mark members as static

    public int Millisecond => _dateTime.Millisecond;

    public int Minute => _dateTime.Minute;

    public int Month => _dateTime.Month;

    public int Second => _dateTime.Second;

    public long Ticks => _dateTime.Ticks;

    public TimeSpan TimeOfDay => _dateTime.TimeOfDay;

    public int Year => _dateTime.Year;

    public UtcDateTime Add(TimeSpan value)
    {
        DateTime dateTime = ToDateTime().Add(value);
        return new(dateTime, false);
    }

    public UtcDateTime AddDays(double value)
    {
        DateTime dateTime = ToDateTime().AddDays(value);
        return new(dateTime, false);
    }

    public UtcDateTime AddHours(double value)
    {
        DateTime dateTime = ToDateTime().AddHours(value);
        return new(dateTime, false);
    }

    public UtcDateTime AddMilliseconds(double value)
    {
        DateTime dateTime = ToDateTime().AddMilliseconds(value);
        return new(dateTime, false);
    }

    public UtcDateTime AddMinutes(double value)
    {
        DateTime dateTime = ToDateTime().AddMinutes(value);
        return new(dateTime, false);
    }

    public UtcDateTime AddMonths(int months)
    {
        DateTime dateTime = ToDateTime().AddMonths(months);
        return new(dateTime, false);
    }

    public UtcDateTime AddSeconds(double value)
    {
        DateTime dateTime = ToDateTime().AddSeconds(value);
        return new(dateTime, false);
    }

    public UtcDateTime AddTicks(long value) => new(_dateTime.Ticks + value);

    public UtcDateTime AddYears(int value)
    {
        DateTime dateTime = ToDateTime().AddYears(value);
        return new(dateTime, false);
    }

    public int CompareTo(UtcDateTime other) => Compare(this, other);

    public int CompareTo(object obj)
    {
        if (obj is UtcDateTime other)
            return Compare(this, other);

        if (obj is null)
            return 1;

        throw new ArgumentException(ArgMustBeDateTime, nameof(obj));
    }

    public bool Equals(UtcDateTime other) => Ticks == other.Ticks;

    public override bool Equals(object obj) => obj is UtcDateTime other && Equals(other);

    public string[] GetDateTimeFormats(IFormatProvider provider) => ToDateTime().GetDateTimeFormats(provider);

    public string[] GetDateTimeFormats(char format, IFormatProvider provider) =>
        ToDateTime().GetDateTimeFormats(format, provider);

    public override int GetHashCode() => Ticks.GetHashCode();

    public TimeSpan Subtract(UtcDateTime value) => new(Ticks - value.Ticks);

    public UtcDateTime Subtract(TimeSpan value)
    {
        DateTime dateTime = ToDateTime().Subtract(value);
        return new(dateTime, false);
    }

    public long ToBinary() => ToDateTime().ToBinary();

    public DateTime ToDateTime() => IsDefault ? s_defaultDateTime : _dateTime;

    public DateTimeOffset ToDateTimeOffset() => new(ToDateTime());

    public long ToFileTimeUtc() => ToDateTime().ToFileTimeUtc();

    public override string ToString() => ToDateTime().ToString("u", CultureInfo.InvariantCulture);

    public string ToString(IFormatProvider provider) => ToDateTime().ToString(provider);

    public string ToString(string format, IFormatProvider formatProvider) =>
        ToDateTime().ToString(format, formatProvider);

#if NETCOREAPP3_1 || NETSTANDARD2_1
    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default,
        IFormatProvider provider = null) =>
        ToDateTime().TryFormat(destination, out charsWritten, format, provider);
#endif
}
