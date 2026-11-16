using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class GameController : MonoBehaviour
{
    [Header ("Images")]
    [SerializeField] Sprite bgImage;
    [SerializeField] GameCanvas gameCanvas;
    [SerializeField] Story story;

    public Sprite[] puzzles;
    public List<Sprite> gamePuzzles = new List<Sprite>();
    [Header("Buttons")]
    List<Button> btns = new List<Button>();

    [Header("Logic")]

    LevelManager levelManager;
    ParticleSystem winParticles;
    SoundFXManager soundFXManager;
    scoreManager score;
    //logic
    bool firstGuess, secondGuess;
    int countGuesses;
    int countCorrectGuesses;
    int gameGuesses;
    int firstGuessIndex, secondGuessIndex;
    string firstGuessPuzzle, secondGuessPuzzle;

    bool storyClosedAfterLevelEnd = false;
    bool gameWon = false;


    void Start()
    {
        GameObject singletonObject = GameObject.FindWithTag("Singleton");
        score = singletonObject.GetComponentInChildren<scoreManager>();
        levelManager = singletonObject.GetComponentInChildren<LevelManager>();
        winParticles = GameObject.FindWithTag("Particles").GetComponent<ParticleSystem>();
        soundFXManager = singletonObject.GetComponentInChildren<SoundFXManager>();

        GetButtons();
        AddListeners();
        AddGamePuzzles();
        Shuffle(gamePuzzles);
        gameGuesses = gamePuzzles.Count /2;
        score.UpdateScore();
        score.SetGuess();
    }

    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");

        for (int i = 0; i < objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
        }
    }

    void AddGamePuzzles()
    {
        int looper = btns.Count;
        int index = 0;

        for (int i = 0; i < looper; i++)
        {
            if (index == looper /2)
            {
                index = 0;
            }

            gamePuzzles.Add(puzzles[index]);
            index++;
        }
    }

    void AddListeners()
    {
        foreach (Button btn in btns) 
        {
            btn.onClick.AddListener(() => PickAPuzzle());
        }
    }

    public void PickAPuzzle()
    {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        soundFXManager.PlayTurnClip();

        if(!firstGuess)
        {
            firstGuess = true;

            firstGuessIndex = int.Parse(name);

            firstGuessPuzzle = gamePuzzles[firstGuessIndex].name;
            btns[firstGuessIndex].image.sprite = gamePuzzles[firstGuessIndex];
        }
        else if (!secondGuess)
        {
            secondGuess = true;

            secondGuessIndex = int.Parse(name);
            secondGuessPuzzle = gamePuzzles[secondGuessIndex].name;

            btns[secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];

            countGuesses++;

            StartCoroutine(CheckPuzzle());
        }
    }

    IEnumerator CheckPuzzle()
    {
        score.AddGuess();
        yield return new WaitForSeconds(.5f);
        if(firstGuessPuzzle == secondGuessPuzzle)
        {
            score.AddScore();
            soundFXManager.PlayMatchClip();
            yield return new WaitForSeconds(0.5f);
            //Make buttons non interactable
            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;

            
            //Make buttons invisible
            btns[firstGuessIndex].image.color = new Color (0f,0f,0f,0f);
            btns[secondGuessIndex].image.color = new Color(0,0,0,0);

            CheckOpenStory();
            CheckLevelFinished();
        }
        else
        {
            btns[firstGuessIndex].image.sprite = bgImage;
            btns[secondGuessIndex].image.sprite = bgImage;
            soundFXManager.PlayTurnClip();
        }
        ResetGuesses();
    }

    public void SetStoryClosedAfterLevelEnd()
    {
        storyClosedAfterLevelEnd = true;
    }

    void CheckOpenStory()
    {
        // if autoopen allowed
        int autoOpen = PlayerPrefs.GetInt("AutoOpen", 0);

        if (autoOpen == 0) //not stopped from auto opening
        {
            gameCanvas.OpenStoryCanvasQuietly();
            story.AutoOpenPage();
        }
    }

    void CheckLevelFinished()
    {
        countCorrectGuesses++;

        if(countCorrectGuesses == gameGuesses)
        {
            gameWon = true;
            int autoOpen = PlayerPrefs.GetInt("AutoOpen", 0);

            if (autoOpen == 1) //stopped from auto opening
            {
                LevelWin();
            }
            else
            {
                storyClosedAfterLevelEnd = false;
                //trigger levelwin when story closed
                StartCoroutine(WaitForValueChange());
            }
        }
    }

    public bool GetGameWon()
    {
        return gameWon;
    }

    IEnumerator WaitForValueChange()
    {
        

        // Loop safely across frames until the value changes
        while (storyClosedAfterLevelEnd == false)
        {
            yield return null; // Pauses until the next frame
        }

        LevelWin();
    }

    void LevelWin()
    {
        //Play success sound
        soundFXManager.PlayWinLevelClip();
        //Play Particle Effect
        winParticles.Play();
        //Load next level
        levelManager.Invoke("LoadNextLevel", 1f);
    }

    void ResetGuesses()
    {
        firstGuess = false;
        secondGuess = false;
    }

    void Shuffle(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
