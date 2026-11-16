using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class scoreManager : MonoBehaviour
{
    int unlockedPages = 0;
    int score = 0;
    int guesses = 0;
    int hiScore;
    TextMeshProUGUI scoreText;
    TextMeshProUGUI guessesText;
    [SerializeField] Story story;
    LevelManager levelManager;
    GameObject singletonObject;
    SoundFXManager soundFXManager;
    //bool fontButton;
    bool soundButton;
    bool musicButton;

    private void OnEnable()
    {
        // Subscribe to the event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Always unsubscribe to prevent memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        singletonObject = GameObject.FindWithTag("Singleton");
        levelManager = singletonObject.GetComponentInChildren<LevelManager>();
        soundFXManager = singletonObject.GetComponentInChildren<SoundFXManager>();
    }

    // This runs automatically once the next scene has loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int currentIndex = levelManager.GetCurrentLevel();
        if (currentIndex == 2 || currentIndex == 3 || currentIndex == 4)
        {
            UpdateScore();
            SetGuess();
        }
        else if (currentIndex == 5)
        {
            CalculateHiScore();
            GameObject.FindAnyObjectByType<UIManager>().GetComponent<UIManager>().UpdateEndText(guesses, hiScore);
        }
        else if (currentIndex == 1)
        {
            score = 0;
            guesses = 0;
        }
    }

       

    public void UpdateScore()
    {
        scoreText = GameObject.FindWithTag("Score").GetComponent<TextMeshProUGUI>();
        if (scoreText != null)
        {
            scoreText.text = ("Score: " + score);
            
        }
    }

    public int ReturnScore()
    {
        return score;
    }

    public int CalculateHiScore()
    {
        Debug.Log("Calculating high score");   
            int previousHighScore = PlayerPrefs.GetInt("HighScore", 2000);
        Debug.Log("previous high score: " + previousHighScore);
            if (guesses <= previousHighScore)
            {
                //New High score!
                hiScore = guesses;
            Debug.Log("new high score: " + hiScore);
                PlayerPrefs.SetInt("HighScore", hiScore);
                PlayerPrefs.Save();
            }
            else hiScore = previousHighScore;
        Debug.Log("same high score: " + hiScore);
        return hiScore;
    }

    

    public int ReturnUnlockedPages()
    {
        return unlockedPages;
    }

    public void AddScore()
    {
        score++;
        unlockedPages++;
        UpdateScore();
    }

    public void AddGuess()
    {
        guesses++;
        Debug.Log("guesses: " + guesses);
        SetGuess();
    }

    public void SetGuess()
    {
        TextMeshProUGUI guessesText = GameObject.FindWithTag("Guesses").GetComponent<TextMeshProUGUI>();
        if(guessesText != null)
        {
            
            guessesText.text = ("Guesses: " + guesses);
            
        }
    }

    /*public void SetFont(bool fontChecked)
    {
        fontButton = fontChecked;
    }*/

    

    



    
}
