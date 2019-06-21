using System;

namespace Instantia
{
    public readonly struct UtcDateTime
    {
        private static readonly DateTime s_defaultDateTime = new DateTime(0, DateTimeKind.Utc);

        private readonly DateTime _dateTime;

        public UtcDateTime(DateTime dateTime)
        {
            if (dateTime.Kind != DateTimeKind.Utc)
                throw new ArgumentException("Invalid DateTimeKind value.", nameof(dateTime));

            _dateTime = dateTime;
        }

        public bool IsDefault => _dateTime.Kind == default;

        public DateTime Value => IsDefault ? s_defaultDateTime : _dateTime;
    }
}
