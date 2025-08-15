using UnityEngine;

[CreateAssetMenu(fileName = "New CardData", menuName = "Card/CardData")]
public class CardData : ScriptableObject
{
    public string id;
    public Sprite sprite;
    public string title;
    public string description;
    public PlayActionData action;
    public int cost;
}
