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

    [SerializeField] float volume = 1.0f;

    

    public void PlayTurnClip()
    {
        PlaySound(turnClip);
    }
    public void PlayMatchClip()
    {
        PlaySound(matchClip);

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
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
    }

    public void SetVolume(float amount)
    {
        volume = amount;
    }
    
}
