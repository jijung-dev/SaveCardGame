using UnityEngine;

[RequireComponent(typeof(Card))]
public class CardDisplay : MonoBehaviour
{
    public float scale;
	public bool promptUpdate;

	void Update()
	{
		if (promptUpdate)
		{
			promptUpdate = false;
			transform.localScale = Vector3.one * scale;
		}
	}
}