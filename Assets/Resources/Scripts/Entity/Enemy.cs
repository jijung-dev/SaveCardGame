using UnityEngine;

public class Enemy : Entity
{
	public override void SetUp()
	{
		base.SetUp();
		Events.OnTurnEnd += EntityProcess;
	}
	public override void Destroy()
	{
		Events.OnTurnEnd -= EntityProcess;
		base.Destroy();
	}

	public override void Select()
	{

	}
	public override void UnSelect()
	{

	}
	public void EntityProcess()
	{
		DebugExt.Log("running", this);
	}
}
