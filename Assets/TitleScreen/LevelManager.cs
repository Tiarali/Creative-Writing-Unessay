using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    public void LoadNextLevel()
    {
        Debug.Log("loading next level");
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("current Index " + currentIndex);
        int nextIndex = currentIndex + 1;
        Debug.Log("Scene " + nextIndex);

        SceneManager.LoadScene(nextIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
