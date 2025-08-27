using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class HoverSystem : MonoBehaviour
{
    public enum HoverPhase
    {
        None,
        Idle,
        Action,
    }
    [SerializeField]
    private AreaSpawner spawner;
    [SerializeField]
    private AreaSpawner hoverSpawner;
    private PlayActionData _currentAction;
    private Entity _currentEntity;

    private HoverPhase _hoverPhase = HoverPhase.Idle;
    public GameTile hoverTile
    {
        get
        {
            Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);

            Vector2Int tilePos = (Vector2Int)mouseWorldPos.RoundToInt();

            if (TileManager.HasTile(tilePos))
            {
                return tilePos;
            }

            return null;
        }
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            HandleClick();
        }

        // if (hoverTile is null || !spawner.HasTile(hoverTile.celPosition))
        // {
        //     hoverSpawner.Despawn();
        //     return;
        // }
        // if (spawner.HasTile(hoverTile.celPosition))
        // {
        //     hoverSpawner.SetArea(_currentAction.hoverArea, hoverTile.celPosition);
        //     hoverSpawner.promptUpdate = true;
        // }
    }

    public void SetAction(PlayActionData action, Vector2Int center)
    {
        DebugExt.Log($"Select Action as {action.name}", this);
        _currentAction = action;

        spawner.SetArea(action.area, center);
        spawner.promptUpdate = true;


        _hoverPhase = HoverPhase.Action;
    }

    void HandleClick()
    {
        if (hoverTile == null && !EventSystem.current.IsPointerOverGameObject())
        {
            UnSelectAll();
            return;
        }

        switch (_hoverPhase)
        {
            // case HoverPhase.Action:
            //     ActionProcessClick();
            //     break;
            default:
                break;
        }
    }
    void UnSelectEntity()
    {
        if (_currentEntity == null) return;

        _currentEntity.UnSelect();
        _currentEntity = null;
        _hoverPhase = HoverPhase.Idle;
    }
    void UnSelectAction()
    {
        if (_currentAction == null) return;

        spawner.Clear();
        _currentAction = null;
        _hoverPhase = HoverPhase.Idle;
    }
    public void UnSelectAll()
    {
        UnSelectEntity();
        UnSelectAction();
        Reference.player.UnSelectCard();
        spawner.Clear();
    }
    public void EntityProcessClick(Entity entity)
    {
        UnSelectAll();

        DebugExt.Log($"Select Entity: {entity.name}", this);
        _currentEntity = entity;

    }
    public void ActionProcessClick(GameTile hoverTile)
    {
        if (spawner.HasTile(hoverTile.celPosition))
        {
            ActionQueue.Stack(_currentAction, hoverTile.celPosition);
            if (_currentAction.owner is Player player)
            {
                player.Discard();
            }
            _currentAction.owner.energy.Hit(_currentAction.cost);
            _currentAction.owner.display.promptUpdate = true;
        }

        UnSelectAll();
    }
}