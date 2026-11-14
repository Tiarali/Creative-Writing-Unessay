using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] Canvas storyCanvas;
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

    

    public void OpenStoryCanvas()
    {
        soundFXManager.PlayButtonClickClip();
        storyCanvas.enabled = true;
        //story.OpenCanvas();
        
    }
}
