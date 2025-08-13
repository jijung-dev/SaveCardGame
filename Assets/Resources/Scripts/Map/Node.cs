using System.Collections.Generic;
using UnityEngine;
using static NodeSpawner;

public class Node : MonoBehaviour
{
	private List<Node> _connectedNode = new List<Node>();
	public Vector2Int celPosition;
	public void SetUp()
	{
		NodeManager.Add(this);
		var nodeSpawner = Reference.nodeSpawner;
		//TEST:
		if (transform.position.y >= 10)
		{
			Reference.nodeSpawner.SpawnStartPoint();
			return;
		}
		//

		List<ConnectDirection> possibleSpawn = new List<ConnectDirection>()
		{
			ConnectDirection.left,
			ConnectDirection.middle,
			ConnectDirection.right,
		};

		//FIXME: Doesnot work lol
		//Remove crossed connection

		if (NodeManager.TryGetNode(Vector2Int.left + celPosition, out Node nodeLeft) && nodeLeft.CheckConnection(Vector2Int.up + celPosition))
		{
			possibleSpawn.Remove(ConnectDirection.left);
		}
		if (NodeManager.TryGetNode(Vector2Int.right + celPosition, out Node nodeRight) && nodeRight.CheckConnection(Vector2Int.up + celPosition))
		{
			possibleSpawn.Remove(ConnectDirection.right);
		}

		if (celPosition.x < -4)
		{
			possibleSpawn.Remove(ConnectDirection.left);
		}
		if (celPosition.x > 4)
		{
			possibleSpawn.Remove(ConnectDirection.right);
		}

		//Add connection bound

		for (int i = 0; i < 2; i++)
		{
			int ranItem = Random.Range(0, 101);
			ConnectDirection connectDir;
			switch (ranItem)
			{
				case <= 20:
					connectDir = ConnectDirection.left;
					break;
				case <= 40:
					connectDir = ConnectDirection.right;
					break;
				default:
					connectDir = ConnectDirection.middle;
					break;
			}

			var connectPos = nodeSpawner.GetVectorFromDir(connectDir) + celPosition;

			if (!NodeManager.HasNode(connectPos))
			{
				nodeSpawner.Spawn(connectPos);
			}
			nodeSpawner.SpawnDirection(this, connectDir);
			_connectedNode.Add(NodeManager.GetNode(connectPos));
			possibleSpawn.Remove(connectDir);

			// if (Random.Range(1, 11) > 3)
			// {
			// 	i++;
			// }
		}
	}
	public bool CheckConnection(Vector2Int nodePos)
	{
		return NodeManager.TryGetNode(nodePos, out Node nodeCross) && _connectedNode.Contains(nodeCross);
	}
	public void RemoveConnection(Vector2Int nodePos)
	{
		if (NodeManager.TryGetNode(nodePos, out Node node) && _connectedNode.Contains(node))
		{
			_connectedNode.Remove(node);
		}
	}
}