using System;

namespace Instantia
{
    public readonly partial struct UtcDateTime
    {
        private const string Argument_InvalidDateTimeKind = "Invalid DateTimeKind value.";

        private static readonly DateTime s_defaultDateTime = new DateTime(0L, DateTimeKind.Utc);

        public static readonly DateTime MinValue = new DateTime(DateTime.MinValue.Ticks, DateTimeKind.Utc);

        public static readonly DateTime MaxValue = new DateTime(DateTime.MaxValue.Ticks, DateTimeKind.Utc);

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

        public bool IsDefault => _dateTime.Kind == default;

        public DateTime Value => IsDefault ? s_defaultDateTime : _dateTime;

        public static UtcDateTime FromDateTime(DateTime dateTime)
        {
            if (dateTime.Kind != DateTimeKind.Utc)
                return new UtcDateTime(dateTime.ToUniversalTime(), false);

            return new UtcDateTime(dateTime, false);
        }
    }
}
