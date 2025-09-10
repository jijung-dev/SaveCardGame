using UnityEngine;

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
