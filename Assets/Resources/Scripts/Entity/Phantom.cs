using UnityEngine;

public class Phantom : Entity
{
	[SerializeField]
	private PlayActionData moveAction;

	public override void SetUp()
	{
		moveAction = ScriptableObject.Instantiate(moveAction);
		moveAction.owner = this;
		energy = new Energy();
		energy.SetUp(999);
	}

	public override void Select()
	{
		base.Select();
		Battle.hoverSystem.SetAction(moveAction, celPosition);
	}

	public override void UnSelect()
	{
		base.UnSelect();
	}
}