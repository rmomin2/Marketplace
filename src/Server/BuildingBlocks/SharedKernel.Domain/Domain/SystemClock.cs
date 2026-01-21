namespace Marketplace.SharedKernel.Domain;

public static class SystemClock
{
    private static DateTime? customDate;

    public static DateTime Now => customDate ?? DateTime.UtcNow;

    public static void Set(DateTime customDate) => SystemClock.customDate = customDate;

    public static void Reset() => customDate = null;
}
