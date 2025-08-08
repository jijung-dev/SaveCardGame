using UnityEngine;

public class Reference : MonoBehaviourSingleton<Reference>
{
    public Deck _deck;
    public Player _player;
    public BattleSystem _battleSystem;
    public EntitySpawner _entitySpawner;
    public static Deck deck => instance._deck;
    public static Player player => instance._player;
    public static BattleSystem battleSystem => instance._battleSystem;
    public static EntitySpawner entitySpawner => instance._entitySpawner;
}
