using PrimeTween;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField]
    private CardData _data;
    public CardData data => _data;
    [SerializeField]
    private CardDisplay _display;
    public CardDisplay display => _display;

    //TEST:
    [SerializeField]
    private Canvas canvas;
    //

    void Awake()
    {
        //Set up Canvas here
        _data.action.owner = Reference.player;
    }

    public void FlipUp()
    {
        _display.scale = 1;
        _display.promptUpdate = true;
    }
    public void FlipDown()
    {
        _display.scale = 0.5f;
        _display.promptUpdate = true;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Tween.Scale(transform, 1.3f, duration: 0.25f, Ease.OutElastic);
        Tween.LocalPositionY(transform, 100f, duration: 0.25f, Ease.OutElastic);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tween.Scale(transform, 1f, duration: 0.25f, Ease.OutElastic);
        Tween.LocalPositionY(transform, 0f, duration: 0.25f, Ease.OutElastic);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //FIXME: Can use action through the card
        if (eventData.button != PointerEventData.InputButton.Left)
            return;

        SelectAction(_data.action);
    }
    public virtual void SelectAction(PlayActionData action)
    {
        if (action.instant)
        {
            ActionQueue.Stack(action, Vector2Int.one * 10000);
            return;
        }
        Reference.player.SelectCard(this);
        HoverSystem.instance.SetAction(action, Vector2Int.one * 10000);
	}
}
