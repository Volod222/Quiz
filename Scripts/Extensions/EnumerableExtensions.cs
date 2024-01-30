using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public static class EnumerableExtensions
{
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
    {
        Random random = new Random();
        return source.OrderBy(item => random.Next());
    } 
}
