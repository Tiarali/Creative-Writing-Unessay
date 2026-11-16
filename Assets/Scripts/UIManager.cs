using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    GameObject singletonObject;
    AudioSource musicAudio;
    LevelManager levelManager;
    //scoreManager score;
    SoundFXManager soundFXManager;
    //scoreManager score;
    [SerializeField] Canvas optionsCanvas;
    [SerializeField] Canvas instructionsCanvas;
    [SerializeField] Canvas storyCanvas;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI hiScoreText;

    void Start()
    {
        singletonObject = GameObject.FindWithTag("Singleton");
        musicAudio = singletonObject.GetComponent<AudioSource>();
        levelManager = singletonObject.GetComponentInChildren<LevelManager>();
        soundFXManager = singletonObject.GetComponentInChildren<SoundFXManager>();
        //score = singletonObject.GetComponentInChildren<scoreManager>();
        CheckMusic();
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
            PlayerPrefs.Save();
        }
    }

    public void OpenStoryButton()
    {
        soundFXManager.PlayButtonClickClip();
        if (storyCanvas != null)
        {
            storyCanvas.enabled = true;
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

    public void UpdateEndText(int score, int hiScore)
    {
        scoreText.text = "Your score is: " + score;
        hiScoreText.text = "Your current best score is: " + hiScore;
    }
}
