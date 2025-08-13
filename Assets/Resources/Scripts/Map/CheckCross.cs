using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckCross : MonoBehaviour
{
    void Awake()
    {
        Reference.nodeSpawner.Add(this);
    }
    public void Check()
    {
        Node parentNode = NodeManager.GetNode(Vector2Int.CeilToInt(transform.parent.position));
        if (NodeManager.TryGetNode(Vector2Int.CeilToInt(parentNode.celPosition + Vector2Int.right), out Node nodeRight))
        {
            var nodeRightUp = nodeRight.celPosition + Vector2Int.up;
            // if (nodeRight.CheckConnection(nodeRightUp))
            // {
            //     var ranCross = Random.Range(1, 3);
            //     if (ranCross == 1)
            //     {
            //         parentNode.RemoveConnection(nodeRightUp);
            //         Destroy(this.gameObject);
            //     }
            //     else
            //     {
            //         nodeRight.RemoveConnection(parentNode.celPosition + Vector2Int.up);
            //         Destroy(nodeRight.transform.GetChildren().FirstOrDefault(r => r.name.Contains("Left")));
            //     }
            // }
            // else
            // {
            // }
            parentNode.RemoveConnection(nodeRightUp);
            //Destroy(this.gameObject);
        }
    }
}
