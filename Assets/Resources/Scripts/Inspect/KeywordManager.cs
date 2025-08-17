using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class KeywordManager
{
    private static Dictionary<string, KeywordData> _keywords = new Dictionary<string, KeywordData>();
    public static ReadOnlyDictionary<string, KeywordData> keywords = new ReadOnlyDictionary<string, KeywordData>(_keywords);

    public static bool HasKeyword(string name)
    {
        return _keywords.ContainsKey(name);
    }

    public static KeywordData GetKeyword(string name)
    {
        if (!_keywords.ContainsKey(name))
        {
            DebugExt.Log($"Getting tile from {name} failed. Tile at {name} doesn't exist", nameof(TileManager), LogType.Error);
            return null;
        }

        return _keywords[name];
    }

    public static void Add(KeywordData keyword)
    {
        if (_keywords.ContainsValue(keyword))
        {
            DebugExt.Log($"Adding {keyword.name} to the list failed. Keyword at {keyword.title} already exists", nameof(KeywordManager), LogType.Error);
            return;
        }

        _keywords.Add(keyword.title, keyword);
    }
    public static void Remove(KeywordData keyword)
    {
        if (!_keywords.ContainsValue(keyword))
        {
            DebugExt.Log($"Remove {keyword.name} from the list failed. Keyword at {keyword.title} doesn't exist", nameof(KeywordManager), LogType.Error);
            return;
        }

        _keywords.Remove(keyword.title);
    }
}
