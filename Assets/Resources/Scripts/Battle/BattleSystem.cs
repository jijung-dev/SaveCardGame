using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField]
    private TileSpawner tileSpawner;
    [SerializeField]
    private EntitySpawner entitySpawner;
    [SerializeField]
    private BattleData _data;
    public bool isActive => _data != null;
    void Awake()
    {
        BattleSetUp();

        BattleStart();
    }

    void BattleSetUp()
    {
        if (_data is null) { DebugExt.LogError("No Battle Data found", this); return; }
        Events.InvokeOnBattleInit(_data);

        //Tile Spawns
        tileSpawner.Spawn(_data);

        //Player, Enemy Spawns
        entitySpawner.Spawn(_data.enemyWave);
        entitySpawner.Spawn(_data.allyWave);

        //Populate Deck
        Reference.deck.Populate();
        Reference.deck.Draw();
    }
    void BattleStart()
    {
        Events.InvokeOnBattleStart(_data);
    }
    void BattleEnd()
    {
        Events.InvokeOnBattleEnd(_data);

        //Check Win or Lose

        //Go to Map
    }
}
