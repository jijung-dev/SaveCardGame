using System.Collections.Generic;
using UnityEngine;

public class TileManager
{
    private static Dictionary<Vector3Int, GameTile> _tiles = new Dictionary<Vector3Int, GameTile>();

    public static bool HasTile(Vector3Int pos)
    {
        return _tiles.ContainsKey(pos);
    }

    public static GameTile GetTile(Vector3Int pos)
    {
        if (!_tiles.ContainsKey(pos))
        {
            DebugExt.Log($"Getting tile from {pos} failed. Tile at {pos} doesn't exist", nameof(TileManager), LogType.Error);
            return null;
        }

        return _tiles[pos];
    }

    public static void Add(GameTile tile)
    {
        if (_tiles.ContainsValue(tile) || _tiles.ContainsKey(tile.celPosition))
        {
            DebugExt.Log($"Adding {tile.name} to the list failed. Tile at {tile.celPosition} already exists", nameof(TileManager), LogType.Error);
            return;
        }

        _tiles.Add(tile.celPosition, tile);
    }
    public static void Remove(GameTile tile)
    {
        if (!_tiles.ContainsValue(tile) || !_tiles.ContainsKey(tile.celPosition))
        {
            DebugExt.Log($"Remove {tile.name} from the list failed. Tile at {tile.celPosition} doesn't exist", nameof(TileManager), LogType.Error);
            return;
        }

        _tiles.Remove(tile.celPosition);
    }
}
