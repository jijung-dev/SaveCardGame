using UnityEngine;

public class Entity : MonoBehaviour
{
    public GameTile container;
	void Awake()
	{
        container = TileManager.GetTile(transform.position.FloorToInt());
        EntityManager.Add(this);
	}
}
