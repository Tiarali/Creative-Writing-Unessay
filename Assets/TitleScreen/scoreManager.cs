using UnityEngine;

public class scoreManager : MonoBehaviour
{
    int unlockedPages = 0;
    int score = 0;
    [SerializeField] Story story;
    
    void Start()
    {
        
    }

    

    public int ReturnUnlockedPages()
    {
        return unlockedPages;
    }

    public void AddScore()
    {
        score++;
        unlockedPages++;
        Debug.Log("unlocked pages = " + unlockedPages);
    }

    
}
