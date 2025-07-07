using System;
using UnityEngine;

[Serializable]
public class EntityWaveData
{
	public GameObject baseObject;
	public int spawnCount;
	public EntityData[] possibleEntity = new EntityData[] { };
	public Vector3Int[] possiblePosition = new Vector3Int[] { };
}