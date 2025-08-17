using UnityEngine;


public class Reference : MonoBehaviourSingleton<Reference>
{
    private static Deck _deck;
    private static Player _player;
    private static BattleSystem _battleSystem;
    private static EntitySpawner _entitySpawner;
    private static TileSpawner _tileSpawner;
    private static HoverSystem _hoverSystem;
    private static NodeSpawner _nodeSpawner;
    private static InspectSystem _inspectSystem;

    public static Deck deck => _deck;
    public static Player player => _player;
    public static BattleSystem battleSystem => _battleSystem;
    public static EntitySpawner entitySpawner => _entitySpawner;
    public static TileSpawner tileSpawner => _tileSpawner;
    public static HoverSystem hoverSystem => _hoverSystem;
    public static NodeSpawner nodeSpawner => _nodeSpawner;
    public static InspectSystem inspectSystem => _inspectSystem;
    protected override void Awake()
    {
        base.Awake();
        Events.OnBattleInit += (data) => InBattle();
        Events.OnBattleEnd += (data) => OutBattle();
        Events.OnCampaignInit += (data) => InCampaign();
        Events.OnCampaignEnd += (data) => OutCampaign();
    }
    void InCampaign()
    {
        _nodeSpawner = FindByTag<NodeSpawner>("NodeSpawner");
    }
    void OutCampaign()
    {
        _nodeSpawner = null;
    }

    void InBattle()
    {
        _deck = FindByTag<Deck>("Deck");
        _player = FindByTag<Player>("Player");
        _battleSystem = FindByTag<BattleSystem>("BattleSystem");
        _entitySpawner = FindByTag<EntitySpawner>("EntitySpawner");
        _tileSpawner = FindByTag<TileSpawner>("TileSpawner");
        _hoverSystem = FindByTag<HoverSystem>("HoverSystem");
        _inspectSystem = FindByTag<InspectSystem>("InspectSystem");
    }
    void OutBattle()
    {
        _deck = null;
        _player = null;
        _battleSystem = null;
        _entitySpawner = null;
        _tileSpawner = null;
        _hoverSystem = null;
        _inspectSystem = null;

        // var initiator = FindByTag<BattleInitiator>("BattleInitiator");
        // initiator.InitBattle();
    }

    private T FindByTag<T>(string tag) where T : Component
    {
        var obj = GameObject.FindGameObjectWithTag(tag);
        return obj != null && obj.TryGetComponent<T>(out var component)
            ? component
            : null;
    }
}
