using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AreaSpot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private GameTile _tile;
    public void SetTile(GameTile tile)
    {
        _tile = tile;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().color = Color.red;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().color = Color.green;
    }
    public void Select()
    {
        Battle.hoverSystem.ActionProcessClick(_tile);
    }
}
