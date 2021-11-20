using System;
using System.Diagnostics;

[assembly: CLSCompliant(true)]

namespace Instantia
{
    internal static class Program
    {
        private static void Main()
        {
            DateTime localNow = DateTime.Now;
            Debug.Assert(localNow.Kind == DateTimeKind.Local);

            // Compile-time error: no implicit conversion from 'System.DateTime' to 'Instantia.UtcDateTime'.
            // UtcDateTime utcNow = localNow;

            // Run-time exception: invalid DateTimeKind value Local.
            // UtcDateTime utcNow = new UtcDateTime(localNow);

            // Valid explicit type conversion from 'System.DateTime' to 'Instantia.UtcDateTime'.
            UtcDateTime utcNow = UtcDateTime.FromDateTime(localNow);
            TakeUtcDateTime(utcNow);

            // There is implicit conversion from 'Instantia.UtcDateTime' to 'System.DateTime'.
            TakePlainDateTime(utcNow);
        }

        private static void TakeUtcDateTime(UtcDateTime instant)
        {
            Console.WriteLine(
                $"[{nameof(TakeUtcDateTime)}] {nameof(instant)}: {instant}, {nameof(instant.Kind)}: {instant.Kind}");

            DateTime underlyingDateTime = instant.ToDateTime();
            Debug.Assert(underlyingDateTime.Kind == DateTimeKind.Utc);
        }

        private static void TakePlainDateTime(DateTime instant)
        {
            Console.WriteLine(
                $"[{nameof(TakePlainDateTime)}] {nameof(instant)}: {instant}, {nameof(instant.Kind)}: {instant.Kind}");
        }
    }
}
