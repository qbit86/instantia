# Instantia

[![Instantia version](https://img.shields.io/nuget/v/Instantia.svg)](https://www.nuget.org/packages/Instantia/)

`Instantia.UtcDateTime` is an alternative to `System.DateTime` that enforces `Kind` to be always `Utc`.

## Usage

```cs
// Intent is not clear from signature:
// which kind of `DateTime` this method supports?
private static void TakePlainDateTime(DateTime instant)
{
    if (instant.Kind != DateTimeKind.Utc)
        throw new ArgumentException(...);
    ...
}

// Usage is clear from signature:
// there is no way to pass `DateTime` of the wrong kind.
private static void TakeUtcDateTime(UtcDateTime instant)
{
    DateTime dateTime = instant.ToDateTime();
    Debug.Assert(dateTime.Kind == DateTimeKind.Utc);
    ...
}

private static void Main()
{
    DateTime localNow = DateTime.Now;
    Debug.Assert(localNow.Kind == DateTimeKind.Local);

    UtcDateTime utcNow = UtcDateTime.FromDateTime(localNow);
    TakeUtcDateTime(utcNow);
    
    // Implicit conversion from 'Instantia.UtcDateTime' to 'System.DateTime':
    TakePlainDateTime(utcNow);
}
```
