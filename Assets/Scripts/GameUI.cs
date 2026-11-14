using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] Button storyButton;
    scoreManager score;
    LevelManager levelManager;
    GameObject singletonObject;


    void Awake()
    {
        singletonObject = GameObject.FindWithTag("Singleton");
        score = singletonObject.GetComponentInChildren<scoreManager>();
        levelManager = singletonObject.GetComponentInChildren<LevelManager>();
    }

    void Update()
    {
        CheckEnableStoryButton();
    }

    void CheckEnableStoryButton()
    {
        if (!storyButton.interactable)
        {
            if (score != null && score.ReturnUnlockedPages() > 0)
            {
                storyButton.interactable = true;
                //effect if level 1 only (index 2)
                levelManager = singletonObject.GetComponentInChildren<LevelManager>();

                if (levelManager != null)
                {
                    if (levelManager.GetCurrentLevel() == 2)
                    {
                        //insert effects here
                    }
                }


            }
        }
    }
}
