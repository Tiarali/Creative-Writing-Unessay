using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
    [SerializeField] PageSO[] pages;
    [SerializeField] TextMeshProUGUI storyText;
    [SerializeField] Button leftButton;
    [SerializeField] Button rightButton;
    [SerializeField] Sprite checkedSprite;
    [SerializeField] Sprite uncheckedSprite;
    [SerializeField] Button stopAutoOpenButton;
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

    void Start()
    {
        //Set Auto Open button image
        int autoOpen = PlayerPrefs.GetInt("AutoOpen", 0);

        if (autoOpen == 0) //auto open allowed
        {
            Debug.Log("auto open allowed");
            stopAutoOpenButton.image.sprite = uncheckedSprite;
            PlayerPrefs.SetInt("AutoOpen", 0);
        }
        else
        {
            Debug.Log("auto open not allowed");
            stopAutoOpenButton.image.sprite = checkedSprite;
            PlayerPrefs.SetInt("AutoOpen", 1);
        }
    }

    public void OpenCanvas()
    {
        //Set up initial page
        if (score != null)
        {
            openPages = score.ReturnUnlockedPages();
        }
        if (openPages > 0)
        {
            ShowPage();
        }
    }

    

    public void CloseButton()
    {
        soundFXManager.PlayButtonClickClip();
        PlayerPrefs.Save();
        gameObject.GetComponent<Canvas>().enabled = false;
    }

    void ShowPage()
    {
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

    public void PressAutoOpenButton()
    {
        soundFXManager.PlayButtonClickClip();

        int autoOpen = PlayerPrefs.GetInt("AutoOpen", 0);

        if (autoOpen == 0) //not stopped from auto opening
        {
            //stop auto opening
            Debug.Log("stop auto opening");
            stopAutoOpenButton.image.sprite = checkedSprite;
            PlayerPrefs.SetInt("AutoOpen", 1);
        }
        else //auto open stopped
        {
            //allow auto open
            Debug.Log("allow auto open");
            stopAutoOpenButton.image.sprite = uncheckedSprite;
            PlayerPrefs.SetInt("AutoOpen", 0);
        }
    }


    
}
