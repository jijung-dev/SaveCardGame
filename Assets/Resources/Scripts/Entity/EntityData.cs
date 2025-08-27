using UnityEngine;

public class EntityData : ScriptableObject
{
	public string title;
	public string description;
	public Sprite sprite;
	public HealthData heartType;
	public CardData[] actions;
}