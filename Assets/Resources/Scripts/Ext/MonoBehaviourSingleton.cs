using UnityEngine;

public class MonoBehaviourSingleton<T> : MonoBehaviour
    where T : MonoBehaviour
{
    public static T instance { get; private set; }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            UnityEngine.Object.DontDestroyOnLoad(instance.gameObject);
        }
        else
        {
            DestroyImmediate(this.gameObject);
        }
    }
}
