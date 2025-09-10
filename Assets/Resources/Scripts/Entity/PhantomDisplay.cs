public class PhantomDisplay : EntityDisplay
{
	protected override void Update()
	{
		if (promptUpdate)
		{
			promptUpdate = false;
			UpdateDisplay();
		}
	}
}