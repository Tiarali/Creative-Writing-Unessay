using UnityEngine;

public class Singleton : MonoBehaviour
{
    private void Awake()
    {
        ManageSingleton();
    }



    void ManageSingleton()
    {
        int instanceCount = FindObjectsByType<Singleton>(FindObjectsSortMode.None).Length;
        if (instanceCount > 1)
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
