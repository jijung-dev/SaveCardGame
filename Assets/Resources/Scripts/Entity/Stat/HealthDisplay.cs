using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
	[SerializeField]
	private Entity owner;
	[SerializeField]
	private GameObject heartBase;
	public bool promptUpdate;

	void Update()
	{
		if (promptUpdate)
		{
			promptUpdate = false;

			//Remove current heart
			foreach (Transform item in transform)
			{
				Destroy(item.gameObject);
			}

			var healthValue = owner.health.value;
			var heartType = owner.data.heartType;

			int heartAmount = healthValue / heartType.capacity;
			int remainAmount = healthValue % heartType.capacity;

			//FIXME: Weird ahh sprite set
			for (int i = 0; i < heartAmount; i++)
			{
				var heart = Instantiate(heartBase, transform).GetComponent<Image>();
				//Get last sprite
				heart.sprite = heartType.sprites[^1];
			}

			var heartRemain = Instantiate(heartBase, transform).GetComponent<Image>();
			heartRemain.sprite = heartType.sprites[remainAmount];
		}
	}
}