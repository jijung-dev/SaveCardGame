using System.Collections.Generic;
using UnityEngine;

public class NodeSpawner : MonoBehaviour
{
	public enum ConnectDirection
	{
		left,
		middle,
		right
	}
	[SerializeField]
	private GameObject nodeBase;
	[SerializeField]
	private List<GameObject> connectionObject;

	private List<CheckCross> crosses = new List<CheckCross>();

	int count;
	List<int> test = new List<int>() { 0, 1, 2, 3, 4 };
	public void SetUp()
	{
		count = Random.Range(3, 6);
		SpawnStartPoint();
	}
	public void SpawnStartPoint()
	{
		if (test.Count + count == 5)
		{
			foreach (var cross in crosses)
			{
				cross.Check();
			}
			crosses.Clear();
			return;
		}

		var item = test.RandomItem();
		Spawn(new Vector2Int(item, 0));
		test.Remove(item);
	}
	public void Add(CheckCross cross)
	{
		crosses.Add(cross);
	}
	public void Spawn(Vector2Int spawnLocation)
	{
		var node = Instantiate(nodeBase, position: (Vector2)spawnLocation, parent: transform, rotation: Quaternion.identity).GetComponent<Node>();
		node.celPosition = spawnLocation;
		node.SetUp();
	}
	public void SpawnDirection(Node node, ConnectDirection direction)
	{
		var spawnObj = connectionObject[(int)direction];
		Instantiate(spawnObj, node.transform);
	}
	public Vector2Int GetVectorFromDir(ConnectDirection direction)
	{
		return direction switch
		{
			ConnectDirection.left => Vector2Int.left + Vector2Int.up,
			ConnectDirection.middle => Vector2Int.zero + Vector2Int.up,
			ConnectDirection.right => Vector2Int.right + Vector2Int.up,
			_ => Vector2Int.zero * -1
		};
	}
}