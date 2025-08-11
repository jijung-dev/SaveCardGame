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
	[SerializeField]
	private HealthDisplay healthDisplay;

	//TEST:
	[Button(true)]
	public void Hitting()
	{
		health.Hit(1);
		healthDisplay.promptUpdate = true;
	}
	[Button(true)]
	public void Healing()
	{
		health.Heal(1);
		healthDisplay.promptUpdate = true;
	}
	//

	void Awake()
	{
		container = (Vector2Int)transform.position.RoundToInt();
		EntityManager.Add(this);

		SetUp();
	}
	public virtual void SetUp()
	{
		health = new Health();
		health.SetUp(5);
		healthDisplay.promptUpdate = true;
	}
	public virtual void Select()
	{
		GetComponent<SpriteRenderer>().color = Color.red;
		Reference.hoverSystem.EntityProcessClick(this);
	}
	public virtual void UnSelect()
	{
		GetComponent<SpriteRenderer>().color = Color.white;
	}
	public virtual void Destroy()
	{
		EntityManager.Remove(this);
		Destroy(this.gameObject);
	}

	//Select Entity show actions

	//Select action for AreaSelector

	//Spawn areaSpot for AreaSelector
}
