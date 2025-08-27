using UnityEngine;
using UnityEngine.EventSystems;

public class EntitySelect : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private Entity entity;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Reference.inspectSystem.Inspect(entity);
        }

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            entity.Select();
        }
    }
}
