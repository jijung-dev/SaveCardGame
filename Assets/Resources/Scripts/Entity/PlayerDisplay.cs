public class PlayerDisplay : EntityDisplay
{
	protected override void Update()
	{
		if (promptUpdate)
		{
			promptUpdate = false;
			energyDisplay.promptUpdate = true;
			UpdateDisplay();
		}
	}
	protected override void UpdateDisplay()
	{
		
	}
}