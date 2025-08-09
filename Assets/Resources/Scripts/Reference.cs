using UnityEngine;


public class Reference : MonoBehaviour
{
    private static Deck _deck;
    private static Player _player;
    private static BattleSystem _battleSystem;
    private static EntitySpawner _entitySpawner;
    private static TileSpawner _tileSpawner;
    private static HoverSystem _hoverSystem;

    public static Deck deck => _deck;
    public static Player player => _player;
    public static BattleSystem battleSystem => _battleSystem;
    public static EntitySpawner entitySpawner => _entitySpawner;
    public static TileSpawner tileSpawner => _tileSpawner;
    public static HoverSystem hoverSystem => _hoverSystem;

    void Awake()
    {
        _deck = FindByTag<Deck>("Deck");
        _player = FindByTag<Player>("Player");
        _battleSystem = FindByTag<BattleSystem>("BattleSystem");
        _entitySpawner = FindByTag<EntitySpawner>("EntitySpawner");
        _tileSpawner = FindByTag<TileSpawner>("TileSpawner");
        _hoverSystem = FindByTag<HoverSystem>("HoverSystem");
        var initiator = FindByTag<BattleInitiator>("BattleInitiator");
        initiator.InitBattle();
    }

    private T FindByTag<T>(string tag) where T : Component
    {
        var obj = GameObject.FindGameObjectWithTag(tag);
        return obj != null && obj.TryGetComponent<T>(out var component)
            ? component
            : null;
    }
}
