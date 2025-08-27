using UnityEngine;
using UnityEngine.UI;

public class EntityDisplay : MonoBehaviour
{
    [SerializeField]
	private SpriteRenderer sprite;
    public HealthDisplay healthDisplay;
    public EnergyDisplay energyDisplay;
    private EntityData _data;
    public bool promptUpdate;
	public void SetData(EntityData data)
	{
		_data = data;
		promptUpdate = true;
    }
    void Update()
	{
		if (promptUpdate)
		{
			promptUpdate = false;
			healthDisplay.promptUpdate = true;
			energyDisplay.promptUpdate = true;
			UpdateDisplay();
		}
	}

	void UpdateDisplay()
	{
		sprite.sprite = _data.sprite;
	}
}
