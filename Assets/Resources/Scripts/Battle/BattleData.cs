using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Battle Data", menuName = "Battle/BattleData")]
public class BattleData : ScriptableObject
{
    public Vector2Int boardSize;
    public EntityWaveData enemyWave;
    public Vector2Int[] allySpawnable;
}
