using UnityEngine;
using UnityEngine.EventSystems;

public class AreaSpot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // private AreaSelector _selector;
    // private GameTile _tile;
    // void Awake()
    // {
    //     _selector = transform.parent.GetComponent<AreaSelector>();
    // }
    // public void SetTile(GameTile tile)
    // {
    //     _tile = tile;
    // }
    public void OnPointerEnter(PointerEventData eventData)
    {
        //_selector.Hover(_tile.celPosition);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       // _selector.Hover(null);
    }
}
