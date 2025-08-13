using EditorAttributes;
using UnityEngine;

public class CampaignSystem : MonoBehaviour
{
	public CampaignData data = new CampaignData();
	[Button(true)]
	public void CampaignSetUp()
	{
		if (data is null) { DebugExt.LogError("No Campaign Data found", this); return; }
		Events.InvokeOnCampaignInit(data);

		//Tile Spawns
		Reference.nodeSpawner.SetUp();
		DebugExt.Log("Spawning Nodes", this);
	}
}