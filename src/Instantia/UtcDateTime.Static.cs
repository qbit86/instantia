using System;
using System.Globalization;

namespace Instantia
{
    public readonly partial struct UtcDateTime
    {
        [Obsolete("Please use GetCurrent() instead.")]
        public static UtcDateTime UtcNow => new UtcDateTime(DateTime.UtcNow, false);

        public static int Compare(UtcDateTime t1, UtcDateTime t2)
        {
            return t1.Ticks.CompareTo(t2.Ticks);
        }

        public static bool Equals(UtcDateTime t1, UtcDateTime t2)
        {
            return t1.Ticks == t2.Ticks;
        }

        public static int DaysInMonth(int year, int month)
        {
            return DateTime.DaysInMonth(year, month);
        }

        public static UtcDateTime FromBinary(long dateData)
        {
            DateTime dateTime = DateTime.FromBinary(dateData);
            return FromDateTime(dateTime);
        }

        public static UtcDateTime FromDateTime(DateTime dateTime)
        {
            return dateTime.Kind == DateTimeKind.Utc
                ? new UtcDateTime(dateTime, false)
                : new UtcDateTime(dateTime.ToUniversalTime(), false);
        }

        public static UtcDateTime FromDateTimeOffset(DateTimeOffset dateTimeOffset)
        {
            return new UtcDateTime(dateTimeOffset.UtcDateTime, false);
        }

        public static UtcDateTime FromFileTimeUtc(long fileTime)
        {
            DateTime dateTime = DateTime.FromFileTimeUtc(fileTime);
            return new UtcDateTime(dateTime, false);
        }

#pragma warning disable CA1024 // Use properties where appropriate
        public static UtcDateTime GetCurrent()
        {
            return new UtcDateTime(DateTime.UtcNow, false);
        }
#pragma warning restore CA1024 // Use properties where appropriate

        public static UtcDateTime Parse(string s, IFormatProvider provider)
        {
            DateTime dateTime = DateTime.Parse(s, provider);
            return FromDateTime(dateTime);
        }

        public static UtcDateTime Parse(string s, IFormatProvider provider, DateTimeStyles styles)
        {
            DateTime dateTime = DateTime.Parse(s, provider, styles);
            return FromDateTime(dateTime);
        }

#if NETCOREAPP2_1 || NETSTANDARD2_1
        public static UtcDateTime Parse(ReadOnlySpan<char> s, IFormatProvider provider = null,
            DateTimeStyles styles = DateTimeStyles.None)
        {
            DateTime dateTime = DateTime.Parse(s, provider, styles);
            return FromDateTime(dateTime);
        }
#endif

        public static UtcDateTime ParseExact(string s, string format, IFormatProvider provider)
        {
            DateTime dateTime = DateTime.ParseExact(s, format, provider);
            return FromDateTime(dateTime);
        }

        public static UtcDateTime ParseExact(string s, string format, IFormatProvider provider, DateTimeStyles style)
        {
            DateTime dateTime = DateTime.ParseExact(s, format, provider, style);
            return FromDateTime(dateTime);
        }

        public static UtcDateTime ParseExact(string s, string[] formats, IFormatProvider provider, DateTimeStyles style)
        {
            DateTime dateTime = DateTime.ParseExact(s, formats, provider, style);
            return FromDateTime(dateTime);
        }

#if NETCOREAPP2_1 || NETSTANDARD2_1
        public static UtcDateTime ParseExact(ReadOnlySpan<char> s, ReadOnlySpan<char> format,
            IFormatProvider provider, DateTimeStyles style = DateTimeStyles.None)
        {
            DateTime dateTime = DateTime.ParseExact(s, format, provider, style);
            return FromDateTime(dateTime);
        }

        public static UtcDateTime ParseExact(ReadOnlySpan<char> s, string[] formats, IFormatProvider provider,
            DateTimeStyles style = DateTimeStyles.None)
        {
            DateTime dateTime = DateTime.ParseExact(s, formats, provider, style);
            return FromDateTime(dateTime);
        }
#endif

        public static bool TryParse(string s, IFormatProvider provider, DateTimeStyles styles, out UtcDateTime result)
        {
            bool success = DateTime.TryParse(s, provider, styles, out DateTime dateTime);
            result = FromDateTime(dateTime);
            return success;
        }

#if NETCOREAPP2_1 || NETSTANDARD2_1
        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider provider, DateTimeStyles styles,
            out UtcDateTime result)
        {
            bool success = DateTime.TryParse(s, provider, styles, out DateTime dateTime);
            result = FromDateTime(dateTime);
            return success;
        }

        public static bool TryParseExact(ReadOnlySpan<char> s, ReadOnlySpan<char> format, IFormatProvider provider,
            DateTimeStyles style, out UtcDateTime result)
        {
            bool success = DateTime.TryParseExact(s, format, provider, style, out DateTime dateTime);
            result = FromDateTime(dateTime);
            return success;
        }

        public static bool TryParseExact(ReadOnlySpan<char> s, string[] formats, IFormatProvider provider,
            DateTimeStyles style, out UtcDateTime result)
        {
            bool success = DateTime.TryParseExact(s, formats, provider, style, out DateTime dateTime);
            result = FromDateTime(dateTime);
            return success;
        }
#endif

        public static bool TryParseExact(string s, string format, IFormatProvider provider, DateTimeStyles style,
            out UtcDateTime result)
        {
            bool success = DateTime.TryParseExact(s, format, provider, style, out DateTime dateTime);
            result = FromDateTime(dateTime);
            return success;
        }

        public static bool TryParseExact(string s, string[] formats, IFormatProvider provider, DateTimeStyles style,
            out UtcDateTime result)
        {
            bool success = DateTime.TryParseExact(s, formats, provider, style, out DateTime dateTime);
            result = FromDateTime(dateTime);
            return success;
        }
    }
}
