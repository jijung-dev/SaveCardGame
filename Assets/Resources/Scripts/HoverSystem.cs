using UnityEngine;
using UnityEngine.InputSystem;

public class HoverSystem : MonoBehaviourSingleton<HoverSystem>
{
    public enum HoverPhase
    {
        Entity,
        Action,
        None
    }
    [SerializeField]
    private AreaSpawner spawner;
    [SerializeField]
    private AreaSpawner hoverSpawner;
    private PlayActionData _currentAction;
    private Entity _currentEntity;

    private HoverPhase _hoverPhase = HoverPhase.Entity;
    public Vector2Int? hoverTile
    {
        get
        {
            if (Mouse.current == null || Camera.main == null)
                return null;

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

    //TEST: 
    [SerializeField]
    private Transform knob;
    //

    void Update()
    {
        if (hoverTile != null)
            knob.position = (Vector3Int)hoverTile.Value;
        else
        {
            Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            knob.position = mouseWorldPos;
        }

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            HandleClick();
        }

        if (hoverTile is null || _hoverPhase is not HoverPhase.Action || !spawner.HasTile(hoverTile.Value))
        {
            hoverSpawner.Despawn();
            return;
        }
        //When enter doesn't update

        if (hoverSpawner.IsDifferentCenter(hoverTile.Value))
        {
            hoverSpawner.SetArea(_currentAction.hoverArea, hoverTile.Value);
            hoverSpawner.promptUpdate = true;
        }
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
        if (hoverTile == null)
        {
            UnSelectEntity();
            UnSelectAction();
            return;
        }

        switch (_hoverPhase)
        {
            case HoverPhase.Entity:
                EntityProcessClick();
                break;
            case HoverPhase.Action:
                ActionProcessClick();
                break;
            default:
                break;
        }
    }
    void UnSelectEntity()
    {
        if (_currentEntity == null) return;

        _currentEntity.UnSelect();
        _currentEntity = null;
        _hoverPhase = HoverPhase.Entity;
    }
    void UnSelectAction()
    {
        if (_currentAction == null) return;

        spawner.Clear();
        _currentAction = null;
        _hoverPhase = HoverPhase.Entity;
    }
    void EntityProcessClick()
    {
        //Glitch when click too close
        UnSelectEntity();
        if (EntityManager.TryGetEntity(hoverTile, out Entity entity))
        {
            DebugExt.Log($"Select Entity: {entity.name}", this);
            entity.Select();
            _currentEntity = entity;
        }
    }
    void ActionProcessClick()
    {
        UnSelectAction();
        //Put Action.Run in ActionQueue
    }
}