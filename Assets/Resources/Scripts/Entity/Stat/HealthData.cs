using UnityEngine;

[CreateAssetMenu(fileName = "New HealthData", menuName = "StatusData/New HealthData")]
public class HealthData : ScriptableObject
{
	public int capacity = 1;
	public Sprite[] sprites;
}