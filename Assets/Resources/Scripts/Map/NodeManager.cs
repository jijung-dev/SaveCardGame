using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class NodeManager
{
    private static Dictionary<Vector2Int, Node> _tiles = new Dictionary<Vector2Int, Node>();
    public static ReadOnlyDictionary<Vector2Int, Node> tiles = new ReadOnlyDictionary<Vector2Int, Node>(_tiles);

    public static bool TryGetNode(Vector2Int pos, out Node node)
    {
        node = null;
        if (HasNode(pos))
        {
            node = GetNode(pos);
            return true;
        }
        return false;
    }

    public static bool HasNode(Vector2Int pos)
    {
        return _tiles.ContainsKey(pos);
    }

    public static Node GetNode(Vector2Int pos)
    {
        if (!_tiles.ContainsKey(pos))
        {
            DebugExt.Log($"Getting tile from {pos} failed. Tile at {pos} doesn't exist", nameof(TileManager), LogType.Error);
            return null;
        }

        return _tiles[pos];
    }

    public static void Add(Node tile)
    {
        if (_tiles.ContainsValue(tile) || _tiles.ContainsKey(tile.celPosition))
        {
            DebugExt.Log($"Adding {tile.name} to the list failed. Tile at {tile.celPosition} already exists", nameof(TileManager), LogType.Error);
            return;
        }

        _tiles.Add(tile.celPosition, tile);
    }
    public static void Remove(Node tile)
    {
        if (!_tiles.ContainsValue(tile) || !_tiles.ContainsKey(tile.celPosition))
        {
            DebugExt.Log($"Remove {tile.name} from the list failed. Tile at {tile.celPosition} doesn't exist", nameof(TileManager), LogType.Error);
            return;
        }

        _tiles.Remove(tile.celPosition);
    }
}