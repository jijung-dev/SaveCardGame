using PrimeTween;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private CardData _data;
    public CardData data => _data;

    [SerializeField]
    private CardDisplay _display;
    public CardDisplay display => _display;

    public CardContainer container;
    public bool isClickable;
    public bool isHoverable;
    public bool isInspectable;

    public void Enable()
    {
        isClickable = true;
        isHoverable = true;
        isInspectable = true;
    }
    public void Disable()
    {
        isClickable = false;
        isHoverable = false;
        isInspectable = false;
    }
    public void SetData(CardData data)
    {
        Disable();

        _data = data;
        _data.action = ScriptableObject.Instantiate(data.action);
        _data.action.cost = data.cost;

        display.SetData(_data);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isHoverable) return;
        Tween.Scale(transform, 1.1f, duration: 0.25f, Ease.OutElastic);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isHoverable) return;
        Tween.Scale(transform, 1f, duration: 0.25f, Ease.OutElastic);
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        if (isInspectable && eventData.button == PointerEventData.InputButton.Right)
        {
            Battle.inspectSystem.Inspect(this);
        }

        if (isClickable && eventData.button == PointerEventData.InputButton.Left)
        {
            if (_data.action.owner.energy.value < _data.cost)
            {
                DebugExt.Log($"{_data.action.owner.name}: Don't have enough energy", this);
                return;
            }

            SelectAction(_data.action);
        }

    }
    public virtual void SelectAction(PlayActionData action)
    {
        if (action.instant)
        {
            ActionQueue.Stack(action, Vector2Int.one * 10000);
            return;
        }
        Battle.player.SelectCard(this);
        Battle.hoverSystem.SetAction(action, Vector2Int.one * 10000);
    }
}
