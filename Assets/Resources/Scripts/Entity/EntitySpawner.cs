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

            Instantiate(ranEntity, ranPos, Quaternion.identity, transform);
            possiblePosition.Remove(ranPos);
        }
    }
}
