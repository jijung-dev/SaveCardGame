using UnityEngine;
using UnityEngine.UI;

public class EnergyDisplay : MonoBehaviour
{
	[SerializeField]
	private Slider slider;
	[SerializeField]
	private Entity owner;
	public bool promptUpdate;
	void Start()
	{
		slider.maxValue = owner.energy.maxValue;
		slider.value = owner.energy.value;
	}

	void Update()
	{
		if (promptUpdate)
		{
			promptUpdate = false;
			slider.maxValue = owner.energy.maxValue;
			slider.value = owner.energy.value;
		}
	}
}