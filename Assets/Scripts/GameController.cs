using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class GameController : MonoBehaviour
{
    [Header ("Images")]
    [SerializeField] Sprite bgImage;

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
        yield return new WaitForSeconds(1f);
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

    void CheckLevelFinished()
    {
        countCorrectGuesses++;

        if(countCorrectGuesses == gameGuesses)
        {
            //Play success sound
            soundFXManager.PlayWinLevelClip();
            //Play Particle Effect
            winParticles.Play();
            //Load next level
            levelManager.Invoke("LoadNextLevel", 0.5f);
        }
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
