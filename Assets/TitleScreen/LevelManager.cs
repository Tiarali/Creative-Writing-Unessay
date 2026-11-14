using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    int currentIndex;

    void Start()
    {
        
    }

    private void DetermineCurrentIndex()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;

    }

    public void LoadNextLevel()
    {
        DetermineCurrentIndex();
        int nextIndex = currentIndex + 1;

        SceneManager.LoadScene(nextIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public int GetCurrentLevel()
    {
        DetermineCurrentIndex();
        Debug.Log("current level = " + currentIndex);
        return currentIndex;
    }
}
