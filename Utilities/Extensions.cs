namespace Social_Sport_Hub.Utilities;

public static class Extensions
{
    public static IReadOnlyList<T> ToPagedList<T>(this IEnumerable<T> source, int page, int size)
        => source.Skip(Math.Max(0, (page - 1) * size)).Take(size).ToList();

    public static bool IsNullOrEmpty<T>(this IEnumerable<T>? source)
        => source is null || !source.Any();
}
