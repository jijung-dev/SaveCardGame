using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Test", menuName = "Action/AttackTest")]
public class ActionAttackTest : PlayActionData
{
	public override IEnumerator Run(Vector2Int center)
	{
		var entity = Battle.entityManager.GetEntity(center);
		entity?.Hit(99);
		yield return null;
	}
}