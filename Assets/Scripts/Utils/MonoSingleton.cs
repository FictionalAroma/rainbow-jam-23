using UnityEngine;

public class MonoSingleton<T>: MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }
    protected virtual void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
		if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this as T;
            DontDestroyOnLoad(Instance);
        }

        
    }
}