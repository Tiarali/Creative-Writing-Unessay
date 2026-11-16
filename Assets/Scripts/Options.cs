using UnityEngine;
using UnityEngine.UI;


public class Options : MonoBehaviour
{
    [SerializeField] Sprite checkedSprite;
    [SerializeField] Sprite uncheckedSprite;
    //[SerializeField] Button fontButton;
    [SerializeField] Button soundButton;
    [SerializeField] Button musicButton;
    [SerializeField] Slider soundSlider;
    [SerializeField] Slider musicSlider;
    //bool fontBool;
    public event System.Action<bool> changeFont;
    scoreManager score;
    SoundFXManager soundFXManager;
    //int font;
    int sound;
    int music;
    float soundVolume;
    float musicVolume;
    
    void Start()
    {
        GameObject singletonObject = GameObject.FindWithTag("Singleton");
        soundFXManager = singletonObject.GetComponentInChildren<SoundFXManager>();
        score = singletonObject.GetComponentInChildren<scoreManager>();
        soundSlider.onValueChanged.AddListener(SoundSliderChange);
        musicSlider.onValueChanged.AddListener(MusicSliderChange);
    }

    void SoundSliderChange(float value)
    {
        soundFXManager.PlaySliderClip();
        soundVolume = value;
        PlayerPrefs.SetFloat("SoundVolume", soundVolume);
    }

    void MusicSliderChange(float value)
    {
        soundFXManager.PlaySliderClip();

        musicVolume = value;
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        soundFXManager.SetMusicVolume();
    }

    /*public void SetFontButton()
    {
        font = PlayerPrefs.GetInt("ChangeFont", 0);
        
        if(font == 0)
        {
            fontButton.image.sprite = uncheckedSprite;
            PlayerPrefs.SetInt("ChangeFont", 0);
        }
        else
        {
            fontButton.image.sprite = checkedSprite;
            PlayerPrefs.SetInt("ChangeFont", 1);
        }

        SendFontEvent();
        
    }

    public void ChangeFontButton()
    {
        soundFXManager.PlayButtonClickClip();

        font = PlayerPrefs.GetInt("ChangeFont", 0);

        if (font == 0)
        {
            Debug.Log("font is 0");
            fontButton.image.sprite = checkedSprite;
            PlayerPrefs.SetInt("ChangeFont", 1);
        }
        else
        {
            Debug.Log("Font is 1");
            fontButton.image.sprite = uncheckedSprite;
            PlayerPrefs.SetInt("ChangeFont", 0);
        }
        SendFontEvent();
    }

    void SendFontEvent()
    {
        font = PlayerPrefs.GetInt("ChangeFont", 0);

        if (font == 0)
        {
            fontBool = false;
        }
        else
        {
            fontBool = true;
        }
        changeFont.Invoke(fontBool);
    }*/

    public void SetSoundButton()
    {
        sound = PlayerPrefs.GetInt("MuteSound", 0);

        if (sound == 0) //sound not muted
        {
            Debug.Log("Sound not muted");
            soundSlider.interactable = true;
            soundButton.image.sprite = uncheckedSprite;
            PlayerPrefs.SetInt("MuteSound", 0);
        }
        else
        {
            Debug.Log("Sound muted");
            soundSlider.interactable = false;
            soundButton.image.sprite = checkedSprite;
            PlayerPrefs.SetInt("MuteSound", 1);
        }

        
    }

    public void ChangeSoundButton()
    {
        soundFXManager.PlayButtonClickClip();

        sound = PlayerPrefs.GetInt("MuteSound", 0);

        if (sound == 0) //not muted
        {
            //mute sound
            Debug.Log("mute sound");
            soundButton.image.sprite = checkedSprite;
            soundSlider.interactable = false;
            PlayerPrefs.SetInt("MuteSound", 1);
        }
        else //sound muted
        {
            //unmute sound
            Debug.Log("unmute sound");
            soundButton.image.sprite = uncheckedSprite;
            soundSlider.interactable = true;
            PlayerPrefs.SetInt("MuteSound", 0);
        }

    }

    public void SetMusicButton()
    {
        music = PlayerPrefs.GetInt("MuteMusic", 0);

        if (music == 0)// music not muted
        {
            Debug.Log("unmute music");
            musicButton.image.sprite = uncheckedSprite;
            musicSlider.interactable = true;
            PlayerPrefs.SetInt("MuteMusic", 0);
        }
        else //music muted
        {
            Debug.Log("Mute music");
            musicButton.image.sprite = checkedSprite;
            musicSlider.interactable = false;
            PlayerPrefs.SetInt("MuteMusic", 1);
        }

        soundFXManager.SetMusicVolume(); 
    }

    public void ChangeMusicButton()
    {
        soundFXManager.PlayButtonClickClip();
        
        music = PlayerPrefs.GetInt("MuteMusic", 0);
        
        if (music == 0) //music not muted
        {
            // music muted
            Debug.Log("mute music");
            musicSlider.interactable = false;
            musicButton.image.sprite = checkedSprite;
            PlayerPrefs.SetInt("MuteMusic", 1);
        }
        else
        {
            //music not muted
            Debug.Log("Music not muted");
            musicSlider.interactable = true;
            musicButton.image.sprite = uncheckedSprite;
            PlayerPrefs.SetInt("MuteMusic", 0);
        }

        soundFXManager.SetMusicVolume();

    }

    void OnDestroy()
    {
        soundSlider.onValueChanged.RemoveListener(SoundSliderChange);
        musicSlider.onValueChanged.RemoveListener(MusicSliderChange);
    }
}
