using System;

namespace Instantia
{
    public readonly partial struct UtcDateTime
    {
        private static readonly DateTime s_defaultDateTime = new DateTime(0L, DateTimeKind.Utc);

        private readonly DateTime _dateTime;

        public UtcDateTime(DateTime dateTime)
        {
            if (dateTime.Kind != DateTimeKind.Utc)
                throw new ArgumentException("Invalid DateTimeKind value.", nameof(dateTime));

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
