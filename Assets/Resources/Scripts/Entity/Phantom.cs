using UnityEngine;

public class Phantom : Entity
{
	[SerializeField]
	private PlayActionData moveAction;

	public override void SetUp()
	{
		
	}

	public override void Select()
	{
		base.Select();
		Reference.hoverSystem.SetAction(moveAction, celPosition);
	}

	public override void UnSelect()
	{

	}
}