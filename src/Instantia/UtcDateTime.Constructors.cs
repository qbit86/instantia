using System;
using System.Diagnostics;

#pragma warning disable CA1303 // Do not pass literals as localized parameters

namespace Instantia;

public readonly partial struct UtcDateTime
{
    public UtcDateTime(DateTime dateTime)
    {
        if (dateTime.Kind != DateTimeKind.Utc)
            throw new ArgumentException(ArgumentInvalidDateTimeKind, nameof(dateTime));

        _dateTime = dateTime;
    }

    public UtcDateTime(long ticks) : this(new(ticks, DateTimeKind.Utc), false) { }

    public UtcDateTime(int year, int month, int day) :
        this(new(year, month, day, 0, 0, 0, DateTimeKind.Utc), false) { }

    public UtcDateTime(int year, int month, int day, int hour, int minute, int second) :
        this(new(year, month, day, hour, minute, second, DateTimeKind.Utc), false) { }

    public UtcDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond) :
        this(new(year, month, day, hour, minute, second, millisecond, DateTimeKind.Utc), false) { }

#pragma warning disable CA1801 // Review unused parameters
    // ReSharper disable once UnusedParameter.Local
    private UtcDateTime(DateTime dateTime, bool _)
    {
        Debug.Assert(dateTime.Kind == DateTimeKind.Utc, "dateTime.Kind == DateTimeKind.Utc");

        _dateTime = dateTime;
    }
#pragma warning restore CA1801 // Review unused parameters
}
