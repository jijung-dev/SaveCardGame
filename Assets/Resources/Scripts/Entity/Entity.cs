using System;
using EditorAttributes;
using PrimeTween;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public abstract class Entity : MonoBehaviour
{
	public EntityData data;
	[HideInInspector]
	public GameTile container;
	public Vector2Int celPosition => container.celPosition;
	public Health health;
	public Energy energy;
	public EntityDisplay display;
	public bool isSelected;

	// //TEST:
	// [Button(true)]
	// public void Hitting()
	// {
	// 	health.Hit(1);
	// 	healthDisplay.promptUpdate = true;
	// }
	// [Button(true)]
	// public void Healing()
	// {
	// 	health.Heal(1);
	// 	healthDisplay.promptUpdate = true;
	// }
	// //
	//TEST:
	[Button(true)]
	public void Use()
	{
		energy.Hit(1);
		display.promptUpdate = true;
	}
	[Button(true)]
	public void Restore()
	{
		energy.Heal(1);
		display.promptUpdate = true;
	}
	//

	public virtual void Awake()
	{
		container = (Vector2Int)transform.position.RoundToInt();
		Battle.entityManager.Add(this);

		SetUp();
	}
	public virtual void SetUp()
	{
		//TODO: Add health info into EnityData
		health = new Health();
		health.SetUp(5);

		energy = new Energy();
		energy.SetUp(3);
		energy.healAmount = 1;
		Events.OnTurnEnd += energy.RecoverEnergy;

		display.SetData(data);
		display.promptUpdate = true;
	}
	public virtual void Select()
	{
		isSelected = true;
		GetComponent<SpriteRenderer>().color = Color.red;
		Battle.hoverSystem.EntityProcessClick(this);
	}
	public virtual void UnSelect()
	{
		isSelected = false;
		GetComponent<SpriteRenderer>().color = Color.white;
	}
	public virtual void Destroy()
	{
		Battle.entityManager.Remove(this);
		if (energy != null)
			Events.OnTurnEnd -= energy.RecoverEnergy;

		DebugExt.Log($"Destroying {gameObject.name}", this);
		Battle.battleSystem.CheckBattleResult();
		Destroy(this.gameObject);
	}
	public void Hit(int damage)
	{
		health.Hit(damage);

		if (health.value <= 0)
			Destroy();
	}
}
