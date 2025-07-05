using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField]
    private TileSpawner tileSpawner;
    [SerializeField]
    private EntitySpawner entitySpawner;
    [SerializeField]
    private Deck deck;
    private BattleData _data;
    public bool isActive => _data != null;
    void Awake()
    {
        BattleSetUp();

        BattleStart();
    }

    void BattleSetUp()
    {
        Events.InvokeOnBattleInit(_data);

        //Tile Spawns
        tileSpawner.Spawn(_data);

        //Player, Enemy Spawns
        entitySpawner.Spawn(_data.enemyWave);
        entitySpawner.Spawn(_data.allyWave);

        //Populate Deck
        deck.Draw();
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
