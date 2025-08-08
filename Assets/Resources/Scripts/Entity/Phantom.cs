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
		SelectAction(moveAction);
	}
	public override void UnSelect()
	{
		
	}
}