using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class CollectionExt
{
    public static T RandomItem<T>(this IList<T> collection)
    {
        try
        {
            return collection[collection.RandomIndex()];
        }
        catch (Exception e)
        {
            throw new Exception("Failed to get random item from collection.", e);
        }
    }

    public static T RandomTopItem<T>(this IList<T> collection, int top)
    {
        var ran = UnityEngine.Random.Range(0, top);
        var check = Mathf.Min(ran, collection.Count - 1);
        return collection[check];
    }

    public static IList<T> GetTopItem<T>(this IList<T> collection, int top)
    {
        int count = Mathf.Min(top, collection.Count);
        return collection.Take(count).ToList();
    }

    public static int RandomIndex<T>(this IList<T> collection)
    {
        return UnityEngine.Random.Range(0, collection.Count);
    }
}
