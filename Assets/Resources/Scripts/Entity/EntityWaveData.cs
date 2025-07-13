using System;
using UnityEngine;

[Serializable]
public class EntityWaveData
{
	public GameObject baseObject;
	public int spawnCount;
	public EntityData[] possibleEntity = new EntityData[] { };
	public Vector2Int[] possiblePosition = new Vector2Int[] { };
}