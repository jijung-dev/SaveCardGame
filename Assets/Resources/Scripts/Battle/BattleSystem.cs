using UnityEngine;
using static Deck;

public class BattleSystem : MonoBehaviour
{
    public enum BattlePhase
    {
        None,
        Start,
        Middle,
        End,
    }
    [HideInInspector]
    public BattleData data;
    [SerializeField]
    private GameObject resultPanel;
    [SerializeField]
    private GameObject winPanel;
    [SerializeField]
    private GameObject losePanel;
    [SerializeField]
    private ActionLoadMainMenu mainMenuLoad;
    [SerializeField]
    private ActionLoadMap mapLoad;

    public BattlePhase phase = BattlePhase.None;

    public void BattleSetUp()
    {
        //Tile Spawns
        Battle.tileManager.tileSpawner.Spawn(data);
        DebugExt.Log("Spawning Tiles", this);

        //Player, Enemy Spawns
        Battle.entityManager.entitySpawner.Spawn(data.enemyWave);
        DebugExt.Log("Spawning Enemies", this);
        Battle.deck.PopulateAlly();
        DebugExt.Log("Spawning Phantoms", this);
        phase = BattlePhase.Start;
    }
    public void BattleStart()
    {
        DebugExt.Log("Starting...", this);
        Battle.deck.SetUp();
        DebugExt.Log("Populating Cards", this);
        Battle.entityManager.entitySpawner.SetUp();
        DebugExt.Log("Spawning Allies", this);

        Events.InvokeOnBattleStart(data);
        phase = BattlePhase.Middle;
    }
    void BattleEnd()
    {
        phase = BattlePhase.End;
        DebugExt.Log("Ending battle", this);
        Events.InvokeOnBattleEnd(data);
    }

    public void CheckBattleResult()
    {
        if (phase == BattlePhase.End) return;

        int enemyCount = 0;
        int allyCount = 0;
        foreach (var entity in Battle.entityManager.GetAllEntities())
        {
            if (entity is Enemy) enemyCount++;
            if (entity is Ally) allyCount++;
        }

        if (enemyCount <= 0)
        {
            BattleWin();
            return;
        }
        if (allyCount <= 0)
        {
            BattleLose();
            return;
        }
    }
    public void BattleLose()
    {
        DebugExt.Log("Battle lost", this);
        losePanel.SetActive(true);
        resultPanel.SetActive(true);
        BattleEnd();
    }

    public void BattleWin()
    {
        DebugExt.Log("Battle won", this);
        winPanel.SetActive(true);
        resultPanel.SetActive(true);
        BattleEnd();
    }
    public void BackToMap()
    {
        ActionQueue.Stack(mapLoad, Vector2Int.one * 10000);
    }
    public void BackToMainMenu()
    {
        ActionQueue.Stack(mainMenuLoad, Vector2Int.one * 10000);
    }
}
