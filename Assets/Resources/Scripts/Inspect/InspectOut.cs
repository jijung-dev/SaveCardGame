using UnityEngine;
using UnityEngine.EventSystems;


public class InspectOut : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left || eventData.button == PointerEventData.InputButton.Right)
        {
            Battle.inspectSystem.Clear();
        }
    }
}
