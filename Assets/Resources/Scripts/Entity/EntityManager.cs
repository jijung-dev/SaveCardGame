using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    [SerializeField]
    private EntitySpawner _entitySpawner;
    public EntitySpawner entitySpawner => _entitySpawner;

    private HashSet<Entity> _entities = new HashSet<Entity>();

    public List<Entity> GetAllEntities() => _entities.ToList();

    public bool HasEntity(GameTile tile)
    {
        return _entities.Any(r => r.container == tile);
    }
    public bool TryGetEntity(GameTile tile, out Entity entity)
    {
        entity = GetEntity(tile);
        return HasEntity(tile);
    }
    public Entity[] GetAllPhantom()
    {
        var phantoms = _entities.Where(r => r is Phantom);
        return phantoms.ToArray();
    }

    public Entity GetEntity(GameTile tile)
    {
        var entity = _entities.FirstOrDefault(r => r.container == tile);

        // if (entity == null)
        // {
        //     DebugExt.Log(
        //         $"Getting entity from {tile.celPosition} failed. Entity at {tile.celPosition} doesn't exist",
        //         nameof(EntityManager),
        //         LogType.Error
        //     );
        // }

        return entity;
    }

    public void Add(Entity entity)
    {
        if (_entities.Contains(entity))
        {
            DebugExt.Log($"Adding {entity.name} to the list failed. Entity {entity.name} already exists", nameof(EntityManager), LogType.Error);
            return;
        }

        _entities.Add(entity);
    }
    public void Remove(Entity entity)
    {
        if (!_entities.Contains(entity))
        {
            DebugExt.Log($"Remove {entity.name} from the list failed. Entity {entity.name} doesn't exist", nameof(EntityManager), LogType.Error);
            return;
        }

        _entities.Remove(entity);
    }
}
