using UnityEngine;

public class Singletons : MonoBehaviour
{
    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        int instanceCount = FindObjectsByType<Singletons>(FindObjectsSortMode.None).Length;

        if(instanceCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
