using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField]
    private TileSpawner tileSpawner;
    [SerializeField]
    private BattleData _data;
    public BattleData data => _data;
    public bool isActive => _data != null;
    void Awake()
    {
        //TEST: 
        Reference.deck.ADD();
        //

        BattleSetUp();
    }

    void BattleSetUp()
    {
        if (_data is null) { DebugExt.LogError("No Battle Data found", this); return; }
        Events.InvokeOnBattleInit(_data);

        //Tile Spawns
        tileSpawner.Spawn(_data);
        DebugExt.Log("Spawning Tiles", this);

        //Player, Enemy Spawns
        Reference.entitySpawner.Spawn(_data.enemyWave);
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

        Events.InvokeOnBattleStart(_data);
    }
    void BattleEnd()
    {
        Events.InvokeOnBattleEnd(_data);

        //Check Win or Lose

        //Go to Map
    }
}
