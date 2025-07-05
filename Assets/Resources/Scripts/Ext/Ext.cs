using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ext { }

public static class DebugExt
{
    public static void Log(string message, UnityEngine.Object obj)
    {
        string label = obj is GameObject go ? go.name : obj.GetType().Name;
        Log(message, label, LogType.Log);
    }

    public static void LogWarning(string message, UnityEngine.Object obj)
    {
        string label = obj is GameObject go ? go.name : obj.GetType().Name;
        Log(message, label, LogType.Warning);
    }

    public static void LogError(string message, UnityEngine.Object obj)
    {
        string label = obj is GameObject go ? go.name : obj.GetType().Name;
        Log(message, label, LogType.Error);
    }

    public static void Log(string message, string obj, LogType type = LogType.Log)
    {
        if (obj == null || string.IsNullOrEmpty(message))
            return;

        switch (type)
        {
            case LogType.Log:
                Debug.Log($"[{obj}] : {message}");
                break;
            case LogType.Warning:
                Debug.LogWarning($"[{obj}] : {message}");
                break;
            case LogType.Error:
                Debug.LogError($"[{obj}] : {message}");
                break;
            default:
                Debug.Log($"[{obj}] : {message}");
                break;
        }
    }
}

public static class VectorExt
{
    public static Vector3Int FloorToInt(this Vector3 vector)
    {
        return new Vector3Int(Mathf.FloorToInt(vector.x), Mathf.FloorToInt(vector.y), Mathf.FloorToInt(vector.z));
    }
}

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
public static class ArrayExt
{
    public static T[] Remove<T>(this T[] array, T item)
    {
        var list = array.ToList();
        list.Remove(item);
        return list.ToArray();
    }
}

public class Scriptable<T>
    where T : ScriptableObject, new()
{
    readonly Action<T> modifier;

    public Scriptable() { }

    public Scriptable(Action<T> modifier)
    {
        this.modifier = modifier;
    }

    public static implicit operator T(Scriptable<T> scriptable)
    {
        T result = ScriptableObject.CreateInstance<T>();
        scriptable.modifier?.Invoke(result);
        return result;
    }
}
