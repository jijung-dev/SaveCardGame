using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    public void Spawn(EntityWaveData data)
    {
        var possiblePosition = data.possiblePosition.ToList();
        var possibleEntity = data.possibleEntity.ToList();
        for (int i = 0; i < data.spawnCount; i++)
        {
            var ranPos = possiblePosition.RandomItem();
            var ranEntity = possibleEntity.RandomItem();
            
            var entity = Instantiate(data.baseObject, (Vector3Int)ranPos, Quaternion.identity, transform).GetComponent<Entity>();
            entity.data = ranEntity;
            possiblePosition.Remove(ranPos);
        }
    }
}
