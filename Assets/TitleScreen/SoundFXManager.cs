using UnityEngine;
using UnityEngine.Rendering;

public class SoundFXManager : MonoBehaviour
{
    
    [SerializeField] AudioClip turnClip;
    [SerializeField] AudioClip matchClip;
    [SerializeField] AudioClip levelWinClip;
    [SerializeField] AudioClip buttonClickClip;
    [SerializeField] AudioClip titleWhackClip;
    [SerializeField] AudioClip titleStingClip;
    [SerializeField] AudioClip winGameClip;
    [SerializeField] AudioClip sliderClip;
    GameObject singletonObject;

    [SerializeField] float volume = 1.0f;

    void Start()
    {
        singletonObject = GameObject.FindWithTag("Singleton");

    }

    public void PlayTurnClip()
    {
        PlaySound(turnClip);
    }
    public void PlayMatchClip()
    {
        PlaySound(matchClip);

    }

    public void PlaySliderClip()
    {
        PlaySound(sliderClip);
    }
    public void PlayWinLevelClip()
    {
        PlaySound(levelWinClip);

    }
    public void PlayButtonClickClip()
    {
        PlaySound(buttonClickClip);

    }
    public void PlayTitleWhackClip()
    {
        PlaySound(titleWhackClip);

    }
    public void PlayTitleStingClip()
    {
        PlaySound(titleStingClip);
    }

    public void PlayWinGameClip()
    {
        PlaySound(winGameClip);
    }

    void PlaySound(AudioClip clip)
    {
        LevelManager levelManager = singletonObject.GetComponentInChildren<LevelManager>();

        if (levelManager.GetCurrentLevel() == 0)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, 1f);
        }
        else
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, SetVolume());
        }
    }

    float SetVolume()
    {
        if(PlayerPrefs.GetInt("MuteSound") == 1)
        {
            volume = 0f;
        }
        else
        {
            volume = PlayerPrefs.GetFloat("SoundVolume", 1f);
        }
        return volume;
    }

    public void SetMusicVolume()
    {
        if(PlayerPrefs.GetInt("MuteMusic") == 1)
        {
            singletonObject.GetComponent<AudioSource>().volume = 0f;
        }
        else
        {
            singletonObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume", 1f);

        }

    }
    
}
