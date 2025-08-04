using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionQueue : MonoBehaviourSingleton<ActionQueue>
{
    public class PlayAction
    {
        PlayActionData _action;
        Vector2Int _center;
        public string name => _action.name;
        public IEnumerator Run()
        {
            yield return _action.Run(_center);
        }

        public PlayAction(PlayActionData action, Vector2Int center)
        {
            _action = action;
            _center = center;
        }
    }
    private static List<PlayAction> _queue = new List<PlayAction>();

    public static void Stack(PlayActionData action, Vector2Int center)
    {
        _queue.Add(new PlayAction(action, center));
    }

    void Start()
    {
        StartCoroutine(Routine());
    }

    IEnumerator Routine()
    {
        while (true)
        {
            if (_queue.Count > 0)
            {
                var action = _queue[0];
                DebugExt.Log($"Running {action.name}", this);
                yield return action.Run();
                _queue.RemoveAt(0);
            }
            else
            {
                yield return null;
            }
        }
    }
}
