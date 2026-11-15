using UnityEngine;

public class UIManager : MonoBehaviour
{
    GameObject singletonObject;
    AudioSource musicAudio;
    LevelManager levelManager;
    SoundFXManager soundFXManager;
    [SerializeField] Canvas optionsCanvas;
    [SerializeField] Canvas instructionsCanvas;

    void Start()
    {
        singletonObject = GameObject.FindWithTag("Singleton");
        musicAudio = singletonObject.GetComponent<AudioSource>();
        levelManager = singletonObject.GetComponentInChildren<LevelManager>();
        soundFXManager = singletonObject.GetComponentInChildren<SoundFXManager>();
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

    public void OpenOptionsCanvas()
    {
        if(optionsCanvas != null)
        {
            Debug.Log("open options canvas");
            optionsCanvas.enabled = true;
            soundFXManager.PlayButtonClickClip();
        }
    }

    public void CloseOptionsCanvas()
    {
        if (optionsCanvas != null)
        {
            optionsCanvas.enabled = false;
            soundFXManager.PlayButtonClickClip();

        }
    }

    public void OpenInstructionsCanvas()
    {
        if (instructionsCanvas != null)
        {
            instructionsCanvas.enabled = true;
            soundFXManager.PlayButtonClickClip();

        }
    }

    public void CloseInstructionsCanvas()
    {
        if (instructionsCanvas != null)
        {
            instructionsCanvas.enabled = false;
            soundFXManager.PlayButtonClickClip();

        }
    }
}
