using UnityEngine;
using static Deck;

public class BattleSystem : MonoBehaviour
{
    [HideInInspector]
    public BattleData data;

    public void BattleSetUp()
    {
        if (data is null) { DebugExt.LogError("No Battle Data found", this); return; }
        Events.InvokeOnBattleInit(data);

        //Tile Spawns
        Reference.tileSpawner.Spawn(data);
        DebugExt.Log("Spawning Tiles", this);

        //Player, Enemy Spawns
        Reference.entitySpawner.Spawn(data.enemyWave);
        DebugExt.Log("Spawning Enemies", this);
        Reference.deck.PopulateAlly();
        DebugExt.Log("Spawning Phantoms", this);
    }
    public void BattleStart()
    {
        DebugExt.Log("Starting...", this);
        Reference.deck.SetUp();
        DebugExt.Log("Populating Cards", this);
        Reference.entitySpawner.SetUp();
        DebugExt.Log("Spawning Allies", this);

        Events.InvokeOnBattleStart(data);
    }
    void BattleEnd()
    {
        Events.InvokeOnBattleEnd(data);

        //Check Win or Lose

        //Go to Map
    }
}
