using UnityEngine;

public class Battle : MonoBehaviour
{
	public static Battle instance { get; private set; }

	void Awake()
	{
		instance = this;
	}

	[SerializeField]
	private Deck _deck;
	[SerializeField]
	private Player _player;

	[SerializeField]
	private BattleSystem _battleSystem;
	[SerializeField]
	private HoverSystem _hoverSystem;
	[SerializeField]
	private InspectSystem _inspectSystem;

	[SerializeField]
	private EntityManager _entityManager;
	[SerializeField]
	private TileManager _tileManager;

	public static Deck deck => instance._deck;
	public static Player player => instance._player;

	public static BattleSystem battleSystem => instance._battleSystem;
	public static HoverSystem hoverSystem => instance._hoverSystem;

	public static InspectSystem inspectSystem => instance._inspectSystem;
	public static EntityManager entityManager => instance._entityManager;
	public static TileManager tileManager => instance._tileManager;
}