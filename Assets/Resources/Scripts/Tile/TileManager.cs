using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField]
    private TileSpawner _tileSpawner;
    public TileSpawner tileSpawner => _tileSpawner;

    private Dictionary<Vector2Int, GameTile> _tiles = new Dictionary<Vector2Int, GameTile>();

    public List<GameTile> GetAllTiles() => _tiles.Values.ToList();

    public bool HasTile(Vector2Int pos)
    {
        return _tiles.ContainsKey(pos);
    }

    public GameTile GetTile(Vector2Int pos)
    {
        if (!_tiles.ContainsKey(pos))
        {
            DebugExt.Log($"Getting tile from {pos} failed. Tile at {pos} doesn't exist", nameof(TileManager), LogType.Error);
            return null;
        }

        return _tiles[pos];
    }

    public void Add(GameTile tile)
    {
        if (_tiles.ContainsValue(tile) || _tiles.ContainsKey(tile.celPosition))
        {
            DebugExt.Log($"Adding {tile.name} to the list failed. Tile at {tile.celPosition} already exists", nameof(TileManager), LogType.Error);
            return;
        }

        _tiles.Add(tile.celPosition, tile);
    }
    public void Remove(GameTile tile)
    {
        if (!_tiles.ContainsValue(tile) || !_tiles.ContainsKey(tile.celPosition))
        {
            DebugExt.Log($"Remove {tile.name} from the list failed. Tile at {tile.celPosition} doesn't exist", nameof(TileManager), LogType.Error);
            return;
        }

        _tiles.Remove(tile.celPosition);
    }
}
