using UnityEngine;

public class Card : MonoBehaviour
{
    private CardData _data;
    [SerializeField]
    private CardDisplay display;

    public void FlipUp()
    {
        display.scale = 1;
        display.promptUpdate = true;
    }
    public void FlipDown()
    {
        display.scale = 0.5f;
        display.promptUpdate = true;
    }
}
