using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
    [SerializeField] PageSO[] pages;
    [SerializeField] TextMeshProUGUI storyText;
    [SerializeField] Button leftButton;
    [SerializeField] Button rightButton;
    //[SerializeField] Button storyButton;
    GameObject singletonObject;
    int currentPage = 0;
    int openPages = 0;

    SoundFXManager soundFXManager;
    scoreManager score;
    LevelManager levelManager;

    void Awake()
    {
        singletonObject = GameObject.FindWithTag("Singleton");
        soundFXManager = singletonObject.GetComponentInChildren<SoundFXManager>();
        score = singletonObject.GetComponentInChildren<scoreManager>();
        
    }

    public void OpenCanvas()
    {
        Debug.Log("story enabled");
        //Set up initial page
        if (score != null)
        {
            Debug.Log("score exists");
            openPages = score.ReturnUnlockedPages();
            Debug.Log("open pages = " + openPages);
        }
        if (openPages > 0)
        {
            ShowPage();
        }
    }

    

    public void CloseButton()
    {
        soundFXManager.PlayButtonClickClip();
        gameObject.GetComponent<Canvas>().enabled = false;
    }

    void ShowPage()
    {
        Debug.Log("show page");
        storyText.text = pages[currentPage].GetPage();
        ToggleLeftButton();
        ToggleRightButton();
    }

    void ToggleLeftButton()
    {
        if(currentPage == 0)
        {
            leftButton.interactable = false;
        }
        else
        {
            leftButton.interactable = true;
        }
    }

    void ToggleRightButton()
    {
        if (currentPage < (openPages - 1))
        {
            rightButton.interactable = true;
        }
        else
        {
            rightButton.interactable = false;
        }
    }

    

    public void PressRightButton()
    {
        soundFXManager.PlayButtonClickClip();
        currentPage++;
        ShowPage();
    }

    public void PressLeftButton()
    {
        soundFXManager.PlayButtonClickClip();
        currentPage--;
        ShowPage();
    }


    
}
