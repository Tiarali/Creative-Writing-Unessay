using UnityEngine;

public class UIManager : MonoBehaviour
{
    GameObject singletonObject;
    AudioSource musicAudio;
    LevelManager levelManager;
    void Start()
    {
        singletonObject = GameObject.FindWithTag("Singleton");
        musicAudio = singletonObject.GetComponent<AudioSource>();
        levelManager = singletonObject.GetComponentInChildren<LevelManager>();
        CheckMusic();
    }


    void Update()
    {
        
    }

    void CheckMusic()
    {
        
            if (!musicAudio.isPlaying)
            {
                musicAudio.Play();
            }
        
    }

    public void StartButton()
    {
        levelManager.LoadNextLevel();
    }

    public void MainMenuButton()
    {
        levelManager.LoadMainMenu();
    }
}
