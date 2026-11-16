using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] Canvas storyCanvas;
    [SerializeField] Canvas optionsCanvas;
    SoundFXManager soundFXManager;
    [SerializeField] Story story;
    [SerializeField] Button storyButton;
    void Start()
    {
        GameObject singletonObject = GameObject.FindWithTag("Singleton");
        soundFXManager = singletonObject.GetComponentInChildren<SoundFXManager>();
        
        storyButton.interactable = false;
        storyCanvas.enabled = false;
    }

    public void OpenOptionsCanvas()
    {
        soundFXManager.PlayButtonClickClip();
        optionsCanvas.enabled = true;
    }

    public void OpenStoryCanvas()
    {
        soundFXManager.PlayButtonClickClip();
        storyCanvas.enabled = true;
        
        
    }

    public void CloseOptionsCanvas()
    {
        soundFXManager.PlayButtonClickClip();
        optionsCanvas.enabled = false;
    }
}
