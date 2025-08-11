using System.Collections.Generic;
using UnityEngine;

public class AreaSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject areaSpot;
    private Dictionary<Vector2Int, GameObject> _spots = new Dictionary<Vector2Int, GameObject>();
    private Area _area;
    private Vector2Int _center;
    public bool promptUpdate;
    public bool IsDifferentCenter(Vector2Int center) => _center != center;

    public bool HasTile(Vector2Int pos)
    {
        return _spots.Count > 0 && _spots.ContainsKey(pos);
    }

    public void SetArea(Area area, Vector2Int center)
    {
        _area = area;
        _center = center;
    }
    public void Clear()
    {
        _area = null;
        _center = Vector2Int.zero;
        Despawn();
    }

    public void Spawn()
    {
        //Check if _center = null then use full board area

        var tilePoses = _area.GetTile(_center);
        foreach (var item in tilePoses)
        {
            var spot = Instantiate(areaSpot, (Vector3Int)item, Quaternion.identity, transform);
            spot.GetComponent<AreaSpot>().SetTile(item);
            _spots.Add(item, spot);
        }
    }

    public void Despawn()
    {
        foreach (var item in _spots)
        {
            Destroy(item.Value);
        }
        _spots.Clear();
    }

    void Update()
    {
        if (promptUpdate)
        {
            promptUpdate = false;
            Despawn();
            Spawn();
        }
    }
}
